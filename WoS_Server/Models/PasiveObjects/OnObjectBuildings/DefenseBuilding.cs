namespace WoS_Server.DataModel
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class DefenseBuilding : Base_Building
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


        public int Id_DefenseBuilding { get; set; }  // Unikátní identifikátor mapy
        public int Id_DefenseBuilding_Type { get; set; }  // Typ mapy
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }
        /*
        public DefenseBuilding(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BuildingType buildingType)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            BuildingType = buildingType;

            // Initialize RequirementsResearch
            RequirementsResearch = new Dictionary<ResearchType, int>
            {
                { ResearchType.Defense, 2 }
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
    public class RocketLauncher : DefenseBuilding
    {
        public RocketLauncher(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.RocketLauncher)
        {
            NameBuildingType = "Rocket Launcher";
            DescriptionBuildingType = "Raketomet";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 800 * Level;
            ActualCostResource[ResourceType.Crystals] += 600 * Level;
        }
    }

    public class LaserCannon : DefenseBuilding
    {
        public LaserCannon(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.LaserCannon)
        {
            NameBuildingType = "Laser Cannon";
            DescriptionBuildingType = "Laserové dělo";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1000 * Level;
            ActualCostResource[ResourceType.Crystals] += 800 * Level;
        }
    }

    public class HeavyLaser : DefenseBuilding
    {
        public HeavyLaser(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.HeavyLaser)
        {
            NameBuildingType = "Heavy Laser";
            DescriptionBuildingType = "Těžký laser";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1200 * Level;
            ActualCostResource[ResourceType.Crystals] += 900 * Level;
        }
    }

    public class IonTower : DefenseBuilding
    {
        public IonTower(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.IonTower)
        {
            NameBuildingType = "Ion Tower";
            DescriptionBuildingType = "Iontová věž";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1100 * Level;
            ActualCostResource[ResourceType.Crystals] += 900 * Level;
        }
    }

    public class PlasmaGun : DefenseBuilding
    {
        public PlasmaGun(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.PlasmaGun)
        {
            NameBuildingType = "Plasma Gun";
            DescriptionBuildingType = "Plazmový kulomet";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 1500 * Level;
            ActualCostResource[ResourceType.Crystals] += 1200 * Level;
        }
    }

    public class SmallShield : DefenseBuilding
    {
        public SmallShield(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.SmallShield)
        {
            NameBuildingType = "Small Shield";
            DescriptionBuildingType = "Malý štít";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 900 * Level;
            ActualCostResource[ResourceType.Crystals] += 700 * Level;
        }
    }

    public class PlanetaryShield : DefenseBuilding
    {
        public PlanetaryShield(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.PlanetaryShield)
        {
            NameBuildingType = "Planetary Shield";
            DescriptionBuildingType = "Planetární štít";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 2000 * Level;
            ActualCostResource[ResourceType.Crystals] += 1500 * Level;
        }
    }

    public class MissileSilo : DefenseBuilding
    {
        public MissileSilo(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BuildingType.MissileSilo)
        {
            NameBuildingType = "Missile Silo";
            DescriptionBuildingType = "Raketové silo";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 2500 * Level;
            ActualCostResource[ResourceType.Crystals] += 2000 * Level;
            ActualCostResource[ResourceType.Deuterium] += 1500 * Level;
        }
    }*/
}
