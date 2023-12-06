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
    public class GBNameBar : GuiComponentBase
    {

        public int QuestsBarSize = 30;



        public GBNameBar(int id, Vector2 position, ContentManager content) : base(id, position, content)

        {
            Id = id;
            Position = position;
            LoadTexture2D("GUI/GuiBasic/GBNameBar", content);
            SetComponentConfig();
            Visible = true;

        }
        public override void SetComponentConfig()
        {
            Width = 500;
            Height = 200;

        }



        public override void OnClick()
        {
            //otevřít vysouvací menu úkolů
            // GBNameBar.Visible = !GBNameBar.Visible;

        }

        protected override void ComponentDraw(SpriteBatch spriteBatch)
        {
             DrawQuests(spriteBatch,QuestsBarSize);



        }


        // vykreslit 10x okénko,
        // po levé straně lišta s posunem  (celkem až 30x  nahoře, uprostřed, dole) = rozlišení 3
        // každé okénko je odkaz na název user.quest[x]


        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            ComponentDraw(spriteBatch);



        }



        public void DrawQuests(SpriteBatch spriteBatch, int ElementsSize)

        {
            for (int i = 0; i < ElementsSize; i++)
            {
                DrawQuest(spriteBatch, i);
            }
        }



        public void DrawQuest(SpriteBatch spriteBatch, int QuestNumber)
        {




        }










    }
}
