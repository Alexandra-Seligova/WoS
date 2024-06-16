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

        public List<BoxModel> MapBoxes = new List<BoxModel>();
        public List<BoxConfigModel> MapBoxConfigs = new List<BoxConfigModel>();


        public List<ArtifactModel> MapArtifacts = new List<ArtifactModel>();
        public List<ArtifactConfigModel> MapArtifactConfigs = new List<ArtifactConfigModel>();


        public List<SpaceBuildingModel> MapSpaceBuildings = new List<SpaceBuildingModel>();
        public List<SpaceBuildingConfigModel> MapSpaceBuildingConfigs = new List<SpaceBuildingConfigModel>();


        public List<NpcModel> MapNpcs = new List<NpcModel>();
        public List<NpcConfigModel> MapNpcConfigMapNpcConfigs = new List<NpcConfigModel>();


        public List<AiShipModel> MapAiShips = new List<AiShipModel>();
        public List<AiShipConfigModel> MapAiShipConfigs = new List<AiShipConfigModel>();




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
            MapAstronomyObjectMaker(2, 2, "Planeta 1", 60);
            MapAstronomyObjectMaker(3, 2, "Planeta 2", 120);
            MapAstronomyObjectMaker(4, 2, "Planeta 3", 100);
            MapAstronomyObjectMaker(5, 2, "Planeta 4", 160);
            MapAstronomyObjectMaker(6, 2, "Planeta 5", 200);
            MapAstronomyObjectMaker(7, 2, "Planeta 6", 400);



            MapAstronomyObjectMaker(8, 3, "Trpasličí Planeta 1", 20);
            MapAstronomyObjectMaker(9, 3, "Trpasličí Planeta 2", 15);
            MapAstronomyObjectMaker(10, 3, "Trpasličí Planeta 3", 10);
            MapAstronomyObjectMaker(11, 3, "Trpasličí Planeta 4", 30);

            MapAstronomyObjectMaker(12, 4, "Kometa 1", 5);
            MapAstronomyObjectMaker(13, 4, "Kometa 2", 15);


            MapAstronomyObjectMaker(14, 4, "Asteroid 1", 1);
            MapAstronomyObjectMaker(15, 4, "Asteroid 2", 5);




            MapAstronomyObjectMaker(16, 4, "Meteoroid 1", 3);
            MapAstronomyObjectMaker(17, 4, "Meteoroid 2", 8);



            MapAstronomyObjectMaker(18, 4, "Černá díra 1", 10);
            MapAstronomyObjectMaker(19, 4, "Černá díra 2", 100);


            MapAstronomyObjectMaker(20, 4, "Energetické pole 1", 1);
            MapAstronomyObjectMaker(21, 4, "Energetické pole 2", 200);


            MapAstronomyObjectMaker(22, 4, "Mlhovina 1", 5);
            MapAstronomyObjectMaker(23, 4, "Mlhovina 1", 100);


            MapAstronomyObjectMaker(24, 4, "Kvasar 1", 10);





            MapBoxesMaker(25, 4, 1, 1, "Boxík 1");


            MapArtifactMaker(26, 4, "Artefakt 1");


            MapSpaceBuildingMaker(27, 4, "Vesmírná stanice 1");


            MapNpcMaker(28, 4, "Npc 1");


            MapAiShipMaker(29, 4, "AiShip 1");







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

            // ADD
            mapObjectsModels.Add(new MapObjectsModel(Id_Map, idObject, idObjectType, idPosition, idMapObjectConfig));
            MapPositions.Add(new MapPositionModel(Id_Map, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));
            MapObjectConfigs.Add(new MapObjectConfigModel(idUser, idObject, idObjectType, idMapObjectConfig, name, width, height, diameter, solarMassWeight,
                gravity, orbit, orbitalPeriod, rotationPeriod, hasAtmosphere, habitable, age));
        }

        private void MapAstronomyObjectMaker(int element, int idObjectType, string name, int width)
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







        private void MapBoxesMaker(int element, int idObjectType, int idBox, int idCargo, string name)
        {
            int idMap=1;
            int idUser=0;
            int idObject=element;// 2
                                 // int idObjectType=2;
            int idPosition=element;// 2


            int Id_Box=idBox;
            int Id_BoxType=1;
            int Id_BoxConfig=1;
            int Id_Cargo=idCargo;

            // ADD
            mapObjectsModels.Add(new MapObjectsModel(idMap, idObject, idObjectType, idPosition));
            MapPositions.Add(new MapPositionModel(idMap, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));
            MapBoxes.Add(new BoxModel(idMap, idUser, idObject, Id_Box, idObjectType, Id_BoxType, idPosition, Id_BoxConfig, Id_Cargo));
            MapBoxConfig.Add(new BoxConfig(Id_Box
            MapCargo.Add(new CargoModel(Id_Box
        }
        private void MapArtifactMaker(int element, int idObjectType, string name, int width)
        {
            int idMap=1;
            int idUser=0;
            int idObject=element;// 2
                                 // int idObjectType=2;
            int idPosition=element;// 2
            int idMapObjectConfig=element;// 2

            // int width =20;



            // ADD
            mapObjectsModels.Add(new MapObjectsModel(idMap, idObject, idObjectType, idPosition, idMapObjectConfig));
            MapPositions.Add(new MapPositionModel(idMap, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));
            MapArtifactConfig.Add(new ArtifactConfig(Id_Box
            MapCargo.Add(new CargoModel(Id_Box


        }
        private void MapSpaceBuildingMaker(int element, int idObjectType, string name, int width)
        {
            int idMap=1;
            int idUser=0;
            int idObject=element;// 2
                                 // int idObjectType=2;
            int idPosition=element;// 2
            int idMapObjectConfig=element;// 2


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


            // ADD
            mapObjectsModels.Add(new MapObjectsModel(idMap, idObject, idObjectType, idPosition, idMapObjectConfig));
            MapPositions.Add(new MapPositionModel(idMap, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));
            MapObjectConfigs.Add(new MapObjectConfigModel(idUser, idObject, idObjectType, idMapObjectConfig, name, width, height, diameter, solarMassWeight,
                gravity, orbit, orbitalPeriod, rotationPeriod, hasAtmosphere, habitable, age));
            MapSpaceBuildingConfig.Add(new SpaceBuildingConfig(Id_Box
            MapSpaceBuildingCargo.Add(new SpaceBuildingCargo(Id_Box

        }
        private void MapNpcMaker(int element, int idObjectType, string name, int width)
        {
            int idMap=1;
            int idUser=0;
            int idObject=element;// 2
                                 // int idObjectType=2;
            int idPosition=element;// 2
            int idMapObjectConfig=element;// 2




            // ADD Sun
            mapObjectsModels.Add(new MapObjectsModel(idMap, idObject, idObjectType, idPosition, idMapObjectConfig));
            MapPositions.Add(new MapPositionModel(idMap, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));
            MapNpcConfig.Add(new NpcConfig(Id_Box
            MapCargo.Add(new CargoModel(Id_Box

        }
        private void MapAiShipMaker(int element, int idObjectType, string name, int width)
        {
            int idMap=1;
            int idUser=0;
            int idObject=element;// 2
                                 // int idObjectType=2;
            int idPosition=element;// 2
            int idMapObjectConfig=element;// 2


            // ADD Sun
            mapObjectsModels.Add(new MapObjectsModel(idMap, idObject, idObjectType, idPosition, idMapObjectConfig));
            MapPositions.Add(new MapPositionModel(idMap, idUser, idObject, idObjectType, idPosition, name, 0, 0, 0, 0, 0, 0, 0));

            MapAiShipConfig.Add(new AiShipConfig(Id_Box
            MapCargo.Add(new CargoModel(Id_Box

        }
    }



}
