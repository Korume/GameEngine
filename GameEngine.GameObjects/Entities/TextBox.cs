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
    [Serializable]
    public class TextBox : DynamicEntity
    {
        public TextBox() : base()
        {
            Drawable rectangle = new RectangleShape
            {
                Size = new Vector2f(100, 40),
                Position = new Vector2f(2, 2),
                FillColor = Color.Transparent,
                OutlineColor = Color.Red,
                OutlineThickness = 2
            };
            Drawable text = new Text
            {
                FillColor = Color.Blue,
                Font = new Font("COMIC.TTF")
            };
            AddFigure(rectangle);
            AddFigure(text);


            SetEventState(EventType.TextEntered, true);
            SetEventState(EventType.MouseButtonPressed, true);
        }

        public override void Update()
        {
        }

        public override void OnTextEntered(object sender, TextEventArgs e)
        {
            const int backspaceCode = 8;

            var text = (Text)Figures[1]; // убрать этот костыль

            if (char.ConvertToUtf32(e.Unicode, 0) == backspaceCode)
            {
                if(text.DisplayedString.Count() > 0)
                    text.DisplayedString = text.DisplayedString.Remove(text.DisplayedString.Count() - 1, 1);
            }
            else
                text.DisplayedString += e.Unicode;
        }

        public override void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            var rectangle = (RectangleShape)Figures[0];
            
            if (e.X >= rectangle.GetPoint(0).X && e.Y >= rectangle.GetPoint(0).Y &&
                e.X <= rectangle.GetPoint(2).X && e.Y <= rectangle.GetPoint(2).Y)
            {
                throw new NotImplementedException();
            }
        }
    }
}
