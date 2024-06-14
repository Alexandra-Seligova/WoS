namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Reprezentuje model lodi, který dědí základní vlastnosti z Base_Module.
    /// </summary>
    public class ShipModel
    {

        public int Id_User { get; set; } // id serveru
        public int Id_Fleet { get; set; } // Identifikátor letky, ke které loď patří

        public int Id_Fleet_Formation { get; set; } // Formace letky
        public int Id_Fleet_FormationPosition { get; set; } // Pozice lodi ve formaci

        [Key]
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        public int Id_Ship_Type { get; set; } // Unikátní identifikátor lodi
        public int Id_Destructible_Type { get; set; }  // Typ

        /// <summary>Název objektu.</summary>
        public string Name { get; set; }
        public int Level { get; set; }
        /// <summary>Označení objektu. Výchozí hodnota je "Ship".</summary>
        public string Designation { get; set; } = "Ship";

        public StaticParameters StaticParameters { get; set; } // Statické parametry lodi

        public ActualParameters ActualParameters { get; set; } // Dynamické parametry lodi

        public ShipConfigurations Configurations { get; set; } // Dynamické parametry lodi



        // Stavová proměnná a zpráva
        public bool FirstRun { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public ShipModel()
    : base()
        {

        }
        public void Attack()
        {
            // Implementace útoku
        }
    }
    public class ShipConfigurations
    {

        public int Id_User { get; set; } // id serveru
        [Key]
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        // Generátory
        public List<ShipComponent> Generators { get; set; }
        // Zbraně
        public List<ShipComponent> Weapons { get; set; }
        // Rozšíření
        public List<ShipComponent> Extensions { get; set; }
        // Munice
        public List<ShipComponent> Ammos { get; set; }
        // Animace
        public List<ShipComponent> Animations { get; set; }

        public ShipConfigurations()
        {
            Generators = new List<ShipComponent>();
            Weapons = new List<ShipComponent>();
            Extensions = new List<ShipComponent>();
            Ammos = new List<ShipComponent>();
            Animations = new List<ShipComponent>();
        }
    }

    public class ShipComponent
    {
        public int Id_User { get; set; } // id serveru
        [Key]
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        public int Id_Ship_Component { get; set; } // Unikátní identifikátor komponenty

        public int Id_Ship_Component_Type { get; set; } // Unikátní identifikátor komponenty


        public string Name { get; set; } // Název komponenty
        public ShipComponentType Type { get; set; } // Typ komponenty (např. generátor, zbraň, rozšíření)
        public Vector3 PositionOnShip { get; set; } // Pozice na lodi
    }
    public enum ShipComponentType
    {
        Generator,   // Generátor
        Weapon,      // Zbraň
        Extension,   // Rozšíření
        Ammo,        // Munice
        Animation    // Animace
    }


    // Třída reprezentující statické vlastnosti lodi, které jsou konstantní
    public class ShipStaticParameters
    {
        public int Id_User { get; set; } // id serveru
        /// <summary>Unikátní identifikátor lodi.</summary>
        [Key]
        public int Id_Ship { get; set; }

        public int Id_Ship_StaticParameters { get; set; } // Unikátní identifikátor komponenty

        /// <summary>Název lodi.</summary>
        [Required]
        [MaxLength(255)]
        public string Ship_Name { get; set; }

        public bool CanBeDestroyed { get; set; } = true; // Výchozí hodnota je true, což znamená, že objekt může být zničen.

        /// <summary>Místo, kde se objekt objevil ve 3D prostoru.</summary>
        public Vector3 SpawnPlace { get; set; }

        public int MaxHP { get; set; }

        /// <summary>Aktuální útočná síla objektu.</summary>
        public int MaxArmor { get; set; }


        public int MaxStructuralIntegrity { get; set; }

        public int MaxShield { get; set; }
        public int MaxShieldLeft { get; set; }
        public int MaxShieldRight { get; set; }
        public int MaxShieldFront { get; set; }
        public int MaxShieldBack { get; set; }



        /// <summary>Maximální rychlost lodi.</summary>
        public float MaxSpeed { get; set; }

        /// <summary>Maximální zdraví lodi.</summary>
        public int MaxHealth { get; set; }

        /// <summary>Maximální útočná síla lodi.</summary>
        public int MaxAttackPower { get; set; }

        /// <summary>Popis lodi.</summary>
        public string Description { get; set; }

        public ShipStaticParameters()
        {
            // Výchozí hodnoty
            MaxSpeed = 100f; // Výchozí maximální rychlost
            MaxHealth = 100; // Výchozí maximální zdraví
            MaxAttackPower = 10; // Výchozí maximální útočná síla
        }
    }
}
