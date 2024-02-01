using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WoS.GUI.GuiBasic.Components;

namespace WoS.GUI.GuiBasic
{
    public class GuiWidgetBuild : GuiWidgetBase
    {
        public GuiWidgetBuild(ContentManager content) : base(content)
        {
            Name = "Gui Build Widget";
            Description = "Základní gui pro vykreslení hlavní scény hry";

            // Inicializace jednotlivých komponent
            components.Add(new GBName(1, new Vector2(100, 100), content));
            /*
            components.Add(new GBXpBar(7, new Vector2(400, 100), content));
            components.Add(new GBMineralBar(8, new Vector2(450, 100), content));

            components.Add(new GBMainButton(2, new Vector2(150, 100), content));

            components.Add(new GBShipFuel(3, new Vector2(200, 100), content));
            components.Add(new GBShipMode(4, new Vector2(250, 100), content));
            components.Add(new GBShipView(5, new Vector2(300, 100), content));

            components.Add(new GBSpellBar(6, new Vector2(350, 100), content));

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