using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.GameObjects.Entities
{
    [Serializable]
    public class DynamicEntity : BaseEntity
    {
        public DynamicEntity() : base()
        {
            Name = "TestDynamicEntity";
        }
    }
}
