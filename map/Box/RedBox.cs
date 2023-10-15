using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.map.Box
{
    internal class RedBox : BoxBase
    {
        public RedBox(Vector2 BoxPozition, int BoxType)
        {
            Position = BoxPozition;
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
