using GameEngine.Business;
using GameEngine.Business.Providers;
using GameEngine.GameProvider.Providers;
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
            .RegisterType<IDataStorage, DataStorage>();
        }
    }
}