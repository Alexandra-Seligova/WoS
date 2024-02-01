namespace WoS.Utility
{
    public abstract class OrbitalMovement : MovementBase
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

*** Přehled vlastností a metod třídy CollisionDetection ***

        // metody
        bool       IsCollidingWith(ElementBase other)
*/

        // Zde můžete inicializovat vlastnosti specifické pro OrbitalMovement

        // Další metody a vlastnosti týkající se OrbitalMovement můžete přidat sem...
    }
}