using GameEngine.Core;
using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Graphics;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.Graphics;
using GameEngine.Interfaces.Phisics;
using GameEngine.Interfaces.Storages;
using GameEngine.Physics;
using GameEngine.SceneProvider;
using GameEngine.SettingsProvider;
using GameEngine.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameEngine.DependencyInjection
{
    public static class UnityRegistrations
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container

            .RegisterSingleton<IEngine, Engine>()
            .RegisterSingleton<ISettingsManager, SettingsManager>()
            .RegisterSingleton<IWindowManager, WindowManager>()
            .RegisterSingleton<ISceneManager, SceneManager>()
            .RegisterSingleton<ISettingsProvider, JsonSettingsProvider>()
            .RegisterSingleton<ISceneProvider, BinarySceneProvider>()
            .RegisterSingleton<IDataStorage, MemoryStorage>()
            .RegisterSingleton<ISceneStorage, SceneStorage>()
            .RegisterSingleton<IDrawer, SceneDrawer>()
            .RegisterSingleton<IUpdater, SceneUpdater>();
        }
    }
}