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
    public class Updater : IUpdater
    {
        public readonly object _stateMachine;

        public Updater(object stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Update(BaseEntity updatableObject)
        {
            throw new NotImplementedException();

            //_stateMachine.ReactToEvents(updatableObject);
            //_stateMachine.CheckNewEvents(updatableObject);
        }

        public void Update(IList<BaseEntity> updatableObjectList)
        {
            throw new NotImplementedException();
        }
    }
}
