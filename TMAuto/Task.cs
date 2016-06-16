using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
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
    }
}
