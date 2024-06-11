namespace WoS_Server.DataModel
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class MiningBuilding : Base_Building
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



        public int Id_MiningBuilding { get; set; }  // Unikátní identifikátor mapy
        public int Id_MiningBuilding_Type { get; set; }  // Typ mapy
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }
        /*
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
        }*/
    }





























    /*
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
    }*/
}
