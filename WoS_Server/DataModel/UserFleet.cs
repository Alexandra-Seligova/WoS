namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class UserFleet // tabulka pro max 9 slotů pro shiptype a veškerého jejího nastavení
    {
        // jaké typy lodí má hráč k dispozici
        public List<ShipType> AvailableShips { get; set; }

        public UserFleet()
        {
            AvailableShips = new List<ShipType>();
        }

        public void SetShip(ShipType shipType)
        {
            // Metoda pro nastavení vybrané lodi
            // Implementace logiky pro nastavení vybrané lodi
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

    public class UserDroneFleet // pro každý záznam v AvailableShips jsou 2 nastavení pro formaci dronů
    {
        // jaké typy dronů má hráč k dispozici
        public List<DroneType> AvailableDrones { get; set; }

        public UserDroneFleet()
        {
            AvailableDrones = new List<DroneType>();
        }

        public void SetDrone(DroneType droneType)
        {
            // Metoda pro nastavení vybraného dronu
            // Implementace logiky pro nastavení vybraného dronu
        }
    }

}
