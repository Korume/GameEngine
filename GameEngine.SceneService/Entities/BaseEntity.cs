using GameEngine.SceneService.Interfaces;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneService.Entities
{
    public abstract class BaseEntity : Transformable, Drawable, IUpdateable
    {
        protected Drawable _figure;

        public BaseEntity(Drawable figure)
        {
            _figure = figure;
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(_figure, states);
        }

        public abstract void Update();

        /*
         * Что делать при каждом из событий
         * OnClick
         * OnKeyPressed
         * OnDragAndDrop
         */
    }
}
