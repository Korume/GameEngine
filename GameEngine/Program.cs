﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using GameEngine.DependencyInjection;
using Unity;
using GameEngine.Core;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = UnityConfig.Container.Resolve<Engine>();

            engine.StartMainCycle();
        }
    }
}
