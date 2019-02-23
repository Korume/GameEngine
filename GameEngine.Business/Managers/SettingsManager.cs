using System.Configuration;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GameEngine.Business.Providers;
using GameEngine.Business.Entities;
using GameEngine.Business;

namespace GameEngine.Business.Managers
{
    public class SettingsManager
    {
        private const string CurrentSettingsKey = "CurrentSettingsKey";

        private IProvider<Settings> _settingsProvider;
        private IDataStorage _storage;

        public SettingsManager(IProvider<Settings> settingsProvider, IDataStorage storage)
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
