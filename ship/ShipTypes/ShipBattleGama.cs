﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WoS.ship.components.extensions.generators;
using WoS.ship.components.extensions.ShipExtensions;
using WoS.ship.components.extensions.weapons;

namespace WoS.ship.ShipTypes
{
    public class ShipBattleGama : ShipBase
    {
        //ShipBattleGama  [Reaktor 1, Pohon 4, MaláZbraň 6,StředníZbraň 2,Štít 2, Rozšíření 6]
        // TODO: Nakonfigurovat hodnoty
        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti

        public ShipBattleGama(ContentManager content, Vector2 startPosition)
            : base(content, startPosition)
        {
            weaponsCount = 1;
            generatorsCount = 2;
            extensionsCount = 2;

            canons = new List<WeaponBase>();
            generators = new List<GeneratorBase>();
            extensions = new List<ShipExtensions1>();

            Texture = content.Load<Texture2D>("spaceShips/ShipBattleGama");

            // Zdraví a rychlost lodě
            Hp = 700;
            HpMax = 700;
            MaxSpeed = 500;

            CreatePositionsOnShip(weaponsCount, generatorsCount, extensionsCount);
            CreateShipExtensions(content, weaponsCount, generatorsCount, extensionsCount);

            PositionOnMap = startPosition;
            Rotation = 0;
            TargetPosition = startPosition;
        }

        public void CreateShipExtensions(ContentManager content, int weaponsNumber, int generatorsNumber, int extensionsNumber)
        {
            //ShipBattleGama  [Reaktor 1, Pohon 4, MaláZbraň 6,StředníZbraň 2,Štít 2, Rozšíření 6]
            generators[0] = new AlphaReactor(content, GetPositionOnShip("Generator", 0));

            canons[0] = new BalisticCanon(content, GetPositionOnShip("Weapon", 0), 1);

            generators[1] = new AlphaEngine(content, GetPositionOnShip("Generator", 1));
            generators[2] = new AlphaEngine(content, GetPositionOnShip("Generator", 2));

            extensions[0] = new ShipExtensions1(content, GetPositionOnShip("Extension", 0));
            extensions[1] = new ShipExtensions1(content, GetPositionOnShip("Extension", 1));
        }

        public void CreatePositionsOnShip(int weaponsCount, int generatorsCount, int extensionsCount)

        {
            // Vytváření pozic pro zbraně
            WeaponsPosition = new Vector2[weaponsCount];
            GeneratorsPosition = new Vector2[generatorsCount];
            ExtensionsPosition = new Vector2[extensionsCount];

            // Vytváření pozic pro zbraně
            WeaponsPosition[0] = new Vector2(0, 0);

            // Vytváření pozic pro generátory
            GeneratorsPosition[0] = new Vector2(0, 0);
            GeneratorsPosition[1] = new Vector2(0, 0);

            // Vytváření pozic pro rozšíření
            ExtensionsPosition[0] = new Vector2(0, 0);
            ExtensionsPosition[1] = new Vector2(0, 0);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
        }

        // Přetížení metody Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);
        }
    }
}