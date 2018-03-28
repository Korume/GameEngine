using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Business.Entities;
using SFML.Graphics;

namespace GameEngine.Modules.SceneModule
{
    public class Scene : IScene
    {
        public string Name;

        private Dictionary<int, Chunk> _chunks;

        public bool IsPause;

        public Scene()
        {
            //Load();
            _chunks = new Dictionary<int, Chunk>();
            _chunks.Add(_chunks.LastOrDefault().Key + 1, new Chunk());

            Name = "MainMenu";

            IsPause = false;
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var chunk in _chunks.Values)
            {
                target.Draw(chunk);
            }
        }

        public void Update()
        {
            foreach (var chunk in _chunks.Values)
            {
                chunk.Update();
            }
        }

        public void TogglePause() => IsPause = !IsPause;
    }
}
