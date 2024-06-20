namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MapPositionModel
    {
        public int Id_Map { get; set; }
        [Key]
        public int Id_User { get; set; }
        public int Id_Object { get; set; }
        public int Id_ObjectType { get; set; }

        public int Id_Position { get; set; }

        public string ObjectName { get; set; }

        public int Velocity { get; set; }
        public int Map_x { get; set; }
        public int Map_y { get; set; }
        public int Map_z { get; set; }
        public int Target_Map_x { get; set; }
        public int Target_Map_y { get; set; }
        public int Target_Map_z { get; set; }


        // Konstruktor
        public MapPositionModel(int idMap, int idUser, int idObject, int idObjectType, int idPosition, string objectName, int velocity,
                                int mapX, int mapY, int mapZ, int targetMapX, int targetMapY, int targetMapZ)
        {
            Id_Map = idMap;
            Id_User = idUser;
            Id_Object = idObject;
            Id_ObjectType = idObjectType;
            Id_Position = idPosition;
            ObjectName = objectName;
            Velocity = velocity;
            Map_x = mapX;
            Map_y = mapY;
            Map_z = mapZ;
            Target_Map_x = targetMapX;
            Target_Map_y = targetMapY;
            Target_Map_z = targetMapZ;
        }

        public MapPositionModel()
        {
        }
        // Konstruktor s parametry
    }
}
