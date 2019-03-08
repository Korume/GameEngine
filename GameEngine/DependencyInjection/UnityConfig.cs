using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameEngine.DependencyInjection
{
    public static class UnityConfig
    {
        private static readonly IUnityContainer _container = new UnityContainer();

        static UnityConfig()
        {
            UnityRegistrations.RegisterTypes(_container);
        }

        public static IUnityContainer Container { get => _container; }
    }
}