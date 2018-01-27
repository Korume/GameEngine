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
        public RenderWindow Window { private set; get; }
        public View View { private set; get; }

        public WindowManager() : this(Settings.GetDefaultSettings())
        {
        }

        public WindowManager(ISettings settings)
        {
            var videoMode = new VideoMode(settings.WindowWidth, settings.WindowHeight);
            Window = new RenderWindow(videoMode, settings.WindowTitle, settings.WindowStyle);

            Window.SetVerticalSyncEnabled(settings.VerticalSync);
            Window.SetKeyRepeatEnabled(settings.KeyRepeat);

            Window.Closed += Window_Closed;
            Window.Resized += Window_Resized;
        }

        public RenderWindow GetWindow()
        {
            return Window;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }

        private void Window_Resized(object sender, SizeEventArgs e)
        {
            Window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }
    }
}
