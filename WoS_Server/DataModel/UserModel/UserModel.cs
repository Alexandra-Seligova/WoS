using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WoS_Server.DataModel
{
    // Třída reprezentující uživatele
    public class UserModel
    {
        [Key]
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele - Primární klíč

        /// <summary>Typ objektu (např. "Battle", "Exploration", "MiningTechnology", "Transport").</summary>
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User_Type { get; set; } // Typ objektu
        public int Id_User_OnMap { get; set; } // Typ objektu
        /// <summary>Fokus uživatele (např. "Warrior", "Explorer", "Builder", "Miner").</summary>
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Délka názvu musí být mezi 5 a 100 znaky.")]
        public string Id_User_Focus { get; set; } // Fokus uživatele

        /// <summary>Vybraná aktivovaná loď uživatele.</summary>
        public int Id_SelectedFleetConfig { get; set; } // Ukazatel na vybranou loď, se kterou hráč letí


        /// <summary>Status uživatele (např. offline, online).</summary>
        [Required]
        [Range(1, 10, ErrorMessage = "Hodnota musí být mezi 1 a 10.")]
        public int Status { get; set; } // Status uživatele


        /// <summary>Přezdívka uživatele.</summary>
        [Required]
        [MaxLength(255)]
        public string Nickname { get; set; } // Název uživatele

        /// <summary>Hash hesla uživatele.</summary>
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } // Heslo

        /// <summary>Email uživatele.</summary>
        [Required]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Neplatná emailová adresa.")]
        public string Email { get; set; } // Email


        public ResourcesModel Resources { get; set; }        // Zdroje 
        public BoostersModel Boosters { get; set; }          // Boostry
        public PermisionsModel Flags { get; set; }           // Pravomoce účtu
        public ResearchModel Research { get; set; }         // Výzkum
        public FleetModel fleet { get; set; }                // Nastavení Ship 
        public AmmoModel ammo { get; set; }     // Munice


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
