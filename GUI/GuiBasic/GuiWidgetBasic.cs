using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


using WoS.GUI.GuiBasic.Components;
using WoS.GUI.ComponentBase;



namespace WoS.GUI.GuiBasic
{
    public class GuiWidgetBasic : GuiWidgetBase
    {


        public GuiWidgetBasic(ContentManager content) : base(content)
        {
            Name = "Gui Basic Widget";
            Description = "Základní gui pro vykreslení hlavní scény hry";

            int width = 1920;
            int height = 1080;
            // Inicializace jednotlivých komponent
            components.Add(new GBName(1, new Vector2(0, 0), content));
            components.Add(new GBShipView(5, new Vector2(80 + 20 + 10, height - 350 - 100), content));
            components.Add(new ShipShieldView(3, new Vector2(200 + 20, height - 200 - 100), content));
            components.Add(new GBMineralBar(8, new Vector2(200, 0), content));

            components.Add(new GBMainButton(2, new Vector2(width - 80, 50), content));
            components.Add(new GBShipFuel(3, new Vector2(35, height - 110), content));
            components.Add(new GBShipMode(4, new Vector2(100, height - 80), content));
            components.Add(new GBSpellBar(6, new Vector2(600, height - 70), content));
            components.Add(new GBMiniMap(9, new Vector2(width - 200, height - 200), content));



            /*
            components.Add(new GBXpBar(7, new Vector2(400, 100), content));



            components.Add(new GBMainButton(2, new Vector2(150, 100), content));



            components.Add(new GBShipMode(4, new Vector2(250, 100), content));





              */
            // Další komponenty...
        }


        // Vykreslení všech komponent
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

        }

        // Update všech komponent
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
    }
}
