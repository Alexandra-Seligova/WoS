namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.XPath;

    public enum ResourceType
    {
        XP,
        Honor,
        Credits,
        SpaceCoin,

        Metal,
        Crystals,
        Minerals,
        Deuterium,
        Antimatter,
        DarkMatter,
        Prom,
        Endu,
        Terb,
        Prom2,
        Endu2,
        Terb2,
        Xenomit,
        Palladium,
        Seprom,
        Osmium,
        SpiceRed,
        SpiceYellow,
        SpiceBlue,
        SpicePurple,
        SpiceGreen,
        SpiceDark
    }

    public class Base_ResourcesModel
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
