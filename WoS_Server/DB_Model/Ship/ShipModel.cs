namespace WoS_Server.DB_Model
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

        /// <summary>Název objektu.</summary>
        public string Name { get; set; }
        public int Level { get; set; }
        /// <summary>Označení objektu. Výchozí hodnota je "Ship".</summary>
        public string Designation { get; set; } = "Ship";

        public int Id_Ship_StaticParameters { get; set; } // Statické parametry lodi

        public int Id_Ship_ActualParameters { get; set; } // Dynamické parametry lodi

        public int Id_Ship_Config { get; set; } // Dynamické parametry lodi


    }

}
