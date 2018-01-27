using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SettingsModule
{
    public interface ISettings
    {
        uint WindowWidth { set; get; }
        uint WindowHeight { set; get; }
        Styles WindowStyle { set; get; }
        string WindowTitle { set; get; }
        bool VerticalSync { set; get; }
        bool KeyRepeat { set; get; }
    }
}
