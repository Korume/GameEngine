using GameEngine.GameObjects.Entities;
using GameEngine.GameObjects.Events;
using GameEngine.Graphics;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.Graphics;
using GameEngine.Interfaces.Phisics;
using GameEngine.Interfaces.Storages;
using GameEngine.Physics;
using GameEngine.SceneProvider;
using GameEngine.Storages;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Core
{
    public class SceneManager : ISceneManager
    {
        private ISceneProvider _sceneProvider;
        private ISceneStorage _sceneStorage;
        private IDrawer _drawer;
        private IUpdater _updater;

        private IList<Scene> Scenes { get => _sceneStorage.GetScenes(); }

        public SceneManager(ISceneProvider sceneProvider, ISceneStorage sceneStorage,
            IUpdater updater, IDrawer drawer)
        {
            _sceneProvider = sceneProvider;
            _sceneStorage = sceneStorage;
            _updater = updater;
            _drawer = drawer;
        }

        public Scene GetSceneFromStorage(string sceneName)
        {
            return _sceneStorage.GetScene(sceneName);
        }

        public void AddSceneToStorage(string sceneName)
        {
            var scene = GetSceneFromFile(sceneName);
            _sceneStorage.AddScene(scene);
        }

        public void AddSceneToStorage(Scene scene)
        {
            _sceneStorage.AddScene(scene);
        }

        public void RemoveSceneFromStorage(string sceneName)
        {
            _sceneStorage.RemoveScene(sceneName);
        }

        public Scene SaveSceneToFile(string sceneName)
        {
            var scene = Scenes.SingleOrDefault(s => s.Name == sceneName);

            return _sceneProvider.Save(scene);
        }

        public Scene GetSceneFromFile(string sceneName)
        {
            return _sceneProvider.Get(sceneName);
        }

        public void UpdateScenes()
        {
            foreach (var scene in Scenes)
            {
                foreach (var chunk in scene.Chunks)
                {
                    foreach (var entity in chunk.Entities)
                    {
                        _updater.Update(entity);
                    }
                }
            }
        }

        public void DrawScenes()
        {
            foreach (var scene in Scenes)
            {
                foreach (var chunk in scene.Chunks)
                {
                    foreach (var entity in chunk.Entities)
                    {
                        _drawer.Draw(entity);
                    }
                }
            }
        }

        public void AddHandlers(RenderWindow mainWindow)
        {
            foreach (var scene in Scenes)
            {
                foreach (var chunk in scene.Chunks)
                {
                    foreach (var entity in chunk.Entities)
                    {
                        //if(entity.GetEventState(EventType.MouseButtonPressed))
                        //    mainWindow.MouseButtonPressed += entity.OnMouseButtonPressed;

                        //if (entity.GetEventState(EventType.KeyPressed))
                        //    mainWindow.KeyPressed += entity.OnKeyPressed;

                        //if (entity.GetEventState(EventType.TextEntered))
                        //    mainWindow.TextEntered += entity.OnTextEntered;

                        //entity.EventStateSwitched += OnEventStateSwitched;
                    }
                }
            }
        }

        public void OnEventStateSwitched(object sender, EventStateSwitchedEventArgs e)
        {
            if (e.EventType == EventType.TextEntered)
                //mainWindow.MouseButtonPressed += entity.OnMouseButtonPressed;

            Console.WriteLine(sender.GetType());
        }
    }
}
