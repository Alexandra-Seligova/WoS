using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WoS;


namespace WoS.GUI.GuiBasic.Components
{
    /// <summary>
    /// Třída komponenty GBName.
    /// </summary>
    public sealed class GBName : GuiComponentBase
    {
        private const float SCALE_FACTOR = 0.18f; // 10% z původní velikosti
        // Pole
        private string UserName;
        private Vector2 UserNamePosition;
        private int UserLevel;
        private Vector2 UserLevelPosition;

        // Konstruktor
        public GBName(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = position;
            LoadTexture2D("GUI/GBName", content);
            SetComponentConfig();

        }

        // Nastavení specifické konfigurace komponenty
        public override void SetComponentConfig()
        {
            UserName = "Scribonia";
            UserLevel = 1;

            Width = 500;
            Height = 100;
            UserNamePosition = new Vector2(10, 10);
            UserLevelPosition = new Vector2(10, 30);
        }

        // Přepsání pro zpracování událostí kliknutí
        public override void OnClick()
        {
            // Zpracování události kliknutí, například otevření menu
        }

        // Přepsání metody Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(Texture, Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR, SpriteEffects.None, 0);
                ComponentDraw(spriteBatch);
            }

        }

        // Vykreslení specifických vlastností komponenty
        protected override void ComponentDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(myFont, UserName, UserNamePosition, Color.White);
            spriteBatch.DrawString(myFont, UserLevel.ToString(), UserLevelPosition, Color.White);
        }
    }
}
