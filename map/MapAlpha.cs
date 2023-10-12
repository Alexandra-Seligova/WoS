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
            NpcCount = 0;
            AsteroidCount = 1;
            UserFleetCount = 1;
            EnemyFleetCount= 1;
            MoonCount = 1;

        InitializeNpcCounts();
        }
        public void InitializeNpcCounts()
        {
            NpcTypeCount[0] = 5; //streuner
            NpcTypeCount[1] = 10; //lolita

            NpcCount = NpcTypeCount.Sum();
        }

        public void LoadConfigFromDb()
        {
            //nastavení pro celou mapu načtené z db

        }
        public void create()
        {
            // vytvoření prvků na mapě dle configu
            Suns.Elements = new List<SunBase>();
            Planets.Elements = new List<PlanetBase>();
            Boxes.Elements = new List<BoxBase>();
            Npcs.Elements = new List<NpcBase>();
            Asteroids.Elements = new List<AsteroidBase>();
            UserFleets.Elements = new List<UserFleet>();
            EnemyFleets.Elements = new List<EnemyFleet>();
            Moons.Elements = new List<MoonBase>();
 new List<MoonBase>();

            CreateElements(Suns, () => new SunSmall());
            CreateElements(Planets, () => new PlanetDeath());




            CreateSun(SunCount);
            CreatePlanet(PlanetCount);
            CreateBox(BoxCount);
            CreateNpcs();
            CreateAsteroids(AsteroidCount);
            CreateUserFleet(UserFleetCount);
            CreateEnemyFleets(EnemyFleetCount);
            CreateMoons(MoonCount);

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
