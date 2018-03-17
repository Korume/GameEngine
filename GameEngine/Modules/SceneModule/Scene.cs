using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GameEngine.Modules.SceneModule
{
    public class Scene : IScene
    {
        private List<World> _worlds;

        private bool IsPause;

        public Scene()
        {
            //Load();
            _worlds = new List<World>(2);
            _worlds.Add(new World());

            IsPause = false;
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var world in _worlds)
            {
                target.Draw(world);
            }
        }

        public void Update()
        {
            foreach (var world in _worlds)
            {
                world.Update();
            }
        }

        public void TogglePause()
        {
            IsPause = !IsPause;
        }
    }
}
