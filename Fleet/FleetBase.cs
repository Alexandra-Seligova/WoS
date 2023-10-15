using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Fleet
{
    public class FleetBase
    {
        // Seznam lodí a dronů v letce
        //private List<Ship> ships;
        //private List<Drone> drones;

        // Aktuálně ovládaný objekt v letce
        private object currentControlledObject;

        // Konstruktor
        public FleetBase()
        {
            // ships = new List<Ship>();
            //drones = new List<Drone>();
        }/*

        // Přidání lodi do letky
        public void AddShip(Ship ship)
        {
            ships.Add(ship);
        }

        // Přidání dronu do letky
        public void AddDrone(Drone drone)
        {
            drones.Add(drone);
        }
        */
        // Přepnutí ovládání na další objekt v letce
        public void SwitchControl()
        {
            // Tady byste mohl implementovat logiku pro přepnutí ovládání mezi objekty v letce
        }

        // Nastavení chování zbytku letky na základě vybrané lodi
        public void SetFleetBehaviorBasedOnCurrentObject()
        {
            // Implementace logiky pro nastavení chování zbytku letky na základě aktuálně ovládaného objektu
        }
    }
}
