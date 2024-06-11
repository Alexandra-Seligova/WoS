namespace WoS_Server.DataModel
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class Factory : Base_Building
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



        public int Id_FactoryBuilding { get; set; }  // Unikátní identifikátor mapy
        public int Id_FactoryBuilding_Type { get; set; }  // Typ mapy
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }
        /*
        public Factory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BuildingType buildingType)
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
    public class OreExtractor : Factory
    {
        public OreExtractor(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.OreExtractor)
        {
            NameBuildingType = "Ore Extractor";
            DescriptionBuildingType = "Extraktor rudy";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Mining, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 500 * Level;
            ActualCostResource[ResourceType.Crystals] += 300 * Level;
        }
    }

    public class Smelting : Factory
    {
        public Smelting(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.Smelting)
        {
            NameBuildingType = "Smelting";
            DescriptionBuildingType = "Slévárna";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Mining, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 700 * Level;
            ActualCostResource[ResourceType.Crystals] += 500 * Level;
        }
    }

    public class RobotFactory : Factory
    {
        public RobotFactory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.RobotFactory)
        {
            NameBuildingType = "Robot Factory";
            DescriptionBuildingType = "Továrna na roboty";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 800 * Level;
            ActualCostResource[ResourceType.Crystals] += 600 * Level;
        }
    }

    public class NanobotFactory : Factory
    {
        public NanobotFactory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.NanobotFactory)
        {
            NameBuildingType = "Nanobot Factory";
            DescriptionBuildingType = "Továrna na nanoboty";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1000 * Level;
            ActualCostResource[ResourceType.Crystals] += 800 * Level;
        }
    }

    public class ChipFactory : Factory
    {
        public ChipFactory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.ChipFactory)
        {
            NameBuildingType = "Chip Factory";
            DescriptionBuildingType = "Továrna na čipy";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.ComputerTechnology, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 900 * Level;
            ActualCostResource[ResourceType.Crystals] += 700 * Level;
        }
    }

    public class FuelFactory : Factory
    {
        public FuelFactory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.FuelFactory)
        {
            NameBuildingType = "Fuel Factory";
            DescriptionBuildingType = "Továrna na výrobu paliva";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1100 * Level;
            ActualCostResource[ResourceType.Crystals] += 800 * Level;
        }
    }

    public class ComponentFactory : Factory
    {
        public ComponentFactory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.ComponentFactory)
        {
            NameBuildingType = "Component Factory";
            DescriptionBuildingType = "Továrna na součástky";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1200 * Level;
            ActualCostResource[ResourceType.Crystals] += 900 * Level;
        }
    }*/
}
