using GameEngine.GameObjects.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Storages
{
    public class SceneStorage
    {
        private static HashSet<Scene> _hashSet;

        public SceneStorage()
        {
            if (_hashSet == null)
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
