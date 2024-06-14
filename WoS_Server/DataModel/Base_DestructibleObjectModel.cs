namespace WoS_Server.DataModel
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class Base_DestructibleObjectModel
    {
        public int Id_User { get; set; } = 0; // id 
        public int Id_Map { get; set; } = 1;  // Unikátní identifikátor mapy

        public int Id_Destructible { get; set; }   // Unikátní identifikátor 
        public int Id_Destructible_Type { get; set; }  // Typ 

        public int Level { get; set; }

        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Armor { get; set; }
        public int MaxArmor { get; set; }
        public int StructuralIntegrity { get; set; }
        public int MaxStructuralIntegrity { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public bool CanBeDestroyed { get; set; } = true; // Výchozí hodnota je true, což znamená, že objekt může být zničen.

        public Dictionary<ResourceType, int> InitialCostResource { get; set; } // nákupní cena
        public Dictionary<ResourceType, int> CurrentCostResource { get; set; } // získatelná cena při zničení
        public float DepreciationRate { get; set; } = 0.6f; // Procentuální pokles ceny při zničení o 60%

        public Base_DestructibleObjectModel()
        {
            InitialCostResource = new Dictionary<ResourceType, int>();
            CurrentCostResource = new Dictionary<ResourceType, int>();
        }
    }

}