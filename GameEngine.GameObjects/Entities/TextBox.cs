using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.Entities
{
    public class TextBox : DynamicEntity
    {
        public TextBox() : base()
        {
            Drawable figure = new RectangleShape()
            {
                Size = new Vector2f(100, 40),
                Position = new Vector2f(0, 0)
            };
            AddFigure(figure);
        }

        public override void Update()
        {

        }

        public override void OnMouseKeyPressed(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
