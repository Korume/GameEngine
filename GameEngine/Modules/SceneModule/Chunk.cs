using GameEngine.Business.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SceneModule
{
    public class Chunk : Transformable, Drawable
    {
        private List<BaseEntity> _entities;

        public Chunk()
        {
            _entities = new List<BaseEntity>(50);
            _entities.Add(new DynamicEntity(new CircleShape(20)));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var entity in _entities)
            {
                target.Draw(entity);
            }
        }

        public void Update()
        {
            foreach (var entity in _entities)
            {
                var castedEntity = entity as DynamicEntity;
                if (castedEntity != null)
                {
                    castedEntity.Update();
                }
            }
        }
    }
}
