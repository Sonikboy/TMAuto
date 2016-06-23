using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class HttpClient : WebClient
    {
        private static readonly HttpClient instance = new HttpClient();
        public static HttpClient Instance { get { return instance; } }

        private CookieContainer container = new CookieContainer();

        private HttpClient() { }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                HttpWebRequest rq = (request as HttpWebRequest);
                rq.CookieContainer = container;
                rq.KeepAlive = true;
                rq.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            }

            return request;
        }

        public void clearCookies()
        {
            container = new CookieContainer();
        }
    }
}
