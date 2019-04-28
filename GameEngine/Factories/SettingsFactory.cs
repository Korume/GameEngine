using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Factories
{
    public class SettingsFactory : ISettingsFactory
    {
        public Settings CreateDefault()
        {
            return new Settings();
        }
    }
}
