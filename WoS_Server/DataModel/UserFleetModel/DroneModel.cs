namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class DroneModel
    {
        public int Id_User { get; set; } // id serveru

        [Key]
        public int Id_Drone { get; set; } // Unikátní identifikátor dronu

        public int Id_DroneType { get; set; } // Unikátní identifikátor dronu

        public int Id_Fleet { get; set; } // Identifikátor letky, ke které dron patří

        public int Id_Drone_Formation { get; set; } // Formace letky

        public int Id_Drone_FormationPosition { get; set; } // Pozice dronu ve formaci


        public StaticParameters StaticParameters { get; set; } // Statické parametry lodi
        public ActualParameters ActualParameters { get; set; } // Dynamické parametry lodi



        public DroneModel()
            : base()
        {
        }

        public void Attack()
        {
            // Implementace útoku
        }
    }
    public class DroneConfigurations
    {

        public int Id_User { get; set; } // id serveru
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        [Key]
        public int Id_Drone { get; set; } // Unikátní identifikátor dronu
        // Generátory
        public List<ShipComponent> Generators { get; set; }
        // Zbraně
        public List<ShipComponent> Weapons { get; set; }
        // Rozšíření
        public List<ShipComponent> Extensions { get; set; }
        // Munice
        public List<ShipComponent> Ammos { get; set; }
        // Animace
        public List<ShipComponent> Animations { get; set; }

        public DroneType Type { get; set; } // Typ dronu


        public DroneConfigurations()
        {
            Generators = new List<ShipComponent>();
            Weapons = new List<ShipComponent>();
            Extensions = new List<ShipComponent>();
            Ammos = new List<ShipComponent>();
            Animations = new List<ShipComponent>();
        }
    }
}
