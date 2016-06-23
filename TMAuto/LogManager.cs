using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class LogManager
    {
        public delegate void UpdateLogHandler(string message);
        public static event UpdateLogHandler LogUpdated;

        public static void log(Village village, string message)
        {
            log(message, village);
        }
        public static void log(string message, Village village = null)
        {
            var sendLog = LogUpdated;

            if (sendLog != null)
            {
                sendLog(DateTime.Now.ToString("h:mm:ss.ff") + "     " + ((village != null ) ? village.Name + ">> " : "" ) + message);
            }
        }
    }
}
