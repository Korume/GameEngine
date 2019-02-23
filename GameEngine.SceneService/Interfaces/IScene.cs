using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.SceneService.Interfaces
{
    public interface IScene
    {
        string Name { get; set; }
        bool IsPause { get; set; }
        int RenderPriority { get; set; }
    }
}
