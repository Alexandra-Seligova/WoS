namespace WoS_Server.DataModel
{
    using System.Collections.Generic;

    public abstract class Base_Building : Base_DestructibleObjectModel
    {
        /*
          public int Id_User { get; set; } = 0; // id 
        public int Id_Map { get; set; } = 1;  // Unikátní identifikátor mapy

        public int Id_Destructible { get; set; }   // Unikátní identifikátor 
        public int Id_Destructible_Type { get; set; }  // Typ 

        public int Level { get; set; }

        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Armor { get; set; }
        public int MaxArmor { get; set; }
        public int StructuralIntegrity { get; set; }
        public int MaxStructuralIntegrity { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public bool CanBeDestroyed { get; set; } = true; // Výchozí hodnota je true, což znamená, že objekt může být zničen.

        public Dictionary<ResourceType, int> InitialCostResource { get; set; } // nákupní cena
        public Dictionary<ResourceType, int> CurrentCostResource { get; set; } // získatelná cena při zničení
        public float DepreciationRate { get; set; } = 0.6f; // Procentuální pokles ceny při zničení o 60%

        */

        public int Id_Building { get; set; }  // Typ mapy
        public int Id_Building_Type { get; set; }  // Typ mapy
        public Dictionary<ResearchType, int> RequirementsResearch { get; set; }
    }

    public enum BuildingType
    {
        OreExtractor = 1, // Extraktor rudy
        Smelting = 2, // Slévárna
        RobotFactory = 3, // Továrna na roboty
        NanobotFactory = 4, // Továrna na nanoboty
        ChipFactory = 5, // Továrna na čipy
        FuelFactory = 6, // Továrna na výrobu paliva
        ComponentFactory = 7, // Továrna na součástky

        Terraformer = 8, // Terraformer
        Laboratory = 9, // Laboratoř
        TransportDock = 10, // Transportní dok
        Observatory = 11, // Observatoř

        ArmedSatellite = 12, // Ozbrojený satelit
        SpyProbe = 13, // Špionážní sonda
        OrbitalMine = 14, // Orbitální mina
        DefenseDrone = 15, // Obranný dron
        ThorHammer = 16, // Thorovo kladivo
        Telescope = 17, // Teleskop
        SpaceStation = 18, // Vesmírná stanice

        RocketLauncher = 19, // Raketomet
        LaserCannon = 20, // Laserové dělo
        HeavyLaser = 21, // Těžký laser
        IonTower = 22, // Iontová věž
        PlasmaGun = 23, // Plazmový kulomet
        SmallShield = 24, // Malý štít
        PlanetaryShield = 25, // Planetární štít
        MissileSilo = 26, // Raketové silo

        MetalMiner = 27, // Kovová mina
        CrystalMiner = 28, // Krystalová mina
        MineralMiner = 29, // Mina na minerály
        DeuteriumExtractor = 30, // Extraktor deuteria

        BasicReactor = 31, // Základní reaktor
        TradeModule = 32, // Obchodní modul
        ScienceModule = 33, // Vědecký modul
        DefenseModule = 34, // Obranný modul

        MetalStorage = 35, // Sklad kovů
        CrystalStorage = 36, // Sklad krystalů
        MineralStorage = 37, // Sklad minerálů
        DeuteriumStorage = 38, // Sklad deuteria
        AlloyStorage = 39, // Sklad slitin
        ChipStorage = 40, // Sklad čipů
        FuelStorage = 41, // Sklad paliva
        ComponentStorage = 42, // Sklad součástek

        AdvancedResearchLab = 43, // Pokročilá výzkumná laboratoř
        AIResearchCenter = 44, // Centrum výzkumu umělé inteligence
        QuantumComputingCenter = 45, // Centrum kvantového počítání

        MedicalFacility = 46, // Lékařské zařízení
        BioengineeringLab = 47, // Bioinženýrská laboratoř

        HydroponicFarm = 48, // Hydroponická farma
        Biodome = 49, // Biodóm

        DroneControlCenter = 50, // Řídicí centrum dronů
        MissileDefenseSystem = 51, // Systém raketové obrany
        SecurityHub = 52, // Bezpečnostní centrum

        FusionPowerPlant = 53, // Fúzní elektrárna
        SolarArray = 54, // Solární pole

        AdvancedManufacturingPlant = 55, // Pokročilá výrobní továrna
        Refinery = 56, // Rafinérie

        StellarGateway = 57, // Hvězdná brána
        SpaceDock = 58, // Kosmický dok

        HolographicSimulator = 59, // Holografický simulátor
        TemporalResearchLab = 60, // Laboratoř temporálního výzkumu
    }
}