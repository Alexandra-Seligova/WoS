namespace WoS_Server.Models
{
    using System.Collections.Generic;

    public class BasicTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public BasicTechnology()
        {
            Id_Type_Research = 0; // Základní výzkum technologií
            NameResearchType = "Basic Technology";
            DescriptionResearchType = "Základní výzkum technologií";
        }
    }

    public class Energy : BasicTechnology
    {
        public Energy()
        {
            Id_Type_Research = 1;
            NameResearchType = "Energy";
            DescriptionResearchType = "Energie";

            // Add specific requirements (if any)
            RequirementsResearch = new Dictionary<ResearchType, int>();

            // Add specific costs
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 15 * Level },
                { ResourceType.Deuterium, 5 * Level }
            };
        }
    }

    public class Materials : BasicTechnology
    {
        public Materials()
        {
            Id_Type_Research = 2;
            NameResearchType = "Materials";
            DescriptionResearchType = "Materiály";

            // Add specific requirements (if any)
            RequirementsResearch = new Dictionary<ResearchType, int>();

            // Add specific costs
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 15 * Level },
                { ResourceType.Deuterium, 5 * Level }
            };
        }
    }

    public class Reactions : BasicTechnology
    {
        public Reactions()
        {
            Id_Type_Research = 3;
            NameResearchType = "Reactions";
            DescriptionResearchType = "Reakce";

            // Add specific requirements (if any)
            RequirementsResearch = new Dictionary<ResearchType, int>();

            // Add specific costs
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 15 * Level },
                { ResourceType.Deuterium, 5 * Level }
            };
        }
    }

    public class Attack : BasicTechnology
    {
        public Attack()
        {
            Id_Type_Research = 4;
            NameResearchType = "Attack";
            DescriptionResearchType = "Útok";

            // Add specific requirements (if any)
            RequirementsResearch = new Dictionary<ResearchType, int>();

            // Add specific costs
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 15 * Level },
                { ResourceType.Deuterium, 5 * Level }
            };
        }
    }

    public class Defense : BasicTechnology
    {
        public Defense()
        {
            Id_Type_Research = 5;
            NameResearchType = "Defense";
            DescriptionResearchType = "Obrana";

            // Add specific requirements (if any)
            RequirementsResearch = new Dictionary<ResearchType, int>();

            // Add specific costs
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, 10 * Level },
                { ResourceType.Crystals, 15 * Level },
                { ResourceType.Deuterium, 5 * Level }
            };
        }
    }
}
