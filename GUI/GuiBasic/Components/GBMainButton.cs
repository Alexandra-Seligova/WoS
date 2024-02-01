using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.GUI.ComponentBase
{
    public class GBMainButton : GuiComponentBase
    {
        private Button SettingsButton;
        private Button ConfigurationButton;
        private Button BuildingButton;

        public bool SettingsIsActive;
        public bool ConfigurationIsActive;
        public bool BuildingIsActive;

        private string SettingsButtonText;
        private string ConfigurationButtonText;
        private string BuildingButtonText;

        public GBMainButton(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = position;
            LoadText(); //

            LoadButtons(content);
        }

        public void LoadText()    // možnot pro lokalizaci
        {
            SettingsButtonText = Localization.Instance.GetText("GBMainButton", "SettingsButtonText");                  //settings
            ConfigurationButtonText = Localization.Instance.GetText("GBMainButton", "ConfigurationButtonText");        //configuration
            BuildingButtonText = Localization.Instance.GetText("GBMainButton", "BuildingButtonText");                  //build
        }

        private void LoadButtons(ContentManager content)
        {
            // Tady nastavíte pozice tlačítek relativně k `Position`

            SettingsButton = new Button(Position + new Vector2(0, 0), SettingsButtonText, content, myFont);
            ConfigurationButton = new Button(Position + new Vector2(0, 100), ConfigurationButtonText, content, myFont);
            BuildingButton = new Button(Position + new Vector2(0, 200), BuildingButtonText, content, myFont);
        }

        public override void OnClick()
        {
            // Zde zpracovat události kliknutí pro každé tlačítko
            SettingsIsActive = SettingsButton.IsClicked(); // Předpokládá, že Button má metodu IsClicked
            ConfigurationIsActive = ConfigurationButton.IsClicked();
            BuildingIsActive = BuildingButton.IsClicked();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                SettingsButton.Draw(spriteBatch);
                ConfigurationButton.Draw(spriteBatch);
                BuildingButton.Draw(spriteBatch);
            }
        }

        private class Button
        {
            private const float SCALE_FACTOR = 0.02f;
            public Vector2 Position;
            public string Text;
            private Texture2D Texture;
            private SpriteFont Font;

            public Button(Vector2 position, string text, ContentManager content, SpriteFont font)
            {
                Position = position;
                Text = text;
                LoadTexture(content);
                Font = font; // Předpokládáme, že font je načten a předán jako parametr
            }

            private void LoadTexture(ContentManager content)
            {
                // Nahraje texturu tlačítka
                Texture = content.Load<Texture2D>("GUI/GBMainButton");
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Texture, Position, null, Color.White, 0, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);

                // Vypočítá pozici pro vykreslení textu na střed tlačítka
                Vector2 textSize = Font.MeasureString(Text);
                Vector2 textPosition = Position + new Vector2((-textSize.X) / 2, (-textSize.Y) / 2);

                spriteBatch.DrawString(Font, Text, textPosition, Color.Black); // Vykreslení textu černou barvou
            }

            public bool IsClicked()
            {
                // Implementace logiky pro zjištění, zda bylo na tlačítko kliknuto
                return false; // Příklad
            }
        }
    }
}