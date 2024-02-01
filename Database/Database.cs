using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using static WoS.Database.CreateMap;

namespace WoS.Database
{
    public class Database
    {
        private readonly string _connectionString;

        public Database()
        {
            // Připojení k databázi na localhost\MSSQLSERVER01
            _connectionString = @"Server=localhost\MSSQLSERVER01;Database=WoS;Trusted_Connection=True;";
        }

        #region createMap

        public void InsertMapConfig(int idMap, string mapName, List<MapConfig> configs)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Konvertujeme konfigurace na JSON
                var sunsJson = configs[0].json;
                var PlanetsJson = configs[1].json;
                var BoxesJson = configs[2].json;
                var NpcsJson = configs[3].json;
                var AsteroidsJson = configs[4].json;
                var UserFleetsJson = configs[5].json;
                var EnemyFleetsJson = configs[6].json;
                var MoonsJson = configs[7].json;

                // ... Stejným způsobem konvertujte další konfigurace ...

                var query = @"
                INSERT INTO [WoS].[dbo].[MapsConfig]
                            ([IdMap],[MapName] ,[Suns],[Planets],[Boxes],[Npcs] ,[Asteroids],[UserFleets] ,[EnemyFleets] ,[Moons])
                VALUES      (@IdMap ,@MapName  ,@Suns, @Planets, @Boxes,  @Npcs ,@Asteroids ,@UserFleets , @EnemyFleets  ,@Moons)";

                connection.Execute(query, new
                {
                    IdMap = idMap,
                    MapName = mapName,
                    Suns = sunsJson,
                    Planets = PlanetsJson,
                    Boxes = BoxesJson,
                    Npcs = NpcsJson,
                    Asteroids = AsteroidsJson,
                    UserFleets = UserFleetsJson,
                    EnemyFleets = EnemyFleetsJson,
                    Moons = MoonsJson,
                    // ... Přiřaďte další konfigurace ...
                });
            }
        }

        #endregion createMap

        public MapConfigData GetMapConfigData(int idMap)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT * FROM [WoS].[dbo].[MapsConfig] WHERE IdMap = @IdMap";
                return connection.QueryFirstOrDefault<MapConfigData>(query, new { IdMap = idMap });
            }
        }

        public class MapConfigData
        {
            public int Id { get; set; }
            public int IdMap { get; set; }
            public string MapName { get; set; }
            public string Suns { get; set; }
            public string Planets { get; set; }
            public string Boxes { get; set; }
            public string Npcs { get; set; }
            public string Asteroids { get; set; }
            public string UserFleets { get; set; }
            public string EnemyFleets { get; set; }
            public string Moons { get; set; }
        }
    }
}