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


    // Základní třída pro všechny lodě
    // Tato třída obsahuje základní charakteristiky lodě, jako je zdraví, štíty, rychlost, pozice, rotace, atd.
    // Dále obsahuje seznamy pro jednotlivé moduly, jako jsou kanóny, generátory, atd.
    // Tato třída obsahuje také metody pro pohyb lodě, střelbu, atd.
    public abstract class ShipBase
    {
        protected Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Target { get; set; }
        public float Speed { get; set; }

        //*************************************

        // Základní charakteristiky lodě
        public string oznaceni;                // Označení lodě
        public Vector2 pozice;                 // Pozice lodě
        public float rotace;                   // Rotace lodě v prostoru
        public Texture2D obrazek;              // Obrazek lodě

        // Fyzikální parametry lodě
        public Vector2 rychlost;               // Aktuální rychlost lodě
        public float zrychleni = 50;           // Zrychlení lodě
        public int speed;                      // Rychlost lodě

        // Velikost lodě
        public float velikost_sirka;           // Šířka lodě
        public float velikost_vyska;           // Výška lodě

        // Zdraví a štíty lodě
        public float hp;                       // Aktuální zdraví (strukturální integrita) lodě
        public float max_hp;                   // Maximální zdraví lodě
        public float shield;                   // Aktuální hodnota štítu lodě
        public float max_shield;               // Maximální hodnota štítu lodě

        // Cílová pozice a stav přenosu
        public Vector2 cil;                    // Cílová pozice pro pohyb lodě
        bool tran = false;              // Stav přenosu
        public bool budeTran = false;          // Bude probíhat přenos?
        public bool jeTran = false;            // Probíhá právě přenos?
        public bool konecTran = true;          // Přenos skončil?
        public bool sebrano = false;           // Bylo něco sebráno?

        // Moduly a vybavení lodě
        public int generatorsNumber;                // Počet doplňků (standardní moduly)
        public int weaponsNumber;                 // Počet zbraní (útočné moduly)
        public Vector2[] kanony = new Vector2[6];   // Pozice kanónů
        public Vector2[] dela = new Vector2[2];     // Pozice del
        public Vector2[] generatory = new Vector2[6]; // Pozice generátorů
        public Vector2[] doplnky = new Vector2[6];  // Pozice doplňků



        // Seznamy pro různé komponenty lodě
        // List<Kanon> kanonyList;         // Seznam kanónů lodě
        // List<Munice> municeList;        // Seznam munice lodě
        // List<Anime> animaceList;        // Seznam animací lodě

        // Ostatní
        public bool prvni_spusteni = true;     // Pro nastavení prvního statusu
        public string msg;                     // Zpráva
        public int seq;                        // Sekvenční číslo
        public int casOmezovac = 0;            // Časový omezovač
        public ShipBase(Texture2D shipTexture, Vector2 startPosition, float speed)
        {

        }

        public void SetTarget(Vector2 newTarget)
        {
            Target = newTarget;
        }
        // Výpočet rotace lodi směrem k cíli
        public void UpdateRotation()
        {
            Vector2 direction = Target - Position;
            rotace = (float)Math.Atan2(direction.Y, direction.X) + MathHelper.PiOver2; // +PiOver2, protože chceme, aby vrch lodi byl směrován k cíli
        }
        public void SetMouseTarget(Vector2 mousePosition, Vector2 screenSize, Vector2 cameraPosition)
        {
            // Převede místní pozici myši na obrazovce na globální pozici na mapě
            Vector2 globalMousePosition = mousePosition + cameraPosition - (screenSize * 0.5f);

            Target = globalMousePosition;
            rotace = (float)Math.Atan2(Target.Y - Position.Y, Target.X - Position.X) + MathHelper.PiOver2;
        }

        public void Update(GameTime gameTime)
        {
            if (Vector2.Distance(Position, Target) > 1.0f)  // Pokud je loď dostatečně daleko od cíle
            {
                Vector2 direction = Vector2.Normalize(Target - Position);
                Vector2 velocity = direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position += velocity;

                // Pokud je loď velmi blízko cíli, nastavte její pozici přímo na cíl
                if (Vector2.Distance(Position, Target) < Speed * (float)gameTime.ElapsedGameTime.TotalSeconds)
                {
                    Position = Target;
                }
            }
        }
        // Upravená metoda pro vykreslení
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, rotace, new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0);
        }





    }
}
