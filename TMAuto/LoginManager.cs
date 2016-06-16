using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class LoginManager
    {
        public static Task GetLoginTask()        
        {
            Task login = new Task() { Name = "login" };
            Settings settings = Settings.Instance;

            //login page
            login.addOperation((r) =>
            {
                LogManager.log("Opening login page.");

                string url = "dorf1.php";

                Task.sendGet(url);
            });
            //continue login choose server
            login.addOperation((r) =>
            {
                LogManager.log("Sending login information.");

                string url = "dorf1.php";
                string loginText = r.GetDoc().DocumentNode.SelectSingleNode("//button[@name='s1']").Attributes["value"].Value;

                NameValueCollection content = new NameValueCollection();
                content.Add("name", settings.Username);
                content.Add("password", settings.Password);
                content.Add("s1", loginText);
                content.Add("w", "1920:1080");
                content.Add("login", ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString());

                Task.sendPost(url, content);
            });

            return login;
        }

        private HtmlAgilityPack.HtmlDocument getDoc(string result)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result);
            return doc;
        }
    }
}
