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

        public int Id_Fleet { get; set; } // Identifikátor letky, ke které dron patří

        public int Id_Drone_Formation { get; set; } // Formace letky

        public int Id_Drone_FormationPosition { get; set; } // Pozice dronu ve formaci

        public string Name { get; set; }
        public DroneType Type { get; set; } // Typ dronu
        public int Speed { get; set; }
        public int Armor { get; set; }
        public int WeaponPower { get; set; }

        public DroneModel()
            : base()
        {
        }

        public void Attack()
        {
            // Implementace útoku
        }
    }

}
