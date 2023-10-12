using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WoS.map.Box;
using WoS.map.Planet;
using WoS.map.Sun;
using WoS.npc;
using WoS.ship;

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


        public int SunCount { get; set; } // Počet planet na mapě
        public int PlanetCount { get; set; } // Počet planet na mapě
        public int BoxCount { get; set; } // Počet boxů na mapě
        public int NpcCount { get; set; } // Počet NPC na mapě
        public int OnlineShipCount { get; set; } // Počet online lodí na mapě
        // Konstruktor
        public MapBase(int id, Vector2 position)
        {

        }

        // Ostatní metody





        // Update metoda
        public void Update()
        {
            // ... (implementace)
            //aktualizace prvků na mapě

        }

        // Ostatní metody pro manipulaci s objekty na mapě
        public void CreateSun(int piece)
        {
            Console.WriteLine("vytvarim ArrayList_Sun");
            for (int i = 0; i < piece; i++)
            {
                ArrayList_Sun.Add(new SunSmall());
                Console.WriteLine($"pridavam planetu: {i}");
            }
        }

        // Metoda pro vytvoření planet.
        public void CreatePlanet(int piece)
        {
            Console.WriteLine("vytvarim ArrayList_Planety");
            for (int i = 0; i < piece; i++)
            {
                ArrayList_Planet.Add(new PlanetDeath(i));
                Console.WriteLine($"pridavam planetu: {i}");
            }
        }

        // Metoda pro vytvoření Boxů.
        public void CreateBox(int piece)
        {
            Console.WriteLine("vytvarim ArrayList_Box");
            for (int i = 0; i < piece; i++)
            {
                Vector2 BoxPosition = new Vector2(
                _random.Next((int)(MapWidth / 10), (int)(MapWidth - MapWidth / 10)),
                _random.Next((int)(MapHeight / 10), (int)(MapHeight - MapHeight / 10))

                                                                         );
                int BoxType = _random.Next(1, 4);
                ArrayList_Box.Add(new BoxBlue(BoxPosition, BoxType));
                Console.WriteLine($"log: new Box {ArrayList_Box.Count}");
            }
        }

        // Metoda pro vytvoření NPC postav.
        public void CreateNpc(int piece)
        {
            Console.WriteLine("vytvarim ArrayList_npc");
            for (int i = 0; i < piece; i++)
            {
                Vector2 position = new Vector2(
                    _random.Next((int)(MapWidth / 10), (int)(MapWidth - MapWidth / 10)),
                    _random.Next((int)(MapHeight / 10), (int)(MapHeight - MapHeight / 10))
                );
                ArrayList_Npc.Add(new NpcStreuner(position, 0, 0, "Streuner", i));
                Console.WriteLine($"pridavam npc: {i}");
            }
        }



        // Funkce pro vykreslení pozadí
        public void RenderBackeground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.White);

        }


        // Funkce pro vykreslení objektů Slunce
        public void RenderSun(SpriteBatch spriteBatch)
        {
            foreach (var slunce in ArrayList_Sun)
            {
                slunce.Render(spriteBatch);
            }
        }

        // Funkce pro vykreslení objektů Planeta
        public void RenderPlanet(SpriteBatch spriteBatch)
        {
            foreach (var planeta in ArrayList_Planet)
            {
                spriteBatch.Begin();  // Nahradí pushMatrix()
                planeta.Render(spriteBatch);
                spriteBatch.End();    // Nahradí popMatrix()

            }
        }

        // Funkce pro vykreslení objektů Box
        public void RenderBox(SpriteBatch spriteBatch)
        {
            foreach (var box in ArrayList_Box)
            {
                box.Render(spriteBatch);
            }
        }

        // Funkce pro aktualizaci a vykreslení objektů NPC
        public void RenderNpc(SpriteBatch spriteBatch)
        {
            foreach (var npc in ArrayList_Npc)
            
                npc.Render(spriteBatch);

            }
        }

    }
}