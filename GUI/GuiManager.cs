using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public Vector2 WindowPosition { get; set; }
        public Vector2 WindowSize { get; set; }

        // Konstruktor
        public GuiManager(ContentManager content, Vector2 windowSize)
        {
            WindowPosition = new Vector2(0, 0);
            WindowSize = new Vector2(1920, 1080);

            GuiBasicIsActive = true;
            // Inicializace jednotlivých GUI komponent
            GuiBasic = new GuiWidgetBasic(content);
            GuiBuild = new GuiWidgetBuild(content);
            GuiEdit = new GuiWidgetEdit(content);
            GuiFleet = new GuiWidgetFleet(content);
            GuiImperium = new GuiWidgetImperium(content);
            GuiPlanetInfo = new GuiWidgetPlanetInfo(content);
            GuiStation = new GuiWidgetStation(content);

            // atd.
        }

        // Metody pro aktualizaci a vykreslení
        public void Update(GameTime gameTime, Vector2 GlobalPosition)
        {
            WindowPosition = GlobalPosition;
            //WindowPosition = new Vector2(GlobalPosition.X - WindowSize.X/2, GlobalPosition.Y - WindowSize.Y/2);
            if (GuiBasicIsActive) GuiBasic.Update(gameTime);
            if (GuiBuildIsActive) GuiBuild.Update(gameTime);
            if (GuiEditIsActive) GuiEdit.Update(gameTime);
            if (GuiFleetIsActive) GuiFleet.Update(gameTime);
            if (GuiImperiumIsActive) GuiImperium.Update(gameTime);
            if (GuiPlanetInfoIsActive) GuiPlanetInfo.Update(gameTime);
            if (GuiStationIsActive) GuiStation.Update(gameTime);

            // atd.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GuiBasicIsActive) GuiBasic.Draw(spriteBatch);
            if (GuiBuildIsActive) GuiBuild.Draw(spriteBatch);
            if (GuiEditIsActive) GuiEdit.Draw(spriteBatch);
            if (GuiFleetIsActive) GuiFleet.Draw(spriteBatch);
            if (GuiImperiumIsActive) GuiImperium.Draw(spriteBatch);
            if (GuiPlanetInfoIsActive) GuiPlanetInfo.Draw(spriteBatch);
            if (GuiStationIsActive) GuiStation.Draw(spriteBatch);

            // atd.
        }
    }
}