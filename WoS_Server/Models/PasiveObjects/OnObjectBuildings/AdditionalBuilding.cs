namespace WoS_Server.DataModel
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class AdditionalBuilding : Base_Building
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



        public int Id_AdditionalBuilding { get; set; }  // Unikátní identifikátor mapy
        public int Id_AdditionalBuilding_Type { get; set; }  // Typ mapy
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }

        /*
        public AdditionalBuilding(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BuildingType buildingType)
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
    public class Terraformer : AdditionalBuilding
    {
        public Terraformer(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.Terraformer)
        {
            NameBuildingType = "Terraformer";
            DescriptionBuildingType = "Terraformer";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1000 * Level;
            ActualCostResource[ResourceType.Crystals] += 800 * Level;
        }
    }

    public class Laboratory : AdditionalBuilding
    {
        public Laboratory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.Laboratory)
        {
            NameBuildingType = "Laboratory";
            DescriptionBuildingType = "Laboratoř";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 700 * Level;
            ActualCostResource[ResourceType.Deuterium] += 500 * Level;
        }
    }

    public class TransportDock : AdditionalBuilding
    {
        public TransportDock(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.TransportDock)
        {
            NameBuildingType = "Transport Dock";
            DescriptionBuildingType = "Transportní dok";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1200 * Level;
            ActualCostResource[ResourceType.Crystals] += 600 * Level;
        }
    }

    public class Observatory : AdditionalBuilding
    {
        public Observatory(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.Observatory)
        {
            NameBuildingType = "Observatory";
            DescriptionBuildingType = "Observatoř";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 900 * Level;
            ActualCostResource[ResourceType.Crystals] += 400 * Level;
        }
    }*/
}
