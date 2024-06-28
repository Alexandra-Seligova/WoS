namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShipConfigModel
    {

        public int Id_User { get; set; } // id serveru
        [Key]
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        public int Id_Ship_Config { get; set; } // Unikátní identifikátor lodi

        // Generátory
        public int GeneratorsGroup { get; set; }
        public int WeaponsGroup { get; set; }
        public int ExtensionsGroup { get; set; }
        public int AmmosGroup { get; set; }
        public int FuelTanksGroup { get; set; }


    }
}
