using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS
{
    public abstract class ElementBase
    {
        // Vlastnosti
        public Texture2D Texture { get; set; }        // Textura pro objekt
        public Vector2 PositionOnMap { get; set; }    // Globální pozice objektu na mapě
        public Vector2 PositionOnScreen { get; set; } // Místní pozice objektu na obrazovce
        public int Width { get; set; }                // Šířka objektu
        public int Height { get; set; }               // Výška objektu

        // Základní vlastnost pozice pro všechny objekty dědící z této třídy.
        public Vector2 Position { get; set; }

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