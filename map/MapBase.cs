using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.map
{
    public class MapBase
    {
        // Textura pro pozadí mapy
        protected Texture2D backgroundTexture;

        // Rozměry mapy
        public int Width { get; private set; }
        public int Height { get; private set; }

        // Ostatní běžné atributy
        public string Name { get; set; }  // Jméno nebo název mapy
        public string Description { get; set; } // Popis nebo krátký přehled o mapě

        // Konstruktor
        public MapBase(Texture2D backgroundImage, int width, int height, string name = "", string description = "")
        {
            backgroundTexture = backgroundImage;
            Width = width;
            Height = height;
            Name = name;
            Description = description;
        }

        // Metoda pro vykreslení mapy
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Width, Height), Color.White);
        }

        // Další metody a charakteristiky, které by mohly být potřebné pro mapu, můžete přidat sem...
    }
}