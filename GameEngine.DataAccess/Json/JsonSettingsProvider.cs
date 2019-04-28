using GameEngine.GameObjects.ServiceObjects;
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
using GameEngine.Interfaces.DataAccess;

namespace GameEngine.DataAccess.Json
{
    public class JsonSettingsProvider : ISettingsProvider
    {
        private readonly string SettingsPath = ConfigurationManager.AppSettings["SettingsPath"];

        public Settings Get()
        {
            bool isFileExist = File.Exists(SettingsPath);
            if(isFileExist)
            {
                using (var fileInfo = new FileStream(SettingsPath, FileMode.Open))
                {
                    var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));
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
            return null;
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
