using GameEngine.GameObjects.ServiceObjects;
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

            .RegisterType<ISettingsProvider, JsonSettingsProvider>()
            .RegisterType<ISceneProvider, BinarySceneProvider>()
            .RegisterType<IDataStorage, MemoryStorage>();
        }
    }
}