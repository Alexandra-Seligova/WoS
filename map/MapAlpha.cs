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
using WoS.Fleet;
using WoS.map.Asteroids;
using Microsoft.Xna.Framework.Content;

namespace WoS.map
{
    public class MapAlpha : MapBase
    {

        private Random _random = new Random();
        // Konstruktor pro MapAlpha s předdefinovanými hodnotami
        public MapAlpha( int id, Vector2 position, ContentManager content)
        : base(id, position, content)
        {

            backgroundTexture = Content.Load<Texture2D>("maps/background/map1");     // Načtení textury pro mapu;


            Id = id;
            Status = 1;
            Position = position;

            Width = 10000;
            Height = 10000;
            MapWidth = Width;
            MapHeight = Height;

            Config();
            LoadConfigFromDb();
            create();
            //create(JSON); //Načtení a vytvoření z Json souboru z DB

            // Nastavení pozice mapy na (0,0)
            this.Position = new Vector2(0, 0);

            // Zde můžete přidat další konkrétní nastavení pro MapAlpha, pokud je potřebujete



        }
        public void Config()
        {
            SunsTypeCount[0] = 1;
            PlanetsTypeCount[0] = 4;
            PlanetsTypeCount[1] = 10;

            BoxesTypeCount[0] = 10;
            BoxesTypeCount[1] = 10;
            NpcsTypeCount[0] = 10;
            NpcsTypeCount[1] = 10;

            //OnlineShipsCount=
            AsteroidsTypeCount[0] = 10;
            UserFleetsTypeCount[0] = 1;
            //EnemyFleetsTypeCount[0] = 0;
            MoonsTypeCount[0] = 10;



            SunsPosition = new[] { new Vector2(MapWidth / 2, MapHeight / 2) };
            PlanetsPosition = InitializePositions(PlanetsTypeCount.Sum());
            BoxesPosition = InitializePositions(BoxesTypeCount.Sum());
            NpcsPosition = InitializePositions(NpcsTypeCount.Sum());
            AsteroidsPosition = InitializePositions(AsteroidsTypeCount.Sum());
            UserFleetsPosition = InitializePositions(UserFleetsTypeCount.Sum());
            //EnemyFleetsPosition = InitializePositions(EnemyFleetsTypeCount.Sum());
            MoonsPosition = InitializePositions(MoonsTypeCount.Sum());


        }


        public void LoadConfigFromDb()
        {
            //nastavení pro celou mapu načtené z db
            //create(JSON); //Načtení a vytvoření z Json souboru z DB
        }

        public void UpdateMap(GameTime gameTime)
        {
            // Aktualizace jednotlivých prvků hry
            UpdateAll(gameTime);

        }

        // Metoda pro vykreslení mapy
        public void DrawMap(SpriteBatch spriteBatch)
        {
            // Vykreslení jednotlivých prvků hry
            RenderBackeground(spriteBatch);
            RenderAll(spriteBatch);


        }
    }
}
