namespace WoS_Server.Models.ResearchTechnology
{
    using System;
    using System.Collections.Generic;

    public class MaterialResearch : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public MaterialResearch()
        {
            Id_Type_Research = 7;
            NameResearchType = "Material Research";
            DescriptionResearchType = "Výzkum materiálů";
        }
    }

    public class AlloysResearch : MaterialResearch
    {
        public AlloysResearch()
        {
            Id_Type_Research = 71;
            NameResearchType = "Alloys Research";
            DescriptionResearchType = "Výzkum slitin";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 10;
            ActualCostResource[ResourceType.Minerals] += Level * 5;
        }
    }

    public class CrystallineLatticeResearch : MaterialResearch
    {
        public CrystallineLatticeResearch()
        {
            Id_Type_Research = 72;
            NameResearchType = "Crystalline Lattice Research";
            DescriptionResearchType = "Výzkum krystalické mřížky";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Crystals] += Level * 30;
            ActualCostResource[ResourceType.Minerals] += Level * 15;
        }
    }

    public class MineralPropertiesResearch : MaterialResearch
    {
        public MineralPropertiesResearch()
        {
            Id_Type_Research = 73;
            NameResearchType = "Mineral Properties Research";
            DescriptionResearchType = "Výzkum vlastností minerálů";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Minerals] += Level * 25;
            ActualCostResource[ResourceType.Deuterium] += Level * 10;
        }
    }

    public class EnergyEfficiencyResearch : MaterialResearch
    {
        public EnergyEfficiencyResearch()
        {
            Id_Type_Research = 74;
            NameResearchType = "Energy Efficiency Research";
            DescriptionResearchType = "Výzkum energetické účinnosti";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Deuterium] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
        }
    }

    public class EssenceOfMatterResearch : MaterialResearch
    {
        public EssenceOfMatterResearch()
        {
            Id_Type_Research = 75;
            NameResearchType = "Essence of Matter Research";
            DescriptionResearchType = "Výzkum podstaty hmoty";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Antimatter] += Level * 25;
            ActualCostResource[ResourceType.DarkMatter] += Level * 20;
        }
    }
}
