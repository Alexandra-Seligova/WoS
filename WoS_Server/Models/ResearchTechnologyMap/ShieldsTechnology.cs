namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;

    public class ShieldsTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public ShieldsTechnology()
        {
            Id_Type_Research = 11;
            NameResearchType = "Shields Technology";
            DescriptionResearchType = "Výzkum štítů";
        }
    }

    public class StandardShields : ShieldsTechnology
    {
        public StandardShields()
        {
            Id_Type_Research = 111;
            NameResearchType = "Standard Shields";
            DescriptionResearchType = "Standardní štíty";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 10;
            ActualCostResource[ResourceType.Crystals] += Level * 10;
        }
    }

    public class HighCapacityShields : ShieldsTechnology
    {
        public HighCapacityShields()
        {
            Id_Type_Research = 112;
            NameResearchType = "High Capacity Shields";
            DescriptionResearchType = "Vysokokapacitní štíty";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
            ActualCostResource[ResourceType.Deuterium] += Level * 5;
        }
    }

    public class RegenerativeShields : ShieldsTechnology
    {
        public RegenerativeShields()
        {
            Id_Type_Research = 113;
            NameResearchType = "Regenerative Shields";
            DescriptionResearchType = "Regenerační štíty";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 25;
            ActualCostResource[ResourceType.Crystals] += Level * 20;
            ActualCostResource[ResourceType.Deuterium] += Level * 10;
        }
    }

    public class AdaptiveShields : ShieldsTechnology
    {
        public AdaptiveShields()
        {
            Id_Type_Research = 114;
            NameResearchType = "Adaptive Shields";
            DescriptionResearchType = "Adaptabilní štíty";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 30;
            ActualCostResource[ResourceType.Crystals] += Level * 25;
            ActualCostResource[ResourceType.Antimatter] += Level * 15;
        }
    }
}
