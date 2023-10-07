using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WoS.ship
{
    public class ShipBase
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Target { get; set; }
        public float Speed { get; set; }

        //*************************************

        // Základní charakteristiky lodě
        string oznaceni;                // Označení lodě
        Vector2 pozice;                 // Pozice lodě
        float rotace;                   // Rotace lodě v prostoru
        Texture2D obrazek;              // Obrazek lodě

        // Fyzikální parametry lodě
        Vector2 rychlost;               // Aktuální rychlost lodě
        float zrychleni = 50;           // Zrychlení lodě
        int speed;                      // Rychlost lodě

        // Velikost lodě
        float velikost_sirka;           // Šířka lodě
        float velikost_vyska;           // Výška lodě

        // Zdraví a štíty lodě
        float hp;                       // Aktuální zdraví (strukturální integrita) lodě
        float max_hp;                   // Maximální zdraví lodě
        float shield;                   // Aktuální hodnota štítu lodě
        float max_shield;               // Maximální hodnota štítu lodě

        // Cílová pozice a stav přenosu
        Vector2 cil;                    // Cílová pozice pro pohyb lodě
        bool tran = false;              // Stav přenosu
        bool budeTran = false;          // Bude probíhat přenos?
        bool jeTran = false;            // Probíhá právě přenos?
        bool konecTran = true;          // Přenos skončil?
        bool sebrano = false;           // Bylo něco sebráno?

        // Moduly a vybavení lodě
        int doplnky_poc;                // Počet doplňků (standardní moduly)
        int zbrane_poc;                 // Počet zbraní (útočné moduly)
        Vector2[] kanony = new Vector2[6];   // Pozice kanónů
        Vector2[] dela = new Vector2[2];     // Pozice del
        Vector2[] generatory = new Vector2[6]; // Pozice generátorů
        Vector2[] doplnky = new Vector2[6];  // Pozice doplňků



        // Seznamy pro různé komponenty lodě
       // List<Kanon> kanonyList;         // Seznam kanónů lodě
       // List<Munice> municeList;        // Seznam munice lodě
       // List<Anime> animaceList;        // Seznam animací lodě

        // Ostatní
        bool prvni_spusteni = true;     // Pro nastavení prvního statusu
        string msg;                     // Zpráva
        int seq;                        // Sekvenční číslo
        int casOmezovac = 0;            // Časový omezovač
        public ShipBase(Texture2D shipTexture, Vector2 startPosition, float speed)
        {
            // Zdraví a rychlost lodě
             hp = 700;
             speed = 500;
            // Moduly a vybavení lodě
             doplnky_poc = 2;
             zbrane_poc = 2;

            // Pozice jednotlivých modulů na lodi
            Vector2 kan1 = new Vector2(-18, -21);
            Vector2 kan2 = new Vector2(18, -21);
            Vector2 gen1 = new Vector2(0, 20);
            Vector2 doplnky1 = new Vector2(-10, -11);
            Vector2 doplnky2 = new Vector2(10, -11);



            texture = shipTexture;
            Position = startPosition;
            Speed = speed;
            Target = startPosition;
        }

        public void SetTarget(Vector2 newTarget)
        {
            Target = newTarget;
        }

        public void Update(GameTime gameTime)
        {
            if (Position != Target)
            {
                Vector2 direction = Vector2.Normalize(Target - Position);
                Position += direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Pokud jsme blízko cíle, nastavíme pozici přímo na cíl, aby se loď nepřesouvala zpět a dopředu.
                if (Vector2.Distance(Position, Target) < Speed * (float)gameTime.ElapsedGameTime.TotalSeconds)
                {
                    Position = Target;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
