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
         *** Přehled vlastností a metod třídy ElementBase ***
         Texture2D Texture          // Textura pro objekt
         Vector2 Position           // Základní vlastnost pozice 
         Vector2 PositionOnMap      // Globální pozice objektu na mapě
         Vector2 PositionOnScreen   // Místní pozice objektu na obrazovce
         int Width                  // Šířka objektu
         int Height                 // Výška objektu

         // Vlastnosti zdraví a štítu
         float Hp                   // Aktuální zdraví objektu
         float HpMax                // Maximální zdraví objektu
         float Shield               // Aktuální hodnota štítu objektu
         float ShieldMax            // Maximální hodnota štítu objektu

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