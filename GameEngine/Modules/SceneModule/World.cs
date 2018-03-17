using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SceneModule
{
    public class World : Transformable, Drawable
    {
        private List<Chunk> _chunks;

        public World()
        {
            _chunks = new List<Chunk>(20);
            _chunks.Add(new Chunk());
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var chunk in _chunks)
            {
                target.Draw(chunk);
            }
        }

        public void Update()
        {
            foreach (var chunk in _chunks)
            {
                chunk.Update();
            }
        }
    }
}
