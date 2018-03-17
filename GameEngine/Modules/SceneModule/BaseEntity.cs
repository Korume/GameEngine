using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SceneModule
{
    public abstract class BaseEntity : Transformable, Drawable
    {
        private Drawable _figure;

        public BaseEntity(Drawable figure)
        {
            _figure = figure;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(_figure, states);
        }

        /*
         * Что делать при каждом из событий
         * OnClick
         * OnKeyPressed
         * OnDragAndDrop
         */
    }
}
