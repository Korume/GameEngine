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
    public class Drawer : IDrawer
    {
        private IWindowManager _windowManager;

        private RenderWindow MainWindow { get => _windowManager.GetGameWindow().MainWindow; }

        public Drawer(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void Draw(Drawable drawableObject)
        {
            MainWindow.Draw(drawableObject);
        }

        public void Draw(IList<Drawable> drawableObjectList)
        {
            foreach (var drawableObject in drawableObjectList)
            {
                MainWindow.Draw(drawableObject);
            }
        }
    }
}
