using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using GameEngine.Modules.SettingsModule;
using GameEngine.Modules.WindowModule;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine(new JsonSettingsManager());

            engine.StartMainCycle();
        }
    }
}
