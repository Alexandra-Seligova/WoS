using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace WoS.ship.components.extensions.generators
{
    public abstract class GeneratorBase : ShipExtensionBase
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

*** Přehled vlastností a metod třídy shipExtensionBase ***


*/


        public void Update( Vector2 actualShipPosition,float atualRotation, Vector2 actualTarget)
        {
            //  Rotation = atualRotation;

            // Implementation of method to update the planet
        }



    }

}





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

*** Přehled vlastností a metod třídy shipExtensionBase ***

*** Přehled vlastností a metod třídy GeneratorBase ***



*/
