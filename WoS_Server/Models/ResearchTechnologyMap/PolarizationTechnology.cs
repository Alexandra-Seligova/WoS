namespace WoS_Server.Models.ResearchTechnology
{
    using System;
    using System.Collections.Generic;

    public class PolarizationTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public PolarizationTechnology()
        {
            Id_Type_Research = 9;
            NameResearchType = "Polarization Technology";
            DescriptionResearchType = "Polarizační technologie";
        }
    }

    public class StandardPolarization : PolarizationTechnology
    {
        public StandardPolarization()
        {
            Id_Type_Research = 91;
            NameResearchType = "Standard Polarization";
            DescriptionResearchType = "Standardní polarizace";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Polarization, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
        }
    }

    public class MultiPhasePolarization : PolarizationTechnology
    {
        public MultiPhasePolarization()
        {
            Id_Type_Research = 92;
            NameResearchType = "Multi-Phase Polarization";
            DescriptionResearchType = "Multifázová polarizace";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Polarization, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Crystals] += Level * 25;
            ActualCostResource[ResourceType.Antimatter] += Level * 20;
        }
    }
}
