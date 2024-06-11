namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;

    public class ArmorTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public ArmorTechnology()
        {
            Id_Type_Research = 2;
            NameResearchType = "Armor Technology";
            DescriptionResearchType = "Výzkum pancíře";

            // Initialize RequirementsResearch
            RequirementsResearch = new Dictionary<ResearchType, int>
            {
                { ResearchType.Defense, 2 }
            };

            // Initialize ActualCostResource
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 5 * Level }
            };
        }
    }

    public class LightArmorTechnology : ArmorTechnology
    {
        public LightArmorTechnology()
        {
            Id_Type_Research = 21;
            NameResearchType = "Light Armor Technology";
            DescriptionResearchType = "Lehčený pancíř: Transportéry";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 5;
            ActualCostResource[ResourceType.Crystals] += Level * 3;
        }
    }

    public class MultiLayeredArmorTechnology : ArmorTechnology
    {
        public MultiLayeredArmorTechnology()
        {
            Id_Type_Research = 22;
            NameResearchType = "Multi-Layered Armor Technology";
            DescriptionResearchType = "Vícevrstvý pancíř: Umožňuje násobné zvýšení";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 15;
            ActualCostResource[ResourceType.Crystals] += Level * 10;
        }
    }

    public class PolarizedArmorTechnology : ArmorTechnology
    {
        public PolarizedArmorTechnology()
        {
            Id_Type_Research = 23;
            NameResearchType = "Polarized Armor Technology";
            DescriptionResearchType = "Polarizovaný pancíř: Má navíc vlastní štít typu regenerace";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Defense, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
            ActualCostResource[ResourceType.Deuterium] += Level * 5;
        }
    }
}
