using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Graphics
{
    public interface IDrawer
    {
        void Draw(Drawable drawableObject);
        void Draw(IList<Drawable> drawableObjectList);
    }
}
