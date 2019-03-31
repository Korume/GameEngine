using GameEngine.GameObjects;
using GameEngine.GameObjects.Entities;
using GameEngine.Interfaces.Phisics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Physics
{
    public class SceneUpdater : IUpdater
    {
        public void Update(IUpdatable updatableObject)
        {
            updatableObject.Update();
        }

        public void Update(IList<IUpdatable> updatableObjectList)
        {
            foreach (var updatableObject in updatableObjectList)
            {
                updatableObject.Update();
            }
        }
    }
}
