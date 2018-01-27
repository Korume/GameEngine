using GameEngine.Modules.SettingsModule;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.WindowModule
{
    public interface IWindow
    {
        void LoadWindow(ISettings settings);
        RenderWindow GetWindow();
    }
}
