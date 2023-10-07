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
            doplnky_poc = 2;
            zbrane_poc = 2;

            // Pozice jednotlivých modulů na lodi
            Vector2 kan1 = new Vector2(-18, -21);
            Vector2 kan2 = new Vector2(18, -21);
            Vector2 gen1 = new Vector2(0, 20);
            Vector2 doplnky1 = new Vector2(-10, -11);
            Vector2 doplnky2 = new Vector2(10, -11);



            texture = shipTexture;
            Position = startPosition;
            Speed = speed;
            Target = startPosition;
        }
        // Přetížení metody Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, rotace, new Vector2(texture.Width / 2, texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);
        }
    }
}

