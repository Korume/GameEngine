using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace GameEngine.DependencyInjection
{
    public static class UnityRegisterExtentions
    {
        public static IUnityContainer RegisterTypeInSingletoneScope<TInterface, TImplementation>(this IUnityContainer container)
            where TImplementation : TInterface
        {
            return container.RegisterType<TInterface, TImplementation>(new ContainerControlledLifetimeManager());
        }
    }
}