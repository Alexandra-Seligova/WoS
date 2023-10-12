using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WoS.map.Asteroids;
using WoS.map.Box;
using WoS.map.moon;
using WoS.map.Planet;
using WoS.map.Sun;
using WoS.npc;
using WoS.ship;
using WoS.Utility;
using WoS.Fleets;

namespace WoS.map
{
    public class MapBase : ElementBase
    {

             // Atributy
        public int Id { get; set; }
        public int Stav { get; set; }
        public Vector2 ImageSize { get; set; }


        // Textura pro pozadí mapy
        protected Texture2D backgroundTexture;

        // Rozměry mapy
        public float MapWidth { get; set; }  // Šířka mapy
        public float MapHeight { get; set; }  // Výška mapy

        private Random _random = new Random();
        // Rozměry mapy

        // Ostatní běžné atributy
        public string Name { get; set; }  // Jméno nebo název mapy
        public string Description { get; set; } // Popis nebo krátký přehled o mapě
        public List<SunBase> ArrayList_Sun { get;  set; }
        public List<PlanetBase> ArrayList_Planet { get;  set; }
        public List<BoxBase> ArrayList_Box { get;  set; }
        public List<NpcBase> ArrayList_Npc { get;  set; }
        public List<AsteroidBase> ArrayList_Asteroids { get; set; }
        public List<UserFleet> ArrayList_UserFleet { get; set; }
        public List<EnemyFleet> ArrayList_EnemyFleets { get; set; }
        public List<MoonBase> ArrayList_Moons { get; set; }


        public int SunCount { get; set; } // Počet planet na mapě
        public int PlanetCount { get; set; } // Počet planet na mapě
        public int BoxCount { get; set; } // Počet boxů na mapě
        public int NpcCount { get; set; } // Počet NPC na mapě
        public int OnlineShipCount { get; set; } // Počet online lodí na mapě
        public int AsteroidCount { get; set; }
        public int UserFleetCount { get; set; }
        public int EnemyFleetCount { get; set; }
        public int MoonCount { get; set; }
        // Konstruktor
        public MapBase(int id, Vector2 position)
        {

        }

        // Ostatní metody



        public override void Render(SpriteBatch spriteBatch)
        {
            RenderBackeground(spriteBatch);
            RenderAll(spriteBatch);
        }

        // Update metoda
        public override void Update()
        {

        }


        public void CreateSun(int piece)
        {
            CreateElements(ArrayList_Sun, piece, i => new SunSmall(), "ArrayList_Sun");
        }

        public void CreatePlanet(int piece)
        {
            CreateElements(ArrayList_Planet, piece, i => new PlanetDeath(i), "ArrayList_Planet");
        }

        public void CreateBox(int piece)
        {
            CreateElements(ArrayList_Box, piece, i => new BoxBlue(GenerateRandomPosition(), _random.Next(1, 4)), "ArrayList_Box");
        }

        public void CreateNpc(int piece)
        {
            CreateElements(ArrayList_Npc, piece, i => new NpcStreuner(i, GenerateRandomPosition()), "ArrayList_Npc");
        }

        public void CreateAsteroids(int piece)
        {
            CreateElements(ArrayList_Asteroids, piece, i => new SmallAsteroid(GenerateRandomPosition()), "ArrayList_Asteroids");
        }

        public void CreateUserFleet(int piece)
        {
            CreateElements(ArrayList_UserFleet, piece, i => new UserFleet(), "ArrayList_UserFleet");
        }

        public void CreateEnemyFleets(int piece)
        {
            CreateElements(ArrayList_EnemyFleets, piece, i => new EnemyFleet(), "ArrayList_EnemyFleets");
        }

        public void CreateMoons(int piece)
        {
            CreateElements(ArrayList_Moons, piece, i => new SmallMoon(GenerateRandomPosition()), "ArrayList_Moons");
        }

        // Funkce pro vykreslení pozadí
        public void RenderBackeground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.White);

        }


        public void RenderAll(SpriteBatch spriteBatch)
        {
            RenderElements(spriteBatch, ArrayList_Sun);
            RenderElements(spriteBatch, ArrayList_Planet);
            RenderElements(spriteBatch, ArrayList_Box);
            RenderElements(spriteBatch, ArrayList_Npc);
            RenderElements(spriteBatch, ArrayList_Asteroids);
            RenderElements(spriteBatch, ArrayList_UserFleet);
            RenderElements(spriteBatch, ArrayList_EnemyFleets);
            RenderElements(spriteBatch, ArrayList_Moons);
        }

        private void CreateElements<T>(List<T> list, int piece, Func<int, T> createElementFunc, string logName)
        {
            Console.WriteLine($"vytvarim {logName}");
            for (int i = 0; i < piece; i++)
            {
                list.Add(createElementFunc(i));
                Console.WriteLine($"pridavam {logName.ToLower()}: {i}");
            }
        }

        private Vector2 GenerateRandomPosition()
        {
            return new Vector2(
                _random.Next((int)(MapWidth / 10), (int)(MapWidth - MapWidth / 10)),
                _random.Next((int)(MapHeight / 10), (int)(MapHeight - MapHeight / 10))
            );
        }

        public void RenderElements<T>(SpriteBatch spriteBatch, List<T> elements) where T : ElementBase
        {
            foreach (var element in elements)
            {
                element.Render(spriteBatch);
            }
        }

    }
}