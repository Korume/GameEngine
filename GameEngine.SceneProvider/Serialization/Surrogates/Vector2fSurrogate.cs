using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneProvider.Serialization.Surrogates
{
    public class Vector2fSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var vector2f = (Vector2f)obj;
            info.AddValue("X", vector2f.X);
            info.AddValue("Y", vector2f.Y);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var vector2f = new Vector2f();
            vector2f.X = (float)info.GetValue("X", typeof(float));
            vector2f.Y = (float)info.GetValue("Y", typeof(float));
            return vector2f;
        }
    }
}
