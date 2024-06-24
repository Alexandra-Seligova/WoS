
namespace WoS_Server.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Game_ViewModel
    {
        // List uživatelů ve hře
        public List<User_ViewModel> Users { get; set; }

        // Definice pro GalaxyMap
        public GalaxyMap_ViewModel GalaxyMap { get; set; }

        // List Map_ViewModel o které se server stará
        public List<Map_ViewModel> Maps { get; set; }

        // Prázdný konstruktor
        public Game_ViewModel()
        {
            Users = new List<User_ViewModel>();
            GalaxyMap = new GalaxyMap_ViewModel();
            Maps = new List<Map_ViewModel>();
        }

        // Metoda pro vytvoření objektů
        public void CreateObjects()
        {
            /*
            GalaxyMap = new GalaxyMap_ViewModel { Id = 1, Name = "Galaxy1" };
            Maps.Add(new Map_ViewModel { Id = 1, Name = "Map1" });
            Users.Add(new User_ViewModel { Id = 1, Name = "User1" });
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
        public async Task<bool> RegisterAsync(User_ViewModel newUser)
        {
            // Základní implementace registrace nového uživatele
            // TODO: Implementace logiky pro registraci nového uživatele
            return await Task.FromResult(true);
        }

        // Metoda pro načtení uživatele podle ID
        public async Task<User_ViewModel> LoadUserByIdAsync(int userId)
        {
            // Základní implementace načtení uživatele podle ID
            // TODO: Implementace logiky pro načtení uživatele podle ID
            return await Task.FromResult(new User_ViewModel { Id = userId, Name = "User" + userId });
        }
    }


}
