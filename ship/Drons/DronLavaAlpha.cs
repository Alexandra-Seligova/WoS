using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.ship.Drons
{
    public class DronLavaAlpha : DroneBase
    {
        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti

        public DronLavaAlpha(ContentManager content, Vector2 startPosition) : base(content, startPosition)
        {
            Texture = content.Load<Texture2D>("drons/DronLavaAlpha");
            Hp = 700;
            HpMax = 700;
            MaxSpeed = 500;
            Shield = 0;
            ShieldMax = 0;
        }

        public override void Update()
        {
            // Implementation of method to update the planet
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);
        }
    }
}