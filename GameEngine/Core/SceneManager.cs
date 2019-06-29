using GameEngine.GameObjects.Entities;
using GameEngine.GameObjects.Events;
using GameEngine.Graphics;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.DataAccess;
using GameEngine.Interfaces.Graphics;
using GameEngine.Interfaces.Phisics;
using GameEngine.Interfaces.Storages;
using GameEngine.Physics;
using GameEngine.Storages;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity;

namespace GameEngine.Core
{
    public class SceneManager : ISceneManager
    {
        private readonly ISceneProvider _sceneProvider;
        private readonly ISceneStorage _sceneStorage;
        private readonly IDrawer _drawer;
        private readonly IUpdater _updater;

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
                foreach (var entity in scene.Entities)
                {
                    _updater.Update(entity);
                }
            }
        }

        public void DrawScenes()
        {
            foreach (var scene in Scenes)
            {
                foreach (var entity in scene.Entities)
                {
                    foreach (var figure in entity.Figures)
                    {
                        _drawer.Draw(figure);
                    }
                }
            }
        }

        public void AddHandlers(RenderWindow mainWindow)
        {
            //foreach (var scene in Scenes)
            //{
            //    foreach (var entity in scene.Entities)
            //    {
            //        if (entity.GetEventState(EventType.MouseButtonPressed))
            //            mainWindow.MouseButtonPressed += OnMouseButtonPressed;

            //        if (entity.GetEventState(EventType.KeyPressed))
            //            mainWindow.KeyPressed += entity.OnKeyPressed;

            //        if (entity.GetEventState(EventType.TextEntered))
            //            mainWindow.TextEntered += entity.OnTextEntered;

            //        entity.EventStateSwitched += OnEventStateSwitched;
            //    }
            //}
            mainWindow.MouseButtonPressed += OnMouseButtonPressed;
        }

        public void OnEventStateSwitched(object sender, EventStateSwitchedEventArgs e)
        {
            if (e.EventType == EventType.TextEntered)
                //mainWindow.MouseButtonPressed += entity.OnMouseButtonPressed;

                Console.WriteLine(sender.GetType());
        }

        public void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            foreach (var scene in Scenes)
            {
                foreach (var entity in scene.Entities)
                {
                    foreach (var figure in entity.Figures)
                    {
                        if (figure is RectangleShape rectangleShape && rectangleShape.GetLocalBounds().Contains(e.X, e.Y))
                        {
                            // Костыль, это не тут должно быть
                            DependencyInjection.UnityConfig.Container.Resolve<IBaseEntityProvider>().Save(entity);
                            break;
                        }
                    }
                }
            }
        }
    }
}
