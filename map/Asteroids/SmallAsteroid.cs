using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
namespace WoS.map.Asteroids
{
    public class SmallAsteroid : AsteroidBase
    {
        // Zde můžete přidat specifické vlastnosti a metody pro SmallAsteroid
        public SmallAsteroid(Vector2 position): base(position)
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
    }
}
