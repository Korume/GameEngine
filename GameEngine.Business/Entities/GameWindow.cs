﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Business.Entities
{
    public class GameWindow
    {
        public RenderWindow MainWindow { get; set; }
        public View MainView { get; set; }
    }
}
