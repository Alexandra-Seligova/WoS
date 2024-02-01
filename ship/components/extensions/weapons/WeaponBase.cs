using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.ship.components.extensions.weapons
{
    public abstract class WeaponBase : ShipExtensionBase
    {
        public void Update(Vector2 actualShipPosition, float atualRotation, Vector2 actualTarget)
        {
            Rotation = atualRotation;

            // Implementation of method to update the planet
        }

        public void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }
    }
}