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

        }

        #endregion createMap

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
