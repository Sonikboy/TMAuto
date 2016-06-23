using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace TMAuto
{
    class Controller
    {
        private Queue<Task> tasks;
        private Task currentTask;
        private Hero hero = Hero.Instance;

        private int action = 1;
        private string result;

        private Player player = Player.Instance;

        private BuildingManager buildingManager;
        private VillageManager villageManager;
        private HeroManager heroManager;

        public bool saveResponses;
        public Controller()
        {
            buildingManager = new BuildingManager(ProcessResult);
            villageManager = new VillageManager(ProcessResult);
            heroManager = new HeroManager(ProcessResult);
            
            initHandlers();
            initTasks();
        }

        private void initHandlers()
        {
            Task.HttpClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(httpclient_DownloadStringCompleted);
            Task.HttpClient.UploadValuesCompleted += new UploadValuesCompletedEventHandler(htptClient_UploadValuesCompleted);

            buildingManager.BuildingTimerElapsed += new BuildingManager.BuildingTimerHandler(buildingManager_BuildingTimerElapsed);
        }

        private void httpclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                result = WebUtility.HtmlDecode(Encoding.UTF8.GetString(Encoding.Default.GetBytes(e.Result)));
                if (saveResponses) { if (!Directory.Exists("responses")) { Directory.CreateDirectory("responses"); } File.WriteAllText(@"responses\GET_" + (action > 1 ? action.ToString() : "") + "_" + currentTask.Name + ".html", result); }
                ProcessResult();
            }
        }

        private void htptClient_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                result = WebUtility.HtmlDecode(Encoding.UTF8.GetString(e.Result));
                if (saveResponses) { if (!Directory.Exists("responses")) { Directory.CreateDirectory("responses"); } File.WriteAllText(@"responses\POST_" + (action > 1 ? action.ToString() : "") + "_" + currentTask.Name + ".html", result); }
                ProcessResult();
            }
        }

        private void initTasks()
        {
            tasks = new Queue<Task>();
            tasks.Enqueue(LoginManager.GetLoginTask());
            tasks.Enqueue(villageManager.GetInitializeVillagesTask());
            tasks.Enqueue(buildingManager.GetCheckBuildingsTask());
        }

        private void buildingManager_BuildingTimerElapsed()
        {
            for (int i = 0; i < player.Villages.Count; i++)
            {
                var nextTask = buildingManager.GetBuildingTask(player.Villages[i]);

                if (nextTask != null) {
                    tasks.Enqueue(nextTask);
                }
            }

            if (hero.AdventureMode != Mode.NONE) tasks.Enqueue(heroManager.GetCheckHeroTask());

            if (tasks.Count > 0 && currentTask == null)
            {
                currentTask = tasks.Dequeue();
                currentTask.ExecuteNextOperation("");
            }
        }

        public void AddBuildingToQueue(Village village, int buildingId, int priority = 0)
        {
            buildingManager.AddBuilding(village, buildingId, priority);
        }

        public void RemoveBuildingFromQueue(Village village, int index)
        {
            buildingManager.RemoveBuilding(village, index);
        }

        private void ProcessResult()
        {
            if (currentTask.IsDone())
            {
                if (tasks.Count > 0)
                {
                    action = 1;
                    currentTask = tasks.Dequeue();
                } else
                {
                    currentTask = null;
                    LogManager.log("Done.");
                    return;
                }
            }

            currentTask.ExecuteNextOperation(result);
            action++;
        }

        public void Start()
        {
            //login task
            currentTask = tasks.Dequeue();
            currentTask.Start();

            if (saveResponses)
            {
                if (Directory.Exists("responses"))
                {
                    Directory.Delete("responses", true);
                }
            }

            buildingManager.StartTimer();
        }
    } 
}
