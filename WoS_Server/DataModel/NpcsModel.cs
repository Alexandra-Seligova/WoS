namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class NpcsModel : Base_DestructibleObjectModel
    {
        /*
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
*/

        public int Id_Npc { get; set; }  // Typ 
        public int Id_Npc_Type { get; set; }  // Typ Borgs
        public int Id_Npc_SubType { get; set; }  // Typ Cube
        public int Id_Npc_StrengeType { get; set; }  // Typ Boss


        /// <summary>
        /// Inteligence NPC:
        /// 0 - nevnímá,
        /// 1 - pokud je nepřítel v dosahu, začne útočit,
        /// 2 - vyhledává nepřátelské lodě.
        /// </summary>
        public int IntelligenceQuotient { get; set; }


        // Constructor
        protected NpcsModel()
            : base()
        {

        }
    }

    public enum NpcsType
    {
        Borgs=1,        // Borgové
        Cylons=2,       // Cyloni
        Replicators=3,  // Replicátoři
        SpaceCreatures=4 // Vesmírní tvorové
    }

    public enum BorgType
    {
        Cube=1,          // Krychle
        Sphere=2,        // Koule
        Scout=3,         // Malá průzkumná
        Diamond=4        // Diamant
    }

    public enum CylonType
    {
        Raider=1,        // Stíhačka
        HeavyRaider=2,   // Těžká stíhačka
        Basestar=3,      // Hvězdná základna
        ResurrectionShip=4 // Loď znovuzrození
    }

    public enum ReplicatorType
    {
        Ship=1,          // Loď
        AdvancedShip=2   // Pokročilá loď
    }

    public enum SpaceCreatureType
    {
        Lordakia=1,      // Lordakia
        Saimon=2,        // Saimon
        Mordon=3,        // Mordon
        Devolarium=4,    // Devolarium
        Sibelon=5,       // Sibelon
        Sibelonit=6,     // Sibelonit
        Lordakium=7,     // Lordakium
        Kristallin=8,    // Kristallin
        Kristallon=9     // Kristallon
    }

    public enum SpaceCreatureStrength
    {
        Common=1,        // Běžné
        Boss=2,          // Boss
        Uber=3           // Uber
    }
}
