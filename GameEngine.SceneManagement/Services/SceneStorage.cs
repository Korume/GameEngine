using GameEngine.SceneManagement.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneManagement.Services
{
    public class SceneStorage
    {
        private static HashSet<Scene> _hashtable;

        public SceneStorage()
        {
            if (_hashtable == null)
                _hashtable = new HashSet<Scene>();
        }

        public Scene GetScene(string sceneName)
        {
            return _hashtable.SingleOrDefault(s => s.Name == sceneName);
        }

        public void AddScene(Scene scene)
        {
            _hashtable.Add(scene);
        }

        public void RemoveScene(string sceneName)
        {
            _hashtable.RemoveWhere(s => s.Name == sceneName);
        }

        public void RemoveScene(Scene scene)
        {
            _hashtable.Remove(scene);
        }

        public IList<Scene> GetScenes() => _hashtable.ToList();
    }
}
