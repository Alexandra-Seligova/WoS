using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.ship.components.extensions.generators
{
    public class AlphaEngine : GeneratorBase
    {
        private Vector2 PositionOnShip;
        private const float SCALE_FACTOR = 0.01f; // 10% z původní velikosti

        public AlphaEngine(ContentManager content, Vector2 positionOnShip) : base()
        {
            Texture = content.Load<Texture2D>("spaceShips/EngineAlpha");
            PositionOnShip = positionOnShip;
            // Zdraví
            Hp = 700;
            HpMax = 700;
            Rotation = 0;
        }

        public override void Update()
        {
            // PositionOnMap = Ship.positionOnMap;
            // Implementation of method to update the planet
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap + PositionOnShip, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), 1.0f, SpriteEffects.None, 0);
        }
    }
}