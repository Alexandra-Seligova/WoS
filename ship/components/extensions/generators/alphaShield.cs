using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.ship.components.extensions.generators
{
    public class AlphaShield : GeneratorBase
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

*** Přehled vlastností a metod třídy GeneratorBase ***

*/
        private Vector2 PositionOnShip;
        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti

        public AlphaShield(ContentManager content, Vector2 positionOnShip) : base()
        {
            Texture = content.Load<Texture2D>("spaceShips/ShieldAlpha");
            PositionOnShip = positionOnShip;
        }

        public override void Update()
        {
            // Implementation of method to update the planet
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }
    }
}