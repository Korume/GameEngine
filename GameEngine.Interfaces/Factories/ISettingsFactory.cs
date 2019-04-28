using GameEngine.GameObjects.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Factories
{
    public interface ISettingsFactory
    {
        Settings CreateDefault();
    }
}
