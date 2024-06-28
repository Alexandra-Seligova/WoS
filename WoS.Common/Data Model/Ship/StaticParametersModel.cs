namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class StaticParametersModel
    {
        public int Id_User { get; set; } // id serveru
        /// <summary>Unikátní identifikátor lodi.</summary>
        [Key]
        public int Id_Ship { get; set; }

        public int Id_StaticParameters { get; set; } // Unikátní identifikátor komponenty

        public string Name { get; set; }

        public bool CanBeDestroyed { get; set; } = true; // Výchozí hodnota je true, což znamená, že objekt může být zničen.

        public int Id_Position_Spawn { get; set; }

        /// <summary>Popis lodi.</summary>
        public string Description { get; set; }


        public int MaxHP { get; set; }

        public int MaxArmor { get; set; }
        public int MaxStructuralIntegrity { get; set; }
        public int MaxShield { get; set; }
        public int MaxShieldLeft { get; set; }
        public int MaxShieldRight { get; set; }
        public int MaxShieldFront { get; set; }
        public int MaxShieldBack { get; set; }

    }
}
