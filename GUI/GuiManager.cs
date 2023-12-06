using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WoS.GUI.GuiBasic;




namespace WoS.GUI
{
    public class GuiManager
    {
        // Definuje základní věci pro jednotlivé GUI listy (stránky)

        public GuiWidgetBasic GuiBasic { get; set; }
        public GuiWidgetBuild GuiBuild { get; set; }
        public GuiWidgetEdit GuiEdit { get; set; }
        public GuiWidgetFleet GuiFleet { get; set; }
        public GuiWidgetImperium GuiImperium { get; set; }
        public GuiWidgetPlanetInfo GuiPlanetInfo { get; set; }
        public GuiWidgetStation GuiStation { get; set; }

        // Stavy aktivace pro každé GUI
        public bool GuiBasicIsActive { get; set; }
        public bool GuiBuildIsActive { get; set; }
        public bool GuiEditIsActive { get; set; }
        public bool GuiFleetIsActive { get; set; }
        public bool GuiImperiumIsActive { get; set; }
        public bool GuiPlanetInfoIsActive { get; set; }
        public bool GuiStationIsActive { get; set; }

        // Konstruktor
        public GuiManager(ContentManager content)
        {
            // Inicializace jednotlivých GUI komponent
            GuiBasic = new GuiWidgetBasic(content);
            GuiBuild = new GuiWidgetBuild(content);
            // atd.
        }

        // Metody pro aktualizaci a vykreslení
        public void Update(GameTime gameTime)
        {
            if (GuiBasicIsActive) GuiBasic.Update(gameTime);
            if (GuiBuildIsActive) GuiBuild.Update(gameTime);
            // atd.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GuiBasicIsActive) GuiBasic.Draw(spriteBatch);
            if (GuiBuildIsActive) GuiBuild.Draw(spriteBatch);
            // atd.
        }
    }
}