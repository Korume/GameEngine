using GameEngine.Business.Managers;
using GameEngine.DependencyInjection;
using GameEngine.Modules.SceneModule;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameEngine
{
    public class Engine
    {
        private WindowManager _windowManager;
        private SceneManager _sceneManager;

        public Engine(WindowManager windowManager, SceneManager sceneManager)
        {
            _windowManager = windowManager;
            _sceneManager = sceneManager;
        }

        public void StartMainCycle()
        {
            var window = _windowManager.GetGameWindow().MainWindow;
            _sceneManager.AddScene(new Scene());

            while (window.IsOpen)
            {
                window.DispatchEvents();

                _sceneManager.Update();
                window.Clear(Color.Black);
                _sceneManager.Draw();
                window.Display();
            }
        }
    }
}