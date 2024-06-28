namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public enum ResourceType
    {
        XP = 1,             // 1
        Honor = 2,          // 2
        Credits = 3,        // 3
        SpaceCoin = 4,      // 4

        Metal = 5,          // 5
        Crystals = 6,       // 6
        Minerals = 7,       // 7
        Deuterium = 8,      // 8
        Antimatter = 9,     // 9
        DarkMatter = 10,    // 10


        Prom = 11,          // 11
        Endu = 12,          // 12
        Terb = 13,          // 13
        Prom2 = 14,         // 14
        Endu2 = 15,         // 15
        Terb2 = 16,         // 16
        Xenomit = 17,       // 17
        Palladium = 18,     // 18
        Seprom = 19,        // 19
        Osmium = 20,        // 20


        SpiceRed = 21,      // 21
        SpiceYellow = 22,   // 22
        SpiceBlue = 23,     // 23
        SpicePurple = 24,   // 24
        SpiceGreen = 25,    // 25
        SpiceDark = 26      // 26
    }

    public class UserResourcesModel
    {
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
