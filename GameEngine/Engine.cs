using GameEngine.Modules.SceneModule;
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
        private ISettingsManager _settingsManager;
        private WindowManager _windowManager;
        private SceneManager _sceneManager;
        private RenderWindow _window;
        private Settings _settings;

        public Engine(ISettingsManager settingsManager)
        {
            LoadSettings(settingsManager);
            LoadWindow();
            _sceneManager = new SceneManager(new Scene(), _window);
        }

        private void LoadSettings(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
            _settingsManager.LoadSettings();
            _settings = _settingsManager.GetSettings();
        }

        private void LoadWindow()
        {
            _windowManager = new WindowManager(_settings);
            _window = _windowManager.MainWindow;
        }

        public void StartMainCycle()
        {
            while (_window.IsOpen)
            {
                _window.DispatchEvents();

                _sceneManager.Update();
                _window.Clear(Color.Black);
                _sceneManager.Draw();
                _window.Display();
            }
        }
    }
}
