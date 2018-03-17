using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SettingsModule
{
    public class Settings
    {
        public uint WindowWidth { set; get; }
        public uint WindowHeight { set; get; }
        public Styles WindowStyle { set; get; }
        public string WindowTitle { set; get; }
        public bool VerticalSync { set; get; }
        public bool KeyRepeat { set; get; }
        public uint AntialiasingLevel { get; set; }

        public Settings()
        {
            WindowWidth = 640;
            WindowHeight = 480;
            WindowStyle = Styles.Default;
            WindowTitle = "GameEngine";
            VerticalSync = true;
            KeyRepeat = false;
            AntialiasingLevel = 2;
        }

        public void SetCustomSettings(Settings settings)
        {
            WindowWidth = settings.WindowWidth;
            WindowHeight = settings.WindowHeight;
            WindowStyle = settings.WindowStyle;
            WindowTitle = settings.WindowTitle;
            VerticalSync = settings.VerticalSync;
            KeyRepeat = settings.KeyRepeat;
            AntialiasingLevel = settings.AntialiasingLevel;
        }

        public static Settings GetDefaultSettings()
        {
            return new Settings();
        }
    }
}
