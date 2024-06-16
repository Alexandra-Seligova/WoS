namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class NpcsModel
    {

        public int Id_Map { get; set; } // Unikátní identifikátor boxu
        public int Id_ObjektType { get; set; } // 14

        [Key]
        public int Id_Npc { get; set; }  // Typ 
        public int Id_Npc_Type { get; set; }  // Typ Borgs
        public int Id_Npc_SubType { get; set; }  // Typ Cube

        public int Id_Position { get; set; }
        public int Id_NpcConfig { get; set; }
        public int Id_Cargo { get; set; }

        public int Id_Npc_StaticParameters { get; set; }
        public int Id_Npc_ActualParameters { get; set; }

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
