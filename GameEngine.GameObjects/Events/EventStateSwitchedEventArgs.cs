using GameEngine.GameObjects.Entities;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.Events
{
    public class EventStateSwitchedEventArgs : EventArgs
    {
        public BaseEntity Entity { get; }
        public bool EventState { get; }
        public EventType EventType { get; }

        public EventStateSwitchedEventArgs(BaseEntity entity, bool eventState, EventType eventType)
        {
            Entity = entity;
            EventState = eventState;
            EventType = eventType;
        }
    }
}
