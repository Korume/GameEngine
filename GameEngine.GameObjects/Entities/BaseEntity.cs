using GameEngine.GameObjects.Events;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
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
    public abstract class BaseEntity : Drawable, IUpdatable
    {
        public IList<Drawable> Figures { private set; get; }
        protected Transformable _transformable;

        public event EventHandler<EventStateSwitchedEventArgs> EventStateSwitched;

        protected IDictionary<EventType, bool> EventStateDictionary = new Dictionary<EventType, bool>
        {
            { EventType.KeyPressed, false },
            { EventType.MouseButtonPressed, false },
            { EventType.TextEntered, false }
        };        

        public BaseEntity()
        {
            Figures = new List<Drawable>();
            _transformable = new Transformable();
        }

        protected void OnEventStateSwitched(EventStateSwitchedEventArgs e)
        {
            Volatile.Read(ref EventStateSwitched)?.Invoke(this, e);
        }

        public bool GetEventState(EventType eventType) => EventStateDictionary[eventType];

        protected void SetEventState(EventType eventType, bool eventState)
        {
            if (EventStateDictionary[eventType] != eventState)
            {
                EventStateDictionary[eventType] = eventState;

                var e = new EventStateSwitchedEventArgs(this, EventStateDictionary[eventType], eventType);

                OnEventStateSwitched(e);
            }
        }

        public BaseEntity AddFigure(Drawable figure)
        {
            Figures.Add(figure);
            return this;
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= _transformable.Transform;
            foreach (var figure in Figures)
            {
                target.Draw(figure, states);
            }
        }

        public abstract void Update();

        public abstract void OnMouseButtonPressed(object sender, MouseButtonEventArgs e);

        public abstract void OnKeyPressed(object sender, KeyEventArgs e);

        public abstract void OnTextEntered(object sender, TextEventArgs e);
    }
}
