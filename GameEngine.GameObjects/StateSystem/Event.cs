using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.StateSystem
{
    public class Event
    {
        public string Name { get; set; }
        public Transition Transition { get; set; }
    }
}
