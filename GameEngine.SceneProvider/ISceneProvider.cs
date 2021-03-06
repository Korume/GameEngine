﻿using GameEngine.GameObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneProvider
{
    public interface ISceneProvider
    {
        Scene Get(string sceneName);
        Scene Save(Scene scene);
    }
}
