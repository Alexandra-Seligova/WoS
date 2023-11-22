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
    public class FleetBase : ElementBase
    {

        public ShipBase ship;
        public FleetBase() : base()
        {
        }


        public override void Update() { }
        public override void Render(SpriteBatch spriteBatch) { }
    }
}
