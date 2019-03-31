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
    public class CircleShapeSurrogate: ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var circleShape = (CircleShape)obj;
            info.AddValue("FillColor", circleShape.FillColor);
            info.AddValue("Origin", circleShape.Origin);
            info.AddValue("OutlineColor", circleShape.OutlineColor);
            info.AddValue("OutlineThickness", circleShape.OutlineThickness);
            info.AddValue("Position", circleShape.Position);
            info.AddValue("Radius", circleShape.Radius);
            info.AddValue("Rotation", circleShape.Rotation);
            info.AddValue("Scale", circleShape.Scale);
            info.AddValue("Texture", circleShape.Texture);
            info.AddValue("TextureRect", circleShape.TextureRect);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var circleShape = new CircleShape
            {
                FillColor = (Color)info.GetValue("FillColor", typeof(Color)),
                Origin = (Vector2f)info.GetValue("Origin", typeof(Vector2f)),
                OutlineColor = (Color)info.GetValue("OutlineColor", typeof(Color)),
                OutlineThickness = info.GetSingle("OutlineThickness"),
                Position = (Vector2f)info.GetValue("Position", typeof(Vector2f)),
                Radius = info.GetSingle("Radius"),
                Rotation = info.GetSingle("Rotation"),
                Scale = (Vector2f)info.GetValue("Scale", typeof(Vector2f)),
                Texture = (Texture)info.GetValue("Texture", typeof(Texture)),
                TextureRect = (IntRect)info.GetValue("TextureRect", typeof(IntRect))
            };
            return circleShape;
        }
    }
}
