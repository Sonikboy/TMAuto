using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace TWAuto
{
    class Controller
    {
        private HttpClient httpclient = HttpClient.Instance;
        private Queue<Task> tasks;
        private Task currentTask;

        private int action = 1;
        private string result;

        private Player player = Player.Instance;
        private Village currentVillage;

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

            buildingManager.StartTimer();
        }

        private void initHandlers()
        {
            httpclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(httpclient_DownloadStringCompleted);
            httpclient.UploadValuesCompleted += new UploadValuesCompletedEventHandler(htptClient_UploadValuesCompleted);

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
            tasks.Enqueue(heroManager.GetCheckHeroTask());
        }

        private void buildingManager_BuildingTimerElapsed()
        {
            Task buildingTask = buildingManager.GetBuildingTask(currentVillage);

            if (buildingTask != null)
            {
                if (currentTask == null)
                {
                    currentTask = buildingTask;
                    currentTask.ExecuteNextOperation("");
                }
                else
                {
                    tasks.Enqueue(buildingTask);
                }
            }
        }

        public void AddBuildingToQueue(Village village, int buildingId)
        {
            buildingManager.AddBuilding(village, buildingId);
        }

        private void log(string message)
        {
            LogManager.log(message);
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
                    currentVillage = player.Villages[0];
                    log("Done.");
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
        }

        public int GetOffset(Village village, int id)
        {
            return buildingManager.GetOffset(village, id);
        }
    } 
}
