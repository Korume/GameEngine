using GameEngine.Core;
using GameEngine.DataAccess.Binary;
using GameEngine.DataAccess.Binary.Serialization.Surrogates;
using GameEngine.DataAccess.Json;
using GameEngine.Factories;
using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Graphics;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.DataAccess;
using GameEngine.Interfaces.Factories;
using GameEngine.Interfaces.Graphics;
using GameEngine.Interfaces.Phisics;
using GameEngine.Interfaces.Storages;
using GameEngine.Physics;
using GameEngine.Storages;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace GameEngine.DependencyInjection
{
    public static class UnityRegistrations
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterSingleton<IEngine, Engine>();
            container.RegisterSingleton<ISettingsManager, SettingsManager>();
            container.RegisterSingleton<IWindowManager, WindowManager>();
            container.RegisterSingleton<ISceneManager, SceneManager>();
            container.RegisterSingleton<ISettingsProvider, JsonSettingsProvider>();
            container.RegisterSingleton<ISceneProvider, BinarySceneProvider>();
            container.RegisterSingleton<IBaseEntityProvider, BinaryBaseEntityProvider>();
            container.RegisterSingleton<IDataStorage, MemoryStorage>();
            container.RegisterSingleton<ISceneStorage, SceneStorage>();
            container.RegisterSingleton<IDrawer, Drawer>();
            container.RegisterSingleton<IUpdater, Updater>();
            container.RegisterSingleton<ISettingsFactory, SettingsFactory>();
            container.RegisterInstance<StreamingContext>(new StreamingContext());
            container.RegisterFactory<ISurrogateSelector>(c =>
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
                var streamingContext = c.Resolve<StreamingContext>();
                foreach (var surrogate in serializationSurrogates)
                {
                    surrogateSelector.AddSurrogate(surrogate.Key, streamingContext, surrogate.Value);
                }
                return surrogateSelector;
            });
        }
    }
}