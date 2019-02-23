using GameEngine.Business.Entities;
using GameEngine.Business.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SettingsProvider
{
    public class JsonSettingsProvider : IProvider<Settings>
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
                try
                {
                    return (Settings)jsonFormatter.ReadObject(fileInfo);
                }
                catch (SerializationException)
                {
                    return null;
                }
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
