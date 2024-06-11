namespace WoS_Server.Models
{
    using System.Collections.Generic;

    public class AdvancedTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public AdvancedTechnology()
        {
            Id_Type_Research = 0; // není to konkrétní druh výzkumu
            NameResearchType = "Advanced Technology";
            DescriptionResearchType = "Pokročilý výzkum technologií";

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

    public class ElectronTechnology : AdvancedTechnology
    {
        public ElectronTechnology()
        {
            Id_Type_Research = 6;
            NameResearchType = "Electron Technology";
            DescriptionResearchType = "Elektronová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 10;
            ActualCostResource[ResourceType.Crystals] += Level * 10;
            ActualCostResource[ResourceType.Deuterium] += Level * 10;
        }
    }

    public class PhotonTechnology : AdvancedTechnology
    {
        public PhotonTechnology()
        {
            Id_Type_Research = 7;
            NameResearchType = "Photon Technology";
            DescriptionResearchType = "Fotonová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 15;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
            ActualCostResource[ResourceType.Deuterium] += Level * 10;
        }
    }

    public class IonTechnology : AdvancedTechnology
    {
        public IonTechnology()
        {
            Id_Type_Research = 8;
            NameResearchType = "Ion Technology";
            DescriptionResearchType = "Iontová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
            ActualCostResource[ResourceType.Deuterium] += Level * 15;
        }
    }

    public class PlasmaTechnology : AdvancedTechnology
    {
        public PlasmaTechnology()
        {
            Id_Type_Research = 9;
            NameResearchType = "Plasma Technology";
            DescriptionResearchType = "Plazmová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 25;
            ActualCostResource[ResourceType.Crystals] += Level * 20;
            ActualCostResource[ResourceType.Deuterium] += Level * 15;
        }
    }

    public class HighEnergyTechnology : AdvancedTechnology
    {
        public HighEnergyTechnology()
        {
            Id_Type_Research = 10;
            NameResearchType = "High-Energy Technology";
            DescriptionResearchType = "Vysokoenergetická technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 6);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 30;
            ActualCostResource[ResourceType.Crystals] += Level * 25;
            ActualCostResource[ResourceType.Deuterium] += Level * 20;
        }
    }

    public class HyperspaceTechnology : AdvancedTechnology
    {
        public HyperspaceTechnology()
        {
            Id_Type_Research = 11;
            NameResearchType = "Hyperspace Technology";
            DescriptionResearchType = "Hyperprostorová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 8);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 35;
            ActualCostResource[ResourceType.Crystals] += Level * 30;
            ActualCostResource[ResourceType.Deuterium] += Level * 25;
        }
    }

    public class GravitonTechnology : AdvancedTechnology
    {
        public GravitonTechnology()
        {
            Id_Type_Research = 8;
            NameResearchType = "Graviton Technology";
            DescriptionResearchType = "Gravitonová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 10);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 40;
            ActualCostResource[ResourceType.Crystals] += Level * 35;
            ActualCostResource[ResourceType.Deuterium] += Level * 30;
        }
    }

    public class ComputerTechnology : AdvancedTechnology
    {
        public ComputerTechnology()
        {
            Id_Type_Research = 12;
            NameResearchType = "Computer Technology";
            DescriptionResearchType = "Počítačová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 45;
            ActualCostResource[ResourceType.Crystals] += Level * 40;
            ActualCostResource[ResourceType.Deuterium] += Level * 35;
        }
    }

    public class LaserTechnology : AdvancedTechnology
    {
        public LaserTechnology()
        {
            Id_Type_Research = 10;
            NameResearchType = "Laser Technology";
            DescriptionResearchType = "Laserová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 50;
            ActualCostResource[ResourceType.Crystals] += Level * 45;
            ActualCostResource[ResourceType.Deuterium] += Level * 40;
        }
    }

    public class QuantumTechnology : AdvancedTechnology
    {
        public QuantumTechnology()
        {
            Id_Type_Research = 13;
            NameResearchType = "Quantum Technology";
            DescriptionResearchType = "Kvantová technologie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 55;
            ActualCostResource[ResourceType.Crystals] += Level * 50;
            ActualCostResource[ResourceType.Deuterium] += Level * 45;
        }
    }
}
