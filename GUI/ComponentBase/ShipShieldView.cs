using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace WoS.GUI.ComponentBase
{
    public class ShipShieldView : GuiComponentBase
    {
        private const float SCALE_FACTOR = 0.35f;

        private Shield ShieldLeft;
        private Shield ShieldRight;
        private Shield ShieldFront;
        private Shield ShieldBack;

        public ShipShieldView(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = position;
            LoadShields(content);
            SetComponentConfig();
        }

        private void LoadShields(ContentManager content)
        {
            ShieldLeft = new Shield(Position + new Vector2(-170, 0), content, "GBShipShield", 0f); // Bez rotace
            ShieldRight = new Shield(Position + new Vector2(170, 0), content, "GBShipShield", -MathHelper.Pi); // Rotace o 90 stupňů
            ShieldFront = new Shield(Position + new Vector2(0, -170), content, "GBShipShield", MathHelper.PiOver2); // Rotace o 180 stupňů
            ShieldBack = new Shield(Position + new Vector2(0, 170), content, "GBShipShield", -MathHelper.PiOver2); // Rotace o -90 stupňů
        }

        public override void SetComponentConfig()
        {
            Width = 500;
            Height = 100;
        }

        public override void OnClick()
        {
            // Zpracování události kliknutí
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                ComponentDraw(spriteBatch);
            }
        }

        protected override void ComponentDraw(SpriteBatch spriteBatch)
        {
            ShieldLeft.Draw(spriteBatch, SCALE_FACTOR);
            ShieldRight.Draw(spriteBatch, SCALE_FACTOR);
            ShieldFront.Draw(spriteBatch, SCALE_FACTOR);
            ShieldBack.Draw(spriteBatch, SCALE_FACTOR);
        }

        private class Shield
        {
            private Dictionary<int, Texture2D> Textures;
            public Vector2 Position;
            public float ShieldValue;
            private float Rotation = 0;

            public Shield(Vector2 position, ContentManager content, string baseTextureName, float rotation)
            {
                Position = position;
                Rotation = rotation;
                Textures = new Dictionary<int, Texture2D>();
                LoadTextures(content, baseTextureName);
                ShieldValue = 100; // Přednastavená hodnota
            }

            private void LoadTextures(ContentManager content, string baseTextureName)
            {
                string path = "GUI/GBShield/";
                Textures[0] = content.Load<Texture2D>(path + baseTextureName + "_0");
                Textures[10] = content.Load<Texture2D>(path + baseTextureName + "_10");
                Textures[20] = content.Load<Texture2D>(path + baseTextureName + "_20");
                Textures[40] = content.Load<Texture2D>(path + baseTextureName + "_40");
                Textures[50] = content.Load<Texture2D>(path + baseTextureName + "_50");
                Textures[60] = content.Load<Texture2D>(path + baseTextureName + "_60");
                Textures[80] = content.Load<Texture2D>(path + baseTextureName + "_80");
                Textures[100] = content.Load<Texture2D>(path + baseTextureName + "_100");
            }

            public void Draw(SpriteBatch spriteBatch, float scaleFactor)
            {
                Texture2D texture = SelectTexture();
                spriteBatch.Draw(texture, Position, null, Color.White, Rotation, new Vector2(texture.Width / 2, texture.Height / 2), scaleFactor, SpriteEffects.None, 0);
            }

            private Texture2D SelectTexture()
            {
                // Předpokládáme, že hodnoty ShieldValue jsou korektně nastaveny
                int textureIndex = (int)(ShieldValue / 10) * 10;
                return Textures.ContainsKey(textureIndex) ? Textures[textureIndex] : Textures[0];
            }
        }
    }
}
