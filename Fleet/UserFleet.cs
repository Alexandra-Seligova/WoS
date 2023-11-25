using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using WoS.Camera;
using WoS.map;
using WoS.ship;
using WoS.Database;

using WoS.map.Asteroids;
using WoS.map.Box;
using WoS.map.moon;
using WoS.map.Planet;
using WoS.map.Sun;
using WoS.npc;
using WoS.Utility;
using WoS.Fleet;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using static WoS.Database.Database;
using WoS.ship.ShipTypes;
using Microsoft.Identity.Client;
using WoS.ship.Drons;
using WoS.ship.Drons.DronBase;
namespace WoS.Fleet
{
    public class UserFleet : FleetBase
    {
        private int DronsCount;

        private int[] DronsType;
        private DroneBase[] Dronslist;
          private Vector2[] DronsPosition;
        public UserFleet(int id, Vector2 position, ContentManager content) : base()
        {

            //ship = new ShipEgla(content, new Vector2(100, 100));      // Inicializace ship

            SetShip("BattleShipT1", content);
            DronsCount = 8;
            DronsType = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            SetDrons(DronsType, content);
            SetDroneFormation("Battle");

        }


        public void SetShip(String shipName, ContentManager content)
        {
            switch (shipName)
            {

                case "BattleShipT1":
                    ship = new ShipBattleAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "BattleShipT2":
                    ship = new ShipBattleBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "ExploratoryShipT1":
                    ship = new ShipExploratoryAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "ExploratoryShipT2":
                    ship = new ShipExploratoryBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "MiningShipT1":
                    ship = new ShipMiningAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "MiningShipT2":
                    ship = new ShipMiningBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "TraderShipT1":
                    ship = new ShipTraderAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "TraderShipT2":
                    ship = new ShipTraderBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "TransportShipT1":
                    ship = new ShipTransportAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "TransportShipT2":
                    ship = new ShipTransportBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                default:
                    ship = new ShipBattleAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
            }



            // Nastavení lodi
        }


        public void SetDron(String dronName, ContentManager content)
        {
            switch (dronName)
            {
                case "DronDeluxeT1":
                    Dronslist = new DronDeluxeAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "DronBattleT1":
                    Dronslist = new DronBattleAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "DronLavaT1":
                    Dronslist = new DronLavaAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "DronAquaT1":
                    Dronslist = new DronAquaAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
                case "DronElectroT1":
                    Dronslist = new DronElectroAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
            }



            // Nastavení lodi
        }
        public void SetDrons(int[] config, ContentManager content)
        {
            for (int i = 0; i < config.Length; i++) // 8 dronů
            {
                if (config[i] > 0 && config[i] < 6)
                {
                    switch (config[i])
                    {
                        case 1:
                            SetDron("DronDeluxeT1", content);
                            break;
                        case 2:
                            SetDron("DronBattleT1", content);
                            break;
                        case 3:
                            SetDron("DronLavaT1", content);
                            break;
                        case 4:
                            SetDron("DronAquaT1", content);
                            break;
                        case 5:
                            SetDron("DronElectroT1", content);
                            break;

                    }
                }
                else
                {
                    SetDron("DronDeluxeT1", content);
                }
            }




        }





        public override void Update()
        {

            ship.Update();
            for (int i = 0; i < DronsCount; i++)
            {
                Dronslist[i].Update();
            }
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            ship.Draw(spriteBatch);

            for (int i = 0; i < DronsCount; i++)
            {
                Dronslist[i].Render(spriteBatch);
            }

        }


        public void SetDroneFormation(String name)
        {
            switch (name)
            {
                case "Battle":

                    Vector2 position1 = new Vector2(0, 0);
                    Vector2 position2 = new Vector2(0, 0);
                    Vector2 position3 = new Vector2(0, 20);
                    Vector2 position4 = new Vector2(0, 20);
                    Vector2 position5 = new Vector2(-10, -11);
                    Vector2 position6 = new Vector2(10, -11);
                    Vector2 position7 = new Vector2(-10, -11);
                    Vector2 position8 = new Vector2(10, -11);


                    DronsPosition = new Vector2[] { position1, position2, position3, position4, position5, position6, position7, position8 };
                      for (int i = 0; i < DronsCount; i++)
                    {
                        Dronslist[i].SetPositionOnShip(DronsPosition[i]);
                    }


                    break;
            }
        }


    }

}
