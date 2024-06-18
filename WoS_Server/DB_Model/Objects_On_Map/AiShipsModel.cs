namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AiShipsModel
    {

        public int Id_Map { get; set; } // Unikátní identifikátor boxu
        public int Id_ObjektType { get; set; } // 14
        [Key]
        public int Id_AiShips { get; set; }  // Typ 
        public int Id_AiShips_Type { get; set; }  // Typ Borgs
        public int Id_AiShips_SubType { get; set; }  // Typ Cube

        public int Id_Position { get; set; }
        public int Id_AiShipsConfig { get; set; }
        public int Id_Cargo { get; set; }

        public int Id_AiShips_StaticParameters { get; set; }
        public int Id_AiShips_ActualParameters { get; set; }


    }
}
