using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace TWAuto
{
    class BuildingManager
    {
        private HttpClient httpClient;
        private Timer timer;
        private Action processResult;

        public delegate void BuildingTimerHandler();
        public event BuildingTimerHandler BuildingTimerElapsed;
        public delegate void CreateTabVillagesPanelHandler(List<Village> villages);
        public static event CreateTabVillagesPanelHandler TabVillagesPanelCreated;
        public delegate void RemoveBuildingQueueHandler(Action action);
        public static event RemoveBuildingQueueHandler BuildingQueueRemoved;

        public BuildingManager(Action processResult)
        {
            this.processResult = processResult;
            httpClient = HttpClient.Instance;
            timer = new Timer(1000 * 30);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        public void StartTimer()
        {
            timer.Start();
        }
        public void AddBuilding(Village village, int id, int priority = 0)
        {
            PriorityQueue queue = village.BuildingQueue;
            
            var b = new QueuedBuilding() { Name = Buildings.GetName(village.Buildings[id].Type), Id = id };
            queue.Enqueue(priority, b);
            b.Level = village.Buildings[id].Level + GetOffset(village, id);
    }

        public void RemoveBuilding(Village village, int index)
        {
            PriorityQueue queue = village.BuildingQueue;

            queue.RemoveAt(index);
        }
        public int GetOffset(Village village, int id)
        {
            PriorityQueue queue = village.BuildingQueue;
            
            return queue.GetOffset(id);
        }

        public Task GetBuildingTask(Village village)
        {
            PriorityQueue queue = village.BuildingQueue;

            if (queue.Empty())
            {
                return null;
            }

            QueuedBuilding b = queue.Peek();
            Building building = village.Buildings[b.Id];
            Task task = new Task() { Name = "Build " + building.Name};
            Settings settins = Settings.Instance;

            task.addOperation((r) =>
            {
                LogManager.log("Checking resources in village " + village);
                Task.sendGet("build.php?id=" + (b.Id + 1));
            });

            Action<string> actionBuildNew = (r) =>
            {
                var node = r.GetDoc().DocumentNode.SelectSingleNode(String.Format("//button[@class='green new' and contains(@onclick,'a={0}')]", building.Type));

                if (node != null)
                {
                    LogManager.log("Building " + building.Name);
                    string url = Regex.Match(node.Attributes["onclick"].Value, "'(.*)'").Groups[1].Value;
                    queue.Dequeue();
                    Task.sendPost(url, new NameValueCollection());
                } else
                {
                    LogManager.log("Not enough resources for " + building.Name);
                    processResult();
                }
            };
             
            task.addOperation((r) =>
            {
                if (building.Type > 4 && building.Level == 0) //building new, not for res
                {
                    LogManager.log("Building new " + building.Name);
                    string category;

                    switch (building.Type)
                    {
                        //RESOURCES
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            category = "3";
                            break;
                        case 13:
                        case 14:
                        case 16:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 29:
                        case 30: 
                        case 36:
                        case 37:
                            category = "2";
                            break;
                        case 31:
                        case 32:
                        case 33: // special, no need to switch to correct building type
                        default:
                            category = "1";
                            break;
                    }

                    if (category == "1")
                    {
                        actionBuildNew(r);
                    } else
                    {
                        //switch to correct buildings type
                        task.addOperation((rr) =>
                        {
                            actionBuildNew(rr);
                        });

                        LogManager.log("switching category");
                        Task.sendGet("build.php?id=" + (b.Id + 1) + "&category=" + category);
                    }
                } else //upgrading building
                {
                    LogManager.log("Upgrading " + building.Name);
                    var node = r.GetDoc().DocumentNode.SelectSingleNode("//button[@class='green build']");
                    //can build, green button
                    if (node != null)
                    {
                        LogManager.log("Building " + building.Name);
                        string url = Regex.Match(node.Attributes["onclick"].Value, "'(.*)'").Groups[1].Value;
                        queue.Dequeue();
                        Task.sendPost(url, new NameValueCollection());
                    }
                    else
                    {
                        LogManager.log("Not enough resources to build " + building.Name);
                        processResult();
                    }
                }  
            });

            return task;
        }

        public Task GetCheckBuildingsTask(Village village)
        {
            Task task = new Task();

            task.addOperation((r) =>
            {
                LogManager.log("Checking resources in village " + village);
                Task.sendGet("dorf1.php?newdid=" + village.Id + "&");
            });

            var buildings = village.Buildings;

            task.addOperation((r) =>
            {
                //process resources info
                var vNode = r.GetDoc().DocumentNode.SelectSingleNode("//div[@id='village_map']");
                village.Type = vNode.Attributes["class"].Value;

                var nodes = vNode.SelectNodes("div");
                
                for (int j = 0; j < nodes.Count; j++)
                {
                    var building = buildings[j];
                    string buildingInfo = nodes[j].Attributes["class"].Value;
                    Match match = Regex.Match(buildingInfo, "gid(\\d).*level(\\d+)"); ;

                    building.Type = int.Parse(match.Groups[1].Value);
                    building.Level = int.Parse(match.Groups[2].Value);
                }

                LogManager.log("Checking buildings in village " + village);
                Task.sendGet("dorf2.php?newdid=" + village.Id + "&");
            });

            task.addOperation((r) =>
            {
                //getting buildings dorf2 info

                var nodesLvl = r.GetDoc().DocumentNode.SelectNodes("//area[@alt]");
                var nodesGid = r.GetDoc().DocumentNode.SelectNodes("//img[(@style and @title) or (contains(@class,'wall'))]");

                for (int i = 0; i < nodesLvl.Count; i++)
                {
                    var node = nodesLvl[i];

                    //if it has title its not built yet
                    if (node.Attributes["title"] != null)
                    {
                        continue;
                    }
                    
                    var building = buildings[i + 18];

                    building.Level = int.Parse(Regex.Match(node.NextSibling.InnerText, "(\\d+)").Groups[1].Value);
                    building.Type = int.Parse(Regex.Match(nodesGid[i].Attributes["class"].Value, "(\\d+)").Groups[1].Value);
                }

                processResult();
            });

            return task;
        }

        public Task GetCheckBuildingsTask()
        {
            Task task = new Task() { Name = "Check buildings info in all villages" };

            task.addOperation((r) =>
            {
                Player player = Player.Instance;

                for (int i = 0; i < player.Villages.Count; i++)
                {
                    task.join(GetCheckBuildingsTask(player.Villages[i]));
                }

                task.addOperation((rr) =>
                {
                    if (TabVillagesPanelCreated != null)
                    {
                        TabVillagesPanelCreated(player.Villages);
                    }

                    processResult();
                });

                processResult();
            });

            return task;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timerElapsed = BuildingTimerElapsed;

            if (timerElapsed != null)
            {
                timerElapsed();
            }
        }

        public static void RemoveAction(Action action)
        {
            if (BuildingQueueRemoved != null)
            {
                BuildingQueueRemoved(action);
            }
        }
    }
}
