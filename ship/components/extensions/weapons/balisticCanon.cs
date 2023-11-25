using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WoS.ship.components.extensions.weapons;
using WoS.Utility;

namespace WoS.ship.components.extensions.weapons
{
    public class BalisticCanon  : WeaponBase
    {

        public BalisticCanon(ContentManager content, Vector2 position,int size): base()
        {
        }


        public void Update(Vector2 actualShipPosition, float atualRotation, Vector2 actualTarget)
        {
            // Implementation of method to update the planet
        }
        public  void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }

    }
}
