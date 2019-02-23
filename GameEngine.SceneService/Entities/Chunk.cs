using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneService.Entities
{
    public class Chunk : Transformable
    {
        public List<BaseEntity> Entities { get; set; }

        public Chunk()
        {
            Entities = new List<BaseEntity>();
            Entities.Add(new DynamicEntity(new CircleShape(20)));
        }
    }
}
