using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WoS.Utility;

namespace WoS.ship
{


    // Základní třída pro všechny lodě
    // Tato třída obsahuje základní charakteristiky lodě, jako je zdraví, štíty, rychlost, pozice, rotace, atd.
    // Dále obsahuje seznamy pro jednotlivé moduly, jako jsou kanóny, generátory, atd.
    // Tato třída obsahuje také metody pro pohyb lodě, střelbu, atd.

    /*
 *** Přehled vlastností a metod třídy ElementBase ***
         Texture2D Texture          // Textura pro objekt
         Vector2 Position           // Základní vlastnost pozice
         Vector2 PositionOnMap      // Globální pozice objektu na mapě
         Vector2 PositionOnScreen   // Místní pozice objektu na obrazovce
         float   Rotation           // Rotace objektu v prostoru
         int     Width              // Šířka objektu
         int     Height             // Výška objektu

        // Vlastnosti zdraví a štítu
         float Hp                   // Aktuální zdraví objektu
         float HpMax                // Maximální zdraví objektu
         float Shield               // Aktuální hodnota štítu objektu
         float ShieldMax            // Maximální hodnota štítu objektu


*** Přehled vlastností a metod třídy MovementBase ***

         Texture2D
         string     Designation      // Název či označení lodi
         float      Rotation
         Vector2    Velocity         // Aktuální rychlost lodi
         float      Acceleration     // Zrychlení lodi
         int        MaxSpeed         // Maximální rychlost lodi
         float      ShipWidth        // Šířka lodi
         float      ShipHeight       // Výška lodi
         Vector2    Target           // Cíl lodi pro pohyb
         Vector2    SpawnPlace       // Místo, kde se loď objevila

         // metody
         bool       IsCollidingWith(ElementBase other)
*/
    public abstract class ShipBase : MovementBase
    {

        // Moduly a vybavení lodě
        public int generatorsNumber;                // Počet doplňků (standardní moduly)
        public int weaponsNumber;                 // Počet zbraní (útočné moduly)
        public Vector2[] kanony = new Vector2[6];   // Pozice kanónů
        public Vector2[] dela = new Vector2[2];     // Pozice del
        public Vector2[] generatory = new Vector2[6]; // Pozice generátorů
        public Vector2[] doplnky = new Vector2[6];  // Pozice doplňků

        // Ostatní
        public bool prvni_spusteni = true;     // Pro nastavení prvního statusu
        public string msg;                     // Zpráva
        public int seq;                        // Sekvenční číslo
        public int casOmezovac = 0;            // Časový omezovač

        // Seznamy pro různé komponenty lodě
        // List<Kanon> kanonyList;         // Seznam kanónů lodě
        // List<Munice> municeList;        // Seznam munice lodě
        // List<Anime> animaceList;        // Seznam animací lodě


        public ShipBase(ContentManager content, Vector2 startPosition)
        : base() // Volání konstruktoru z třídy ElementBase pro nastavení pozice
        {
        }

        public void SetTarget(Vector2 newTarget)
        {
            Target = newTarget;
        }
        // Výpočet rotace lodi směrem k cíli
        public void UpdateRotation()
        {
            Vector2 direction = Target - PositionOnMap;
            Rotation = (float)Math.Atan2(direction.Y, direction.X) + MathHelper.PiOver2; // +PiOver2, protože chceme, aby vrch lodi byl směrován k cíli
        }
        public void SetMouseTarget(Vector2 mousePosition, Vector2 screenSize, Vector2 cameraPosition)
        {
            // Převede místní pozici myši na obrazovce na globální pozici na mapě
            Vector2 globalMousePosition = mousePosition + cameraPosition - (screenSize * 0.5f);

            Target = globalMousePosition;
            Rotation = (float)Math.Atan2(Target.Y - PositionOnMap.Y, Target.X - PositionOnMap.X) + MathHelper.PiOver2;
        }

        public void Update(GameTime gameTime)
        {
            if (Vector2.Distance(PositionOnMap, Target) > 1.0f)  // Pokud je loď dostatečně daleko od cíle
            {
                Vector2 direction = Vector2.Normalize(Target - PositionOnMap);
                Vector2 velocity = direction * MaxSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                PositionOnMap += velocity;

                // Pokud je loď velmi blízko cíli, nastavte její pozici přímo na cíl
                if (Vector2.Distance(PositionOnMap, Target) < MaxSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds)
                {
                    PositionOnMap = Target;
                }
            }
        }
        // Upravená metoda pro vykreslení
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), 1.0f, SpriteEffects.None, 0);
        }





    }
}
