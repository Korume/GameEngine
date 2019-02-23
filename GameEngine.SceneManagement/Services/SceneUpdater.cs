﻿using GameEngine.SceneManagement.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneManagement.Services
{
    public class SceneUpdater
    {
        public SceneUpdater()
        {
        }

        public void Update(Scene scene)
        {
            foreach (var chunk in scene.Chunks)
            {
                foreach (var entity in chunk.Entities)
                {
                    entity.Update();
                }
            }
        }
    }
}
