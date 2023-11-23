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
using WoS;
using WoS.ship.components.extensions;
using WoS.ship.components.extensions.weapons;
using WoS.ship.components.extensions.generators;
using WoS.ship.components.extensions.ShipExtensions;



namespace WoS.ship.BattleType
{
    public class ShipBattleAlpha : ShipBase
    {
        /* Popis a poznámky
         * BattleShip Alpha typ 1 - 1x kanón, 2x generátor, 2x extension
         *

         */

        BalisticCanon canon1;

        AlphaReactor reactor1;

        AlphaEngine generator1;

        ShipExtensions1 extension1;

        private const float SCALE_FACTOR = 0.1f; // 10% z původní velikosti

        public ShipBattleAlpha(ContentManager content, Vector2 startPosition)
            : base(content, startPosition)
        {
            Texture = content.Load<Texture2D>("spaceShips/BattleShipT1");
            // Zdraví a rychlost lodě
            Hp = 700;
            HpMax = 700;
            MaxSpeed = 500;
            // Moduly a vybavení lodě

            weaponsNumber = 1;
            generatorsNumber = 2;
            extensionsNumber = 2;


            CreateShipExtensions(content, weaponsNumber, generatorsNumber, extensionsNumber);

            PositionOnMap = startPosition;
            Rotation = 0;
            Target = startPosition;
        }
        // Přetížení metody Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, PositionOnMap, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), SCALE_FACTOR, SpriteEffects.None, 0);
        }



        public void CreateShipExtensions(ContentManager content, int weaponsNumber, int generatorsNumber, int extensionsNumber)
        {
            // Pozice jednotlivých modulů na lodi
            Vector2 reaktor1Position = new Vector2(0, 0);

            Vector2 canon1Position = new Vector2(0, 0);

            Vector2 generator1Position = new Vector2(0, 20);
            Vector2 generator2Position = new Vector2(0, 20);


            Vector2 extension1Position = new Vector2(-10, -11);
            Vector2 extension2Position = new Vector2(10, -11);

            canon1 = new BalisticCanon(content, canon1Position);

            reactor1 = new AlphaReactor(content, reaktor1Position);

            generator1 = new AlphaEngine(content, generator1Position);

            extension1 = new ShipExtensions1(content, extension1Position);

        }


        public void UpdateShipExtensions()
        {
            float atualRotation = Rotation;
            Vector2 actualShipPosition = PositionOnMap;
            Vector2 actualTarget = Target;

            canon1.Update();
            reactor1.Update();
            generator1.Update();
            extension1.Update();


        }



        public override void Update()
        {

            if (Vector2.Distance(PositionOnMap, Target) > 1.0f)  // Pokud je loď dostatečně daleko od cíle
            {
                Vector2 direction = Vector2.Normalize(Target - PositionOnMap);
                Vector2 velocity = direction * MaxSpeed * (float)0.01;
                //Vector2 velocity = direction * MaxSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                PositionOnMap += velocity;

                // Pokud je loď velmi blízko cíli, nastavte její pozici přímo na cíl
                if (Vector2.Distance(PositionOnMap, Target) < MaxSpeed * 0.01)
                // if (Vector2.Distance(PositionOnMap, Target) < MaxSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds)
                {
                    PositionOnMap = Target;
                }
            }

            UpdateShipExtensions();


        }
        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }
    }
}
