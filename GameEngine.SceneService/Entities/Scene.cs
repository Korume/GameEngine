using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.SceneService.Interfaces;
using SFML.Graphics;

namespace GameEngine.SceneService.Entities
{
    public class Scene : IScene
    {
        public IList<Chunk> Chunks { get; set; }

        public string Name { get; set; }
        public bool IsPause { get; set; }
        public int RenderPriority { get; set; }

        public Scene()
        {
            //Load();
            Chunks = new List<Chunk>();
            Chunks.Add(new Chunk());

            Name = "MainMenu";

            IsPause = false;
        }

        public void TogglePause() => IsPause = !IsPause;
    }
}
