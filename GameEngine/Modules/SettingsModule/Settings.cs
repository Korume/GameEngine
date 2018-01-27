using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SettingsModule
{
    [DataContract]
    public class Settings : ISettings
    {
        [DataMember]
        public uint WindowWidth { set; get; }

        [DataMember]
        public uint WindowHeight { set; get; }

        [DataMember]
        public Styles WindowStyle { set; get; }

        [DataMember]
        public string WindowTitle { set; get; }

        [DataMember]
        public bool VerticalSync { set; get; }

        [DataMember]
        public bool KeyRepeat { set; get; }

        public Settings()
        {
            WindowWidth = 640;
            WindowHeight = 480;
            WindowStyle = Styles.Default;
            WindowTitle = "GameEngine";
            VerticalSync = true;
            KeyRepeat = false;
        }

        public void SetCustomSettings(Settings settings)
        {
            WindowWidth = settings.WindowWidth;
            WindowHeight = settings.WindowHeight;
            WindowStyle = settings.WindowStyle;
            WindowTitle = settings.WindowTitle;
            VerticalSync = settings.VerticalSync;
            KeyRepeat = settings.KeyRepeat;
        }

        public static ISettings GetDefaultSettings()
        {
            var settings = new Settings()
            {
                WindowWidth = 640,
                WindowHeight = 480,
                WindowStyle = Styles.Default,
                WindowTitle = "GameEngine",
                VerticalSync = true,
                KeyRepeat = false
            };
            return settings;
        }
    }
}
