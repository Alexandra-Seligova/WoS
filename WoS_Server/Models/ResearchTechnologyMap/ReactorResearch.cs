namespace WoS_Server.Models
{
    using System.Collections.Generic;

    public class ReactorResearch : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public ReactorResearch()
        {
            Id_Type_Research = 10;
            NameResearchType = "Reactor Research";
            DescriptionResearchType = "Výzkum reaktorů";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 5);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += 150;
            ActualCostResource[ResourceType.Crystals] += 200;
            ActualCostResource[ResourceType.Deuterium] += 100;
        }
    }

    public class HydrogenReactor : ReactorResearch
    {
        public HydrogenReactor()
        {
            Id_Type_Research = 11;
            NameResearchType = "Hydrogen Reactor";
            DescriptionResearchType = "Vodíkový reaktor";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 4);
            RequirementsResearch.Add(ResearchType.Reactions, 2);
            RequirementsResearch.Add(ResearchType.Hydrogen, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
            ActualCostResource[ResourceType.Deuterium] += Level * 10;
        }
    }

    public class NuclearReactor : ReactorResearch
    {
        public NuclearReactor()
        {
            Id_Type_Research = 12;
            NameResearchType = "Nuclear Reactor";
            DescriptionResearchType = "Jaderný reaktor";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 5);
            RequirementsResearch.Add(ResearchType.Reactions, 4);
            RequirementsResearch.Add(ResearchType.ComputerTechnology, 3);
            RequirementsResearch.Add(ResearchType.Nuclear, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 30;
            ActualCostResource[ResourceType.Crystals] += Level * 20;
            ActualCostResource[ResourceType.Deuterium] += Level * 15;
        }
    }

    public class FusionReactor : ReactorResearch
    {
        public FusionReactor()
        {
            Id_Type_Research = 13;
            NameResearchType = "Fusion Reactor";
            DescriptionResearchType = "Fůzní reaktor";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 7);
            RequirementsResearch.Add(ResearchType.Reactions, 6);
            RequirementsResearch.Add(ResearchType.ComputerTechnology, 6);
            RequirementsResearch.Add(ResearchType.Fusion, 4);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 40;
            ActualCostResource[ResourceType.Crystals] += Level * 30;
            ActualCostResource[ResourceType.Deuterium] += Level * 20;
        }
    }

    public class AntimatterReactor : ReactorResearch
    {
        public AntimatterReactor()
        {
            Id_Type_Research = 14;
            NameResearchType = "Antimatter Reactor";
            DescriptionResearchType = "Antihmotový reaktor";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 10);
            RequirementsResearch.Add(ResearchType.Reactions, 8);
            RequirementsResearch.Add(ResearchType.ComputerTechnology, 10);
            RequirementsResearch.Add(ResearchType.AntimatterReactor, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 50;
            ActualCostResource[ResourceType.Crystals] += Level * 40;
            ActualCostResource[ResourceType.Deuterium] += Level * 30;
        }
    }

    public class DarkMatterReactor : ReactorResearch
    {
        public DarkMatterReactor()
        {
            Id_Type_Research = 15;
            NameResearchType = "Dark Matter Reactor";
            DescriptionResearchType = "Temnohmotový reaktor";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Materials, 12);
            RequirementsResearch.Add(ResearchType.Reactions, 12);
            RequirementsResearch.Add(ResearchType.ComputerTechnology, 12);
            RequirementsResearch.Add(ResearchType.DarkMatterReactor, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 60;
            ActualCostResource[ResourceType.Crystals] += Level * 50;
            ActualCostResource[ResourceType.Deuterium] += Level * 40;
        }
    }
}
