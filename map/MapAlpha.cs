using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Numerics;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.map
{
    /*
    public class MapAlpha
    {
        public int Id { get; set; }
        public int Stav { get; set; }
        public float Sirka { get; set; }
        public float Vyska { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 ImageSize { get; set; }  // Xvel, Yvel in original
        public string L1 { get; set; }
        // ... [Other Properties]
        public int PocetNpc { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int PocetPlanet { get; set; }
        public int PocBoxu { get; set; }
        public int PocAsteroidu { get; set; }
        public int CasOmezovac { get; set; }

        public int NpcOznaceni { get; set; }
        public Vector2 NpcPozice { get; set; }
        public float NpcRotace { get; set; }

        public int BoxOznaceni { get; set; }
        public Vector2 BoxPozice { get; set; }

        private List<Slunce> ArrayList_Slunce;
        private List<Planeta> ArrayList_Planety;
        private List<Box> ArrayList_Box;
        private List<AL_lod> ArrayList_npc;
        private List<Ship_online> ArrayList_Online_Ship;
        private List<Kanon_online> ArrayList_Kanony;
        private List<Munice> ArrayList_Munice;
        private List<Anime> ArrayList_Animace;

        private Ship ship; // Předpokládám, že třída 'Ship' je definovaná někde jinde ve vašem kódu
        private float width; // Toto by měla být šířka okna, měli byste ji nastavit při inicializaci
        private float height; // Toto by měla být výška okna, měli byste ji nastavit při inicializaci


        public Mapa(int id, Vector2 position, int oznSektor, float sirka, float vyska)
        {
            L1 = "Streuner";
            Id = id;
            Sirka = sirka;
            Vyska = vyska;
            Position = position;

            Config();
            Vytvorit();
        }

        private void Config()
        {
            pocet_planet = 54;
            pocBoxu = 6;       // 1 box na 1000p čtverečních
            pocAsteroidu = 10; // 1 asteroid na 2000p čtverečních

            Xvel = 1920 * 2;
            Yvel = 1080 * 2;
        }
        public void Vytvorit()
        {
            Console.WriteLine("log: mapa vytvořit");

            ArrayList_Slunce = new List<Slunce>();
            ArrayList_Planety = new List<Planeta>();
            ArrayList_Box = new List<Box>();
            ArrayList_npc = new List<AL_lod>();
            ArrayList_Online_Ship = new List<Ship_online>();
            ArrayList_Kanony = new List<Kanon_online>();
            ArrayList_Munice = new List<Munice>();
            ArrayList_Animace = new List<Anime>();

            VytvorSlunce();
            VytvorPlaneta();
            VytvorNPC();
            VytvorShipOnline();
            VytvorKanon(10);

            Console.WriteLine("log: mapa vytvořit - konec");
        }

        public void Update()
        {
            // Inkrementace časového omezovače
            casOmezovac++;

            // Výpočet pozice na základě pozice lodi
            x = (ship.pozice.x - width / 2) - ((ship.pozice.x / sirka) * (Xvel - width));
            y = (ship.pozice.y - height / 2) - ((ship.pozice.y / vyska) * (Yvel - height));

            // udrzovani();
        }

        public void Render(SpriteBatch spriteBatch)
        {
            // Aktualizace herních hodnot před vykreslením
            update();


            // Vykreslení jednotlivých prvků hry
            render_Pozadi();
            renderSlunce();
            renderPlaneta();
            renderBox();
            renderNPC();
            renderShipOnline();
            renderKanon();
            renderMunice();
            renderAnimace();

        }

        public void ResetMapa()
        {
            // Lokální proměnné pro pozici
            int pozX, pozY;

            // Vytvoření nového seznamu pro NPC postavy
            Console.WriteLine("vytvarim ArrayList_npc");
            ArrayList_npc = new List<AL_lod>();

            // Vytvoření a přidání NPC postav do seznamu
            for (int i = 0; i < G_pocet_npc; i++)
            {
                pozX = Random.Next(100, (int)mapSirka - 100); // Předpokládá se, že máte instance třídy Random nazvané "Random"
                pozY = Random.Next(100, (int)mapSirka - 100);

                ArrayList_npc.Add(new AL_lod(new Vector2(pozX, pozY), 0, 0, "Streuner", i));
                // Poznámka: Funkce SQL_makeMapa_NPC je volána zde, ale její implementace není v poskytnutém kódu
                SQL_makeMapa_NPC(i, 1, 1, pozX, pozY);
                Console.WriteLine($"pridavam npc: {i}");
            }

            // Vytvoření nového seznamu pro Planety
            Console.WriteLine("vytvarim ArrayList_Planety");
            ArrayList_Planety = new List<Planeta>();

            // Vytvoření a přidání Planet do seznamu
            for (int i = 0; i < G_pocet_planet; i++)
            {
                ArrayList_Planety.Add(new Planeta(i));
                Console.WriteLine($"pridavam planetu: {i}");
            }
        }


    }*/
}
