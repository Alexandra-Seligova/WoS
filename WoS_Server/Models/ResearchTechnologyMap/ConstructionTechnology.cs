namespace WoS_Server.Models
{
    using System.Collections.Generic;

    public class ConstructionTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public ConstructionTechnology()
        {
            Id_Type_Research = 4;
            NameResearchType = "Construction Technology";
            DescriptionResearchType = "Výzkum stavitelství";
        }
    }

    public class BuildingsTechnology : ConstructionTechnology
    {
        public BuildingsTechnology()
        {
            Id_Type_Research = 16;
            NameResearchType = "Buildings Technology";
            DescriptionResearchType = "Výzkum budov";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 10;
        }
    }

    public class StationsTechnology : ConstructionTechnology
    {
        public StationsTechnology()
        {
            Id_Type_Research = 17;
            NameResearchType = "SpaceStation Technology";
            DescriptionResearchType = "Výzkum stanic";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 30;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
        }
    }

    public class SatellitesTechnology : ConstructionTechnology
    {
        public SatellitesTechnology()
        {
            Id_Type_Research = 18;
            NameResearchType = "Satellites Technology";
            DescriptionResearchType = "Výzkum satelitů";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 25;
            ActualCostResource[ResourceType.Crystals] += Level * 20;
        }
    }

    public class ColoniesTechnology : ConstructionTechnology
    {
        public ColoniesTechnology()
        {
            Id_Type_Research = 19;
            NameResearchType = "Colonies Technology";
            DescriptionResearchType = "Výzkum kolonií";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Reactions, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 40;
            ActualCostResource[ResourceType.Crystals] += Level * 30;
        }
    }

    public class GalacticGatesTechnology : ConstructionTechnology
    {
        public GalacticGatesTechnology()
        {
            Id_Type_Research = 20;
            NameResearchType = "Galactic Gates Technology";
            DescriptionResearchType = "Výzkum galaktických bran";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 50;
            ActualCostResource[ResourceType.Crystals] += Level * 40;
        }
    }
}
