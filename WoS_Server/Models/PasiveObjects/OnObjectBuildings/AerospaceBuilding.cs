namespace WoS_Server.Models
{
    using WoS_Server.Models;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class AerospaceBuilding : Base_Building
    {
        public BuildingType BuildingType { get; set; }
        public string NameBuildingType { get; set; }
        public string DescriptionBuildingType { get; set; }


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
        }
    }

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
    }
}