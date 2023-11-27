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

namespace WoS.ship.components.extensions.generators
{
    public class AlphaEngine : GeneratorBase
    {
                 Vector2 PositionOnShip;
         private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti
        public AlphaEngine(ContentManager content, Vector2 positionOnShip): base()
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
            // Implementation of method to update the planet
        }
        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), 1.0f, SpriteEffects.None, 0);

        }
    }
}
