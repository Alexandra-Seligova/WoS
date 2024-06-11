namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    /*
     public int Id_Global { get; set; }

 /// <summary>Identifikace uživatele, pod kterého objekt spadá.</summary>
 public int Id_User { get; set; }

 /// <summary>Typ objektu (např. "Battle", "Exploration", "MiningTechnology", "Transport").</summary>
 public int Id_Type { get; set; }

 public int Status { get; set; }

 /// <summary>Název objektu.</summary>
 public string Name { get; set; }

 /// <summary>Typ objektu (např. "Battle", "Exploration", "MiningTechnology", "Transport").</summary>
 public string Type { get; set; }

 /// <summary>Označení objektu. Výchozí hodnota je "Ship".</summary>
 public string Designation { get; set; } = "Ship";

 /// <summary>Popis objektu.</summary>
 public string Description { get; set; }

 /// <summary>Místo, kde se objekt objevil ve 3D prostoru.</summary>
 public Vector3 SpawnPlace { get; set; }

 /// <summary>Pozice objektu ve 3D prostoru.</summary>
 public Vector3 Position { get; set; }

 /// <summary>Globální pozice objektu na mapě.</summary>
 public Vector2 PositionOnMap { get; set; }

 /// <summary>Cílová pozice objektu.</summary>
 public Vector2 TargetPosition { get; set; }

 /// <summary>Rotace objektu v prostoru.</summary>
 public float Rotation { get; set; }

 /// <summary>Rychlost objektu.</summary>
 public Vector2 Velocity { get; set; }

 // Základní vlastnosti lodi
 public float Acceleration { get; set; }

 /// <summary>Šířka objektu (X-osa).</summary>
 public int Width { get; set; }

 /// <summary>Výška objektu (Y-osa).</summary>
 public int Height { get; set; }

 /// <summary>Hloubka objektu (Z-osa).</summary>
 public int Depth { get; set; }

 public int Weight { get; set; }

 private bool _canBeDestroyed;

 /// <summary>Objekt, vůči kterému je objekt svázaný gravitačním polem.</summary>
 public Vector3 GravityCenter { get; set; }

 /// <summary>Objekt, okolo kterého se objekt otáčí.</summary>
 public Vector3 OrbitalCenter { get; set; }


        private float _hp;
        private float _maxHP;
        private float _armor;
        private float _maxArmor;
        private float _structuralIntegrity;
        private float _maxStructuralIntegrity;
        private float _shield;
        private float _maxShield;

        public Dictionary<ResourceType, int> InitialCostResource { get; set; } // nákupní cena
        public Dictionary<ResourceType, int> CurrentCostResource { get; set; } // získatelná cena při zničení
        public float DepreciationRate { get; set; } = 0.6f; // Procentuální pokles ceny při zničení o 60%

    */

    public class Base_NpcsModel : Base_DestructibleMapObjectModel
    {

        public int Level { get; set; }

        /// <summary>
        /// Inteligence NPC:
        /// 0 - nevnímá,
        /// 1 - pokud je nepřítel v dosahu, začne útočit,
        /// 2 - vyhledává nepřátelské lodě.
        /// </summary>
        public int IntelligenceQuotient { get; set; }

        public Dictionary<ResourceType, int> ActualCostResource { get; set; }
        public bool IsCostMet { get; set; }

        // Constructor
        protected Base_NpcsModel(int idGlobal, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, 0, spawnPlace, width, height, depth)
        {
            ActualCostResource = new Dictionary<ResourceType, int>();
        }
    }

    public enum NpcsType
    {
        Borgs,        // Borgové
        Cylons,       // Cyloni
        Replicators,  // Replicátoři
        SpaceCreatures // Vesmírní tvorové
    }

    public enum BorgType
    {
        Cube,          // Krychle
        Sphere,        // Koule
        Scout,         // Malá průzkumná
        Diamond        // Diamant
    }

    public enum CylonType
    {
        Raider,        // Stíhačka
        HeavyRaider,   // Těžká stíhačka
        Basestar,      // Hvězdná základna
        ResurrectionShip // Loď znovuzrození
    }

    public enum ReplicatorType
    {
        Ship,          // Loď
        AdvancedShip   // Pokročilá loď
    }

    public enum SpaceCreatureType
    {
        Lordakia,      // Lordakia
        Saimon,        // Saimon
        Mordon,        // Mordon
        Devolarium,    // Devolarium
        Sibelon,       // Sibelon
        Sibelonit,     // Sibelonit
        Lordakium,     // Lordakium
        Kristallin,    // Kristallin
        Kristallon     // Kristallon
    }

    public enum SpaceCreatureStrength
    {
        Common,        // Běžné
        Boss,          // Boss
        Uber           // Uber
    }
}
