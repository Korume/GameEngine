using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.GameObjects.Entities
{
    [Serializable]
    public class DynamicEntity : BaseEntity
    {
        public DynamicEntity() : base()
        {
        }

        public override void OnKeyPressed(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnTextEntered(object sender, TextEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
        }
    }
}
