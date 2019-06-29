using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.StateSystem
{
    public class Transition
    {
        public State CurrentState { get; set; }
        public State NextState { get; set; }
    }
}
