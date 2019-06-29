using GameEngine.GameObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.StateSystem
{
    public class Reaction
    {
        public Event Event { get; set; }
        public BaseEntity Entity { get; set; }
        public Action<BaseEntity> Action { get; set; }
    }
}
