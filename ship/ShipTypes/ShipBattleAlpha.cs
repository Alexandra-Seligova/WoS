using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WoS.ship.components.extensions.generators;
using WoS.ship.components.extensions.ShipExtensions;
using WoS.ship.components.extensions.weapons;

namespace WoS.ship.ShipTypes
{
    public class ShipBattleAlpha : ShipBase
    {
        //  ShipBattleAlpha [Reaktor 1, Pohon 2, MaláZbraň 2, Štít 0, Rozšíření 2]
        private const float SCALE_FACTOR = 0.2f; // 10% z původní velikosti

        public ShipBattleAlpha(ContentManager content, Vector2 startPosition)
            : base(content, startPosition)
        {
            weaponsNumber = 2;
            generatorsNumber = 3;
            extensionsNumber = 2;

            canons = new List<WeaponBase>();
            generators = new List<GeneratorBase>();
            extensions = new List<ShipExtensions1>();

            Texture = content.Load<Texture2D>("spaceShips/ShipBattleAlpha");

            // Zdraví a rychlost lodě
            Hp = 700;
            HpMax = 700;
            MaxSpeed = 500;

            CreatePositionsOnShip(weaponsNumber, generatorsNumber, extensionsNumber);
            CreateShipExtensions(content, weaponsNumber, generatorsNumber, extensionsNumber);

            PositionOnMap = startPosition;
            Rotation = 0;
            TargetPosition = startPosition;
        }

        public void CreateShipExtensions(ContentManager content, int weaponsNumber, int generatorsNumber, int extensionsNumber)
        {
            //  ShipBattleAlpha [Reaktor 1, Pohon 2, MaláZbraň 2, Štít 0, Rozšíření 2]
            generators.Add(new AlphaReactor(content, GetPositionOnShip("Generator", 0)));

            canons.Add(new BalisticCanon(content, GetPositionOnShip("Weapon", 0), 1));
            canons.Add(new BalisticCanon(content, GetPositionOnShip("Weapon", 1), 1));

            generators.Add(new AlphaEngine(content, GetPositionOnShip("Generator", 1)));
            generators.Add(new AlphaEngine(content, GetPositionOnShip("Generator", 2)));

            extensions.Add(new ShipExtensions1(content, GetPositionOnShip("Extension", 0)));
            extensions.Add(new ShipExtensions1(content, GetPositionOnShip("Extension", 1)));
        }

        public void CreatePositionsOnShip(int weaponsCount, int generatorsCount, int extensionsCount)

        {
            // Vytváření pozic pro zbraně
            WeaponsPosition = new Vector2[weaponsCount];
            GeneratorsPosition = new Vector2[generatorsCount];
            ExtensionsPosition = new Vector2[extensionsCount];

            // Vytváření pozic pro zbraně
            WeaponsPosition[0] = new Vector2(0, 0);
            WeaponsPosition[1] = new Vector2(0, 0);

            // Vytváření pozic pro generátory
            GeneratorsPosition[0] = new Vector2(0, 0);
            GeneratorsPosition[1] = new Vector2(0, 0);
            GeneratorsPosition[2] = new Vector2(0, 0);

            // Vytváření pozic pro rozšíření
            ExtensionsPosition[0] = new Vector2(0, 0);
            ExtensionsPosition[1] = new Vector2(0, 0);
        }

        public void Update(Vector2 actualShipPosition, float actualRotation, Vector2 actualTarget)
        {
            // Aktualizace pozice lodi
            PositionOnMap = actualShipPosition;
            Rotation = actualRotation;
            TargetPosition = actualTarget;

            // Aktualizace kanónů
            foreach (var canon in canons)
            {
                canon.PositionOnMap = PositionOnMap;
                canon.Update();
            }

            // Aktualizace generátorů
            foreach (var generator in generators)
            {
                generator.PositionOnMap = PositionOnMap;
                generator.Update();
            }

            // Aktualizace rozšíření
            foreach (var extension in extensions)
            {
                extension.PositionOnMap = PositionOnMap;
                extension.Update();
            }
        }

        public override void Render(SpriteBatch spriteBatch)
        {
        }

        // Přetížení metody Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Vykreslení lodě
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);

            // Vykreslení kanónů
            foreach (var canon in canons)
            {
                canon.Render(spriteBatch);
            }

            // Vykreslení generátorů
            foreach (var generator in generators)
            {
                generator.Render(spriteBatch);
            }

            // Vykreslení rozšíření
            foreach (var extension in extensions)
            {
                extension.Render(spriteBatch);
            }
        }
    }
}