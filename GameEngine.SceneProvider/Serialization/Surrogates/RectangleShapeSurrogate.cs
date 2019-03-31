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
    public class RectangleShapeSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var rectangleShape = (RectangleShape)obj;
            info.AddValue("FillColor", rectangleShape.FillColor);
            info.AddValue("Origin", rectangleShape.Origin);
            info.AddValue("OutlineColor", rectangleShape.OutlineColor);
            info.AddValue("OutlineThickness", rectangleShape.OutlineThickness);
            info.AddValue("Position", rectangleShape.Position);
            info.AddValue("Rotation", rectangleShape.Rotation);
            info.AddValue("Scale", rectangleShape.Scale);
            info.AddValue("Size", rectangleShape.Size);
            info.AddValue("Texture", rectangleShape.Texture);
            info.AddValue("TextureRect", rectangleShape.TextureRect);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var rectangleShape = new RectangleShape
            {
                FillColor = (Color)info.GetValue("FillColor", typeof(Color)),
                Origin = (Vector2f)info.GetValue("Origin", typeof(Vector2f)),
                OutlineColor = (Color)info.GetValue("OutlineColor", typeof(Color)),
                OutlineThickness = info.GetSingle("OutlineThickness"),
                Position = (Vector2f)info.GetValue("Position", typeof(Vector2f)),
                Rotation = info.GetSingle("Rotation"),
                Scale = (Vector2f)info.GetValue("Scale", typeof(Vector2f)),
                Size = (Vector2f)info.GetValue("Size", typeof(Vector2f)),
                Texture = (Texture)info.GetValue("Texture", typeof(Texture)),
                TextureRect = (IntRect)info.GetValue("TextureRect", typeof(IntRect))
            };
            return rectangleShape;
        }
    }
}
