using Microsoft.Xna.Framework;
using WoS.Utility; // Předpokládá se, že OrbitalMovement je v tomto namespace

namespace WoS.map.Asteroids
{
    public abstract class AsteroidBase : OrbitalMovement
    {
        public AsteroidBase(Vector2 position)
        {
            this.Position = position;
        }

        // Zde můžete přidat specifické vlastnosti a metody pro AsteroidBase

        /*
public Texture2D Texture { get; set; }        // Textura pro objekt
public Vector2 PositionOnMap { get; set; }    // Globální pozice objektu na mapě
public Vector2 PositionOnScreen { get; set; } // Místní pozice objektu na obrazovce
public int Width { get; set; }                // Šířka objektu
public int Height { get; set; }               // Výška objektu
public bool SupportsCollision { get; set; }   // Podpora pro detekci kolize
public bool HasAutomaticMovement { get; set; } // Podpora pro automatický pohyb
*/
    }
}