﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WoS.ship.Drons;
using WoS.ship.ShipTypes;

namespace WoS.Fleet
{
    public class UserFleet : FleetBase
    {
        public int DronsCount;
        public List<DroneBase> Dronslist;
        public int[] DronsType;

        public Vector2[] DronsPosition;

        public UserFleet(int id, Vector2 position, ContentManager content) : base()
        {
            //ship = new ShipEgla(content, new Vector2(100, 100));      // Inicializace ship

            Dronslist = new List<DroneBase>();
            SetShip("ShipBattleAlpha", content);
            DronsCount = 8;
            DronsType = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            SetDrons(DronsType, content);
            SetDroneFormation("Battle");
        }

        public void SetShip(String shipName, ContentManager content)
        {
            switch (shipName)
            {
                case "ShipBattleAlpha":
                    ship = new ShipBattleAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipBattleBeta":
                    ship = new ShipBattleBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipExploratoryAlpha":
                    ship = new ShipExploratoryAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipExploratoryBeta":
                    ship = new ShipExploratoryBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipMiningAlpha":
                    ship = new ShipMiningAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipMiningBeta":
                    ship = new ShipMiningBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipTraderAlpha":
                    ship = new ShipTraderAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipTraderBeta":
                    ship = new ShipTraderBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipTransportAlpha":
                    ship = new ShipTransportAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                case "ShipTransportBeta":
                    ship = new ShipTransportBeta(content, new Vector2(100, 100));      // Inicializace ship
                    break;

                default:
                    ship = new ShipBattleAlpha(content, new Vector2(100, 100));      // Inicializace ship
                    break;
            }

            // Nastavení lodi
        }

        public void SetDron(String dronName, int position, ContentManager content)
        {
            switch (dronName)
            {
                case "DronDeluxeAlpha":
                    Dronslist.Add(new DronDeluxeAlpha(content, new Vector2(100, 100)));      // Inicializace ship
                    break;

                case "DronBattleAlpha":
                    Dronslist.Add(new DronBattleAlpha(content, new Vector2(100, 100)));      // Inicializace ship
                    break;

                case "DronLavaAlpha":
                    Dronslist.Add(new DronLavaAlpha(content, new Vector2(100, 100)));      // Inicializace ship
                    break;

                case "DronAquaAlpha":
                    Dronslist.Add(new DronAquaAlpha(content, new Vector2(100, 100)));      // Inicializace ship
                    break;

                case "DronElectroAlpha":
                    Dronslist.Add(new DronElectroAlpha(content, new Vector2(100, 100)));      // Inicializace ship
                    break;
            }

            // Nastavení lodi
        }

        public void SetDrons(int[] config, ContentManager content)
        {
            for (int i = 0; i < config.Length; i++) // 8 dronů
            {
                if (config[i] > 0 && config[i] < DronsCount)
                {
                    switch (config[i])
                    {
                        case 1:
                            SetDron("DronDeluxeAlpha", i, content);
                            break;

                        case 2:
                            SetDron("DronBattleAlpha", i, content);
                            break;

                        case 3:
                            SetDron("DronLavaAlpha", i, content);
                            break;

                        case 4:
                            SetDron("DronAquaAlpha", i, content);
                            break;

                        case 5:
                            SetDron("DronElectroAlpha", i, content);
                            break;
                    }
                }
                else
                {
                    SetDron("DronDeluxeAlpha", i, content);
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