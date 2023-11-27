using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WoS.ship.components.extensions.weapons;
using WoS.Utility;
using WoS.ship.components.extensions.generators;
using WoS.ship.components.extensions.ShipExtensions;
using WoS.ship.components.extensions.weapons;





namespace WoS.ship
{


    public abstract class ShipBase : MovementBase
    {

        // Moduly a vybavení lodě
        public int generatorsNumber;                // Počet doplňků (standardní moduly)
        public int weaponsNumber;                 // Počet zbraní (útočné moduly)
        public int extensionsNumber;              // Počet rozšíření (defenzivní moduly)

        // Ostatní
        public bool prvni_spusteni = true;     // Pro nastavení prvního statusu
        public string msg;                     // Zpráva
        public int seq;                        // Sekvenční číslo
        public int casOmezovac = 0;            // Časový omezovač

        // Seznamy pro různé komponenty lodě
        // List<Kanon> kanonyList;         // Seznam kanónů lodě
        // List<Munice> municeList;        // Seznam munice lodě
        // List<Anime> animaceList;        // Seznam animací lodě
      

        public List<WeaponBase> canons;
        public List<GeneratorBase> generators;
        public List<ShipExtensions1> extensions;



        public Vector2[] WeaponsPosition;
        public Vector2[] GeneratorsPosition;
        public Vector2[] ExtensionsPosition;


        public ShipBase(ContentManager content, Vector2 startPosition)
        : base() // Volání konstruktoru z třídy ElementBase pro nastavení pozice
        {
        }

        public void SetTargetPosition(Vector2 newTarget)
        {
            TargetPosition = newTarget;
        }

        public void SetShipPosition(Vector2 newPosition)
        {
            PositionOnMap = newPosition;
            SetTargetPosition(newPosition);
        }

        // Výpočet rotace lodi směrem k cíli
        public void UpdateRotation()
        {
            Vector2 direction = TargetPosition - PositionOnMap;
            Rotation = (float)Math.Atan2(direction.Y, direction.X) + MathHelper.PiOver2; // +PiOver2, protože chceme, aby vrch lodi byl směrován k cíli
        }
        public void SetMouseTarget(Vector2 mousePosition, Vector2 screenSize, Vector2 cameraPosition)
        {
            // Převede místní pozici myši na obrazovce na globální pozici na mapě
            Vector2 globalMousePosition = mousePosition + cameraPosition - (screenSize * 0.5f);

            TargetPosition = globalMousePosition;
            Rotation = (float)Math.Atan2(TargetPosition.Y - PositionOnMap.Y, TargetPosition.X - PositionOnMap.X) + MathHelper.PiOver2;
        }

        public override void Update()
        {

            if (Vector2.Distance(PositionOnMap, TargetPosition) > 1.0f)  // Pokud je loď dostatečně daleko od cíle
            {
                Vector2 direction = Vector2.Normalize(TargetPosition - PositionOnMap);
                Vector2 velocity = direction * MaxSpeed * (float)0.01;
                //Vector2 velocity = direction * MaxSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                PositionOnMap += velocity;

                // Pokud je loď velmi blízko cíli, nastavte její pozici přímo na cíl
                if (Vector2.Distance(PositionOnMap, TargetPosition) < MaxSpeed * 0.01)
                // if (Vector2.Distance(PositionOnMap, Target) < MaxSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds)
                {
                    PositionOnMap = TargetPosition;
                }
            }

            UpdateShipExtensions();


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), 1.0f, SpriteEffects.None, 0);
        }

        public Vector2 GetPositionOnShip(string type, int number)
        {
            switch (type)
            {
                case "Weapon":
                    return WeaponsPosition[number];
                case "Generator":
                    return GeneratorsPosition[number];
                case "Extension":
                    return ExtensionsPosition[number];
                default:
                    throw new ArgumentException("Neplatný typ komponenty");
            }
        }


        public void UpdateShipExtensions()
        {
            float atualRotation = Rotation;
            Vector2 actualShipPosition = PositionOnMap;
            Vector2 actualTarget = TargetPosition;

            for (int i = 0; i < canons.Count; i++)
            {
                if (canons[i] != null)
                {
                    canons[i].Update(actualShipPosition, atualRotation, actualTarget);
                }
            }

            for (int i = 0; i < generators.Count; i++)
            {
                if (generators[i] != null)
                {
                    generators[i].Update(actualShipPosition, atualRotation, actualTarget);
                }
            }

            for (int i = 0; i < extensions.Count; i++)
            {
                if (extensions[i] != null)
                {
                    extensions[i].Update(actualShipPosition, atualRotation, actualTarget);
                }
            }






        }


    }
}
