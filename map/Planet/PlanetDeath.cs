using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.map.Planet
{
    public class PlanetDeath : PlanetBase
    {

        public PlanetDeath(int id) : base(id)
        {
            Id = id;
            PlanetElementList = new List<PlanetElement>();
            PopulateElementList();
        }


    }
}
