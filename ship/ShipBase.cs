using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WoS.ship.components.extensions.generators;
using WoS.ship.components.extensions.ShipExtensions;
using WoS.ship.components.extensions.weapons;

namespace WoS.ship
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Intrinsics.Arm;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using WoS.ammunition;
    using WoS.Animation;

    public abstract class ShipBase : MovementBase
    {
        // Moduly a vybavení lodě
        public int GeneratorsCount => Generators?.Count ?? 0; // Počet doplňků (standardní moduly)
        public int WeaponsCount => Canons?.Count ?? 0; // Počet zbraní (útočné moduly)
        public int ExtensionsCount => Extensions?.Count ?? 0; // Počet rozšíření (defenzivní moduly)

        public int AmmosCount => Ammos?.Count ?? 0;
        public int AnimationsCount => Animations?.Count ?? 0;

        // Ostatní
        public bool FirstRun { get; set; } = true; // Pro nastavení prvního statusu
        public string Message { get; set; } // Zpráva
        public int Seq { get; set; } // Sekvenční číslo

        // Seznamy modulů a dalších komponent
        public List<WeaponBase> Canons { get; set; } // canons, ArrayList_Kanony
        public List<GeneratorBase> Generators { get; set; } // generators
        public List<ShipExtensions1> Extensions { get; set; } // extensions
        public List<AmmunitionBase> Ammos { get; set; } // ArrayList_Munice
        public List<EffectBase> Animations { get; set; } // ArrayList_Animace

        // Pozice modulů
        public Vector2[] WeaponsPosition { get; set; } // WeaponsPosition
        public Vector2[] GeneratorsPosition { get; set; } // GeneratorsPosition
        public Vector2[] ExtensionsPosition { get; set; } // ExtensionsPosition

        // Konstruktor
        public ShipBase(ContentManager content, Vector2 startPosition)
            : base() // Volání konstruktoru z třídy ElementBase pro nastavení pozice
        {
            PositionOnMap = startPosition;
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
            if(Vector2.Distance(PositionOnMap, TargetPosition) > 1.0f)  // Pokud je loď dostatečně daleko od cíle
            {
                Vector2 direction = Vector2.Normalize(TargetPosition - PositionOnMap);
                Vector2 velocity = direction * MaxSpeed * (float)0.01;
                PositionOnMap += velocity;

                // Pokud je loď velmi blízko cíli, nastavte její pozici přímo na cíl
                if(Vector2.Distance(PositionOnMap, TargetPosition) < MaxSpeed * 0.01)
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
            switch(type)
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
            float actualRotation = Rotation;
            Vector2 actualShipPosition = PositionOnMap;
            Vector2 actualTarget = TargetPosition;

            for(int i = 0; i < Canons.Count; i++)
            {
                if(Canons[i] != null)
                {
                    Canons[i].Update(actualShipPosition, actualRotation, actualTarget);
                }
            }

            for(int i = 0; i < Generators.Count; i++)
            {
                if(Generators[i] != null)
                {
                    Generators[i].Update(actualShipPosition, actualRotation, actualTarget);
                }
            }

            for(int i = 0; i < ExtensionsCount; i++)
            {
                if(Extensions[i] != null)
                {
                    Extensions[i].Update(actualShipPosition, actualRotation, actualTarget);
                }
            }

            for(int i = 0; i < AmmosCount; i++)
            {
                if(Ammos[i] != null)
                {
                    Ammos[i].Update(actualShipPosition, actualRotation, actualTarget);
                }
            }

            for(int i = 0; i < AnimationsCount; i++)
            {
                if(Animations[i] != null)
                {
                    Animations[i].Update(actualShipPosition, actualRotation, actualTarget);
                }
            }


        }
    }

}

/*

   */