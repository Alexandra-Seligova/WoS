namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class FleetModel
    {

        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele - Primární klíč

        [Key]
        public int Id_Fleet { get; set; }

        // Hlavní loď
        public ShipModel MainShip { get; set; }

        // Drony ve formaci
        public List<DroneModel> Drones { get; set; }

        // Doprovodné lodě
        public List<ShipModel> EscortShips { get; set; }

        // Formace
        public ShipsFormation ShipsFormation { get; set; }
        public DronesFormation DronesFormation { get; set; }

        public FleetModel()
        {
            Drones = new List<DroneModel>();
            EscortShips = new List<ShipModel>();
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
