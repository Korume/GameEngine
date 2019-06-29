using GameEngine.GameObjects.StateSystem;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.Entities
{
    [Serializable]
    public abstract class BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Drawable> Figures { get; set; }
        public Stack<State> States { get; set; }

        public BaseEntity()
        {
            Name = "TestBaseEntity";
        }
    }
}
