using GameEngine.GameObjects;
using GameEngine.GameObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Phisics
{
    public interface IUpdater
    {
        void Update(BaseEntity updatableObject);
        void Update(IList<BaseEntity> updatableObjectList);
    }
}
