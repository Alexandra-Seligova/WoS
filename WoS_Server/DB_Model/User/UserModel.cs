using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WoS_Server.DB_Model
{
    // Třída reprezentující uživatele
    public class UserModel
    {
        [Key]
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public int Id_User_Type { get; set; } // Typ objektu
        public int Id_User_GameType { get; set; } // Typ objektu



        public int Id_Position { get; set; }
        public int Id_User_Config { get; set; } // id uživatele - Primární klíč

        public int Id_Resources { get; set; }
        public int Id_Boosters { get; set; }
        public int Id_Research { get; set; }
        public int Id_Cargo_Items { get; set; }


        public int Id_User_ConnectionStatus { get; set; }



        public UserModel()
        {

        }
    }




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


    public enum ResearchType
    {
        // Základní výzkum technologií
        Energy,                 // Energie
        Materials,              // Materiály
        Reactions,              // Reakce
        Attack,                 // Útok
        Defense,                // Obrana
        Mining,

        // Pokročilý výzkum technologií
        ElectronTechnology,     // Elektronová technologie
        PhotonTechnology,       // Fotonová technologie
        IonTechnology,          // Iontová technologie
        PlasmaTechnology,       // Plazmová technologie
        HighEnergyTechnology,   // Vysokoenergetická technologie
        HyperspaceTechnology,   // Hyperprostorová technologie
        GravitonTechnology,     // Gravitonová technologie
        ComputerTechnology,     // Počítačová technologie
        LaserTechnology,        // Laserová technologie
        QuantumTechnology,      // Kvantová technologie
        Polarization,

        // Specializovaný výzkum
        Hydrogen,               // Vodíková
        Nuclear,                // Jaderná
        Fusion,                 // Fůzní
        Antimatter,             // Antihmotová
        Alloys,                 // Slitiny (kov)
        CrystallineLattice,     // Krystalická mřížka (krystaly)
        MineralProperties,      // Vlastnosti minerálů (minerály)
        EnergyEfficiency,       // Energetická účinnost (deutérium)
        EssenceOfMatter,        // Podstata hmoty (antihmota)

        // Výzkum reaktorů
        HydrogenReactor,        // Vodíkový
        NuclearReactor,         // Jaderný
        FusionReactor,          // Fůzní
        AntimatterReactor,      // Antihmotový
        DarkMatterReactor,      // Temnohmotový

        // Výzkum pohonů
        HydrogenDrive,          // Vodíkový
        ImpulseDrive,           // Impulzní
        FTLDrive,               // FTL (Faster Than Light)
        WarpDrive,              // Warpový
        ProtonDrive,            // Protonový

        // Bojový výzkum
        ProjectileWeapons,      // Projektilové zbraně
        EnergyWeapons,          // Energetické zbraně
        RadioactiveWeapons,     // Radioaktivní zbraně

        //ArmorTechnology
        LightArmor,             // Lehčený pancíř
        MultiLayeredArmor,      // Vícevrstvý pancíř
        PolarizedArmor,         // Polarizovaný pancíř
        Light_ArmorTechnology,          // Lehčený pancíř: Transportéry
        Multi_Layered_ArmorTechnology,  // Vícevrstvý pancíř: Umožňuje násobné zvýšení
        Polarized_ArmorTechnology,      // Polarizovaný pancíř: Má navíc vlastní štít typu regenerace

        // Polarizační technologie
        StandardPolarization,   // standardní
        MultiPhasePolarization, // Multifázová

        // Výzkum štítů
        StandardShields,        // Standardní štíty
        HighCapacityShields,    // Vysokokapacitní štíty
        RegenerativeShields,    // Regenerační štíty
        AdaptiveShields,        // Adaptabilní štíty

        // Výzkum těžby
        PlanetaryMining,        // Planetární
        OrbitalMining,          // Orbitální
        LaserMining,            // Laserová
        PlasmaMining,           // Plasmová
        HighEnergyMining,       // VysokoEnergetická

        // Výzkum stavitelství
        Buildings,              // Budovy
        SpaceStation,           // Stanice
        Satellites,             // Satelity
        Colonies,               // Kolonie
        GalacticGates           // Galaktické brány
    }

}
