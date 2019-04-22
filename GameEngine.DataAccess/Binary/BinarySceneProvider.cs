using GameEngine.DataAccess.Binary.Serialization.Surrogates;
using GameEngine.GameObjects.Entities;
using GameEngine.Interfaces.DataAccess;
using GameEngine.SceneProvider.Serialization.Surrogates;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.DataAccess.Binary
{
    public class BinarySceneProvider : ISceneProvider
    {
        public Scene Get(string sceneName)
        {
            using (var fileInfo = new FileStream($"{sceneName}.sc", FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                formatter.SurrogateSelector = GetSurrogateSelector(formatter.Context);

                return (Scene)formatter.Deserialize(fileInfo);
            }
        }

        public Scene Save(Scene entity)
        {
            using (var fileInfo = new FileStream($"{entity.Name}.sc", FileMode.Create))
            {
                // ToDo сделать проверку возможности перезаписи

                var formatter = new BinaryFormatter();
                formatter.SurrogateSelector = GetSurrogateSelector(formatter.Context);

                formatter.Serialize(fileInfo, entity);
            }

            return entity;
        }

        private SurrogateSelector GetSurrogateSelector(StreamingContext streamingContext)
        {
            var serializationSurrogates = new Dictionary<Type, ISerializationSurrogate>
            {
                { typeof(CircleShape), new DefaultSerializationSurrogate<CircleShape>()},
                { typeof(Transformable), new DefaultSerializationSurrogate<Transformable>() },
                { typeof(Color), new DefaultSerializationSurrogate<Color>() },
                { typeof(Vector2f), new DefaultSerializationSurrogate<Vector2f>() },
                { typeof(IntRect), new DefaultSerializationSurrogate<IntRect>() },
                { typeof(RectangleShape), new DefaultSerializationSurrogate<RectangleShape>() },
                { typeof(Text), new DefaultSerializationSurrogate<Text>() },
                { typeof(Texture), new DefaultSerializationSurrogate<Texture>() },
                { typeof(Font), new FontSerializationSurrogate() }
            };

            var surrogateSelector = new SurrogateSelector();
            foreach (var surrogate in serializationSurrogates)
            {
                surrogateSelector.AddSurrogate(surrogate.Key, streamingContext, surrogate.Value);
            }
            return surrogateSelector;
        }
    }
}
