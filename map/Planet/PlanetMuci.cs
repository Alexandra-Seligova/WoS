using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoS.map.Planet;

namespace WoS.map.Planet
{
    public class PlanetMuci : PlanetBase
    {
        public PlanetMuci(int id) : base(id)
        {
            Id = id;
            PlanetElementList = new List<PlanetElement>();
            PopulateElementList();
        }
        public override void Update()
        {
            // Implementation of method to update the planet
        }
        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }
    }
}
