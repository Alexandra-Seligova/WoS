namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SpaceBuildingsModel
    {

        public int Id_Map { get; set; } // Unikátní identifikátor boxu
        public int Id_ObjektType { get; set; } // 13
        [Key]
        public int Id_SpaceBuilding { get; set; } // Unikátní identifikátor boxu
        public int Id_SpaceBuildingType { get; set; } // Unikátní identifikátor boxu

        // Pozice

        public int Id_Position { get; set; }
        public int Id_SpaceBuildingConfig { get; set; }
        public int Id_Cargo { get; set; }



    }
}
