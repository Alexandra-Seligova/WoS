namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShipComponentModel
    {
        public int Id_User { get; set; } // id serveru
        [Key]
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        public int Id_Ship_Component { get; set; } // Unikátní identifikátor komponenty

        public int Id_Ship_Component_Type { get; set; } // Unikátní identifikátor komponenty


        public string Component_Name { get; set; } // Název komponenty

        public int PositionOnShip_x { get; set; } // Pozice na lodi
        public int PositionOnShip_y { get; set; } // Pozice na lodi
        public int PositionOnShip_z { get; set; } // Pozice na lodi


        public enum ShipComponentType
        {
            Generator,   // Generátor
            Weapon,      // Zbraň
            Extension,   // Rozšíření
            Ammo,        // Munice
            Animation    // Animace
        }
    }

}
