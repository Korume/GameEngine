using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneManagement.Serialization.Surrogates
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
            var rectangleShape = new RectangleShape();
            rectangleShape.FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            rectangleShape.Origin = (Vector2f)info.GetValue("Origin", typeof(Vector2f));
            rectangleShape.OutlineColor = (Color)info.GetValue("OutlineColor", typeof(Color));
            rectangleShape.OutlineThickness = (float)info.GetValue("OutlineThickness", typeof(float));
            rectangleShape.Position = (Vector2f)info.GetValue("Position", typeof(Vector2f));
            rectangleShape.Rotation = (float)info.GetValue("Rotation", typeof(float));
            rectangleShape.Scale = (Vector2f)info.GetValue("Scale", typeof(Vector2f));
            rectangleShape.Size = (Vector2f)info.GetValue("Size", typeof(Vector2f));
            rectangleShape.Texture = (Texture)info.GetValue("Texture", typeof(Texture));
            rectangleShape.TextureRect = (IntRect)info.GetValue("TextureRect", typeof(IntRect));
            return rectangleShape;
        }
    }
}
