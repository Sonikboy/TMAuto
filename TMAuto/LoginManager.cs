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
                Task.sendGet("dorf1.php");
            });
            //continue login choose server
            login.addOperation((r) =>
            {
                LogManager.log("Sending login information.");

                string loginText = r.GetDoc().DocumentNode.SelectSingleNode("//button[@name='s1']").Attributes["value"].Value;

                NameValueCollection content = new NameValueCollection();
                content.Add("name", settings.Username);
                content.Add("password", settings.Password);
                content.Add("s1", loginText);
                content.Add("w", "1920:1080");
                content.Add("login", ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString());

                Task.sendPost("dorf1.php", content);
            });

            return login;
        }
    }
}
