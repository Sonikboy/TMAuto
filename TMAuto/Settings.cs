using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    sealed class Settings
    {
        private static string GENERAL_SETTINGS_FILE = @"generalSettings.xml";

        private static readonly Settings instance = new Settings();
        public static Settings Instance { get { return instance; } }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }

        private Settings()
        {
            Username = "";
            Password = "";
            Server = "";
        }

        private void loadLastSettings()
        {
            IOHandler.Load(GENERAL_SETTINGS_FILE, instance);
        }

        public void saveLastSettings()
        {
            IOHandler.Save(GENERAL_SETTINGS_FILE, instance);
        }

        static Settings() {
            IOHandler.Load(GENERAL_SETTINGS_FILE, instance);
        }
    }
}
