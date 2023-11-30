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
    public class GBName : GuiComponentBase
    {
        private String UserName;
        private Vector2 UserNamePosition;
        private int UserLevel;
        private Vector2 UserLevelPosition;


        public GBName(int id, Vector2 position, ContentManager content) : base(id, position, content)

        {
            Id = id;
            Position = position;
            LoaderTexture2D("GUI/GuiBasic/GBName", content);
            SetComponentConfig();
            Visible = true;

        }

        public override void OnClick()
        {
            //otevřít vysouvací menu úkolů
            // GBNameBar.Visible = !GBNameBar.Visible;

        }

        public override void ComponentDraw()
        {
            //vykreslit text
            //  spriteBatch.DrawString(myFont, UserName, UserNamePositionnew, Color.White);
            //  SpriteBatch.DrawString(myFont, UserLevel, UserLevelPosition, Color.White);


        }
        public override void SetComponentConfig()
        {
            Width = 500;
            Height = 200;
            UserNamePosition = new Vector2(50, 30);
            UserLevelPosition = new Vector2(100, 100);
        }

    }
}
