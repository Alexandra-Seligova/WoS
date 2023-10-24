using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Fleet
{
    // Rozhraní pro ovladatelné objekty
    public interface IControllable
    {
        void Control();
    }

    public class Ship : IControllable
    {
        public void Control()
        {
            // Implementace pro ovládání lodi
        }
    }

    public class Drone : IControllable
    {
        public void Control()
        {
            // Implementace pro ovládání dronu
        }
    }
}
