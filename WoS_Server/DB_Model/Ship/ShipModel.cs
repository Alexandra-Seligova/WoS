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
        public int Id_Cargo { get; set; }

        public MapPositionModel Position { get; set; }
        public ShipConfigModel ShipConfig { get; set; }
        public ShipComponentModel ShipComponent { get; set; }
        public FleetFormationModel FleetFormation { get; set; }
        public ActualParametersModel ActualParameters { get; set; }
        public StaticParametersModel StaticParameters { get; set; }
        public CargoModel Cargo { get; set; }

        public List<AmmoModel> ammos { get; set; }

        // Prázdný konstruktor
        public ShipModel()
        {
            ShipConfig = new ShipConfigModel();
            ShipComponent = new ShipComponentModel();
            FleetFormation = new FleetFormationModel();
            ActualParameters = new ActualParametersModel();
            StaticParameters = new StaticParametersModel();
        }

        // Konstruktor s argumenty
        public ShipModel(int id_User, int id_Fleet, int id_Fleet_Formation, int id_Fleet_FormationPosition, int id_Ship, int id_Ship_Type, string name, int level, string designation,
            int id_Ship_StaticParameters, int id_Ship_ActualParameters, int id_Ship_Config)
        {
            Id_User = id_User;
            Id_Fleet = id_Fleet;
            Id_Fleet_Formation = id_Fleet_Formation;
            Id_Fleet_FormationPosition = id_Fleet_FormationPosition;
            Id_Ship = id_Ship;
            Id_Ship_Type = id_Ship_Type;
            Name = name;
            Level = level;
            Designation = designation;
            Id_Ship_StaticParameters = id_Ship_StaticParameters;
            Id_Ship_ActualParameters = id_Ship_ActualParameters;
            Id_Ship_Config = id_Ship_Config;
            ShipConfig = new ShipConfigModel();
            ShipComponent = new ShipComponentModel();
            FleetFormation = new FleetFormationModel();
            ActualParameters = new ActualParametersModel();
            StaticParameters = new StaticParametersModel();
        }
    }

}
