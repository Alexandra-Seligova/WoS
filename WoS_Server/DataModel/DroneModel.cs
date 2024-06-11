namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class DroneModel
    {
        public int Id { get; set; } // Unikátní identifikátor dronu
        public string Name { get; set; }
        public DroneType Type { get; set; } // Typ dronu
        public int Speed { get; set; }
        public int Armor { get; set; }
        public int WeaponPower { get; set; }

        public DroneModel()
            : base()
        {
        }
    }

    public enum DroneType
    {
        Battle,     // Battle drone
        Aqua,       // Aqua drone
        Electro,    // Electro drone
        Delux,      // Delux drone
        Lava        // Lava drone
    }
}
