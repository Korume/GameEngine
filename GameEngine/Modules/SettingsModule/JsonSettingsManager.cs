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

        private Settings Settings;

        public JsonSettingsManager()
        {
            Settings = new Settings();
        }

        public Settings GetSettings() => Settings;

        public void LoadSettings()
        {
            bool isFileExist = File.Exists(SettingsPath);
            if (isFileExist)
            {
                bool isLoadSuccessful = LoadSettingsFromFile();
                if (!isLoadSuccessful)
                {
                    CreateDefaultSettingsFile();
                }
            }
            else
            {
                CreateDefaultSettingsFile();
            }
        }

        public void SaveSettings(Settings settingsForSave)
        {
            using (var fileInfo = new FileStream(SettingsPath, FileMode.Create))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
                jsonFormatter.WriteObject(fileInfo, settingsForSave);
            }
        }

        private bool LoadSettingsFromFile()
        {
            using (var fileInfo = new FileStream(SettingsPath, FileMode.Open))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
                Settings loadedSettings = null;
                try
                {
                    loadedSettings = (Settings)jsonFormatter.ReadObject(fileInfo);
                }
                catch (SerializationException)
                {
                    return false;
                }
                Settings.SetCustomSettings(loadedSettings);
                return true;
            }
        }

        private void CreateDefaultSettingsFile() => SaveSettings(Settings);
    }
}
