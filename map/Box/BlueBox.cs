using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;  // Potřebné pro Vector2 a další třídy
using Microsoft.Xna.Framework.Graphics;

namespace WoS.map.Box
{
    internal class BlueBox : BoxBase
    {
        public BlueBox(Vector2 BoxPosition,int BoxType)
        {
            Position = BoxPosition;
            //this.BoxType = BoxType;
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
