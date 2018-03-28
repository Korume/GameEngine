using GameEngine.Business.Entities;
using GameEngine.Business.Providers;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameProvider.Providers
{
    public class JsonSettingsProvider : ISettingsProvider
    {
        private readonly string SettingsPath = ConfigurationManager.AppSettings["SettingsPath"];

        public Settings Get()
        {
            bool isFileExist = File.Exists(SettingsPath);
            var settings = isFileExist ? LoadFromFile() ?? CreateDefaultSettingsFile() : CreateDefaultSettingsFile();
            return settings;
        }

        private Settings CreateDefaultSettingsFile() => Save(Settings.CreateDefault());

        private Settings LoadFromFile()
        {
            using (var fileInfo = new FileStream(SettingsPath, FileMode.Open))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
                //newtonsoft json -- hz
                Settings loadedSettings = null;
                try
                {
                    loadedSettings = (Settings)jsonFormatter.ReadObject(fileInfo);
                    var fieldInfoArray = loadedSettings.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (var fieldInfo in fieldInfoArray)
                    {
                        var field = fieldInfo.GetValue(loadedSettings);
                        if (field == null)
                        {
                            throw new SerializationException();
                        }
                    }
                }
                catch (SerializationException)
                {
                    return null;
                }

                return loadedSettings.Clone();
            }
        }

        public Settings Save(Settings settingsForSave)
        {
            using (var fileInfo = new FileStream(SettingsPath, FileMode.Create))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
                jsonFormatter.WriteObject(fileInfo, settingsForSave);
            }
            return settingsForSave;
        }
    }
}
