using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;  // Pro použití Vector2
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace WoS.Fleets
{
    public abstract class FleetBase : ElementBase
    {
        public FleetBase(Vector2 position)
        {
            Position = position;
        }
    }
}
