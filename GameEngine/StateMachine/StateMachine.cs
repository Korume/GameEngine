using GameEngine.GameObjects.Entities;
using GameEngine.GameObjects.StateSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.StateMachine
{
    public class StateMachine
    {
        private IEnumerable<Reaction> _reactions;

        public void ReactToEvents(BaseEntity entity)
        {
            if(entity.States.First().Name == "TestStateName")
            {
                _reactions.First(r => r.)
            }
        }

        public void CheckNewEvents(BaseEntity entity)
        {

        }

        public Action<BaseEntity> SetupEvent(BaseEntity entity, Event happenedEvent)
        {
            var reaction = new Reaction
            {
                Entity = entity,
                Event = happenedEvent
            };
            _reactions.Append(reaction);
        }
    }
}
