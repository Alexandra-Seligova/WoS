namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Základní třída pro všechny informace o výzkumu.
    /// </summary>
    public abstract class Base_ResearchModel
    {

        public int Id_User { get; set; }
        public int Id_Research { get; set; } // od každého typu max jedno id na uživatele
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public Dictionary<ResearchType, int> RequirementsResearch { get; set; }
        public bool IsRequirementsMet { get; set; }
        public Dictionary<ResourceType, int> ActualCostResource { get; set; }
        public bool IsCostMet { get; set; }

        public Base_ResearchModel()
        {
            RequirementsResearch = new Dictionary<ResearchType, int>();
            ActualCostResource = new Dictionary<ResourceType, int>();
        }
    }

    public enum ResearchType
    {
        // Základní výzkum technologií
        Energy = 0,                 // 0 - Energie
        Materials = 1,              // 1 - Materiály
        Reactions = 2,              // 2 - Reakce
        Attack = 3,                 // 3 - Útok
        Defense = 4,                // 4 - Obrana
        Mining = 5,                 // 5 - Těžba

        // Pokročilý výzkum technologií
        ElectronTechnology = 6,     // 6 - Elektronová technologie
        PhotonTechnology = 7,       // 7 - Fotonová technologie
        IonTechnology = 8,          // 8 - Iontová technologie
        PlasmaTechnology = 9,       // 9 - Plazmová technologie
        HighEnergyTechnology = 10,  // 10 - Vysokoenergetická technologie
        HyperspaceTechnology = 11,  // 11 - Hyperprostorová technologie
        GravitonTechnology = 12,    // 12 - Gravitonová technologie
        ComputerTechnology = 13,    // 13 - Počítačová technologie
        LaserTechnology = 14,       // 14 - Laserová technologie
        QuantumTechnology = 15,     // 15 - Kvantová technologie
        Polarization = 16,          // 16 - Polarizace

        // Specializovaný výzkum
        Hydrogen = 17,              // 17 - Vodíková
        Nuclear = 18,               // 18 - Jaderná
        Fusion = 19,                // 19 - Fůzní
        Antimatter = 20,            // 20 - Antihmotová
        Alloys = 21,                // 21 - Slitiny (kov)
        CrystallineLattice = 22,    // 22 - Krystalická mřížka (krystaly)
        MineralProperties = 23,     // 23 - Vlastnosti minerálů (minerály)
        EnergyEfficiency = 24,      // 24 - Energetická účinnost (deutérium)
        EssenceOfMatter = 25,       // 25 - Podstata hmoty (antihmota)

        // Výzkum reaktorů
        HydrogenReactor = 26,       // 26 - Vodíkový reaktor
        NuclearReactor = 27,        // 27 - Jaderný reaktor
        FusionReactor = 28,         // 28 - Fůzní reaktor
        AntimatterReactor = 29,     // 29 - Antihmotový reaktor
        DarkMatterReactor = 30,     // 30 - Temnohmotový reaktor

        // Výzkum pohonů
        HydrogenDrive = 31,         // 31 - Vodíkový pohon
        ImpulseDrive = 32,          // 32 - Impulzní pohon
        FTLDrive = 33,              // 33 - FTL (Faster Than Light) pohon
        WarpDrive = 34,             // 34 - Warpový pohon
        ProtonDrive = 35,           // 35 - Protonový pohon

        // Bojový výzkum
        ProjectileWeapons = 36,     // 36 - Projektilové zbraně
        EnergyWeapons = 37,         // 37 - Energetické zbraně
        RadioactiveWeapons = 38,    // 38 - Radioaktivní zbraně

        // Armor a Polarizační technologie
        LightArmor = 39,            // 39 - Lehčený pancíř
        MultiLayeredArmor = 40,     // 40 - Vícevrstvý pancíř
        PolarizedArmor = 41,        // 41 - Polarizovaný pancíř

        StandardPolarization = 42,  // 42 - Standardní polarizace
        MultiPhasePolarization = 43,// 43 - Multifázová polarizace

        // Výzkum štítů
        StandardShields = 44,       // 44 - Standardní štíty
        HighCapacityShields = 45,   // 45 - Vysokokapacitní štíty
        RegenerativeShields = 46,   // 46 - Regenerační štíty
        AdaptiveShields = 47,       // 47 - Adaptabilní štíty

        // Výzkum těžby
        PlanetaryMining = 48,       // 48 - Planetární těžba
        OrbitalMining = 49,         // 49 - Orbitální těžba
        LaserMining = 50,           // 50 - Laserová těžba
        PlasmaMining = 51,          // 51 - Plazmová těžba
        HighEnergyMining = 52,      // 52 - Vysokoenergetická těžba

        // Výzkum stavitelství
        Buildings = 53,             // 53 - Budovy
        SpaceStation = 54,          // 54 - Stanice
        Satellites = 55,            // 55 - Satelity
        Colonies = 56,              // 56 - Kolonie
        GalacticGates = 57,         // 57 - Galaktické brány

        // Výzkum v oblasti biotechnologií
        Biotechnology = 58,         // 58 - Výzkum v oblasti biotechnologií
        GeneticEngineering = 59,    // 59 - Genetické inženýrství
        MedicalAdvancements = 60,   // 60 - Lékařský pokrok
        CloningTechnology = 61,     // 61 - Technologie klonování

        // Výzkum v oblasti umělé inteligence
        ArtificialIntelligence = 62,// 62 - Výzkum v oblasti umělé inteligence
        MachineLearning = 63,       // 63 - Strojové učení
        NeuralNetworks = 64,        // 64 - Neuronové sítě
        Robotics = 65,              // 65 - Robotika

        // Výzkum v oblasti nanotechnologií
        Nanotechnology = 66,        // 66 - Výzkum v oblasti nanotechnologií
        Nanomaterials = 67,         // 67 - Nanomateriály
        Nanoelectronics = 68,       // 68 - Nanoelektronika
        Nanomedicine = 69,          // 69 - Nanomedicína

        // Výzkum v oblasti ekologie a zemědělství
        EcologyAndAgriculture = 70, // 70 - Výzkum v oblasti ekologie a zemědělství
        SustainableAgriculture = 71,// 71 - Udržitelné zemědělství
        RenewableEnergy = 72,       // 72 - Obnovitelná energie
        EnvironmentalConservation = 73,// 73 - Ochrana životního prostředí

        // Výzkum v oblasti kosmických technologií
        SpaceTechnology = 74,       // 74 - Výzkum v oblasti kosmických technologií
        SpaceExploration = 75,      // 75 - Průzkum vesmíru
        SpaceColonization = 76,     // 76 - Kolonizace vesmíru
        AdvancedPropulsion = 77,    // 77 - Pokročilý pohon

        // Výzkum v oblasti materiálových věd
        MaterialScience = 78,       // 78 - Výzkum v oblasti materiálových věd
        Superconductors = 79,       // 79 - Supravodiče
        Metamaterials = 80,         // 80 - Metamateriály
        CompositeMaterials = 81,    // 81 - Kompozitní materiály

        // Výzkum v oblasti vojenských technologií
        MilitaryTechnology = 82,    // 82 - Výzkum v oblasti vojenských technologií
        AdvancedBallistics = 83,    // 83 - Pokročilá balistika
        StealthTechnology = 84,     // 84 - Technologie stealth
        CyberWarfare = 85,          // 85 - Kybernetická válka

        // Výzkum v oblasti sociálních věd
        SocialScience = 86,         // 86 - Výzkum v oblasti sociálních věd
        CulturalStudies = 87,       // 87 - Kulturní studia
        PoliticalScience = 88,      // 88 - Politologie
        Psychology = 89             // 89 - Psychologie
    }

}
