namespace WoS_Server.DataModel
{
    using WoS_Server.Models;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class AerospaceBuilding : Base_Building
    {
        /*
          public int Id_User { get; set; } = 0; // id
          public int Id_Map { get; set; } = 1;  // Unikátní identifikátor mapy


          public int Id_Destructible { get; set; }   // Unikátní identifikátor
          public int Id_Destructible_Type { get; set; }  // Typ


        public int Id_Building_Type { get; set; }  // Typ mapy


          public int Level { get; set; }

          int _hp;
          int _maxHP;
          int _armor;
          int _maxArmor;
          int _structuralIntegrity;
          int _maxStructuralIntegrity;
          int _shield;
          int _maxShield;

          bool canBeDestroyed;

          public Dictionary<ResourceType, int> InitialCostResource { get; set; } // nákupní cena
          public Dictionary<ResourceType, int> CurrentCostResource { get; set; } // získatelná cena při zničení
          public float DepreciationRate { get; set; } = 0.6f; // Procentuální pokles ceny při zničení o 60%


          public Dictionary<ResearchType, int> RequirementsResearch { get; set; }


        */

        public int Id_AerospaceBuilding { get; set; }  // Unikátní identifikátor mapy
        public int Id_AerospaceBuilding_Type { get; set; }  // Typ mapy
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }

        /*
        public AerospaceBuilding(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BuildingType buildingType)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            BuildingType = buildingType;

            // Initialize RequirementsResearch
            RequirementsResearch = new Dictionary<ResearchType, int>
            {
                { ResearchType.Energy, 2 },
                { ResearchType.Materials, 2 }
            };

            // Initialize ActualCostResource
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 15 * Level },
                { ResourceType.Deuterium, 5 * Level }
            };
        }*/
    }




































    /*
    public class ArmedSatellite : AerospaceBuilding
    {
        public ArmedSatellite(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.ArmedSatellite)
        {
            NameBuildingType = "Armed Satellite";
            DescriptionBuildingType = "Ozbrojený satelit";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1500 * Level;
            ActualCostResource[ResourceType.Crystals] += 1000 * Level;
        }
    }

    public class SpyProbe : AerospaceBuilding
    {
        public SpyProbe(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.SpyProbe)
        {
            NameBuildingType = "Spy Probe";
            DescriptionBuildingType = "Špionážní sonda";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 800 * Level;
            ActualCostResource[ResourceType.Deuterium] += 600 * Level;
        }
    }

    public class OrbitalMine : AerospaceBuilding
    {
        public OrbitalMine(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.OrbitalMine)
        {
            NameBuildingType = "Orbital Mine";
            DescriptionBuildingType = "Orbitální mina";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1200 * Level;
            ActualCostResource[ResourceType.Crystals] += 900 * Level;
        }
    }

    public class DefenseDrone : AerospaceBuilding
    {
        public DefenseDrone(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.DefenseDrone)
        {
            NameBuildingType = "Defense Drone";
            DescriptionBuildingType = "Obranný dron";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1000 * Level;
            ActualCostResource[ResourceType.Crystals] += 700 * Level;
        }
    }

    public class ThorHammer : AerospaceBuilding
    {
        public ThorHammer(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.ThorHammer)
        {
            NameBuildingType = "Thor's Hammer";
            DescriptionBuildingType = "Thorovo kladivo";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 2000 * Level;
            ActualCostResource[ResourceType.Crystals] += 1500 * Level;
        }
    }

    public class Telescope : AerospaceBuilding
    {
        public Telescope(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.Telescope)
        {
            NameBuildingType = "Telescope";
            DescriptionBuildingType = "Teleskop";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1100 * Level;
            ActualCostResource[ResourceType.Crystals] += 900 * Level;
        }
    }

    public class SpaceStation : AerospaceBuilding
    {
        public SpaceStation(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.SpaceStation)
        {
            NameBuildingType = "Space Station";
            DescriptionBuildingType = "Vesmírná stanice";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 3000 * Level;
            ActualCostResource[ResourceType.Crystals] += 2500 * Level;
            ActualCostResource[ResourceType.Deuterium] += 2000 * Level;
        }
    }*/
}