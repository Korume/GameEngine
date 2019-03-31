using GameEngine.GameObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Core
{
    public interface ISceneManager
    {
        Scene GetSceneFromStorage(string sceneName);

        void AddSceneToStorage(string sceneName);

        void AddSceneToStorage(Scene scene);

        void RemoveSceneFromStorage(string sceneName);

        Scene SaveSceneToFile(string sceneName);

        Scene GetSceneFromFile(string sceneName);

        void UpdateScenes();

        void DrawScenes();
    }
}
