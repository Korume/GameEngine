using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GameEngine.SceneService.Entities
{
    public class StaticEntity : BaseEntity
    {
        public StaticEntity(Drawable figure) : base(figure)
        {
        }

        public override void Update()
        {

        }
    }
}
