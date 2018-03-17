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
        private RenderWindow _renderTarget;
        private IScene _currentScene;

        public SceneManager(IScene scene, RenderWindow renderTarget)
        {
            _currentScene = scene;
            _renderTarget = renderTarget;
        }

        public void Update() => _currentScene.Update();

        public void Draw() => _renderTarget.Draw(_currentScene);
    }
}
