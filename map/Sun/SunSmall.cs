﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.map.Sun
{
    public class SunSmall : SunBase
    {
        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti

        public SunSmall(int id, Vector2 position, ContentManager content)
        {
            Id = id;
            Position = position;
            PositionOnMap = position;
            Rotation = 0;
            //Texture = content.Load<Texture2D>("spaceShips/Egla");
            // Implementation of method to update the planet
        }

        public override void Update()
        {
            // Implementation of method to update
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);
        }
    }
}