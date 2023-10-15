
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoS.npc;  // Přidáno pro přístup k třídě NpcBase (pokud je v jiném souboru v tomto namespace)

using Microsoft.Xna.Framework;  // Pro použití Vector2
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.npc
{
    public class NpcLolita : NpcBase
    {
        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti
        public NpcLolita(int id, Vector2 position, ContentManager content) : base(position)
        {
            Id = id;
            Position = position;
            PositionOnMap = position;
            Rotation = 0;
            Texture = content.Load<Texture2D>("npc/ships/Uber_Lordakia");  // Zde můžete inicializovat vlastnosti specifické pro NpcStreuner // Zde můžete inicializovat vlastnosti specifické pro NpcStreuner
        }
        public override void Update()
        {
            // Implementation of method to update the planet
        }
        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);

        }// Další metody a vlastnosti týkající se NpcStreuner můžete přidat sem...
        // Další metody a vlastnosti týkající se NpcStreuner můžete přidat sem...
    }
}
