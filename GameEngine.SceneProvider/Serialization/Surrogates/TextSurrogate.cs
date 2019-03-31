using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static SFML.Graphics.Text;

namespace GameEngine.SceneProvider.Serialization.Surrogates
{
    public class TextSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var text = (Text)obj;
            info.AddValue("CharacterSize", text.CharacterSize);
            info.AddValue("DisplayedString", text.DisplayedString);
            info.AddValue("FillColor", text.FillColor);
            info.AddValue("Font", text.Font);
            info.AddValue("LetterSpacing", text.LetterSpacing);
            info.AddValue("LineSpacing", text.LineSpacing);
            info.AddValue("Origin", text.Origin);
            info.AddValue("OutlineColor", text.OutlineColor);
            info.AddValue("OutlineThickness", text.OutlineThickness);
            info.AddValue("Position", text.Position);
            info.AddValue("Rotation", text.Rotation);
            info.AddValue("Scale", text.Scale);
            info.AddValue("Style", text.Style);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var text = new Text
            {
                CharacterSize = info.GetUInt32("CharacterSize"),
                DisplayedString = info.GetString("DisplayedString"),
                FillColor = (Color)info.GetValue("FillColor", typeof(Color)),
                Font = (Font)info.GetValue("Font", typeof(Font)),
                LetterSpacing = info.GetSingle("LetterSpacing"),
                LineSpacing = info.GetSingle("LineSpacing"),
                Origin = (Vector2f)info.GetValue("Origin", typeof(Vector2f)),
                OutlineColor = (Color)info.GetValue("OutlineColor", typeof(Color)),
                OutlineThickness = info.GetSingle("OutlineThickness"),
                Position = (Vector2f)info.GetValue("Position", typeof(Vector2f)),
                Rotation = info.GetSingle("Rotation"),
                Scale = (Vector2f)info.GetValue("Scale", typeof(Vector2f)),
                Style = (Styles)info.GetValue("Style", typeof(Styles))
            };
            return text;
        }
    }
}
