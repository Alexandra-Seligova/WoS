namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class FleetModel
    {
        public int Id_User { get; set; } // id uživatele - Primární klíč

        [Key]
        public int Id_Fleet { get; set; }
        public int Id_Ship_Group { get; set; }
        public int Id_Fleet_Formation { get; set; }

        // Hlavní loď
        public int ID_MainShip { get; set; }


        public MapPositionModel Position { get; set; }

        public FleetModel()
        {
        }

    }


    public enum ShipType
    {
        ShipBattleAlpha,
        ShipBattleBeta,
        ShipExploratoryAlpha,
        ShipExploratoryBeta,
        ShipMiningAlpha,
        ShipMiningBeta,
        ShipTraderAlpha,
        ShipTraderBeta,
        ShipTransportAlpha,
        ShipTransportBeta
    }

    public enum DroneType
    {
        Battle,     // Battle drone
        Aqua,       // Aqua drone
        Electro,    // Electro drone
        Delux,      // Delux drone
        Lava        // Lava drone
    }
    // Enum pro formace letky
    public enum ShipsFormation
    {
        Circle,     // Kruh
        VShape,     // Tvar V
        Line,       // Linie
        Custom      // Vlastní formace
    }
    public enum DronesFormation
    {
        Circle,     // Kruh
        VShape,     // Tvar V
        Line,       // Linie
        Custom      // Vlastní formace
    }

}
