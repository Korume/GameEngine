﻿using GameEngine.GameObjects.Entities;
using GameEngine.Interfaces.DataAccess;
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
        private readonly ISurrogateSelector _surrogateSelector;
        private readonly StreamingContext _streamingContext;

        public BinarySceneProvider(ISurrogateSelector surrogateSelector, StreamingContext streamingContext)
        {
            _surrogateSelector = surrogateSelector;
            _streamingContext = streamingContext;
        }

        public Scene Get(string sceneName)
        {
            using (var fileInfo = new FileStream($"{sceneName}.sc", FileMode.Open))
            {
                var formatter = new BinaryFormatter()
                {
                    Context = _streamingContext,
                    SurrogateSelector = _surrogateSelector
                };

                return (Scene)formatter.Deserialize(fileInfo);
            }
        }

        public Scene Save(Scene scene)
        {
            using (var fileInfo = new FileStream($"{scene.Name}.sc", FileMode.Create))
            {
                // ToDo сделать проверку возможности перезаписи

                var formatter = new BinaryFormatter()
                {
                    Context = _streamingContext,
                    SurrogateSelector = _surrogateSelector
                };

                formatter.Serialize(fileInfo, scene);
            }

            return scene;
        }
    }
}
