using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.Storages;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Core
{
    public class WindowManager : IWindowManager
    {
        private const string CurrentWindowKey = "CurrentWindowKey";

        private ISettingsManager _settingsManager;
        private IDataStorage _storage;

        public WindowManager(ISettingsManager settingsManager, IDataStorage storage)
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

            var videoMode = new VideoMode(settings.WindowWidth, settings.WindowHeight);
            var contextSettings = new ContextSettings(settings.DepthBits, settings.StencilBits, settings.AntialiasingLevel);
            var window = new RenderWindow(videoMode, settings.WindowTitle, settings.WindowStyle, contextSettings);
            var view = new View(new FloatRect(0, 0, settings.WindowWidth, settings.WindowHeight));

            window.SetVerticalSyncEnabled(settings.VerticalSync);
            window.SetKeyRepeatEnabled(settings.KeyRepeat);

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
