using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoS.map.Planet;

namespace WoS.map.Planet
{
    public class PlanetMuci : PlanetBase
    {
        private const float SCALE_FACTOR = 0.3f; // 10% z původní velikosti

        public PlanetMuci(int id, Vector2 position, ContentManager content) : base(id)
        {
            Id = id;
            Position = position;
            PositionOnMap = position;
            Rotation = 0;
            Texture = content.Load<Texture2D>("Planets/pla2");


            PlanetElementList = new List<PlanetElement>();
            PopulateElementList();
        }

        public override void Update()
        {
            // Implementation of method to update the planet
        }
        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);

        }
    }
}
