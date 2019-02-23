using GameEngine.DependencyInjection;
using GameEngine.SceneManagement.Entities;
using GameEngine.SceneManagement.Services;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GameEngine.Core
{
    public class Engine
    {
        private WindowManager _windowManager;
        private SceneManager _sceneManager;

        private RenderWindow MainWindow { get => _windowManager.GetGameWindow().MainWindow; }

        public Engine(WindowManager windowManager, SceneManager sceneManager)
        {
            _windowManager = windowManager;
            _sceneManager = sceneManager;
        }

        public void StartMainCycle()
        {
            _sceneManager.AddSceneToStorage(new Scene());
            _sceneManager.AddHandlers(MainWindow);

            while (MainWindow.IsOpen)
            {
                MainWindow.DispatchEvents();

                Update();

                Draw();

                MainWindow.Display();
            }
        }

        private void Update()
        {
            _sceneManager.UpdateScenes();
        }

        private void Draw()
        {
            MainWindow.Clear(Color.Black);
            _sceneManager.DrawScenes();
        }
    }
}