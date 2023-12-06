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


namespace WoS.GUI.GuiBasics.Components
{
    /// <summary>
    /// Třída komponenty GBName.
    /// </summary>
    public sealed class GBName : GuiComponentBase
    {
        // Pole
        private string UserName;
        private Vector2 UserNamePosition;
        private int UserLevel;
        private Vector2 UserLevelPosition;

        // Konstruktor
        public GBName(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            LoadTexture2D("GUI/GuiBasic/GBName", content);
            SetComponentConfig();
        }

        // Nastavení specifické konfigurace komponenty
        public override void SetComponentConfig()
        {
            UserName = "Jmeno";
            UserLevel = 1;

            Width = 500;
            Height = 200;
            UserNamePosition = new Vector2(50, 30);
            UserLevelPosition = new Vector2(100, 100);
        }

        // Přepsání pro zpracování událostí kliknutí
        public override void OnClick()
        {
            // Zpracování události kliknutí, například otevření menu
        }

        // Přepsání metody Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            ComponentDraw(spriteBatch);
        }

        // Vykreslení specifických vlastností komponenty
        protected override void ComponentDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(myFont, UserName, UserNamePosition, Color.White);
            spriteBatch.DrawString(myFont, UserLevel.ToString(), UserLevelPosition, Color.White);
        }
    }
}
