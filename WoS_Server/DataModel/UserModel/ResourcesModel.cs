namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;




    public class ResourcesModel
    {
        [Key]
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public int Id_Resources { get; set; } // id uživatele - Primární klíč

        // Zkušenostní body
        public int XP { get; set; }

        // Čest
        public int Honor { get; set; }

        // Úroveň
        public int Level { get; set; }

        // Kredity
        public int Credits { get; set; }

        // SpaceCoiny
        public int SpaceCoin { get; set; }

        // Zdroje
        public int Metal { get; set; }      // Kov
        public int Crystals { get; set; }   // Krystaly
        public int Minerals { get; set; }   // Minerály
        public int Deuterium { get; set; }  // Deuterium
        public int Antimatter { get; set; } // Antihmota
        public int DarkMatter { get; set; } // Temná hmota

        // Minerály
        public int Prom { get; set; }
        public int Endu { get; set; }
        public int Terb { get; set; }
        public int Prom2 { get; set; }
        public int Endu2 { get; set; }
        public int Terb2 { get; set; }
        public int Xenomit { get; set; }
        public int Palladium { get; set; }
        public int Seprom { get; set; }
        public int Osmium { get; set; }

        // Koření
        public int SpiceRed { get; set; }       // Červené
        public int SpiceYellow { get; set; }    // Žluté
        public int SpiceBlue { get; set; }      // Modré
        public int SpicePurple { get; set; }    // Fialové
        public int SpiceGreen { get; set; }     // Zelené
        public int SpiceDark { get; set; }      // Temné
    }
}
