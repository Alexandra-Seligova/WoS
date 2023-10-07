using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS
{
    public abstract class MovementBase : ElementBase
    {
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
        public Vector2 Target { get; set; }

        // Místo, kde se loď objevila
        public Vector2 SpawnPlace { get; set; }


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


*** Přehled vlastností a metod třídy MovementBase ***

         Texture2D
         string     Designation      // Název či označení lodi
         float      Rotation
         Vector2    Velocity         // Aktuální rychlost lodi
         float      Acceleration     // Zrychlení lodi
         int        MaxSpeed         // Maximální rychlost lodi
         float      ShipWidth        // Šířka lodi
         float      ShipHeight       // Výška lodi
         Vector2    Target           // Cíl lodi pro pohyb
         Vector2    SpawnPlace       // Místo, kde se loď objevila

         // metody
         bool       IsCollidingWith(ElementBase other)
*/