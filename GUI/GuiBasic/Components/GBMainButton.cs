using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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


        public GBMainButton(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = position;
            LoadButtons(content);
        }

        private void LoadButtons(ContentManager content)
        {
            // Tady nastavíte pozice tlačítek relativně k `Position`

            SettingsButton = new Button(Position + new Vector2(0, 0), "Settings", content, myFont);
            ConfigurationButton = new Button(Position + new Vector2(0, 100), "Configuration", content, myFont);
            BuildingButton = new Button(Position + new Vector2(0, 200), "Building", content, myFont);
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
