using GameEngine.GameObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.DataAccess
{
    public interface IBaseEntityProvider
    {
        BaseEntity Get(string sceneName);
        BaseEntity Save(BaseEntity scene);
    }
}
