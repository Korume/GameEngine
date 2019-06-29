using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace GameEngine.GameObjects.Entities
{
    [Serializable]
    public class Scene
    {
        public string Name { get; set; }
        public IList<BaseEntity> Entities { get; set; }

        public Scene()
        {
            //Load();
            Name = "MainMenu";
            Entities = new List<BaseEntity>
            {
                new DynamicEntity
                {
                    Figures = new List<Drawable>
                    {
                        new CircleShape(80),
                        new RectangleShape(new Vector2f(200, 10))
                    }
                },
                new TextBox
                {
                    Figures = new List<Drawable>
                    {
                        new RectangleShape
                        {
                            Size = new Vector2f(100, 40),
                            Position = new Vector2f(2, 2),
                            FillColor = Color.Transparent,
                            OutlineColor = Color.Red,
                            OutlineThickness = 2
                        },
                        new Text
                        {
                            FillColor = Color.Blue,
                            Font = new Font("COMIC.TTF"),
                            DisplayedString = "Test text"
                        }
                    }
                }
            };
        }
    }
}
