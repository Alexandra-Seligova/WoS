using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
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
                var sunsJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "Suns"));
                var PlanetsJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "Planets"));
                var BoxesJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "Boxes"));
                var NpcsJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "Npcs"));
                var AsteroidsJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "Asteroids"));
                var UserFleetsJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "UserFleets"));
                var EnemyFleetsJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "EnemyFleets")); 
                var MoonsJson = JsonConvert.SerializeObject(configs.FirstOrDefault(c => c.Name == "Moons"));


                // ... Stejným způsobem konvertujte další konfigurace ...

                var query = @"
INSERT INTO [WoS].[dbo].[MapsConfig]
           ([IdMap],[MapName] ,[Suns],[Planets],[Boxes],[Npcs] ,[Asteroids],[UserFleets] ,[EnemyFleets] ,[Moons])
VALUES     (@IdMap ,@MapName  ,@Suns, @Planets, @Boxes,  @Npcs ,@Asteroids ,@UserFleets , @EnemyFleets  ,@Moons)";

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
    }
}