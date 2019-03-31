using GameEngine.GameObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Storages
{
    public interface ISceneStorage
    {
        Scene GetScene(string sceneName);
        void AddScene(Scene scene);
        void RemoveScene(string sceneName);
        void RemoveScene(Scene scene);
        IList<Scene> GetScenes();
    }
}
