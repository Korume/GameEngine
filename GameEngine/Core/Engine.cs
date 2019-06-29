using GameEngine.DependencyInjection;
using GameEngine.GameObjects.Entities;
using GameEngine.Interfaces.Core;
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
    public class Engine : IEngine
    {
        private IWindowManager _windowManager;
        private ISceneManager _sceneManager;

        private RenderWindow MainWindow { get => _windowManager.GetGameWindow().MainWindow; }

        public Engine(IWindowManager windowManager, ISceneManager sceneManager)
        {
            _windowManager = windowManager;
            _sceneManager = sceneManager;
        }

        public void StartMainCycle()
        {
            //_sceneManager.AddSceneToStorage("MainMenu");

            _sceneManager.AddSceneToStorage(new Scene());
            _sceneManager.SaveSceneToFile("MainMenu");

            //var textBox = new DynamicEntity();
            //textBox.Figures.Add(new TextBox());
            //new DataAccess.Binary.BinaryBaseEntityProvider().Save(textBox);

            (_sceneManager as SceneManager).AddHandlers(MainWindow); // to do переделать этот метод

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