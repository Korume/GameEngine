using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SceneModule
{
    public interface IScene : Drawable
    {
        void Load();
        void TogglePause();

        void Update();
    }
}
