using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneProvider.Serialization.Surrogates
{
    public class ColorSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var color = (Color)obj;
            info.AddValue("A", color.A);
            info.AddValue("B", color.B);
            info.AddValue("G", color.G);
            info.AddValue("R", color.R);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var color = new Color
            {
                A = info.GetByte("A"),
                B = info.GetByte("B"),
                G = info.GetByte("G"),
                R = info.GetByte("R")
            };
            return color;
        }
    }
}
