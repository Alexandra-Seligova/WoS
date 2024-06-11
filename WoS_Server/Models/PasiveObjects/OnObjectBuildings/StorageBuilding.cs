namespace WoS_Server.DataModel
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class StorageBuilding : Base_Building
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


        public int Id_StorageBuilding { get; set; }  // Unikátní identifikátor mapy
        public int Id_StorageBuilding_Type { get; set; }  // Typ mapy
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }




        /*
        public StorageBuilding(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BuildingType buildingType)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            BuildingType = buildingType;

            // Initialize RequirementsResearch
            RequirementsResearch = new Dictionary<ResearchType, int>
            {
                { ResearchType.Materials, 1 }
            };

            // Initialize ActualCostResource
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 5 * Level },
                { ResourceType.Deuterium, 2 * Level }
            };
        }*/

    }































    /*
    public class MetalStorage : StorageBuilding
    {
        public MetalStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.MetalStorage)
        {
            NameBuildingType = "Metal Storage";
            DescriptionBuildingType = "Sklad kovů";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 500 * Level;
            ActualCostResource[ResourceType.Crystals] += 200 * Level;
        }
    }

    public class CrystalStorage : StorageBuilding
    {
        public CrystalStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.CrystalStorage)
        {
            NameBuildingType = "Crystal Storage";
            DescriptionBuildingType = "Sklad krystalů";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 400 * Level;
            ActualCostResource[ResourceType.Crystals] += 300 * Level;
        }
    }

    public class MineralStorage : StorageBuilding
    {
        public MineralStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.MineralStorage)
        {
            NameBuildingType = "Mineral Storage";
            DescriptionBuildingType = "Sklad minerálů";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 600 * Level;
            ActualCostResource[ResourceType.Crystals] += 300 * Level;
        }
    }

    public class DeuteriumStorage : StorageBuilding
    {
        public DeuteriumStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.DeuteriumStorage)
        {
            NameBuildingType = "Deuterium Storage";
            DescriptionBuildingType = "Sklad deuteria";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 700 * Level;
            ActualCostResource[ResourceType.Crystals] += 200 * Level;
            ActualCostResource[ResourceType.Deuterium] += 100 * Level;
        }
    }

    public class AlloyStorage : StorageBuilding
    {
        public AlloyStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.AlloyStorage)
        {
            NameBuildingType = "Alloy Storage";
            DescriptionBuildingType = "Sklad slitin";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 800 * Level;
            ActualCostResource[ResourceType.Crystals] += 400 * Level;
            ActualCostResource[ResourceType.Deuterium] += 200 * Level;
        }
    }

    public class ChipStorage : StorageBuilding
    {
        public ChipStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.ChipStorage)
        {
            NameBuildingType = "Chip Storage";
            DescriptionBuildingType = "Sklad čipů";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 600 * Level;
            ActualCostResource[ResourceType.Crystals] += 300 * Level;
        }
    }

    public class FuelStorage : StorageBuilding
    {
        public FuelStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.FuelStorage)
        {
            NameBuildingType = "Fuel Storage";
            DescriptionBuildingType = "Sklad paliva";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 700 * Level;
            ActualCostResource[ResourceType.Crystals] += 400 * Level;
            ActualCostResource[ResourceType.Deuterium] += 200 * Level;
        }
    }

    public class ComponentStorage : StorageBuilding
    {
        public ComponentStorage(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.ComponentStorage)
        {
            NameBuildingType = "Component Storage";
            DescriptionBuildingType = "Sklad součástek";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 800 * Level;
            ActualCostResource[ResourceType.Crystals] += 400 * Level;
            ActualCostResource[ResourceType.Deuterium] += 200 * Level;
        }
    }*/
}