namespace WoS_Server.ObjectModel.Map_Objects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using WoS_Server.DB_Model;



    public class Map : MapModel
    {
        /*
                public int Id_Map { get; set; }
                public int Id_Map_Type { get; set; }

                public int Id_GalaxyPosition { get; set; }// Odkaz do tabulky [GalaxyPosition]
                public int Id_MapObjectConfig { get; set; }

                public string Name { get; set; }

                */




        // Id_Map, Id_Object, Id_ObjectType, Id_Position, Id_MapObjectConfig
        public List<MapObjectsModel> mapObjectsModels = new List<MapObjectsModel>();


        // Id_Map, Id_User, Id_Object, Id_ObjectType, Id_Position, ObjectName, Velocity,    Map_x,Map_y, Map_z,  Target_Map_x,Target_Map_y,Target_Map_z
        public List<MapPositionModel> MapPositions = new List<MapPositionModel>();

        //Id_User, Id_Object, Id_ObjectType, Id_MapObjectConfig, Name, Width, Height, Diameter, SolarMassWeight, Gravity, OrbitalPeriod, RotationPeriod, HasAtmosphere, Habitable, Age
        public List<MapObjectConfigModel> MapObjectConfigs = new List<MapObjectConfigModel>();


        public Map(int idMap, int idMapType, int idGalaxyPosition, int idMapObjectConfig, string name)
        {
            Id_Map = idMap;
            Id_Map_Type = idMapType;
            Id_GalaxyPosition = idGalaxyPosition;
            Id_MapObjectConfig = idMapObjectConfig;
            Name = name;

        }
        public enum ObjectType
        {
            Suns = 1,            // Slunce
            Planets = 2,         // Planety
            DwarfPlanets = 3,    // Trpasličí planety
            Comets = 4,          // Komety
            Asteroids = 5,       // Asteroidy
            Meteoroids = 6,      // Meteoroidy
            BlackHoles = 7,      // Černé díry
            EnergyFields = 8,    // Energetická pole
            Nebulas = 9,         // Mlhoviny
            Quasars = 10,        // Kvasary
            Boxes = 11,          // Krabice
            Artifacts = 12,      // Artefakty
            SpaceBuildings = 13, // Vesmírné budovy
            Npcs = 14,           // NPC
            AiShips = 15         // AI lodě
        }

        private void MapMaker()
        {
            SunMaker(1);
            ObjectMaker(2, 2, "Planeta 1", 40);
            ObjectMaker(3, 2, "Planeta 2", 40);
            ObjectMaker(4, 2, "Planeta 3", 40);
            ObjectMaker(5, 2, "Planeta 4", 40);
            ObjectMaker(6, 2, "Planeta 5", 40);
            ObjectMaker(7, 2, "Planeta 6", 40);



            ObjectMaker(2, 2, "Planeta 1", 40);
















        }


        private void SunMaker(int element)
        {


            int idMap=1;
            int idUser=0;
            int idObject=element;// 1
            int idObjectType=1;
            int idPosition=element;// 1
            int idMapObjectConfig=element;// 1
            string name = "Sun";
            int width =1000;
            int height = width;
            int diameter =width;
            int solarMassWeight =0;
            float gravity =1;
            int orbit=element; // 1
            float orbitalPeriod =1;
            float rotationPeriod = 1;
            bool hasAtmosphere =false;
            bool habitable =false;
            float age=1.200f;// 1 200 000 000 



            // ADD Sun
            mapObjectsModels.Add(new MapObjectsModel(Id_Map, idObject, idObjectType, idPosition, idMapObjectConfig));
            MapPositions.Add(new MapPositionModel(Id_Map, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));
            MapObjectConfigs.Add(new MapObjectConfigModel(idUser, idObject, idObjectType, idMapObjectConfig, name, width, height, diameter, solarMassWeight,
                gravity, orbit, orbitalPeriod, rotationPeriod, hasAtmosphere, habitable, age));


        }

        private void ObjectMaker(int element, int idObjectType, string name, int width)
        {
            int idMap=1;
            int idUser=0;
            int idObject=element;// 2
                                 // int idObjectType=2;
            int idPosition=element;// 2
            int idMapObjectConfig=element;// 2

            // int width =20;
            int height = width;
            int diameter =width;
            int solarMassWeight =0;
            float gravity =1;
            int orbit=element; // 1
            float orbitalPeriod =1;
            float rotationPeriod = 1;
            bool hasAtmosphere =false;
            bool habitable =true;
            float age=0.800f;



            // ADD Sun
            mapObjectsModels.Add(new MapObjectsModel(idMap, idObject, idObjectType, idPosition, idMapObjectConfig));
            MapPositions.Add(new MapPositionModel(idMap, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));
            MapObjectConfigs.Add(new MapObjectConfigModel(idUser, idObject, idObjectType, idMapObjectConfig, name, width, height, diameter, solarMassWeight,
                gravity, orbit, orbitalPeriod, rotationPeriod, hasAtmosphere, habitable, age));


        }





    }



}
