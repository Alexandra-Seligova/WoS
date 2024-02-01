using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WoS.GUI
{
    public class GBShipMode : GuiComponentBase
    {
        private Button ModeAttackButton;
        private Button ModeShieldButton;
        private Button ModeSpeedButton;

        public GBShipMode(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = position;
            LoadButtons(content);
        }

        private void LoadButtons(ContentManager content)
        {
            ModeAttackButton = new Button(new Vector2(Position.X + 0, Position.Y), "Attack", "GBShipModeAttack", content, myFont);
            ModeShieldButton = new Button(new Vector2(Position.X + 100, Position.Y), "Shield", "GBShipModeShield", content, myFont);
            ModeSpeedButton = new Button(new Vector2(Position.X + 200, Position.Y), "Speed", "GBShipModeSpeed", content, myFont);
        }

        public override void OnClick()
        {
            ModeAttackButton.CheckIfClicked();
            ModeShieldButton.CheckIfClicked();
            ModeSpeedButton.CheckIfClicked();
            // Zpracujte reakci na kliknutí na tlačítka zde
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                ModeAttackButton.Draw(spriteBatch);
                ModeShieldButton.Draw(spriteBatch);
                ModeSpeedButton.Draw(spriteBatch);
            }
        }

        private class Button
        {
            private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti

            public Vector2 Position;
            private string Text;
            private Texture2D Texture;
            private SpriteFont Font;

            public Button(Vector2 position, string text, string textureName, ContentManager content, SpriteFont font)
            {
                Position = position;
                Text = text;
                Font = font;
                LoadTexture(textureName, content);
            }

            private void LoadTexture(string textureName, ContentManager content)
            {
                Texture = content.Load<Texture2D>("GUI/" + textureName);
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Texture, Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR, SpriteEffects.None, 0);

                Vector2 textSize = Font.MeasureString(Text);
                // Vector2 textPosition = Position + new Vector2((Texture.Width - textSize.X) / 2, (Texture.Height - textSize.Y) / 2);
                Vector2 textPosition = Position;
                spriteBatch.DrawString(Font, Text, textPosition, Color.Black);
            }

            public void CheckIfClicked()
            {
                var mouseState = Mouse.GetState();
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    mouseState.X >= Position.X && mouseState.X <= Position.X + Texture.Width &&
                    mouseState.Y >= Position.Y && mouseState.Y <= Position.Y + Texture.Height)
                {
                    // Tlačítko bylo kliknuto, implementujte reakci
                }
            }
        }
    }
}