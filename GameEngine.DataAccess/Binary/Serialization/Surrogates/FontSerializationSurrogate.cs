using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.DataAccess.Binary.Serialization.Surrogates
{
    public class FontSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var font = (Font)obj;
            info.AddValue("FileName", ConfigurationManager.AppSettings[font.GetInfo().Family]);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var font = new Font(info.GetString("FileName"));
            return font;
        }
    }
}
