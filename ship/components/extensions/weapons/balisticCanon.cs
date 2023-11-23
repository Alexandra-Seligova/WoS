using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WoS.ship.components.extensions.weapons;
using WoS.Utility;

namespace WoS.ship.components.extensions.weapons
{
    public class BalisticCanon  : WeaponBase
    {

        public BalisticCanon(ContentManager content, Vector2 position): base()
        {
        }


        public override void Update()
        {
            // Implementation of method to update the planet
        }
        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
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

*** Přehled vlastností a metod třídy WeaponBase ***


*/



    }
}
