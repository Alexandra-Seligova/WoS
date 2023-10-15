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
using Microsoft.Xna.Framework.Content;

namespace WoS.map
{
    public class MapAlpha : MapBase
    {

        private Random _random = new Random();
        // Konstruktor pro MapAlpha s předdefinovanými hodnotami
        public MapAlpha(Texture2D backgroundImage, int id, Vector2 position, ContentManager content)
        : base(id, position, content)
        {
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

            backgroundTexture = backgroundImage;

            // Nastavení pozice mapy na (0,0)
            this.Position = new Vector2(0, 0);

            // Zde můžete přidat další konkrétní nastavení pro MapAlpha, pokud je potřebujete

        }
        public void Config()
        {
            SunsCount[0] = 1;
            PlanetsCount[0] = 4;
            PlanetsCount[1] = 10;

            BoxesCount[0] = 10;
            BoxesCount[1] = 10;
            NpcsCount[0] = 10;
            NpcsCount[1] = 10;

            //OnlineShipsCount=
            AsteroidsCount[0] = 10;
            UserFleetsCount[0] = 1;
            EnemyFleetsCount[0] = 10;
            MoonsCount[0] = 10;



            SunsPosition = new[] { new Vector2(MapWidth / 2, MapHeight / 2) };
            PlanetsPosition = InitializePositions(PlanetsCount.Sum());
            BoxesPosition = InitializePositions(BoxesCount.Sum());
            NpcsPosition = InitializePositions(NpcsCount.Sum());
            AsteroidsPosition = InitializePositions(AsteroidsCount.Sum());
            UserFleetsPosition = InitializePositions(UserFleetsCount.Sum());
            EnemyFleetsPosition = InitializePositions(EnemyFleetsCount.Sum());
            MoonsPosition = InitializePositions(MoonsCount.Sum());


        }


        public void LoadConfigFromDb()
        {
            //nastavení pro celou mapu načtené z db

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
