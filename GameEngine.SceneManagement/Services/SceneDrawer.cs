using GameEngine.SceneManagement.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneManagement.Services
{
    public class SceneDrawer
    {
        private RenderWindow _mainWindow;

        public SceneDrawer(WindowManager windowManager)
        {
            _mainWindow = windowManager.GetGameWindow().MainWindow;
        }

        public void Draw(Scene scene)
        {
            foreach (var chunk in scene.Chunks)
            {
                foreach (var entity in chunk.Entities)
                {
                    _mainWindow.Draw(entity);
                }
            }
        }

        public void Draw(IList<Scene> scenes)
        {
            foreach (var scene in scenes)
            {
                Draw(scene);
            }
        }
    }
}
