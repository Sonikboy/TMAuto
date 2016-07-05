using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace TMAuto
{
    class BuildingManager
    {
        private CustomTimer timer;
        private Action processResult;
        private Player player = Player.Instance;

        public delegate void BuildingTimerHandler();
        public event BuildingTimerHandler BuildingTimerElapsed;
        public delegate void CreateTabVillagesPanelHandler(List<Village> villages);
        public static event CreateTabVillagesPanelHandler TabVillagesPanelCreated;
        public delegate void RemoveBuildingQueueHandler(Action action);
        public static event RemoveBuildingQueueHandler BuildingQueueRemoved;

        public BuildingManager(Action processResult)
        {
            this.processResult = processResult;
            timer = new CustomTimer(60, 90);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        public void StartTimer()
        {
            timer.Start();
        }
        public void AddBuilding(Village village, int id, int priority = 0)
        {
            PriorityQueue queue = village.BuildingQueue;

            var b = new QueuedBuilding() { Name = Buildings.GetName(village.Buildings[id].Type), Id = id, Type = village.Buildings[id].Type };
            queue.Enqueue(priority, b);
            var building = village.Buildings[id];
            building.Offset = GetOffset(village, id);
            b.Level = building.Total;
        }

        public void RemoveBuilding(Village village, int index)
        {
            PriorityQueue queue = village.BuildingQueue;

            dynamic forBuilding = queue.RemoveAt(index);
            village.Buildings[forBuilding.Id].Offset = forBuilding.Offset;
        }
        public int GetOffset(Village village, int id)
        {
            PriorityQueue queue = village.BuildingQueue;

            return queue.GetOffset(id);
        }

        public Task GetBuildingTask(Village village, QueuedBuilding queuedBuilding)
        {
            Task task = new Task();

            Building building = village.Buildings[queuedBuilding.Id];

            task.addOperation((r) =>
            {
                var nextLevelCost = Buildings.getNextLevelCost(queuedBuilding.Type, queuedBuilding.Level);

                var rm = Regex.Match(r, "resources.storage = {.*?\"l1\": (\\d+).*?,\"l2\": (\\d+).*?,\"l3\": (\\d+).*?,\"l4\": (\\d+).*?};", RegexOptions.Singleline);
                var freeCrop = int.Parse(Regex.Match(r, ",\"l5\":.*?(\\d+).*?};").Groups[1].Value);
                var currentResources = new Resources() { Wood = int.Parse(rm.Groups[1].Value), Clay = int.Parse(rm.Groups[2].Value), Iron = int.Parse(rm.Groups[3].Value), Crop = int.Parse(rm.Groups[4].Value), FreeCrop = freeCrop };

                if (currentResources >= nextLevelCost)
                {
                    Task.SelectBuilding(queuedBuilding.Id + 1);
                }
                else
                {
                    /**
                    *
                    * Build croplands?? [POSSIBLE_EDIT]
                    *
                    */
                    LogManager.log(village, "Not enough resources to build " + building.Name);
                    processResult();
                }
            });

            Action<string> actionBuildNew = (r) =>
            {
                var node = r.GetDoc().DocumentNode.SelectSingleNode(String.Format("//button[@class='green new' and contains(@onclick,'a={0}')]", building.Type));

                if (node != null)
                {
                    LogManager.log(village, "Building new " + building.Name);
                    string url = Regex.Match(node.Attributes["onclick"].Value, "'(.*)'").Groups[1].Value;
                    var bb = village.BuildingQueue.Remove(queuedBuilding);
                    building.Offset = bb.Offset;
                    Task.sendPost(url, new NameValueCollection());
                }
                else
                {
                    LogManager.log(village, "Cant build " + building.Name);
                    processResult();
                }
            };

            task.addOperation((r) =>
            {
                if (building.Type > 4 && building.Level == 0) //building new, not for res
                {
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
                    }
                    else
                    {
                        //switch to correct buildings type
                        task.addOperation((rr) =>
                        {
                            actionBuildNew(rr);
                        });

                        LogManager.log("switching category");
                        Task.sendGet("build.php?id=" + (queuedBuilding.Id + 1) + "&category=" + category);
                    }
                }
                else //upgrading building
                {
                    var node = r.GetDoc().DocumentNode.SelectSingleNode("//button[@class='green build']");
                    //can build, green button
                    if (node != null)
                    {
                        LogManager.log(village, "Upgrading " + building.Name + " to " + queuedBuilding.Level);
                        string url = Regex.Match(node.Attributes["onclick"].Value, "'(.*)'").Groups[1].Value;
                        var bb = village.BuildingQueue.Remove(queuedBuilding);
                        building.Offset = bb.Offset;
                        Task.sendPost(url, new NameValueCollection());
                    }
                    else
                    {
                        LogManager.log(village, "Cant build " + building.Name);
                        processResult();
                    }
                }
            });

            return task;
        }

        public Task GetBuildingTaskForVillage(Village village)
        {
            Task task = new Task() { Name = "Build" };

            PriorityQueue queue = village.BuildingQueue;

            if (queue.Empty())
            {
                return null;
            }

            List<QueuedBuilding> b = new List<QueuedBuilding>();

            //if roman => double queue check
            if (player.Tribe == Tribe.Romans)
            {
                QueuedBuilding bRes = queue.Peek(BuildingType.Resource);
                QueuedBuilding bBuild = queue.Peek(BuildingType.Building);

                if (bRes != null)
                {
                    b.Add(bRes);
                }
                if (bBuild != null)
                {
                    b.Add(bBuild);
                }
            } else
            {
                QueuedBuilding build = queue.Peek();
                b.Add(build);
            }
            
            task.addOperation((r) =>
            {
                Task.SwitchVillage(village);
            });

            task.addOperation((r) =>
            {
                var ongoingBuildingQueue = Task.GetOngoingBuildingQueue(village, r);
                
                for (int buildingIndex = 0; buildingIndex < b.Count; buildingIndex++)
                {
                    QueuedBuilding queuedBuilding = b[buildingIndex];
                    Building building = village.Buildings[queuedBuilding.Id];
                    task.Name = "Build " + building.Name;

                    bool freeQueue = ongoingBuildingQueue.Count == 0;

                    //if anything in queue
                    if (!freeQueue)
                    {
                        //romans can dual build so check
                        if (player.Tribe == Tribe.Romans)
                        {
                            //res id < 18, building id >= 18
                            freeQueue = (queuedBuilding.Id < 18 && ongoingBuildingQueue.Count(bq => bq.Id <= 18) == 0) || (queuedBuilding.Id >= 18 && ongoingBuildingQueue.Count(buq => buq.Id > 18) == 0);
                        }
                    }

                    if (freeQueue)
                    {
                        task.join(GetBuildingTask(village, queuedBuilding));
                    }
                }

                processResult();
            });

            return task;
        }

        public Task GetCheckBuildingsTask(Village village)
        {
            Task task = new Task();

            task.addOperation((r) =>
            {
                LogManager.log(village, "Checking resources");
                Task.SwitchVillage(village);
            });

            var buildings = village.Buildings;

            task.addOperation((r) =>
            {
                //analyze ongoing building queues
                Task.GetOngoingBuildingQueue(village, r);
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

                LogManager.log(village, "Checking buildings");
                Task.sendGet("dorf2.php");
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
