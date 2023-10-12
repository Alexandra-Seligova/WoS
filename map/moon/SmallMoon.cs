using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace WoS.map.moon
{
    public class SmallMoon : MoonBase
    {
        // Zde můžete přidat specifické vlastnosti a metody pro smallMoon
        // Zde můžete přidat specifické vlastnosti a metody pro SmallAsteroid
        public SmallMoon(Vector2 position) : base(position)
        {
            this.Position = position;
        }
    }
}