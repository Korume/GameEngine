using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace GameEngine.GameObjects.Entities
{
    [Serializable]
    public class Scene
    {
        public string Name { get; set; }
        public bool IsPause { get; set; }
        public int RenderPriority { get; set; }

        public IList<Chunk> Chunks { get; set; }

        public Scene()
        {
            //Load();
            var chunk = new Chunk();
            chunk.Entities.Add(new TextBox());
            Chunks = new List<Chunk> { chunk };

            Name = "MainMenu";

            IsPause = false;
        }

        public void TogglePause() => IsPause = !IsPause;
    }
}
