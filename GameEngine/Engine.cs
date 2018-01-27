using GameEngine.Modules.SettingsModule;
using GameEngine.Modules.WindowModule;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Engine
    {
        private ISettingsManager _settingsManager = null;
        private WindowManager _windowManager = null;
        private RenderWindow _window = null;
        private ISettings _settings = null;

        public Engine(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
            LoadSettings();

            LoadWindow();
        }

        private void LoadSettings()
        {
            _settingsManager.LoadSettings();
            _settings = _settingsManager.GetSettings();
        }

        private void LoadWindow()
        {
            _windowManager = new WindowManager(_settings);
            _window = _windowManager.Window;
        }

        public void StartMainCycle()
        {
            while (_window.IsOpen)
            {
                _window.DispatchEvents();

                _window.Clear(Color.Black);
                _window.Display();
            }
        }
    }
}
