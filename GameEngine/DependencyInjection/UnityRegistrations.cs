using GameEngine.Business;
using GameEngine.Business.Entities;
using GameEngine.Business.Providers;
using GameEngine.SceneManagement.Entities;
using GameEngine.SceneManagement.Interfaces;
using GameEngine.SceneProvider;
using GameEngine.SettingsProvider;
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

            .RegisterType<IProvider<Settings>, JsonSettingsProvider>()
            .RegisterType<ISceneProvider, BinarySceneProvider>()
            .RegisterType<IDataStorage, MemoryStorage>();
        }
    }
}