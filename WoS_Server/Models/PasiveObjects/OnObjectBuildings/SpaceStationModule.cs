namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class SpaceStationModule : Base_Building
    {
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }

        public SpaceStationModule(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BuildingType buildingType)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            BuildingType = buildingType;

            // Initialize RequirementsResearch
            RequirementsResearch = new Dictionary<ResearchType, int>
            {
                { ResearchType.SpaceStation, 1 }
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

    public class BasicReactor : SpaceStationModule
    {
        public BasicReactor(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.BasicReactor)
        {
            NameBuildingType = "Basic Reactor";
            DescriptionBuildingType = "Základní reaktor";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1000 * Level;
            ActualCostResource[ResourceType.Crystals] += 800 * Level;
        }
    }

    public class TradeModule : SpaceStationModule
    {
        public TradeModule(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.TradeModule)
        {
            NameBuildingType = "Trade Module";
            DescriptionBuildingType = "Obchodní modul";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 700 * Level;
            ActualCostResource[ResourceType.Deuterium] += 500 * Level;
        }
    }

    public class ScienceModule : SpaceStationModule
    {
        public ScienceModule(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.ScienceModule)
        {
            NameBuildingType = "Science Module";
            DescriptionBuildingType = "Vědecký modul";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 900 * Level;
            ActualCostResource[ResourceType.Crystals] += 600 * Level;
        }
    }

    public class DefenseModule : SpaceStationModule
    {
        public DefenseModule(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.DefenseModule)
        {
            NameBuildingType = "Defense Module";
            DescriptionBuildingType = "Obranný modul";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1200 * Level;
            ActualCostResource[ResourceType.Crystals] += 600 * Level;
        }
    }
}
