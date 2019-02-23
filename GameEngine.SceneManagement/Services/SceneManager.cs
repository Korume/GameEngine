using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.SceneManagement.Interfaces;
using GameEngine.SceneManagement.Entities;

namespace GameEngine.SceneManagement.Services
{
    public class SceneManager
    {
        private ISceneProvider _sceneProvider;
        private SceneStorage _sceneStorage;
        private SceneDrawer _sceneDrawer;
        private SceneUpdater _sceneUpdater;

        private IList<Scene> Scenes { get => _sceneStorage.GetScenes(); }

        public SceneManager(ISceneProvider sceneProvider, SceneStorage sceneStorage,
            SceneDrawer sceneDrawer, SceneUpdater sceneUpdater)
        {
            _sceneProvider = sceneProvider;
            _sceneStorage = sceneStorage;
            _sceneDrawer = sceneDrawer;
            _sceneUpdater = sceneUpdater;
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
                _sceneUpdater.Update(scene);
            }
        }

        public void DrawScenes()
        {
            foreach (var scene in Scenes)
            {
                _sceneDrawer.Draw(scene);
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
                        mainWindow.MouseButtonPressed += entity.OnMouseKeyPressed;
                    }
                }
            }
        }
    }
}
