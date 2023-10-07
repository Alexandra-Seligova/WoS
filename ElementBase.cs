using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS
{
    public abstract class ElementBase
    {
        // Vlastnosti
        public Texture2D Texture { get; set; }        // Textura pro objekt
        public Vector2 Position { get; set; }         // Základní vlastnost pozice pro všechny objekty dědící z této třídy.
        public Vector2 PositionOnMap { get; set; }    // Globální pozice objektu na mapě
        public Vector2 PositionOnScreen { get; set; } // Místní pozice objektu na obrazovce
        public float Rotation { get; set; }           // Rotace objektu v prostoru
        public int Width { get; set; }                // Šířka objektu
        public int Height { get; set; }               // Výška objektu

        // Vlastnosti zdraví a štítu
        public float Hp { get; set; }                 // Aktuální zdraví objektu
        public float HpMax { get; set; }              // Maximální zdraví objektu
        public float Shield { get; set; }             // Aktuální hodnota štítu objektu
        public float ShieldMax { get; set; }          // Maximální hodnota štítu objektu

        // Konstruktor pro inicializaci pozice.
        public ElementBase(Vector2 position)
        {
            Position = position;
        }

        // Výchozí konstruktor, pokud nechcete předat žádnou pozici.
        public ElementBase() : this(Vector2.Zero) { }

        // Další základní funkce a vlastnosti mohou být přidány podle potřeby.

    }
}

/*
 *** Přehled vlastností a metod třídy ElementBase ***
         Texture2D Texture          // Textura pro objekt
         Vector2 Position           // Základní vlastnost pozice 
         Vector2 PositionOnMap      // Globální pozice objektu na mapě
         Vector2 PositionOnScreen   // Místní pozice objektu na obrazovce
         float   Rotation           // Rotace objektu v prostoru
         int     Width              // Šířka objektu
         int     Height             // Výška objektu

        // Vlastnosti zdraví a štítu
         float Hp                   // Aktuální zdraví objektu
         float HpMax                // Maximální zdraví objektu
         float Shield               // Aktuální hodnota štítu objektu
         float ShieldMax            // Maximální hodnota štítu objektu

*/