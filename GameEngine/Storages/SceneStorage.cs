using GameEngine.GameObjects.Entities;
using GameEngine.Interfaces.Storages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Storages
{
    public class SceneStorage : ISceneStorage
    {
        private HashSet<Scene> _hashSet;

        public SceneStorage()
        {
            _hashSet = new HashSet<Scene>();
        }

        public Scene GetScene(string sceneName)
        {
            return _hashSet.SingleOrDefault(s => s.Name == sceneName);
        }

        public void AddScene(Scene scene)
        {
            _hashSet.Add(scene);
        }

        public void RemoveScene(string sceneName)
        {
            _hashSet.RemoveWhere(s => s.Name == sceneName);
        }

        public void RemoveScene(Scene scene)
        {
            _hashSet.Remove(scene);
        }

        public IList<Scene> GetScenes() => _hashSet.ToList();
    }
}
