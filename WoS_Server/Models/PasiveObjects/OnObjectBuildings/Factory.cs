namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class Factory : Base_Building
    {
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }

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
        }
    }

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
    }
}
