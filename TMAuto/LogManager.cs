using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWAuto
{
    class LogManager
    {
        public delegate void UpdateLogHandler(string message);
        public static event UpdateLogHandler LogUpdated;

        public static void log(string message)
        {
            var sendLog = LogUpdated;

            if (sendLog != null)
            {
                sendLog(message);
            }
        }
    }
}
