using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneProvider.Serialization.Surrogates
{
    public class IntRectSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var intRect = (IntRect)obj;
            info.AddValue("Height", intRect.Height);
            info.AddValue("Left", intRect.Left);
            info.AddValue("Top", intRect.Top);
            info.AddValue("Width", intRect.Width);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var intRect = new IntRect
            {
                Height = info.GetInt32("Height"),
                Left = info.GetInt32("Left"),
                Top = info.GetInt32("Top"),
                Width = info.GetInt32("Width")
            };
            return intRect;
        }
    }
}
