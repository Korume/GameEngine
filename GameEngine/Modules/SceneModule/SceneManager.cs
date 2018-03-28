using GameEngine.Business.Managers;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Modules.SceneModule
{
    public class SceneManager
    {
        private RenderWindow _mainWindow;
        private List<IScene> _scenes;

        public SceneManager(WindowManager windowManager)
        {
            _mainWindow = windowManager.GetGameWindow().MainWindow;
            _scenes = new List<IScene>();
        }

        public void AddScene(IScene scene)
        { 
            _scenes.Add(scene);
        }

        public void AddScene(string sceneName)
        {

        }

        public void RemoveScene(string sceneName)
        {
            foreach (var scene in _scenes)
            {
                if((scene as Scene).Name == sceneName)
                {
                    _scenes.Remove(scene);
                }
            }
        }

        public void Update()
        {
            foreach (var scene in _scenes)
            {
                scene.Update();
            }
        }

        public void Draw()
        {
            foreach (var scene in _scenes)
            {
                _mainWindow.Draw(scene);
            }
        }
    }
}
