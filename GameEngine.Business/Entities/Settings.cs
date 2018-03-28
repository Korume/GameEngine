using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Business.Entities
{
    public class Settings
    {
        public uint? WindowWidth { get; set; }
        public uint? WindowHeight { get; set; }
        public Styles? WindowStyle { get; set; }
        public string WindowTitle { get; set; }
        public bool? VerticalSync { get; set; }
        public bool? KeyRepeat { get; set; }
        public uint? DepthBits { get; set; }
        public uint? StencilBits { get; set; }
        public uint? AntialiasingLevel { get; set; }

        public Settings Clone() => (Settings)MemberwiseClone();

        public static Settings CreateDefault()
        {
            return new Settings()
            {
                WindowWidth = 640,
                WindowHeight = 480,
                WindowStyle = Styles.Default,
                WindowTitle = "GameEngine",
                VerticalSync = true,
                KeyRepeat = false,
                AntialiasingLevel = 2,
                DepthBits = 2,
                StencilBits = 2
            };
        }
    }
}
