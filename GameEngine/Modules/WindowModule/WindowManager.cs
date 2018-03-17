using GameEngine.Modules.SettingsModule;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.WindowModule
{
    public class WindowManager
    {
        public RenderWindow MainWindow { private set; get; }
        public View MainView { private set; get; }

        public WindowManager() : this(Settings.GetDefaultSettings())
        {
        }

        public WindowManager(Settings settings)
        {
            var videoMode = new VideoMode(settings.WindowWidth, settings.WindowHeight);
            var contextSettings = new ContextSettings(16, 0, settings.AntialiasingLevel);
            MainWindow = new RenderWindow(videoMode, settings.WindowTitle, settings.WindowStyle, contextSettings);

            MainWindow.SetVerticalSyncEnabled(settings.VerticalSync);
            MainWindow.SetKeyRepeatEnabled(settings.KeyRepeat);

            MainWindow.Closed += Window_Closed;
            MainWindow.Resized += Window_Resized;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.Close();
        }

        private void Window_Resized(object sender, SizeEventArgs e)
        {
            MainWindow.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }
    }
}
