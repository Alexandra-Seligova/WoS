namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    // Třída reprezentující dron
    public class DroneModel : Base_Module
    {
        public int Id { get; set; } // Unikátní identifikátor dronu
        public string Name { get; set; }
        public DroneType Type { get; set; } // Typ dronu
        public int Speed { get; set; }
        public int Armor { get; set; }
        public int WeaponPower { get; set; }

        public DroneModel(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, DroneType type)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            Id = idGlobal; // Assuming Id is assigned as idGlobal
            Type = type;
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
