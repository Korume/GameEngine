using GameEngine.GameObjects.Entities;
using GameEngine.Interfaces.Core;
using GameEngine.Interfaces.Graphics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics
{
    public class SceneDrawer : IDrawer
    {
        private IWindowManager _windowManager;

        private RenderWindow _mainWindow { get => _windowManager.GetGameWindow().MainWindow; }

        public SceneDrawer(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void Draw(Drawable drawableObject)
        {
            _mainWindow.Draw(drawableObject);
        }

        public void Draw(IList<Drawable> drawableObjectList)
        {
            foreach (var drawableObject in drawableObjectList)
            {
                _mainWindow.Draw(drawableObject);
            }
        }
    }
}
