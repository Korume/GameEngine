using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.Entities

{
    [Serializable]
    public abstract class BaseEntity : Drawable, IUpdateable
    {
        public IList<Drawable> Figures { private set; get; }
        public IList<Action> OnEventMethods { private set; get; }
        protected Transformable _transformable;

        public BaseEntity()
        {
            Figures = new List<Drawable>();
            _transformable = new Transformable();
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

        public abstract void OnMouseKeyPressed(object sender, MouseButtonEventArgs e);

        /*
         * Что делать при каждом из событий
         * OnClick
         * OnKeyPressed
         * OnDragAndDrop
         */
    }
}
