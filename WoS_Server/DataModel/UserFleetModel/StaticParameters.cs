namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;


    public class StaticParameters
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

    }
}
