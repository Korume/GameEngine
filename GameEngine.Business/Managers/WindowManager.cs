using GameEngine.Business.Entities;
using GameEngine.Business.Providers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Business.Managers
{
    public class WindowManager
    {
        private const string CurrentWindowKey = "CurrentWindowKey";

        private SettingsManager _settingsManager;
        private IDataStorage _storage;

        public WindowManager(SettingsManager settingsManager, IDataStorage storage)
        {
            _settingsManager = settingsManager;
            _storage = storage;
        }

        public GameWindow GetGameWindow()
        {
            var gameWindow = _storage.GetValue<GameWindow>(CurrentWindowKey);
            if (gameWindow == null)
            {
                gameWindow = CreateGameWindow();
                _storage.SetValue(CurrentWindowKey, gameWindow);
            }
            return gameWindow;
        }

        private GameWindow CreateGameWindow()
        {
            var settings = _settingsManager.GetSettings();

            var videoMode = new VideoMode(settings.WindowWidth.Value, settings.WindowHeight.Value);
            var contextSettings = new ContextSettings(
                settings.DepthBits.Value,
                settings.StencilBits.Value,
                settings.AntialiasingLevel.Value);
            var window = new RenderWindow(videoMode, settings.WindowTitle, settings.WindowStyle.Value, contextSettings);
            var view = new View(new FloatRect(0, 0, settings.WindowWidth.Value, settings.WindowHeight.Value));

            window.SetVerticalSyncEnabled(settings.VerticalSync.Value);
            window.SetKeyRepeatEnabled(settings.KeyRepeat.Value);

            window.Closed += OnClosed;
            window.Resized += OnResized;

            return new GameWindow()
            {
                MainWindow = window,
                MainView = view
            };
        }

        private void OnClosed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }

        private void OnResized(object sender, SizeEventArgs e)
        {
            ((RenderWindow)sender).SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }
    }
}
