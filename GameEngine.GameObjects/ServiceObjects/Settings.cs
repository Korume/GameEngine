using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.ServiceObjects
{
    public class Settings
    {
        public uint WindowWidth { get; set; } = 640;
        public uint WindowHeight { get; set; } = 480;
        public Styles WindowStyle { get; set; } = Styles.Default;
        public string WindowTitle { get; set; } = "GameEngine";
        public bool VerticalSync { get; set; } = true;
        public bool KeyRepeat { get; set; } = false;
        public uint DepthBits { get; set; } = 2;
        public uint StencilBits { get; set; } = 2;
        public uint AntialiasingLevel { get; set; } = 2;
    }
}
