using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WoS.Utility;  // Pro přístup k třídě OrbitalMovement

namespace WoS.map.moon
{
    public abstract class MoonBase : OrbitalMovement
    {
        public MoonBase(Vector2 position)
        {
            this.Position = position;
        }

        public override void Update()
        {
            // Implementation of method to update the planet
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }

        // Zde můžete přidat specifické vlastnosti a metody pro moonBase
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