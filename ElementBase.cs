using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS
{
    public abstract class ElementBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string TypeDescription { get; set; }



        // Vlastnosti
        public Texture2D Texture { get; set; }        // Textura pro objekt
        public string Designation { get; set; } // oznaceni


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




        // Fyzikální parametry lodi
        public Vector2 Velocity { get; set; }          // Aktuální rychlost lodi


        public int Speed { get; set; } // speed

        public float Acceleration { get; set; } = 50;  // Zrychlení lodi
        public int MaxSpeed { get; set; }              // Maximální rychlost lodi

        // Velikost lodi
        public float ShipWidth { get; set; }           // Šířka lodi

        public float ShipHeight { get; set; }          // Výška lodi

        // Cíl lodi pro pohyb
        public Vector2 TargetPosition { get; set; }

        // Místo, kde se loď objevila
        public Vector2 SpawnPlace { get; set; }





        // Konstruktor pro inicializaci pozice.
        public ElementBase(Vector2 position)
        {
            Position = position;
        }

        // Výchozí konstruktor, pokud nechcete předat žádnou pozici.
        public ElementBase() : this(Vector2.Zero) { }

        // Další základní funkce a vlastnosti mohou být přidány podle potřeby.

        public abstract void Update();

        public abstract void Render(SpriteBatch spriteBatch);
    }
}


/*

public class ShipBattleAlpha : ShipBase
{

    // Vlastnosti
    public Texture2D Texture { get; set; }        // Textura pro objekt

    public Vector2 Position { get; set; }         // Základní vlastnost pozice pro všechny objekty dědící z této třídy.
    public Vector2 PositionOnMap { get; set; }    // Globální pozice objektu na mapě
    public Vector2 PositionOnScreen { get; set; } // Místní pozice objektu na obrazovce
    public float Rotation { get; set; }           // Rotace objektu v prostoru
    public int Width { get; set; }                // Šířka objektu
    public int Height { get; set; }               // Výška objektu

    public int Id { get; set; }

    // Vlastnosti zdraví a štítu
    public float Hp { get; set; }                 // Aktuální zdraví objektu
    public float HpMax { get; set; }              // Maximální zdraví objektu
    public float Shield { get; set; }             // Aktuální hodnota štítu objektu
    public float ShieldMax { get; set; }          // Maximální hodnota štítu objektu

**
    // Název či označení lodi
    public string Designation { get; set; }

    // Fyzikální parametry lodi
    public Vector2 Velocity { get; set; }          // Aktuální rychlost lodi
    public float Acceleration { get; set; } = 50;  // Zrychlení lodi
    public int MaxSpeed { get; set; }              // Maximální rychlost lodi

    // Velikost lodi
    public float ShipWidth { get; set; }           // Šířka lodi
    public float ShipHeight { get; set; }          // Výška lodi

    // Cíl lodi pro pohyb
    public Vector2 TargetPosition { get; set; }

    // Místo, kde se loď objevila
    public Vector2 SpawnPlace { get; set; }

**

    private const float SCALE_FACTOR = 0.2f; // 10% z původní velikosti

    // Moduly a vybavení lodě
    public int generatorsCount;                // Počet doplňků (standardní moduly)
    public int weaponsCount;                   // Počet zbraní (útočné moduly)
    public int extensionsCount;                // Počet rozšíření (defenzivní moduly)


    // Seznamy pro různé komponenty lodě
    public List<WeaponBase> canons;             // Seznam kanónů lodě
    public List<GeneratorBase> generators;      // Seznam generátorů lodě
    public List<ShipExtensions1> extensions;    // Seznam rozšíření lodě

    public Vector2[] WeaponsPosition;           // Pozice zbraní
    public Vector2[] GeneratorsPosition;        // Pozice generátorů
    public Vector2[] ExtensionsPosition;        // Pozice rozšíření

    // Ostatní
    public bool prvni_spusteni = true;          // Pro nastavení prvního statusu
    public string msg;                          // Zpráva
    public int seq;                             // Sekvenční číslo
    public int casOmezovac = 0;                 // Časový omezovač


**





















    public ShipBattleAlpha(ContentManager content, Vector2 startPosition)
        : base(content, startPosition)
    {
    }



    public virtual bool IsCollidingWith(ElementBase other)
    {
        if (Position.X + Width > other.Position.X &&
            Position.X < other.Position.X + other.Width &&
            Position.Y + Height > other.Position.Y &&
            Position.Y < other.Position.Y + other.Height)
        {
            return true;
        }
        return false;
    }






}

public class ShipBase : ElementBase
{
    public ShipBase(ContentManager content, Vector2 startPosition)
        : base()
    {
    }
}





public class CollisionDetection : ElementBase
{

}


    // Výchozí konstruktor, pokud nechcete předat žádnou pozici.
    public ElementBase() : this(Vector2.Zero) { }
}


*/