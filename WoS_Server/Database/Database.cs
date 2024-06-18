

namespace WoS_Server
{
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using WoS_Server.DB_Model;


    public class Database
    {
        private readonly string _connectionString;

        public Database()
        {
            // Připojení k databázi na localhost\MSSQLSERVER01
            _connectionString = @"Server=localhost\MSSQLSERVER01;Database=WoS;Trusted_Connection=True;";
        }

        #region Table list
        /*
        dbo.Ammo
        dbo.AmmoConfig
        dbo.Map
        dbo.MapGalaxyPosition
        dbo.MapObjectConfig
        dbo.MapObjects
        dbo.MapPosition
        dbo.OnMap_AiShips
        dbo.OnMap_Artifact
        dbo.OnMap_Box
        dbo.OnMap_Npcs
        dbo.OnMap_SpaceBuildings
        dbo.Ship_ActualParameters
        dbo.Ship_Component
        dbo.Ship_Config
        dbo.Ship_Fleet
        dbo.Ship_Ship
        dbo.Ship_StaticParameters
        dbo.User_Boosters
        dbo.User_Config
        dbo.User_Items
        dbo.User_User
        dbo.User_Permissions
        dbo.User_Research
        */
        #endregion

        public enum SqlOperationType
        {
            Insert,             // Vložení nového záznamu
            Delete,             // Smazání existujícího záznamu
            Update,             // Aktualizace existujícího záznamu
            SelectById,         // Výběr záznamu podle ID
            SelectByCustomClause, // Výběr záznamu podle vlastní WHERE klauzule
            SelectByParameters   // Výběr záznamu podle předaných parametrů
        }

        private Dictionary<string, object> CreateParameters<T>(List<T> objects)
        {
            var parameters = new Dictionary<string, object>();
            var obj = objects.FirstOrDefault();
            if(obj != null)
            {
                var properties = obj.GetType().GetProperties();
                foreach(var property in properties)
                {
                    var name = property.Name;
                    var value = property.GetValue(obj);
                    parameters.Add(name, value);
                }
            }
            return parameters;
        }

        public async Task<bool> ExecuteOperationAsync<T>(List<T> objects, SqlOperationType operationType, string tableName)
        {
            var parameters = CreateParameters(objects);

            string query = string.Empty;

            switch(operationType)
            {
                case SqlOperationType.Insert:
                query = $"INSERT INTO {tableName} ({string.Join(", ", parameters.Keys)}) VALUES ({string.Join(", ", parameters.Keys.Select(k => "@" + k))})";
                break;
                case SqlOperationType.Delete:
                query = $"DELETE FROM {tableName} WHERE Id = @Id";
                break;
                case SqlOperationType.Update:
                query = $"UPDATE {tableName} SET {string.Join(", ", parameters.Keys.Select(k => k + " = @" + k))} WHERE Id = @Id";
                break;
            }

            try
            {
                using(var connection = new SqlConnection(_connectionString))
                using(var command = new SqlCommand(query, connection))
                {
                    foreach(var param in parameters)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }

                    await connection.OpenAsync();
                    int result = await command.ExecuteNonQueryAsync();

                    return result > 0; // If one or more rows were affected, return true
                }
            }
            catch(SqlException ex)
            {
                // Log or handle the error as necessary
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch(Exception ex)
            {
                // Log or handle the error as necessary
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false; // Return false if an exception occurred or no rows were affected
        }





        private async Task<List<T>> ExecuteSelectOperationAsync<T>(SqlOperationType operationType, string tableName, Dictionary<string, object> parameters, string customWhereClause = null)
        {
            string query = string.Empty;

            switch(operationType)
            {
                case SqlOperationType.SelectById:
                query = $"SELECT * FROM {tableName} WHERE Id = @Id";
                break;
                case SqlOperationType.SelectByCustomClause:
                query = $"SELECT * FROM {tableName} WHERE {customWhereClause}";
                break;
                case SqlOperationType.SelectByParameters:
                query = $"SELECT * FROM {tableName} WHERE {string.Join(" AND ", parameters.Keys.Select(k => k + " = @" + k))}";
                break;
            }

            try
            {
                using(var connection = new SqlConnection(_connectionString))
                using(var command = new SqlCommand(query, connection))
                {
                    if(parameters != null)
                    {
                        foreach(var param in parameters)
                        {
                            command.Parameters.AddWithValue("@" + param.Key, param.Value);
                        }
                    }

                    await connection.OpenAsync();
                    using(var reader = await command.ExecuteReaderAsync())
                    {
                        var result = new List<T>();
                        while(await reader.ReadAsync())
                        {
                            // Map the data to your model class
                            // Assumes your model class has a parameterless constructor and properties matching the columns
                            var item = Activator.CreateInstance<T>();
                            foreach(var prop in typeof(T).GetProperties())
                            {
                                if(!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(item, reader.GetValue(reader.GetOrdinal(prop.Name)));
                                }
                            }
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
            catch(SqlException ex)
            {
                // Log or handle the error as necessary
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch(Exception ex)
            {
                // Log or handle the error as necessary
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null; // Return null if an exception occurred or no rows were affected

            /*
            var parameters = new Dictionary<string, object> { { "Id", 123 } };
            var result = await ExecuteSelectOperationAsync<MyModel>(SqlOperationType.SelectById, "MyTable", parameters);

            var customWhereClause = "Name = 'John' AND Age > 30";
            var resultWithCustomWhere = await ExecuteSelectOperationAsync<MyModel>(SqlOperationType.SelectByCustomClause, "MyTable", null, customWhereClause);

            var parametersForSelect = new Dictionary<string, object> { { "Name", "John" }, { "Age", 30 } };
            var resultWithParameters = await ExecuteSelectOperationAsync<MyModel>(SqlOperationType.SelectByParameters, "MyTable", parametersForSelect);

            */
        }



        #region Execute
        public async Task<bool> ExecuteAmmoOperationAsync(AmmoModel ammo, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<AmmoModel> { ammo }, operationType, "dbo.Ammo");
        }

        public async Task<bool> ExecuteAmmoConfigOperationAsync(AmmoConfigModel ammoConfig, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<AmmoConfigModel> { ammoConfig }, operationType, "dbo.AmmoConfig");
        }

        public async Task<bool> ExecuteMapOperationAsync(MapModel map, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<MapModel> { map }, operationType, "dbo.Map");
        }

        public async Task<bool> ExecuteGalaxyPositionOperationAsync(GalaxyPosition galaxyPosition, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<GalaxyPosition> { galaxyPosition }, operationType, "dbo.MapGalaxyPosition");
        }

        public async Task<bool> ExecuteMapObjectConfigOperationAsync(MapObjectConfigModel mapObjectConfig, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<MapObjectConfigModel> { mapObjectConfig }, operationType, "dbo.MapObjectConfig");
        }

        public async Task<bool> ExecuteMapObjectsOperationAsync(MapObjectsModel mapObject, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<MapObjectsModel> { mapObject }, operationType, "dbo.MapObjects");
        }

        public async Task<bool> ExecuteMapPositionOperationAsync(MapPositionModel mapPosition, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<MapPositionModel> { mapPosition }, operationType, "dbo.MapPosition");
        }

        public async Task<bool> ExecuteOnMapAiShipsOperationAsync(AiShipsModel aiShips, SqlOperationType operationType)
        {
            aiShips.Id_ObjektType = 14; // přednastavena hodnota
            return await ExecuteOperationAsync(new List<AiShipsModel> { aiShips }, operationType, "dbo.OnMap_AiShips");
        }

        public async Task<bool> ExecuteOnMapArtifactOperationAsync(ArtifactModel artifact, SqlOperationType operationType)
        {
            artifact.Id_ObjektType = 12; // přednastavena hodnota
            return await ExecuteOperationAsync(new List<ArtifactModel> { artifact }, operationType, "dbo.OnMap_Artifact");
        }

        public async Task<bool> ExecuteOnMapBoxOperationAsync(BoxModel box, SqlOperationType operationType)
        {
            //  box.Id_ObjektType = 11; // přednastavena hodnota
            return await ExecuteOperationAsync(new List<BoxModel> { box }, operationType, "dbo.OnMap_Box");
        }

        public async Task<bool> ExecuteOnMapNpcsOperationAsync(NpcsModel npc, SqlOperationType operationType)
        {
            npc.Id_ObjektType = 14; // přednastavena hodnota
            return await ExecuteOperationAsync(new List<NpcsModel> { npc }, operationType, "dbo.OnMap_Npcs");
        }

        public async Task<bool> ExecuteOnMapSpaceBuildingsOperationAsync(SpaceBuildingsModel spaceBuilding, SqlOperationType operationType)
        {
            spaceBuilding.Id_ObjektType = 13; // přednastavena hodnota
            return await ExecuteOperationAsync(new List<SpaceBuildingsModel> { spaceBuilding }, operationType, "dbo.OnMap_SpaceBuildings");
        }

        public async Task<bool> ExecuteShipActualParametersOperationAsync(ActualParametersModel actualParameters, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<ActualParametersModel> { actualParameters }, operationType, "dbo.Ship_ActualParameters");
        }

        public async Task<bool> ExecuteShipComponentOperationAsync(ShipComponentModel shipComponent, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<ShipComponentModel> { shipComponent }, operationType, "dbo.Ship_Component");
        }

        public async Task<bool> ExecuteShipConfigOperationAsync(ShipConfigModel shipConfig, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<ShipConfigModel> { shipConfig }, operationType, "dbo.Ship_Config");
        }

        public async Task<bool> ExecuteShipFleetOperationAsync(FleetModel fleet, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<FleetModel> { fleet }, operationType, "dbo.Ship_Fleet");
        }

        public async Task<bool> ExecuteShipOperationAsync(ShipModel ship, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<ShipModel> { ship }, operationType, "dbo.Ship_Ship");
        }

        public async Task<bool> ExecuteShipStaticParametersOperationAsync(StaticParametersModel staticParameters, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<StaticParametersModel> { staticParameters }, operationType, "dbo.Ship_StaticParameters");
        }

        public async Task<bool> ExecuteUserBoostersOperationAsync(UserBoostersModel userBoosters, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<UserBoostersModel> { userBoosters }, operationType, "dbo.User_Boosters");
        }

        public async Task<bool> ExecuteUserConfigOperationAsync(UserConfigModel userConfig, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<UserConfigModel> { userConfig }, operationType, "dbo.User_Config");
        }

        public async Task<bool> ExecuteUserItemsOperationAsync(UserItemsModel userItems, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<UserItemsModel> { userItems }, operationType, "dbo.User_Items");
        }

        public async Task<bool> ExecuteUserOperationAsync(UserModel user, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<UserModel> { user }, operationType, "dbo.User_User");
        }

        public async Task<bool> ExecuteUserPermissionsOperationAsync(UserPermissionsModel userPermissions, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<UserPermissionsModel> { userPermissions }, operationType, "dbo.User_Permissions");
        }

        public async Task<bool> ExecuteUserResearchOperationAsync(UserResearchModel userResearch, SqlOperationType operationType)
        {
            return await ExecuteOperationAsync(new List<UserResearchModel> { userResearch }, operationType, "dbo.User_Research");
        }
        #endregion

    }

}
