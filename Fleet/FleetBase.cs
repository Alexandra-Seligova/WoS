using Microsoft.Xna.Framework.Graphics;
using WoS.ship;

namespace WoS.Fleet
{
    public class FleetBase : ElementBase
    {
        public ShipBase ship;

        public FleetBase() : base()
        {
        }

        public override void Update()
        { }

        public override void Render(SpriteBatch spriteBatch)
        { }
    }
}