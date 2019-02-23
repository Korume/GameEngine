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
            var circleShape = new CircleShape();
            circleShape.FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            circleShape.Origin = (Vector2f)info.GetValue("Origin", typeof(Vector2f));
            circleShape.OutlineColor = (Color)info.GetValue("OutlineColor", typeof(Color));
            circleShape.OutlineThickness = (float)info.GetValue("OutlineThickness", typeof(float));
            circleShape.Position = (Vector2f)info.GetValue("Position", typeof(Vector2f));
            circleShape.Radius = (float)info.GetValue("Radius", typeof(float));
            circleShape.Rotation = (float)info.GetValue("Rotation", typeof(float));
            circleShape.Scale = (Vector2f)info.GetValue("Scale", typeof(Vector2f));
            circleShape.Texture = (Texture)info.GetValue("Texture", typeof(Texture));
            circleShape.TextureRect = (IntRect)info.GetValue("TextureRect", typeof(IntRect));
            return circleShape;
        }
    }
}
