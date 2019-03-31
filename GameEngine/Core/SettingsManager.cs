using System.Configuration;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GameEngine.SettingsProvider;
using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.Storages;

namespace GameEngine.Core
{
    public class SettingsManager : ISettingsManager
    {
        private const string CurrentSettingsKey = "CurrentSettingsKey";

        private ISettingsProvider _settingsProvider;
        private IDataStorage _storage;

        public SettingsManager(ISettingsProvider settingsProvider, IDataStorage storage)
        {
            _settingsProvider = settingsProvider;
            _storage = storage;
        }

        public Settings GetSettings()
        {
            var settings = _storage.GetValue<Settings>(CurrentSettingsKey);
            if(settings == null)
            {
                settings = _settingsProvider.Get();
                _storage.SetValue(CurrentSettingsKey, settings);
            }
            return settings;
        }

        public Settings SaveSettings(Settings settingsForSave)
        {
            return _settingsProvider.Save(settingsForSave);
        }
    }
}
