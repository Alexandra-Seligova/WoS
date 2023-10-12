using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Xml.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using WoS.map.Box;
using WoS.map.Planet;
using WoS.map.Sun;
using WoS.npc;
using WoS.map.moon;
using WoS.Fleets;
using WoS.map.Asteroids;

namespace WoS.map
{
    public class MapAlpha : MapBase
    {


        // Konstruktor pro MapAlpha s předdefinovanými hodnotami
        public MapAlpha(Texture2D backgroundImage, int id, Vector2 position)
        : base(id, position)
        {
            Id = id;
            Position = position;

            Width = 10000;
            Height = 10000;
            MapWidth = Width;
            MapHeight = Height;
            Config();
            LoadConfigFromDb();
            create();

            backgroundTexture = backgroundImage;
            // Nastavení pozice mapy na (0,0)
            this.Position = new Vector2(0, 0);

            // Zde můžete přidat další konkrétní nastavení pro MapAlpha, pokud je potřebujete

        }
        public void Config()
        {

            SunCount = 1;
            PlanetCount = 10;
            BoxCount = 10;
            NpcCount = 10;

        }

        public void LoadConfigFromDb()
        {
            //nastavení pro celou mapu načtené z db

        }
        public void create()
        {
            // vytvoření prvků na mapě dle configu

            ArrayList_Sun = new List<SunBase>();
            ArrayList_Planet = new List<PlanetBase>();
            ArrayList_Box = new List<BoxBase>();
            ArrayList_Npc = new List<NpcBase>();

            ArrayList_Asteroids = new List<AsteroidBase>();
            ArrayList_UserFleet = new List<UserFleet>();
            ArrayList_EnemyFleets = new List<EnemyFleet>();
            ArrayList_Moons = new List<MoonBase>();


            CreateSun(SunCount);
            CreatePlanet(PlanetCount);
            CreateBox(BoxCount);
            CreateNpc(NpcCount);

        }



        // Metoda pro vykreslení mapy
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.White);

            // Vykreslení jednotlivých prvků hry
            RenderBackeground(spriteBatch);
            RenderAll(spriteBatch);
            

        }


    }

}
