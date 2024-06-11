namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;

    public class MiningTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public MiningTechnology()
        {
            Id_Type_Research = 8;
            NameResearchType = "Mining Technology";
            DescriptionResearchType = "Výzkum těžby";
        }
    }

    public class PlanetaryMining : MiningTechnology
    {
        public PlanetaryMining()
        {
            Id_Type_Research = 81;
            NameResearchType = "Planetary Mining";
            DescriptionResearchType = "Planetární těžba";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Mining, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Minerals] += Level * 10;
        }
    }

    public class OrbitalMining : MiningTechnology
    {
        public OrbitalMining()
        {
            Id_Type_Research = 82;
            NameResearchType = "Orbital Mining";
            DescriptionResearchType = "Orbitální těžba";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Mining, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 25;
            ActualCostResource[ResourceType.Deuterium] += Level * 15;
        }
    }

    public class LaserMining : MiningTechnology
    {
        public LaserMining()
        {
            Id_Type_Research = 83;
            NameResearchType = "Laser Mining";
            DescriptionResearchType = "Laserová těžba";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Mining, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Crystals] += Level * 30;
            ActualCostResource[ResourceType.Deuterium] += Level * 20;
        }
    }

    public class PlasmaMining : MiningTechnology
    {
        public PlasmaMining()
        {
            Id_Type_Research = 84;
            NameResearchType = "Plasma Mining";
            DescriptionResearchType = "Plasmová těžba";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Mining, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Minerals] += Level * 35;
            ActualCostResource[ResourceType.Deuterium] += Level * 25;
        }
    }

    public class HighEnergyMining : MiningTechnology
    {
        public HighEnergyMining()
        {
            Id_Type_Research = 85;
            NameResearchType = "High Energy Mining";
            DescriptionResearchType = "Vysokoenergetická těžba";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Mining, 5);

            // Add specific costs
            ActualCostResource[ResourceType.Antimatter] += Level * 40;
            ActualCostResource[ResourceType.DarkMatter] += Level * 30;
        }
    }
}
