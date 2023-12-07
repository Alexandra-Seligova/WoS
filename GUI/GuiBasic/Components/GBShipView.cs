using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WoS.GUI.GuiBasic.Components
{
    public sealed class GBShipView : GuiComponentBase
    {
        private const float SCALE_FACTOR = 0.08f; // 10% z původní velikosti
        public GBShipView(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = position;
            LoadTexture2D("GUI/GBShip", content);
            SetComponentConfig();

        }

        public override void SetComponentConfig()
        {
            Width = 500;
            Height = 100;
        }

        public override void OnClick()
        {
            // Zpracování události kliknutí, například otevření menu
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(Texture, Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR, SpriteEffects.None, 0);
                ComponentDraw(spriteBatch);
            }
        }

        protected override void ComponentDraw(SpriteBatch spriteBatch)
        {
            // Vykreslení specifických komponent
        }
    }
}
