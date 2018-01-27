using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace GameEngine.Modules.SettingsModule
{
    public class JsonSettingsManager : ISettingsManager
    {
        const string SettingsPath = @"settings.json";

        public Settings Settings { private set; get; }

        public JsonSettingsManager()
        {
            Settings = new Settings();
        }

        public Settings GetSettings()
        {
            return Settings;
        }

        public void LoadSettings()
        {
            bool isFileExist = File.Exists(SettingsPath);
            if (isFileExist)
            {
                LoadSettingsFromFile();
            }
            else
            {
                CreateSettingsFile();
            }
        }

        public void SaveSettings()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
            using (var fileInfo = new FileStream(SettingsPath, FileMode.Create))
            {
                jsonFormatter.WriteObject(fileInfo, Settings);
            }
        }

        private void CreateSettingsFile()
        {
            SaveSettings();
        }

        private void LoadSettingsFromFile()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
            using (var fileInfo = new FileStream(SettingsPath, FileMode.Open))
            {
                var loadedSettings = (Settings)jsonFormatter.ReadObject(fileInfo);
                Settings.SetCustomSettings(loadedSettings);
            }
        }
    }
}
