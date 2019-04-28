using System.Configuration;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.Storages;
using GameEngine.Interfaces.DataAccess;
using GameEngine.Interfaces.Factories;

namespace GameEngine.Core
{
    public class SettingsManager : ISettingsManager
    {
        private const string CurrentSettingsKey = "CurrentSettingsKey";

        private ISettingsProvider _settingsProvider;
        private IDataStorage _storage;
        private ISettingsFactory _settingsFactory;

        public SettingsManager(ISettingsProvider settingsProvider, IDataStorage storage, ISettingsFactory settingsFactory)
        {
            _settingsProvider = settingsProvider;
            _storage = storage;
            _settingsFactory = settingsFactory;
        }

        public Settings GetSettings()
        {
            var settings = _storage.GetValue<Settings>(CurrentSettingsKey);
            if(settings == null)
            {
                settings = _settingsProvider.Get();
                if(settings == null)
                {
                    settings = _settingsFactory.CreateDefault();
                    _settingsProvider.Save(settings);
                }
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
