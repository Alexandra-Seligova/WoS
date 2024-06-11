namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;

    public class WeaponsTechnology : Base_ResearchModel
    {
        public int Id_Type_Research { get; set; }
        public string NameResearchType { get; set; }
        public string DescriptionResearchType { get; set; }

        public WeaponsTechnology()
        {
            Id_Type_Research = 12;
            NameResearchType = "Weapons Technology";
            DescriptionResearchType = "Výzkum zbraní";
        }
    }

    public class ProjectileWeapons : WeaponsTechnology
    {
        public ProjectileWeapons()
        {
            Id_Type_Research = 121;
            NameResearchType = "Projectile Weapons";
            DescriptionResearchType = "Projektilové zbraně";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 1);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 10;
            ActualCostResource[ResourceType.Crystals] += Level * 10;
        }
    }

    public class EnergyWeapons : WeaponsTechnology
    {
        public EnergyWeapons()
        {
            Id_Type_Research = 122;
            NameResearchType = "Energy Weapons";
            DescriptionResearchType = "Energetické zbraně";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 2);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 20;
            ActualCostResource[ResourceType.Crystals] += Level * 15;
            ActualCostResource[ResourceType.Deuterium] += Level * 5;
        }
    }

    public class RadioactiveWeapons : WeaponsTechnology
    {
        public RadioactiveWeapons()
        {
            Id_Type_Research = 123;
            NameResearchType = "Radioactive Weapons";
            DescriptionResearchType = "Radioaktivní zbraně";

            // Add specific requirements
            RequirementsResearch.Add(ResearchType.Attack, 3);

            // Add specific costs
            ActualCostResource[ResourceType.Metal] += Level * 25;
            ActualCostResource[ResourceType.Crystals] += Level * 20;
            ActualCostResource[ResourceType.Deuterium] += Level * 10;
        }
    }
}
