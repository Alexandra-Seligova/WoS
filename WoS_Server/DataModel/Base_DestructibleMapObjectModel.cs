namespace WoS_Server.DataModel
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class Base_DestructibleMapObjectModel
    {
        public int Id_User { get; set; } = 0; // id 
        public int Id_Map { get; set; } = 1;  // Unikátní identifikátor mapy

        public int Id_Destructible { get; set; }   // Unikátní identifikátor 
        public int Id_Destructible_Type { get; set; }  // Typ 


        public int Level { get; set; }

        int _hp;
        int _maxHP;
        int _armor;
        int _maxArmor;
        int _structuralIntegrity;
        int _maxStructuralIntegrity;
        int _shield;
        int _maxShield;

        bool canBeDestroyed;

        public Dictionary<ResourceType, int> InitialCostResource { get; set; } // nákupní cena
        public Dictionary<ResourceType, int> CurrentCostResource { get; set; } // získatelná cena při zničení
        public float DepreciationRate { get; set; } = 0.6f; // Procentuální pokles ceny při zničení o 60%

        public Base_DestructibleMapObjectModel()
        {
            canBeDestroyed = true; // Výchozí hodnota je true, což znamená, že objekt může být zničen.



        }
    }
}