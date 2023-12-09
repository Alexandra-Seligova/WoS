using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace WoS.GUI.GuiBasic.Components
{
    public sealed class GBShipFuel : GuiComponentBase
    {
        private const float SCALE_FACTOR = 0.08f;
        private Dictionary<int, Texture2D> Textures;
        private int FuelPercentage; // Palivo v procentech
        //private SpriteFont myFont;
        private Vector2 FuelCountPosition;

        public GBShipFuel(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = FuelCountPosition = position;
            LoadTextures(content);
            SetComponentConfig();
        }

        private void LoadTextures(ContentManager content)
        {
            Textures = new Dictionary<int, Texture2D>();
            string path = "GUI/GBFuel/";

            // Načtení textur pro různá procenta paliva
            for (int i = 10; i <= 100; i += 10)
            {
                Textures[i] = content.Load<Texture2D>(path + "GBShipFuel_" + i.ToString());
            }

            //myFont = content.Load<SpriteFont>("FontPath"); // Nahraďte "FontPath" skutečnou cestou k fontu
        }

        public void UpdateFuelLevel(int newFuelPercentage)
        {
            FuelPercentage = MathHelper.Clamp(newFuelPercentage, 10, 100);
        }
        public override void OnClick()
        {
            throw new System.NotImplementedException();
        }
        public override void SetComponentConfig()
        {
            FuelPercentage = 100;
            Width = 500;
            Height = 100;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                Texture2D texture = SelectTexture();
                spriteBatch.Draw(texture, Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR, SpriteEffects.None, 0);
                ComponentDraw(spriteBatch);
            }
        }

        protected override void ComponentDraw(SpriteBatch spriteBatch)
        {
            string fuelText = FuelPercentage.ToString() + "%";
            spriteBatch.DrawString(myFont, fuelText, FuelCountPosition, Color.White);
        }

        private Texture2D SelectTexture()
        {
            int textureIndex = (FuelPercentage / 10) * 10;
            return Textures.ContainsKey(textureIndex) ? Textures[textureIndex] : Textures[10];
        }
    }
}
