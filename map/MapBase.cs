using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.map
{
    public class MapBase : ElementBase
    {
        /*
        public Texture2D Texture { get; set; }        // Textura pro objekt
        public Vector2 PositionOnMap { get; set; }    // Globální pozice objektu na mapě
        public Vector2 PositionOnScreen { get; set; } // Místní pozice objektu na obrazovce
        public int Width { get; set; }                // Šířka objektu
        public int Height { get; set; }               // Výška objektu
        public bool SupportsCollision { get; set; }   // Podpora pro detekci kolize
        public bool HasAutomaticMovement { get; set; } // Podpora pro automatický pohyb
        */

        // Textura pro pozadí mapy
        protected Texture2D backgroundTexture;

        // Rozměry mapy
       
        // Ostatní běžné atributy
        public string Name { get; set; }  // Jméno nebo název mapy
        public string Description { get; set; } // Popis nebo krátký přehled o mapě

        // Konstruktor
        public MapBase(Texture2D backgroundImage, int width, int height, string name = "", string description = "")
            : base(new Vector2(width / 2, height / 2))  // Nastavení střední pozice mapy vzhledem k jejím rozměrům
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
            spriteBatch.Draw(backgroundTexture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.White);
        }

        // Další metody a charakteristiky, které by mohly být potřebné pro mapu, můžete přidat sem...
    }
}