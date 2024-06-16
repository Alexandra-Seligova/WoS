namespace WoS_Server.DB_Model
{
    using System.ComponentModel.DataAnnotations;

    public class MapObjectsModel
    {

        public int Id_Map { get; set; }
        [Key]
        public int Id_Object { get; set; }
        public int Id_ObjectType { get; set; }

        public int Id_Position { get; set; }
        public int Id_MapObjectConfig { get; set; }

        // Konstruktor s parametry
        public MapObjectsModel(int idMap, int idObject, int idObjectType, int idPosition, int idMapObjectConfig)
        {
            Id_Map = idMap;
            Id_Object = idObject;
            Id_ObjectType = idObjectType;
            Id_Position = idPosition;
            Id_MapObjectConfig = idMapObjectConfig;
        }

        // Výchozí konstruktor
        public MapObjectsModel() { }
    }



    public class MapObjectConfigModel
    {

        public int Id_Map { get; set; }
        public int Id_User { get; set; }
        public int Id_Object { get; set; }
        public int Id_ObjectType { get; set; }

        public int Id_MapObjectConfig { get; set; }


        public string Name { get; set; }  // Název
        public int Width { get; set; }  // Šířka
        public int Height { get; set; }  // Výška
        public int Diameter { get; set; }  // Průměr
        public int SolarMassWeight { get; set; }  // Hmotnost v solárních hmotnostech
        public float Gravity { get; set; }  // Gravitace

        public int Orbit { get; set; }  // Oběžná doba kolem slunce
        public float OrbitalPeriod { get; set; }  // Oběžná doba kolem slunce
        public float RotationPeriod { get; set; }  // Doba rotace kolem vlastní osy
        public bool HasAtmosphere { get; set; }  // Indikátor, zda má objekt atmosféru
        public bool Habitable { get; set; }  // Indikátor, zda je objekt obyvatelný
        public float Age { get; set; }  // Věk objektu v milionech let
                                        // Konstruktor
        public MapObjectConfigModel(int idUser, int idObject, int idObjectType, int idMapObjectConfig, string name, int width, int height, int diameter, int solarMassWeight, float gravity, int orbit, float orbitalPeriod, float rotationPeriod, bool hasAtmosphere, bool habitable, float age)
        {
            Id_User = idUser;
            Id_Object = idObject;
            Id_ObjectType = idObjectType;
            Id_MapObjectConfig = idMapObjectConfig;
            Name = name;
            Width = width;
            Height = height;
            Diameter = diameter;
            SolarMassWeight = solarMassWeight;
            Gravity = gravity;
            Orbit = orbit;
            OrbitalPeriod = orbitalPeriod;
            RotationPeriod = rotationPeriod;
            HasAtmosphere = hasAtmosphere;
            Habitable = habitable;
            Age = age;
        }
    }

















}
