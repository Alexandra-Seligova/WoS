namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ResearchModel
    {
        [Key]
        public int Id_Research { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public ResearchType Id_Research_Type { get; set; }

        [Required]
        public int Research_level { get; set; }

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

            LightArmor,             // Lehčený pancíř
            MultiLayeredArmor,      // Vícevrstvý pancíř
            PolarizedArmor,         // Polarizovaný pancíř
                                    //
                                    //ArmorTechnology
            Light_ArmorTechnology, //: Transporters  // Lehčený pancíř: Transportéry
            Multi_Layered_ArmorTechnology,//: Allows for multiple increases  // Vícevrstvý pancíř: Umožňuje násobné zvýšení
            Polarized_ArmorTechnology,//: Has an additional regenerative shield  // Polarizovaný pancíř: Má navíc vlastní štít typu regenerace

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
    /// <summary>
    /// Aktualizuje úroveň výzkumu a přidává nový typ, pokud ještě neexistuje.
    /// </summary>
    /// <param name="researchType">Typ výzkumu</param>
    /// <param name="levelIncrement">Zvýšení úrovně výzkumu</param>
    public void UpdateResearchLevel(ResearchType researchType, int levelIncrement)
    {
        if(researchType == Id_Research_Type)
        {
            Research_level += levelIncrement;
        }
        else
        {
            Id_Research_Type = researchType;
            Research_level = levelIncrement;
        }
    }
}
}
