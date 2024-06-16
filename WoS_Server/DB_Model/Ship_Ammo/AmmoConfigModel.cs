namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AmmoConfigModel
    {

        public int Id_User { get; set; } // Unikátní identifikátor lodi
        [Key]
        public int Id_Ammo_Config { get; set; } // Unikátní identifikátor munice



        // Vlastnosti munice
        public float Size { get; set; } = 5; // Velikost munice
        public int Damage { get; set; } // Poškození způsobené municí
        public int Range { get; set; } // Dostřel munice

        public bool IsControlable { get; set; }


    }
}
