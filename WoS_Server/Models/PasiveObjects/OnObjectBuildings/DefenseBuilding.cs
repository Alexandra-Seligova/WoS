namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class DefenseBuilding : Base_Building
    {
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }

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
        }
    }

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
    }
}
