using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.SceneManagement.Entities
{
    public class StaticEntity : BaseEntity
    {
        public StaticEntity() : base()
        {
        }

        public override void OnMouseKeyPressed(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {

        }
    }
}
