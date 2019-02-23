using GameEngine.GameObjects.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Physics
{
    public class SceneUpdater
    {
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
