using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using WoS.Fleet;
using WoS.map.Asteroids;
using WoS.map.Box;
using WoS.map.moon;
using WoS.map.Planet;
using WoS.map.Sun;
using WoS.npc;
using static WoS.Database.Database;

namespace WoS.map
{
    public class MapBase : ElementBase
    {
        #region MapElement Class

        /// <summary>
        /// Reprezentuje skupinu mapových prvků stejného typu.
        /// </summary>
        /// <typeparam name="T">Typ mapového prvku.</typeparam>
        public class MapElementGroup<T> where T : class
        {
            private Random _random;                                  // Generátor náhodných čísel.
            public List<T> ElementsList { get; set; }                    // Seznam mapových prvků v této skupině.
            public int Count => ElementsList.Count;                      // Vrací počet prvků v této skupině.
            public int[] TypeCount { get; set; }                     // Pole počtů prvků dle jejich typu.
            public Vector2[] Positions { get; set; }                 // Pole pozic jednotlivých prvků v této skupině.

            // Inicializuje novou instanci třídy MapElementGroup s danými hodnotami.
            public MapElementGroup(int[] typeCount, List<T> elements, Vector2[] positions)
            {
                TypeCount = typeCount;
                ElementsList = elements ?? new List<T>();
                Positions = positions ?? new Vector2[0];
            }
        }

        #endregion MapElement Class

        //   Database Db = new Database();
        // Atributy
        public int Id { get; set; }

        public int Status { get; set; }
        public Vector2 ImageSize { get; set; }

        // Textura pro pozadí mapy
        protected Texture2D backgroundTexture;

        // Rozměry mapy
        public float MapWidth { get; set; }  // Šířka mapy

        public float MapHeight { get; set; }  // Výška mapy

        private Random _random = new Random();
        // Rozměry mapy

        #region MapElementGroup List

        public MapElementGroup<SunBase> Suns { get; set; }
        public MapElementGroup<PlanetBase> Planets { get; set; }
        public MapElementGroup<BoxBase> Boxes { get; set; }
        public MapElementGroup<NpcBase> Npcs { get; set; }
        public MapElementGroup<AsteroidBase> Asteroids { get; set; }
        public MapElementGroup<FleetBase> UserFleets { get; set; }

        //   public MapElementGroup<EnemyFleets> EnemyFleets { get; set; }
        public MapElementGroup<MoonBase> Moons { get; set; }

        #endregion MapElementGroup List

        #region Count

        public int[] SunsTypeCount { get; set; } = new int[1];  // Například pro pole s 5 prvky// Počet planet na mapě
        public int[] PlanetsTypeCount { get; set; } = new int[10];// Počet planet na mapě
        public int[] BoxesTypeCount { get; set; } = new int[10];// Počet boxů na mapě
        public int[] NpcsTypeCount { get; set; } = new int[10];// Počet NPC na mapě
        public int[] OnlineShipsTypeCount { get; set; } = new int[10];// Počet online lodí na mapě
        public int[] AsteroidsTypeCount { get; set; } = new int[10];
        public int[] UserFleetsTypeCount { get; set; } = new int[1];

        //    public int[] EnemyFleetsTypeCount { get; set; } = new int[10];
        public int[] MoonsTypeCount { get; set; } = new int[10];

        #endregion Count

        #region Position

        public Vector2[] SunsPosition { get; set; }
        public Vector2[] PlanetsPosition { get; set; }
        public Vector2[] BoxesPosition { get; set; }
        public Vector2[] NpcsPosition { get; set; }
        public Vector2[] OnlineShipsPosition { get; set; }
        public Vector2[] AsteroidsPosition { get; set; }
        public Vector2[] UserFleetsPosition { get; set; }

        //  public Vector2[] EnemyFleetsPosition { get; set; }
        public Vector2[] MoonsPosition { get; set; }

        #endregion Position

        public ContentManager Content { get; set; }

        // Konstruktor
        public MapBase(int id, Vector2 position, ContentManager content)
        {
            Id = id;
            Position = position;
            Content = content;
        }

        // Ostatní metody

        #region Create

        public void create()
        {
            // vytvoření skupin pro jednotlivé prvky na mapě.
            Suns = new MapElementGroup<SunBase>(SunsTypeCount, new List<SunBase>(), SunsPosition);
            Planets = new MapElementGroup<PlanetBase>(PlanetsTypeCount, new List<PlanetBase>(), PlanetsPosition);
            Boxes = new MapElementGroup<BoxBase>(BoxesTypeCount, new List<BoxBase>(), BoxesPosition);
            Npcs = new MapElementGroup<NpcBase>(NpcsTypeCount, new List<NpcBase>(), NpcsPosition);
            Asteroids = new MapElementGroup<AsteroidBase>(AsteroidsTypeCount, new List<AsteroidBase>(), AsteroidsPosition);
            UserFleets = new MapElementGroup<FleetBase>(UserFleetsTypeCount, new List<FleetBase>(), UserFleetsPosition);
            //  EnemyFleets = new MapElementGroup<EnemyFleets>(EnemyFleetsTypeCount, new List<EnemyFleets>(), EnemyFleetsPosition);
            Moons = new MapElementGroup<MoonBase>(MoonsTypeCount, new List<MoonBase>(), MoonsPosition);

            // Vytvoření prvků mapy:

            // Slunce
            CreateSmallSun(SunsTypeCount[0]);            // Vytvoření malého slunce

            // Planety
            CreateDeathPlanets(PlanetsTypeCount[0]);        // Vytvoření planety typu "Death"
            CreateMuciPlanets(PlanetsTypeCount[1]);         // Vytvoření planety typu "Muci"

            // Boxíky
            CreateBlueBoxes(BoxesTypeCount[0]);           // Vytvoření modrého boxu
            CreaterRedBoxes(BoxesTypeCount[1]);           // Vytvoření červeného boxu

            // NPC postavy
            CreateStreunerNpcs(NpcsTypeCount[0]);        // Vytvoření NPC typu "Streuner"
            CreateLolitaNpcs(NpcsTypeCount[1]);          // Vytvoření NPC typu "Lolita"

            // Asteroidy
            CreateSmallAsteroids(AsteroidsTypeCount[0]);      // Vytvoření malého asteroidu

            // Flotily
            CreateUserFleet(UserFleetsTypeCount[0]);           // Vytvoření uživatelské flotily

            //   CreateEnemyFleets(EnemyFleetsTypeCount[0]);         // Vytvoření nepřátelské flotily

            // Měsíce
            CreateSmallMoons(MoonsTypeCount[0]);          // Vytvoření malého měsíce
        }

        #endregion Create

        public void create(MapConfigData configData)  //config z db
        {
            // Deserializujeme JSON řetězce z databáze
            var sunsList = JsonConvert.DeserializeObject<List<SunBase>>(configData.Suns);
            var planetsList = JsonConvert.DeserializeObject<List<PlanetBase>>(configData.Planets);
            var boxesList = JsonConvert.DeserializeObject<List<BoxBase>>(configData.Boxes);
            var npcsList = JsonConvert.DeserializeObject<List<NpcBase>>(configData.Npcs);
            var asteroidsList = JsonConvert.DeserializeObject<List<AsteroidBase>>(configData.Asteroids);
            var userFleetsList = JsonConvert.DeserializeObject<List<FleetBase>>(configData.UserFleets);
            //var enemyFleetsList = JsonConvert.DeserializeObject<List<EnemyFleets>>(configData.EnemyFleets);
            var moonsList = JsonConvert.DeserializeObject<List<MoonBase>>(configData.Moons);

            // vytvoření skupin pro jednotlivé prvky na mapě
            Suns = new MapElementGroup<SunBase>(SunsTypeCount, sunsList, SunsPosition);
            Planets = new MapElementGroup<PlanetBase>(PlanetsTypeCount, planetsList, PlanetsPosition);
            Boxes = new MapElementGroup<BoxBase>(BoxesTypeCount, boxesList, BoxesPosition);
            Npcs = new MapElementGroup<NpcBase>(NpcsTypeCount, npcsList, NpcsPosition);
            Asteroids = new MapElementGroup<AsteroidBase>(AsteroidsTypeCount, asteroidsList, AsteroidsPosition);
            UserFleets = new MapElementGroup<FleetBase>(UserFleetsTypeCount, userFleetsList, UserFleetsPosition);
            // EnemyFleets = new MapElementGroup<EnemyFleet>(EnemyFleetsTypeCount, enemyFleetsList, EnemyFleetsPosition);
            Moons = new MapElementGroup<MoonBase>(MoonsTypeCount, moonsList, MoonsPosition);

            // Vytvoření prvků mapy:

            // Slunce
            CreateSmallSun(SunsTypeCount[0]);            // Vytvoření malého slunce

            // Planety
            CreateDeathPlanets(PlanetsTypeCount[0]);        // Vytvoření planety typu "Death"
            CreateMuciPlanets(PlanetsTypeCount[1]);         // Vytvoření planety typu "Muci"

            // Boxíky
            CreateBlueBoxes(BoxesTypeCount[0]);           // Vytvoření modrého boxu
            CreaterRedBoxes(BoxesTypeCount[1]);           // Vytvoření červeného boxu

            // NPC postavy
            CreateStreunerNpcs(NpcsTypeCount[0]);        // Vytvoření NPC typu "Streuner"
            CreateLolitaNpcs(NpcsTypeCount[1]);          // Vytvoření NPC typu "Lolita"

            // Asteroidy
            CreateSmallAsteroids(AsteroidsTypeCount[0]);      // Vytvoření malého asteroidu

            // Flotily
            CreateUserFleet(UserFleetsTypeCount[0]);           // Vytvoření uživatelské flotily

            //    CreateEnemyFleets(EnemyFleetsTypeCount[0]);         // Vytvoření nepřátelské flotily

            // Měsíce
            CreateSmallMoons(MoonsTypeCount[0]);          // Vytvoření malého měsíce

            // Zde můžeš pokračovat ve vytváření prvků mapy na základě dat z databáze
            // ...
        }

        public void loadConfigFromDb(int idMap)
        {
            //    MapConfigData configData = db.GetMapConfigData(idMap);

            //    map.create(configData);
        }

        public void UpdateAll(GameTime gameTime)
        {
            UpdateElements(Suns);
            UpdateElements(Planets);
            UpdateElements(Boxes);
            UpdateElements(Npcs);
            UpdateElements(Asteroids);
            UpdateElements(UserFleets);
            //   UpdateElements(EnemyFleets);
            UpdateElements(Moons);
        }

        public void RenderAll(SpriteBatch spriteBatch)
        {
            RenderElements(spriteBatch, Suns);
            RenderElements(spriteBatch, Planets);
            RenderElements(spriteBatch, Boxes);
            RenderElements(spriteBatch, Npcs);
            RenderElements(spriteBatch, Asteroids);
            RenderElements(spriteBatch, UserFleets);
            //   RenderElements(spriteBatch, EnemyFleets);
            RenderElements(spriteBatch, Moons);
        }

        #region CreateElements

        public void CreateSmallSun(int piece)// 1 kus
        {
            CreateElements(Suns, piece, i => new SunSmall(i, SunsPosition[i], Content), "Suns");
        }

        public void CreateDeathPlanets(int piece)
        {
            CreateElements(Planets, piece, i => new PlanetDeath(i, PlanetsPosition[i], Content), "ArrayList_Planet");
        }

        public void CreateMuciPlanets(int piece)
        {
            CreateElements(Planets, piece, i => new PlanetDeath(i, PlanetsPosition[i], Content), "ArrayList_Planet");
        }

        public void CreateBlueBoxes(int piece)
        {
            CreateElements(Boxes, piece, i => new BlueBox(i, GenerateRandomPosition(), Content), "ArrayList_Box");
        }

        public void CreaterRedBoxes(int piece)
        {
            CreateElements(Boxes, piece, i => new RedBox(i, GenerateRandomPosition(), Content), "ArrayList_Box");
        }

        private int id = 0;

        public void CreateStreunerNpcs(int piece)
        {
            CreateElements(Npcs, piece, i => new NpcStreuner(i, GenerateRandomPosition(), Content), "ArrayList_Npcs");
        }

        public void CreateLolitaNpcs(int piece)
        {
            CreateElements(Npcs, piece, i => new NpcLolita(i, GenerateRandomPosition(), Content), "ArrayList_Npcs");
        }

        public void CreateSmallAsteroids(int piece)
        {
            CreateElements(Asteroids, piece, i => new SmallAsteroid(i, GenerateRandomPosition(), Content), "ArrayList_Asteroids");
        }

        public void CreateUserFleet(int piece)
        {
            CreateElements(UserFleets, piece, i => new UserFleet(i, UserFleetsPosition[i], Content), "ArrayList_UserFleet");
        }

        /*
public void CreateEnemyFleets(int piece)
{
  CreateElements(EnemyFleets, piece, i => new EnemyFleets(i, EnemyFleetsPosition[i], Content), "ArrayList_EnemyFleets");
}
        */

        public void CreateSmallMoons(int piece)
        {
            CreateElements(Moons, piece, i => new SmallMoon(i, GenerateRandomPosition(), Content), "ArrayList_Moons");
        }

        // Funkce pro vykreslení pozadí
        public void RenderBackeground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.White);
        }

        #endregion CreateElements

        #region Methods

        public override void Update()
        { }

        public override void Render(SpriteBatch spriteBatch)
        { }

        private void CreateElements<T>(MapElementGroup<T> group, int piece, Func<int, T> createElementFunc, string logName) where T : class
        {
            Console.WriteLine($"vytvarim {logName}");
            for (int i = 0; i < piece; i++)
            {
                group.ElementsList.Add(createElementFunc(i));
                Console.WriteLine($"pridavam {logName.ToLower()}: {i}");
            }
        }

        public void CreateElements<T>(MapElementGroup<T> group, Func<T> createElementFunc) where T : class
        {
            for (int i = 0; i < group.TypeCount.Length; i++)
            {
                int count = group.TypeCount[i];
                for (int j = 0; j < count; j++)
                {
                    group.ElementsList.Add(createElementFunc());
                }
            }
        }

        private Vector2 GenerateRandomPosition()
        {
            return new Vector2(
                _random.Next((int)(MapWidth / 10), (int)(MapWidth - MapWidth / 10)),
                _random.Next((int)(MapHeight / 10), (int)(MapHeight - MapHeight / 10))
            );
        }

        public void UpdateElements<T>(MapElementGroup<T> group) where T : ElementBase
        {
            foreach (var element in group.ElementsList)
            {
                element.Update();
            }
        }

        public void RenderElements<T>(SpriteBatch spriteBatch, MapElementGroup<T> group) where T : ElementBase
        {
            foreach (var element in group.ElementsList)
            {
                element.Render(spriteBatch);
            }
        }

        public Vector2[] InitializePositions(int count)
        {
            Vector2[] positions = new Vector2[count];
            for (int i = 0; i < count; i++)
            {
                positions[i] = new Vector2(_random.Next(0, (int)MapWidth), _random.Next(0, (int)MapHeight));
            }
            return positions;
        }

        #endregion Methods
    }
}