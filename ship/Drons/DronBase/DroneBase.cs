using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.ship.Drons
{
    public class DroneBase : MovementBase
    {


        Vector2 PositionOnShip;

        public DroneBase(ContentManager content, Vector2 startPosition) : base()
        {
            // Implementation of constructor
        }

        public override void Update()
        {
            // Implementation of method to update the planet
        }
        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }
        public void SetPositionOnShip(Vector2 position)
        {
            PositionOnShip = position;
            // Implementation of method to draw the planet
        }
        public void SetDronPosition(Vector2 newPosition)
        {
            PositionOnMap = newPosition;
            //SetTargetPosition(newPosition);
        }

        // Výpočet rotace lodi směrem k cíli
        public void UpdateRotation()
        {
            Vector2 direction = TargetPosition - PositionOnMap;
            Rotation = (float)Math.Atan2(direction.Y, direction.X) + MathHelper.PiOver2; // +PiOver2, protože chceme, aby vrch lodi byl směrován k cíli
        }

    }
}
