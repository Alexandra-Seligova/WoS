using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WoS.ship
{
    public class ShipEgla : ShipBase
    {

        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti

        public ShipEgla(Texture2D shipTexture, Vector2 startPosition, float speed)
            : base(shipTexture, startPosition, speed)
        {
            // Zdraví a rychlost lodě
            hp = 700;
            speed = 500;
            // Moduly a vybavení lodě
            generatorsNumber = 2;
            weaponsNumber = 1;

            // Pozice jednotlivých modulů na lodi
            Vector2 canon1Position = new Vector2(0, 0);

            Vector2 generator1Position = new Vector2(0, 20);
            Vector2 extension1Position = new Vector2(-10, -11);
            Vector2 extension2Position = new Vector2(10, -11);



            texture = shipTexture;
            PositionOnMap = startPosition;
            Speed = speed;
            Target = startPosition;
        }
        // Přetížení metody Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, PositionOnMap, null, Color.White, rotace, new Vector2(texture.Width / 2, texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);
        }
    }
}

