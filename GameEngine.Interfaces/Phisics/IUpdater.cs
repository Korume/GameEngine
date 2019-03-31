using GameEngine.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Phisics
{
    public interface IUpdater
    {
        void Update(IUpdatable updatableObject);
        void Update(IList<IUpdatable> updatableObjectList);
    }
}
