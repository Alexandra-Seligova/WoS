namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class BoostersModel
    {
        [Key]
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public int Speed { get; set; } // Rychlost
        public int Attack { get; set; } // Útok
        public int Defense { get; set; } // Obrana
        public int Colonization { get; set; } // Kolonizace
        public int Construction { get; set; } // Výstavba
        public int IndustrialProduction { get; set; } // Průmyslová produkce
    }
}
