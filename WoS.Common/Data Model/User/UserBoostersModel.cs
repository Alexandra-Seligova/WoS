namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class UserBoostersModel
    {
        [Key]
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public int Id_Booster { get; set; } // id uživatele - Primární klíč
        public int Speed { get; set; } // Rychlost
        public int Attack { get; set; } // Útok
        public int Defense { get; set; } // Obrana
        public int Construction { get; set; } // Obrana
        public int Production { get; set; } // Obrana
    }
}