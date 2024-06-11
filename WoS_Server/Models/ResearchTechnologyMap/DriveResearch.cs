namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;

    public class DriveResearch : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public DriveResearch()
        {
            Id_Type_Research = 5;
            NameResearchType = "Drive Research";
            DescriptionResearchType = "Výzkum pohonů";
        }
    }

    public class HydrogenDriveResearch : DriveResearch
    {
        public HydrogenDriveResearch()
        {
            Id_Type_Research = 21;
            NameResearchType = "Hydrogen Drive Research";
            DescriptionResearchType = "Výzkum vodíkového pohonu";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Deuterium] += Level * 15;
        }
    }

    public class ImpulseDriveResearch : DriveResearch
    {
        public ImpulseDriveResearch()
        {
            Id_Type_Research = 22;
            NameResearchType = "Impulse Drive Research";
            DescriptionResearchType = "Výzkum impulzního pohonu";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 30;
            ActualCostResource[ResourceType.Deuterium] += Level * 25;
        }
    }

    public class FTLDriveResearch : DriveResearch
    {
        public FTLDriveResearch()
        {
            Id_Type_Research = 23;
            NameResearchType = "FTL Drive Research";
            DescriptionResearchType = "Výzkum FTL pohonu (Faster Than Light)";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.HighEnergyTechnology, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 50;
            ActualCostResource[ResourceType.DarkMatter] += Level * 40;
        }
    }

    public class WarpDriveResearch : DriveResearch
    {
        public WarpDriveResearch()
        {
            Id_Type_Research = 24;
            NameResearchType = "Warp Drive Research";
            DescriptionResearchType = "Výzkum warpového pohonu";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.HighEnergyTechnology, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 50;
            ActualCostResource[ResourceType.Antimatter] += Level * 30;
        }
    }

    public class ProtonDriveResearch : DriveResearch
    {
        public ProtonDriveResearch()
        {
            Id_Type_Research = 25;
            NameResearchType = "Proton Drive Research";
            DescriptionResearchType = "Výzkum protonového pohonu";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Energy, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 40;
            ActualCostResource[ResourceType.Crystals] += Level * 25;
        }
    }
}
