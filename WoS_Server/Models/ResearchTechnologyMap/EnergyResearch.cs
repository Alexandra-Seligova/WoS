namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;

    public class EnergyResearch : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public EnergyResearch()
        {
            Id_Type_Research = 6;
            NameResearchType = "Energy Research";
            DescriptionResearchType = "Výzkum energie";
        }
    }

    public class HydrogenEnergyResearch : EnergyResearch
    {
        public HydrogenEnergyResearch()
        {
            Id_Type_Research = 61;
            NameResearchType = "Hydrogen Energy Research";
            DescriptionResearchType = "Výzkum vodíkové energie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Deuterium] += Level * 15;
        }
    }

    public class NuclearEnergyResearch : EnergyResearch
    {
        public NuclearEnergyResearch()
        {
            Id_Type_Research = 62;
            NameResearchType = "Nuclear Energy Research";
            DescriptionResearchType = "Výzkum jaderné energie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 30;
            ActualCostResource[ResourceType.Deuterium] += Level * 25;
        }
    }

    public class FusionEnergyResearch : EnergyResearch
    {
        public FusionEnergyResearch()
        {
            Id_Type_Research = 63;
            NameResearchType = "Fusion Energy Research";
            DescriptionResearchType = "Výzkum fúzní energie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.HighEnergyTechnology, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 50;
            ActualCostResource[ResourceType.Deuterium] += Level * 40;
        }
    }

    public class AntimatterEnergyResearch : EnergyResearch
    {
        public AntimatterEnergyResearch()
        {
            Id_Type_Research = 64;
            NameResearchType = "Antimatter Energy Research";
            DescriptionResearchType = "Výzkum antihmotové energie";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.HighEnergyTechnology, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 50;
            ActualCostResource[ResourceType.Antimatter] += Level * 30;
        }
    }
}
