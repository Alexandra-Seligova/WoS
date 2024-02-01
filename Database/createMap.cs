using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;

namespace WoS.Database
{
    public class CreateMap
    {
        // Reprezentuje konfiguraci mapy
        public class MapConfig
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
            public List<Vector2> Positions { get; set; }
            public List<int> Types { get; set; }
            public string json { get; set; }

            public MapConfig(int id, string name, int count, List<Vector2> positions, List<int> types)
            {
                Positions = new List<Vector2>();
                Types = new List<int>();
                Id = id;
                Name = name;
                Count = count;
                Positions = positions;
                Types = types;
                json = ToJson();
            }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }

            public static MapConfig FromJson(string json)
            {
                return JsonConvert.DeserializeObject<MapConfig>(json);
            }
        }

        private Database Db = new Database();

        private int Id { get; set; } // Id mapy
        private string Name { get; set; } // Jméno mapy
        public float MapWidth { get; set; }  // Šířka mapy
        public float MapHeight { get; set; }  // Výška mapy

        private Random _random = new Random();

        private List<MapConfig> Configs { get; set; }

        // počítadla pro jednotlivé typy objektů
        private List<int> Types { get; set; }

        private List<Vector2> Positions { get; set; }
        private int elementCounts { get; set; }
        private int numberOfPeaces { get; set; }

        public CreateMap()
        {
            Types = new List<int>();
            Positions = new List<Vector2>();
            elementCounts = 0;
            numberOfPeaces = 0;
            Configs = new List<MapConfig>();

            MapWidth = 10000;
            MapHeight = 10000;

            Id = 1;
            Name = "AlphaMap";
        }

        public void CreateMapAndInsertToDatabase()
        {
            createMapConfigs();
            Db.InsertMapConfig(Id, Name, Configs);
        }

        public void createMapConfigs()
        {
            configSuns();
            configPlanets(new int[] { 5, 5 });
            configBoxes(new int[] { 5, 5 });
            configNpcs(new int[] { 5, 5 });
            configAsteroids(new int[] { 5, 5 });
            configUserFleets(new int[] { 1 });
            configUEnemyFleets(new int[] { 1 });
            configMoons(new int[] { 5, 5 });
        }

        #region CreateConfigElements

        private void configSuns()
        {
            elementCounts = 0;

            Types.Add(1); //typ 1 obsahuje počet 1
            Positions.Add(new Vector2(100, 100)); // jenom jedna pozice

            numberOfPeaces = Types[0];

            Configs.Add(new MapConfig(1, "Suns", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        private void configPlanets(int[] types)
        {
            elementCounts = 0;

            generateTypesCounts(types);
            numberOfPeaces = sectiPocetKusuCelkem();
            generatePositions(numberOfPeaces);

            Configs.Add(new MapConfig(2, "Planets", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        private void configBoxes(int[] types)
        {
            elementCounts = 0;

            generateTypesCounts(types);
            numberOfPeaces = sectiPocetKusuCelkem();
            generatePositions(numberOfPeaces);

            Configs.Add(new MapConfig(3, "Boxes", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        private void configNpcs(int[] types)
        {
            elementCounts = 0;

            generateTypesCounts(types);
            numberOfPeaces = sectiPocetKusuCelkem();
            generatePositions(numberOfPeaces);

            Configs.Add(new MapConfig(4, "Npcs", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        private void configAsteroids(int[] types)
        {
            elementCounts = 0;

            generateTypesCounts(types);
            numberOfPeaces = sectiPocetKusuCelkem();
            generatePositions(numberOfPeaces);

            Configs.Add(new MapConfig(5, "Asteroids", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        private void configUserFleets(int[] types)
        {
            elementCounts = 0;

            generateTypesCounts(types);
            numberOfPeaces = sectiPocetKusuCelkem();
            generatePositions(numberOfPeaces);

            Configs.Add(new MapConfig(6, "UserFleets", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        private void configUEnemyFleets(int[] types)
        {
            elementCounts = 0;

            generateTypesCounts(types);
            numberOfPeaces = sectiPocetKusuCelkem();
            generatePositions(numberOfPeaces);

            Configs.Add(new MapConfig(7, "EnemyFleets", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        private void configMoons(int[] types)
        {
            elementCounts = 0;

            generateTypesCounts(types);
            numberOfPeaces = sectiPocetKusuCelkem();
            generatePositions(numberOfPeaces);

            Configs.Add(new MapConfig(8, "Moons", numberOfPeaces, Positions, Types));

            resetPocitadel();
        }

        #endregion CreateConfigElements

        #region Metody

        private void resetPocitadel()
        {
            elementCounts = 0;
            numberOfPeaces = 0;
            Types.Clear();
            Positions.Clear();
        }

        private Vector2 GenerateRandomPosition()
        {
            return new Vector2(
                _random.Next((int)(MapWidth / 10), (int)(MapWidth - MapWidth / 10)),
                _random.Next((int)(MapHeight / 10), (int)(MapHeight - MapHeight / 10))
            );
        }

        private int sectiPocetKusuCelkem()
        {
            elementCounts = 0;
            for (int i = 0; i < Types.Count; i++)
            {
                elementCounts += Types[i];
            }
            return elementCounts;
        }

        private List<int> generateTypesCounts(int[] TypesCount)
        {
            for (int i = 0; i < TypesCount.Length; i++)
            {
                Types.Add(TypesCount[i]); //typ 1 obsahuje počet 1
            }
            return Types;
        }

        private List<Vector2> generatePositions(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                Positions.Add(GenerateRandomPosition()); // jenom jedna pozice
            }
            return Positions;
        }

        private string ConvertMapConfigToJson(MapConfig config)
        {
            return JsonConvert.SerializeObject(config);
        }

        private MapConfig ConvertJsonToMapConfig(string json)
        {
            return JsonConvert.DeserializeObject<MapConfig>(json);
        }

        #endregion Metody
    }
}