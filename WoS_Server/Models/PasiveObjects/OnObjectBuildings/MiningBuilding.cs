namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class MiningBuilding : Base_Building
    {
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }

        public MiningBuilding(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BuildingType buildingType)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            BuildingType = buildingType;

            // Initialize RequirementsResearch
            RequirementsResearch = new Dictionary<ResearchType, int>
            {
                { ResearchType.Mining, 1 }
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

    public class MetalMiner : MiningBuilding
    {
        public MetalMiner(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.MetalMiner)
        {
            NameBuildingType = "Metal Miner";
            DescriptionBuildingType = "Kovová mina";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 500 * Level;
            ActualCostResource[ResourceType.Crystals] += 300 * Level;
        }
    }

    public class CrystalMiner : MiningBuilding
    {
        public CrystalMiner(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.CrystalMiner)
        {
            NameBuildingType = "Crystal Miner";
            DescriptionBuildingType = "Krystalová mina";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 700 * Level;
            ActualCostResource[ResourceType.Crystals] += 500 * Level;
        }
    }

    public class MineralMiner : MiningBuilding
    {
        public MineralMiner(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.MineralMiner)
        {
            NameBuildingType = "Mineral Miner";
            DescriptionBuildingType = "Mina na minerály";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 800 * Level;
            ActualCostResource[ResourceType.Crystals] += 600 * Level;
        }
    }

    public class DeuteriumExtractor : MiningBuilding
    {
        public DeuteriumExtractor(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.DeuteriumExtractor)
        {
            NameBuildingType = "Deuterium Extractor";
            DescriptionBuildingType = "Extraktor deuteria";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 900 * Level;
            ActualCostResource[ResourceType.Crystals] += 700 * Level;
            ActualCostResource[ResourceType.Deuterium] += 500 * Level;
        }
    }
}
