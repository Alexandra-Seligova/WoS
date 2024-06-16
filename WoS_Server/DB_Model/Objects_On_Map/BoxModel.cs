namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;


    public class BoxModel
    {
        public int Id_Map { get; set; } // Unikátní identifikátor boxu
        public int Id_MapType { get; set; } // 11 Boxík
        [Key]
        public int Id_Box { get; set; } // Unikátní identifikátor boxu
        public int Id_BoxType { get; set; } // Unikátní identifikátor boxu

        // Pozice

        public int Id_Position { get; set; }
        public int Id_BoxConfig { get; set; }
        public int Id_Cargo { get; set; }



        public BoxModel()
        {
        }

        public BoxModel(int idMap, int idUser, int idObject, int idBox, int idObjectType, int idBoxType, int idPosition, int idBoxConfig, int idCargo)
        {
            Id_Map = idMap;
            Id_MapType = 11; // Předpoklad, že MapType je vždy 11 pro Boxík
            Id_Box = idBox;
            Id_BoxType = idBoxType;
            Id_Position = idPosition;
            Id_BoxConfig = idBoxConfig;
            Id_Cargo = idCargo;
        }
    }

    public enum BoxType
    {
        Basic,         // Základní
        Rare,          // Vzácný
        Epic,          // Epický
        Legendary,     // Legendární
        Event          // Událostní
    }
}
