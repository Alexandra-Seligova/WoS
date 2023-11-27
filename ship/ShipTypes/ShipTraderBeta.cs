
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WoS.ship.components.extensions;
using WoS.ship.components.extensions.generators;
using WoS.ship.components.extensions.ShipExtensions;
using WoS.ship.components.extensions.weapons;

namespace WoS.ship.ShipTypes
{
    public class ShipTraderBeta : ShipBase
    {
        //ShipTraderBeta  [Reaktor 1, Pohon 2, MaláZbraň 2, StředníZbraň 1,Štít 2, Rozšíření 4]
        // TODO: Nakonfigurovat hodnoty
        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti



        public ShipTraderBeta(ContentManager content, Vector2 startPosition)
            : base(content, startPosition)
        {
            weaponsNumber = 1;
            generatorsNumber = 2;
            extensionsNumber = 2;


            canons = new List<WeaponBase>();
            generators = new List<GeneratorBase>();
            extensions = new List<ShipExtensions1>();


            Texture = content.Load<Texture2D>("spaceShips/ShipTraderBeta");

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
            //ShipTraderBeta  [Reaktor 1, Pohon 2, MaláZbraň 2, StředníZbraň 1,Štít 2, Rozšíření 4]
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
