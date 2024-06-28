namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class ActualParametersModel
    {
        public int Id_User { get; set; } // id serveru
        /// <summary>Unikátní identifikátor lodi.</summary>

        [Key]
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi

        public int Id_Ammo_ActualParameters { get; set; } // Unikátní identifikátor komponenty

        public int Id_Position { get; set; } // Unikátní identifikátor lodi
        public float Rotation { get; set; } // Unikátní identifikátor lodi
        public int Velocity { get; set; } // Unikátní identifikátor lodi
        public int Acceleration { get; set; } // Unikátní identifikátor lodi



        public bool IsTarget { get; set; }
        public bool IsAutomaticTarget { get; set; }


        public int Id_Target { get; set; }
        public int Id_TargetType { get; set; }
        public int Id_Target_Position { get; set; }



        public int HP { get; set; }
        public int Armor { get; set; }
        public int Integrity { get; set; }
        public int Shield { get; set; }
        public int ShieldLeft { get; set; }
        public int ShieldRight { get; set; }
        public int ShieldFront { get; set; }
        public int ShieldBack { get; set; }
    }

}
