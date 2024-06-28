namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class FleetFormationModel
    {
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public int Id_Fleet_Formation { get; set; }

        public int Id_InFormation { get; set; }
        public float Id_Formation_x { get; set; }
        public float Id_InFormation_y { get; set; }
        public float Id_InFormation_z { get; set; }

    }
}
