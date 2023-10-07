using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WoS;

namespace WoS.Utility
{
    public abstract class CollisionDetection : MovementBase
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

        */



        // Konstruktor pro inicializaci pozice.
        public CollisionDetection(Vector2 position)
        {
            Position = position;
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
        // Další metody a vlastnosti týkající se detekce kolize můžete přidat sem...
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


*** Přehled vlastností a metod třídy CollisionDetection ***


        // metody
        bool       IsCollidingWith(ElementBase other)
*/