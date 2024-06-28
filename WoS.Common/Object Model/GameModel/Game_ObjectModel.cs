
namespace WoS_Server.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Game_ObjectModel
    {
        // List uživatelů ve hře
        public List<User_ObjectModel> Users { get; set; }

        // Definice pro GalaxyMap
        public GalaxyMap_ObjectModel GalaxyMap { get; set; }

        // List Map_ObjectModel o které se server stará
        public List<Map_ObjectModel> Maps { get; set; }

        // Prázdný konstruktor
        public Game_ObjectModel()
        {
            Users = new List<User_ObjectModel>();
            GalaxyMap = new GalaxyMap_ObjectModel();
            Maps = new List<Map_ObjectModel>();
        }

        // Metoda pro vytvoření objektů
        public void CreateObjects()
        {
            /*
            GalaxyMap = new GalaxyMap_ObjectModel { Id = 1, Name = "Galaxy1" };
            Maps.Add(new Map_ObjectModel { Id = 1, Name = "Map1" });
            Users.Add(new User_ObjectModel { Id = 1, Name = "User1" });
            */
        }

        // Metoda pro přihlášení uživatele
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Základní implementace přihlášení uživatele
            // TODO: Implementace logiky pro přihlášení uživatele
            return await Task.FromResult(true);
        }

        // Metoda pro registraci nového uživatele
        public async Task<bool> RegisterAsync(User_ObjectModel newUser)
        {
            // Základní implementace registrace nového uživatele
            // TODO: Implementace logiky pro registraci nového uživatele
            return await Task.FromResult(true);
        }

        // Metoda pro načtení uživatele podle ID
        public async Task<User_ObjectModel> LoadUserByIdAsync(int userId)
        {
            // Základní implementace načtení uživatele podle ID
            // TODO: Implementace logiky pro načtení uživatele podle ID
            return await Task.FromResult(new User_ObjectModel { Id = userId, Name = "User" + userId });
        }
    }


}
