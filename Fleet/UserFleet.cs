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
namespace WoS.Fleet
{
    public class UserFleet : FleetBase
    {

        public UserFleet(int id, Vector2 position, ContentManager content) : base()
        {

            ship = new ShipEgla(content, new Vector2(100, 100));      // Inicializace ship
            //drons = new Drons(content, new Vector2(100, 100));      // Inicializace drons
        }






        public override void Update()
        {

            ship.Update();
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            ship.Draw(spriteBatch);

        }



        public void SetDroneFormation()
        {
            // Nastavení formace dronů vůči hlavní lodi
        }

        // ... další metody specifické pro UserFleet
    }

    /*
Má vytvořit instance a přidá do ní všechny objekty, které budou ovládány hráčem:

Ship
Drons


      */

}
