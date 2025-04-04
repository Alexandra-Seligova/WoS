﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.GUI.ComponentBase
{
    public class ShipView : GuiComponentBase
    {
        private const float SCALE_FACTOR = 0.18f; // 10% z původní velikosti

        public ShipView(int id, Vector2 position, ContentManager content) : base(id, position, content)
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