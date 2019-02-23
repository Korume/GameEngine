using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects.Entities
{
    [Serializable]
    public class Chunk
    {
        public List<BaseEntity> Entities { get; set; }

        public Chunk()
        {
            Entities = new List<BaseEntity>();

            var entity = new DynamicEntity();
            entity.AddFigure(new CircleShape(80));
            entity.AddFigure(new RectangleShape(new SFML.System.Vector2f(200, 10)));

            Entities.Add(entity);
        }
    }
}
