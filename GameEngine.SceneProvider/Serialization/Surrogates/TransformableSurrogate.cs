using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneProvider.Serialization.Surrogates
{
    public class TransformableSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var transformable = (Transformable)obj;
            info.AddValue("Origin", transformable.Origin);
            info.AddValue("Position", transformable.Position);
            info.AddValue("Rotation", transformable.Rotation);
            info.AddValue("Scale", transformable.Scale);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var transformable = new Transformable();
            transformable.Origin = (Vector2f)info.GetValue("Origin", typeof(Vector2f));
            transformable.Position = (Vector2f)info.GetValue("Position", typeof(Vector2f));
            transformable.Rotation = (float)info.GetValue("Rotation", typeof(float));
            transformable.Scale = (Vector2f)info.GetValue("Scale", typeof(Vector2f));
            return transformable;
        }
    }
}
