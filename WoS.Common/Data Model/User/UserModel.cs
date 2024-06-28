using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WoS_Server.DB_Model
{
    // Třída reprezentující uživatele
    public class UserModel
    {
        [Key]
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public int Id_User_Type { get; set; } // Typ objektu
        public int Id_User_GameType { get; set; } // Typ objektu
        public int Id_User_Permission { get; set; } // Typ objektu

        public int Id_Position { get; set; }
        public int Id_User_Config { get; set; } // id uživatele - Primární klíč

        public int Id_Resources { get; set; }
        public int Id_Boosters { get; set; }
        public int Id_Research { get; set; }
        public int Id_Cargo_Items { get; set; }
        public int Id_User_ConnectionStatus { get; set; }



        public UserPermissionsModel UserPermissions { get; set; }
        public MapPositionModel MapPosition { get; set; }

        public UserConfigModel UserConfig { get; set; }
        public UserResourcesModel UserResources { get; set; }
        public UserBoostersModel UserBoosters { get; set; }
        public UserResearchModel UserResearch { get; set; }
        public CargoModel Cargo { get; set; }
        public UserItemsModel UserItems { get; set; }

        public UserModel()
        {
            UserBoosters = new UserBoostersModel();
            UserConfig = new UserConfigModel();
            UserResources = new UserResourcesModel();
            UserResearch = new UserResearchModel();
            Cargo = new CargoModel();
            UserItems = new UserItemsModel();
            UserPermissions = new UserPermissionsModel();
            MapPosition = new MapPositionModel();
        }

        public UserModel(int idUser, int idUserType, int idUserGameType, int idPosition, int idUserConfig, int idResources, int idBoosters, int idResearch, int idCargoItems, int idUserConnectionStatus)
        {
            Id_User = idUser;
            Id_User_Type = idUserType;
            Id_User_GameType = idUserGameType;
            Id_Position = idPosition;
            Id_User_Config = idUserConfig;
            Id_Resources = idResources;
            Id_Boosters = idBoosters;
            Id_Research = idResearch;
            Id_Cargo_Items = idCargoItems;
            Id_User_ConnectionStatus = idUserConnectionStatus;

            UserBoosters = new UserBoostersModel();
            UserConfig = new UserConfigModel();
            UserResources = new UserResourcesModel();
            UserResearch = new UserResearchModel();
            Cargo = new CargoModel();
            UserItems = new UserItemsModel();
            UserPermissions = new UserPermissionsModel();
            MapPosition = new MapPositionModel();
        }
    }
}
