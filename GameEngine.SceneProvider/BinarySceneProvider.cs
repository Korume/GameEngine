using GameEngine.SceneManagement.Serialization.Surrogates;
using GameEngine.SceneManagement.Entities;
using GameEngine.SceneManagement.Interfaces;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneProvider
{
    public class BinarySceneProvider : ISceneProvider
    {
        public Scene Get(string sceneName)
        {
            using (var fileInfo = new FileStream($"{sceneName}.sc", FileMode.Open))
            {
                var formatter = new BinaryFormatter();

                formatter.SurrogateSelector = GetSurrogateSelector();

                return (Scene)formatter.Deserialize(fileInfo);
            }
        }

        public Scene Save(Scene entity)
        {
            using (var fileInfo = new FileStream($"{entity.Name}.sc", FileMode.Create))
            {
                // ToDo сделать проверку возможности перезаписи

                var formatter = new BinaryFormatter();

                formatter.SurrogateSelector = GetSurrogateSelector();

                formatter.Serialize(fileInfo, entity);
            }

            return entity;
        }

        private SurrogateSelector GetSurrogateSelector()
        {
            var surrogateSelector = new SurrogateSelector();
            surrogateSelector.AddSurrogate(typeof(CircleShape), new StreamingContext(StreamingContextStates.All),
                                           new CircleShapeSurrogate());
            surrogateSelector.AddSurrogate(typeof(Transformable), new StreamingContext(StreamingContextStates.All),
                                           new TransformableSurrogate());
            surrogateSelector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All),
                                           new ColorSurrogate());
            surrogateSelector.AddSurrogate(typeof(Vector2f), new StreamingContext(StreamingContextStates.All),
                                           new Vector2fSurrogate());
            surrogateSelector.AddSurrogate(typeof(IntRect), new StreamingContext(StreamingContextStates.All),
                                           new IntRectSurrogate());
            surrogateSelector.AddSurrogate(typeof(RectangleShape), new StreamingContext(StreamingContextStates.All),
                                           new RectangleShapeSurrogate());
            return surrogateSelector;
        }
    }
}
