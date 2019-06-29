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
            Name = "TextBoxEntity";

            //SetEventState(EventType.TextEntered, true);
            //SetEventState(EventType.MouseButtonPressed, true);
        }

        //public override void OnTextEntered(object sender, TextEventArgs e)
        //{
        //    const int backspaceCode = 8;

        //    var text = Figures.Single(d => d is Text) as Text; // убрать этот костыль

        //    if (char.ConvertToUtf32(e.Unicode, 0) == backspaceCode)
        //    {
        //        if(text.DisplayedString.Count() > 0)
        //            text.DisplayedString = text.DisplayedString.Remove(text.DisplayedString.Count() - 1, 1);
        //    }
        //    else
        //        text.DisplayedString += e.Unicode;
        //}

        //public override void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        //{
        //    base.OnMouseButtonPressed(sender, e);

        //    //var rectangle = (RectangleShape)Figures[0];
            
        //    //if (e.X >= rectangle.GetPoint(0).X && e.Y >= rectangle.GetPoint(0).Y &&
        //    //    e.X <= rectangle.GetPoint(2).X && e.Y <= rectangle.GetPoint(2).Y)
        //    //{
        //    //    throw new NotImplementedException();
        //    //}
        //}
    }
}
