

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

        public enum SqlOperationType
        {
            Insert,
            Delete,
            Update
        }

        private async Task<bool> ExecuteOperationAsync<T>(T model, SqlOperationType operationType, string tableName, Dictionary<string, object> parameters)
        {
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


        public async Task<bool> ExecuteAmmoOperationAsync(AmmoModel ammo, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
        {
            { "Id_User", ammo.Id_User },
            { "Id_Ship", ammo.Id_Ship },
            { "Id_Ammo", ammo.Id_Ammo },
            { "Id_Ammo_Type", ammo.Id_Ammo_Type },
            { "Id_Ammo_Penetration_Type", ammo.Id_Ammo_Penetration_Type },
            { "Id_Ammo_Config", ammo.Id_Ammo_Config },
            { "Id_Position", ammo.Id_Position }
        };

            return await ExecuteOperationAsync(ammo, operationType, "dbo.Ammo", parameters);
        }

        public async Task<bool> ExecuteAmmoConfigOperationAsync(AmmoConfigModel ammoConfig, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", ammoConfig.Id_User },
        { "Id_Ammo_Config", ammoConfig.Id_Ammo_Config },
        { "Size", ammoConfig.Size },
        { "Damage", ammoConfig.Damage },
        { "Range", ammoConfig.Range },
        { "IsControlable", ammoConfig.IsControlable }
    };

            return await ExecuteOperationAsync(ammoConfig, operationType, "dbo.AmmoConfig", parameters);
        }

        public async Task<bool> ExecuteMapOperationAsync(MapModel map, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", map.Id_Map },
        { "Id_Map_Type", map.Id_Map_Type },
        { "Id_GalaxyPosition", map.Id_GalaxyPosition },
        { "Id_MapObjectConfig", map.Id_MapObjectConfig },
        { "Name", map.Name }
    };

            return await ExecuteOperationAsync(map, operationType, "dbo.Map", parameters);
        }

        public async Task<bool> ExecuteGalaxyPositionOperationAsync(GalaxyPosition galaxyPosition, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", galaxyPosition.Id_Map },
        { "Id_GalaxyPosition", galaxyPosition.Id_GalaxyPosition },
        { "Id_Sector", galaxyPosition.Id_Sector },
        { "Position_X", galaxyPosition.Position_X },
        { "Position_Y", galaxyPosition.Position_Y }
    };

            return await ExecuteOperationAsync(galaxyPosition, operationType, "dbo.MapGalaxyPosition", parameters);
        }

        public async Task<bool> ExecuteMapObjectConfigOperationAsync(MapObjectConfigModel mapObjectConfig, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", mapObjectConfig.Id_Map },
        { "Id_User", mapObjectConfig.Id_User },
        { "Id_Object", mapObjectConfig.Id_Object },
        { "Id_ObjectType", mapObjectConfig.Id_ObjectType },
        { "Id_MapObjectConfig", mapObjectConfig.Id_MapObjectConfig },
        { "Name", mapObjectConfig.Name },
        { "Width", mapObjectConfig.Width },
        { "Height", mapObjectConfig.Height },
        { "Diameter", mapObjectConfig.Diameter },
        { "SolarMassWeight", mapObjectConfig.SolarMassWeight },
        { "Gravity", mapObjectConfig.Gravity },
        { "Orbit", mapObjectConfig.Orbit },
        { "OrbitalPeriod", mapObjectConfig.OrbitalPeriod },
        { "RotationPeriod", mapObjectConfig.RotationPeriod },
        { "HasAtmosphere", mapObjectConfig.HasAtmosphere },
        { "Habitable", mapObjectConfig.Habitable },
        { "Age", mapObjectConfig.Age }
    };

            return await ExecuteOperationAsync(mapObjectConfig, operationType, "dbo.MapObjectConfig", parameters);
        }

        public async Task<bool> ExecuteMapObjectsOperationAsync(MapObjectsModel mapObject, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", mapObject.Id_Map },
        { "Id_Object", mapObject.Id_Object },
        { "Id_ObjectType", mapObject.Id_ObjectType },
        { "Id_Position", mapObject.Id_Position },
        { "Id_MapObjectConfig", mapObject.Id_MapObjectConfig }
    };

            return await ExecuteOperationAsync(mapObject, operationType, "dbo.MapObjects", parameters);
        }
        public async Task<bool> ExecuteMapPositionOperationAsync(MapPositionModel mapPosition, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", mapPosition.Id_Map },
        { "Id_User", mapPosition.Id_User },
        { "Id_Object", mapPosition.Id_Object },
        { "Id_ObjectType", mapPosition.Id_ObjectType },
        { "Id_Position", mapPosition.Id_Position },
        { "ObjectName", mapPosition.ObjectName },
        { "Velocity", mapPosition.Velocity },
        { "Map_x", mapPosition.Map_x },
        { "Map_y", mapPosition.Map_y },
        { "Map_z", mapPosition.Map_z },
        { "Target_Map_x", mapPosition.Target_Map_x },
        { "Target_Map_y", mapPosition.Target_Map_y },
        { "Target_Map_z", mapPosition.Target_Map_z }
    };

            return await ExecuteOperationAsync(mapPosition, operationType, "dbo.MapPosition", parameters);
        }

        public async Task<bool> ExecuteOnMapAiShipsOperationAsync(AiShips aiShips, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", aiShips.Id_Map },
        { "Id_ObjektType", 14 }, // přednastavena hodnota
        { "Id_AiShips", aiShips.Id_AiShips },
        { "Id_AiShips_Type", aiShips.Id_AiShips_Type },
        { "Id_AiShips_SubType", aiShips.Id_AiShips_SubType },
        { "Id_Position", aiShips.Id_Position },
        { "Id_AiShipsConfig", aiShips.Id_AiShipsConfig },
        { "Id_Cargo", aiShips.Id_Cargo },
        { "Id_AiShips_StaticParameters", aiShips.Id_AiShips_StaticParameters },
        { "Id_AiShips_ActualParameters", aiShips.Id_AiShips_ActualParameters }
    };

            return await ExecuteOperationAsync(aiShips, operationType, "dbo.OnMap_AiShips", parameters);
        }

        public async Task<bool> ExecuteOnMapArtifactOperationAsync(ArtifactModel artifact, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", artifact.Id_Map },
        { "Id_ObjektType", 12 }, // přednastavena hodnota
        { "Id_Artifact", artifact.Id_Artifact },
        { "Id_ArtifactType", artifact.Id_ArtifactType },
        { "Id_Position", artifact.Id_Position },
        { "Id_ArtifactConfig", artifact.Id_ArtifactConfig },
        { "Id_Cargo", artifact.Id_Cargo }
    };

            return await ExecuteOperationAsync(artifact, operationType, "dbo.OnMap_Artifact", parameters);
        }

        public async Task<bool> ExecuteOnMapBoxOperationAsync(BoxModel box, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", box.Id_Map },
        { "Id_ObjektType", 11 }, // přednastavena hodnota
        { "Id_Box", box.Id_Box },
        { "Id_BoxType", box.Id_BoxType },
        { "Id_Position", box.Id_Position },
        { "Id_BoxConfig", box.Id_BoxConfig },
        { "Id_Cargo", box.Id_Cargo }
    };

            return await ExecuteOperationAsync(box, operationType, "dbo.OnMap_Box", parameters);
        }

        public async Task<bool> ExecuteOnMapNpcsOperationAsync(NpcsModel npc, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", npc.Id_Map },
        { "Id_ObjektType", 14 }, // přednastavena hodnota
        { "Id_Npc", npc.Id_Npc },
        { "Id_Npc_Type", npc.Id_Npc_Type },
        { "Id_Npc_SubType", npc.Id_Npc_SubType },
        { "Id_Position", npc.Id_Position },
        { "Id_NpcConfig", npc.Id_NpcConfig },
        { "Id_Cargo", npc.Id_Cargo },
        { "Id_Npc_StaticParameters", npc.Id_Npc_StaticParameters },
        { "Id_Npc_ActualParameters", npc.Id_Npc_ActualParameters }
    };

            return await ExecuteOperationAsync(npc, operationType, "dbo.OnMap_Npcs", parameters);
        }

        public async Task<bool> ExecuteOnMapSpaceBuildingsOperationAsync(SpaceBuildings spaceBuilding, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_Map", spaceBuilding.Id_Map },
        { "Id_ObjektType", 13 }, // přednastavena hodnota
        { "Id_SpaceBuilding", spaceBuilding.Id_SpaceBuilding },
        { "Id_SpaceBuildingType", spaceBuilding.Id_SpaceBuildingType },
        { "Id_Position", spaceBuilding.Id_Position },
        { "Id_SpaceBuildingConfig", spaceBuilding.Id_SpaceBuildingConfig },
        { "Id_Cargo", spaceBuilding.Id_Cargo }
    };

            return await ExecuteOperationAsync(spaceBuilding, operationType, "dbo.OnMap_SpaceBuildings", parameters);
        }

        public async Task<bool> ExecuteShipActualParametersOperationAsync(ActualParametersModel actualParameters, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", actualParameters.Id_User },
        { "Id_Ship", actualParameters.Id_Ship },
        { "Id_Ammo_ActualParameters", actualParameters.Id_Ammo_ActualParameters },
        { "Id_Position", actualParameters.Id_Position },
        { "Rotation", actualParameters.Rotation },
        { "Velocity", actualParameters.Velocity },
        { "Acceleration", actualParameters.Acceleration },
        { "IsTarget", actualParameters.IsTarget },
        { "IsAutomaticTarget", actualParameters.IsAutomaticTarget },
        { "Id_Target", actualParameters.Id_Target },
        { "Id_TargetType", actualParameters.Id_TargetType },
        { "Id_Target_Position", actualParameters.Id_Target_Position },
        { "HP", actualParameters.HP },
        { "Armor", actualParameters.Armor },
        { "Integrity", actualParameters.Integrity },
        { "Shield", actualParameters.Shield },
        { "ShieldLeft", actualParameters.ShieldLeft },
        { "ShieldRight", actualParameters.ShieldRight },
        { "ShieldFront", actualParameters.ShieldFront },
        { "ShieldBack", actualParameters.ShieldBack }
    };

            return await ExecuteOperationAsync(actualParameters, operationType, "dbo.Ship_ActualParameters", parameters);
        }

        public async Task<bool> ExecuteShipComponentOperationAsync(ShipComponentModel shipComponent, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", shipComponent.Id_User },
        { "Id_Ship", shipComponent.Id_Ship },
        { "Id_Ship_Component", shipComponent.Id_Ship_Component },
        { "Id_Ship_Component_Type", shipComponent.Id_Ship_Component_Type },
        { "Component_Name", shipComponent.Component_Name },
        { "PositionOnShip_x", shipComponent.PositionOnShip_x },
        { "PositionOnShip_y", shipComponent.PositionOnShip_y },
        { "PositionOnShip_z", shipComponent.PositionOnShip_z }
    };

            return await ExecuteOperationAsync(shipComponent, operationType, "dbo.Ship_Component", parameters);
        }

        public async Task<bool> ExecuteShipConfigOperationAsync(ShipConfigModel shipConfig, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", shipConfig.Id_User },
        { "Id_Ship", shipConfig.Id_Ship },
        { "Id_Ship_Config", shipConfig.Id_Ship_Config },
        { "GeneratorsGroup", shipConfig.GeneratorsGroup },
        { "WeaponsGroup", shipConfig.WeaponsGroup },
        { "ExtensionsGroup", shipConfig.ExtensionsGroup },
        { "AmmosGroup", shipConfig.AmmosGroup },
        { "FuelTanksGroup", shipConfig.FuelTanksGroup }
    };

            return await ExecuteOperationAsync(shipConfig, operationType, "dbo.Ship_Config", parameters);
        }
        public async Task<bool> ExecuteShipFleetOperationAsync(FleetModel fleet, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", fleet.Id_User },
        { "Id_Fleet", fleet.Id_Fleet },
        { "Id_Ship_Group", fleet.Id_Ship_Group },
        { "Id_Fleet_Formation", fleet.Id_Fleet_Formation },
        { "ID_MainShip", fleet.ID_MainShip }
    };

            return await ExecuteOperationAsync(fleet, operationType, "dbo.Ship_Fleet", parameters);
        }

        public async Task<bool> ExecuteShipOperationAsync(ShipModel ship, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", ship.Id_User },
        { "Id_Fleet", ship.Id_Fleet },
        { "Id_Fleet_Formation", ship.Id_Fleet_Formation },
        { "Id_Fleet_FormationPosition", ship.Id_Fleet_FormationPosition },
        { "Id_Ship", ship.Id_Ship },
        { "Id_Ship_Type", ship.Id_Ship_Type },
        { "Name", ship.Name },
        { "Level", ship.Level },
        { "Designation", ship.Designation },
        { "Id_Ship_StaticParameters", ship.Id_Ship_StaticParameters },
        { "Id_Ship_ActualParameters", ship.Id_Ship_ActualParameters },
        { "Id_Ship_Config", ship.Id_Ship_Config }
    };

            return await ExecuteOperationAsync(ship, operationType, "dbo.Ship_Ship", parameters);
        }

        public async Task<bool> ExecuteShipStaticParametersOperationAsync(StaticParametersModel staticParameters, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", staticParameters.Id_User },
        { "Id_Ship", staticParameters.Id_Ship },
        { "Id_StaticParameters", staticParameters.Id_StaticParameters },
        { "Name", staticParameters.Name },
        { "CanBeDestroyed", staticParameters.CanBeDestroyed },
        { "Id_Position_Spawn", staticParameters.Id_Position_Spawn },
        { "Description", staticParameters.Description },
        { "MaxHP", staticParameters.MaxHP },
        { "MaxArmor", staticParameters.MaxArmor },
        { "MaxStructuralIntegrity", staticParameters.MaxStructuralIntegrity },
        { "MaxShield", staticParameters.MaxShield },
        { "MaxShieldLeft", staticParameters.MaxShieldLeft },
        { "MaxShieldRight", staticParameters.MaxShieldRight },
        { "MaxShieldFront", staticParameters.MaxShieldFront },
        { "MaxShieldBack", staticParameters.MaxShieldBack }
    };

            return await ExecuteOperationAsync(staticParameters, operationType, "dbo.Ship_StaticParameters", parameters);
        }

        public async Task<bool> ExecuteUserBoostersOperationAsync(UserBoostersModel userBoosters, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", userBoosters.Id_User },
        { "Id_Booster", userBoosters.Id_Booster },
        { "Speed", userBoosters.Speed },
        { "Attack", userBoosters.Attack },
        { "Defense", userBoosters.Defense },
        { "Construction", userBoosters.Construction },
        { "Production", userBoosters.Production }
    };

            return await ExecuteOperationAsync(userBoosters, operationType, "dbo.User_Boosters", parameters);
        }

        public async Task<bool> ExecuteUserConfigOperationAsync(UserConfigModel userConfig, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", userConfig.Id_User },
        { "Id_Config", userConfig.Id_Config },
        { "Id_Permissions", userConfig.Id_Permissions },
        { "Id_UserFocus", userConfig.Id_UserFocus },
        { "NickName", userConfig.NickName },
        { "Password", userConfig.Password },
        { "Email", userConfig.Email },
        { "Id_SelectedFleet", userConfig.Id_SelectedFleet },
        { "Id_SelectedShip", userConfig.Id_SelectedShip },
        { "Id_SelectedFormation", userConfig.Id_SelectedFormation }
    };

            return await ExecuteOperationAsync(userConfig, operationType, "dbo.User_Config", parameters);
        }

        public async Task<bool> ExecuteUserItemsOperationAsync(UserItemsModel userItems, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", userItems.Id_User },
        { "Id_Item", userItems.Id_Item },
        { "Id_ItemType", userItems.Id_ItemType },
        { "ItemName", userItems.ItemName },
        { "Level", userItems.Level }
    };

            return await ExecuteOperationAsync(userItems, operationType, "dbo.User_Items", parameters);
        }

        public async Task<bool> ExecuteUserOperationAsync(UserModel user, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", user.Id_User },
        { "Id_User_Type", user.Id_User_Type },
        { "Id_User_GameType", user.Id_User_GameType },
        { "Id_Position", user.Id_Position },
        { "Id_User_Config", user.Id_User_Config },
        { "Id_Resources", user.Id_Resources },
        { "Id_Boosters", user.Id_Boosters },
        { "Id_Research", user.Id_Research },
        { "Id_Cargo_Items", user.Id_Cargo_Items },
        { "Id_User_ConnectionStatus", user.Id_User_ConnectionStatus }
    };

            return await ExecuteOperationAsync(user, operationType, "dbo.User_User", parameters);
        }

        public async Task<bool> ExecuteUserPermissionsOperationAsync(UserPermissionsModel userPermissions, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", userPermissions.Id_User },
        { "Id_Permission", userPermissions.Id_Permission },
        { "IsAdmin", userPermissions.IsAdmin },
        { "IsPremium", userPermissions.IsPremium },
        { "IsBanned", userPermissions.IsBanned },
        { "IsLocked", userPermissions.IsLocked }
    };

            return await ExecuteOperationAsync(userPermissions, operationType, "dbo.User_Permissions", parameters);
        }

        public async Task<bool> ExecuteUserResearchOperationAsync(UserResearchModel userResearch, SqlOperationType operationType)
        {
            var parameters = new Dictionary<string, object>
    {
        { "Id_User", userResearch.Id_User },
        { "Id_Research", userResearch.Id_Research },
        { "Id_Research_Type", userResearch.Id_Research_Type },
        { "Name", userResearch.Name },
        { "Research_level", userResearch.Research_level }
    };

            return await ExecuteOperationAsync(userResearch, operationType, "dbo.User_Research", parameters);
        }

    }

}
