using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMAuto
{
    class Task
    {
        private int i;
        private List<Action<string>> operations;
        private static HttpClient httpClient = HttpClient.Instance;
        public string Name { get; set; }
       
        public Task()
        {
            operations = new List<Action<string>>();
            i = 0;
        }

        public void Start()
        {
            ExecuteNextOperation("");
        }

        public void addOperation(Action<string> op)
        {
            operations.Add(op);
        }

        public bool IsDone()
        {
            return i == operations.Count;
        }

        public void ExecuteNextOperation(string result)
        {
            operations[i++].Invoke(result);
        }

        public void join(Task task)
        {
            var ops = task.operations;

            for (int i = 0; i < ops.Count(); i++) 
            {
                operations.Add(ops[i]);
            }
        }

        public static void sendPost(string url, NameValueCollection content)
        {
            httpClient.UploadValuesAsync(new Uri(addUrl(url)), content);
        }

        public static  void sendGet(string url)
        {
            httpClient.DownloadStringAsync(new Uri(addUrl(url)));
        }

        private static string addUrl(string path)
        {
            return "http://" + Settings.Instance.Server + "/" + path;
        }

        public static void SwitchVillage(string id)
        {
            sendGet("dorf1.php?newdid=" + id + "&");
        }

        public static byte[] send(string url, NameValueCollection content)
        {
            return httpClient.UploadValues(new Uri(url), content);
        }
        //returns queue
        public static List<dynamic> GetOngoingBuildingQueue(Village village, string result)
        {
            LogManager.log("Analyzing building queue");

            var docNode = result.GetDoc().DocumentNode;
            var queueNodes = docNode.SelectNodes("//li[.//img[@class='del' and @title]]");
            var queueMatch = Regex.Match(result, "bld=\\[(.*)\\]");
            var queues = queueMatch.Groups[1].Value.Replace(",{", "?{").Split('?');

            List<dynamic> buildQueue = new List<dynamic>();

            //no queue
            if (queueNodes == null)
            {
                return buildQueue;
            }

            for (int i = 0; i < queues.Count(); i++)
            {
                Match match = Regex.Match(queues[i], "{\"stufe\":(.*),\"gid\":\"(.*)\",\"aid\":\"(.*)\"}");

                int type = int.Parse(match.Groups[2].Value);
                int id = int.Parse(match.Groups[3].Value);
                string time = queueNodes[i].SelectSingleNode(".//span[@class='timer']").InnerText;

                buildQueue.Add(new { Type = type, Id = id, Time = time });
            }

            village.updateOngoingQueue(buildQueue);

            return buildQueue;
        }
    }
}
