namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class ActualParameters
    {
        public int Id_User { get; set; } // id serveru
        /// <summary>Unikátní identifikátor lodi.</summary>

        [Key]
        public int Id_Ammo { get; set; } // Unikátní identifikátor munice

        public int Id_Ammo_ActualParameters { get; set; } // Unikátní identifikátor komponenty

        public int Id_Ammo_Target { get; set; }
        public int Id_Ammo_TargetType { get; set; }

        /// <summary>Pozice objektu ve 3D prostoru.</summary>
        public Vector3 Position { get; set; }

        /// <summary>Globální pozice objektu na mapě.</summary>
        public Vector2 PositionOnMap { get; set; }

        /// <summary>Cílová pozice objektu.</summary>
        public Vector2 TargetPosition { get; set; }

        public bool IsTarget { get; set; }

        public bool IsAutomaticTarget { get; set; }


        /// <summary>Rotace objektu v prostoru.</summary>
        public float Rotation { get; set; }

        /// <summary>Rychlost objektu.</summary>
        public Vector2 Velocity { get; set; }

        /// <summary>Zrychlení objektu.</summary>
        public float Acceleration { get; set; }

        /// <summary>Aktuální zdraví objektu.</summary>
        public int HP { get; set; }

        /// <summary>Aktuální útočná síla objektu.</summary>
        public int Armor { get; set; }


        public int StructuralIntegrity { get; set; }

        public int Shield { get; set; }
        public int ShieldLeft { get; set; }
        public int ShieldRight { get; set; }
        public int ShieldFront { get; set; }
        public int ShieldBack { get; set; }

        /// <summary>Maximální rychlost lodi.</summary>
        public float Speed { get; set; }

    }
}
