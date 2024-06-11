namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static class MyValidator
    {
        public static ValidationResult ValidateName(string name, ValidationContext context)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult("Jméno nesmí být prázdné.");
            }
            return ValidationResult.Success;
        }
    }
    // [CustomValidation(typeof(MyValidator), "ValidateName")]
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }

    public class UserMetadata
    {
        [Required]
        public string Name { get; set; }
    }









    // Třída reprezentující uživatele
    public class UserModel
    {
        // [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Formát data musí být YYYY-MM-DD.")]
        //Validuje hodnotu podle zadaného regulárního výrazu.

        /// <summary>Jedinečná identifikace objektu.</summary>
        public int Id_Global { get; set; } // úplně originální klíč k objektu napříč databází

        [Key]
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele

        /// <summary>Typ objektu (např. "Battle", "Exploration", "MiningTechnology", "Transport").</summary>
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_Type { get; set; } // Typ objektu

        /// <summary>Fokus uživatele (např. "Warrior", "Explorer", "Builder", "Miner").</summary>
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Délka řetězce musí být mezi 5 a 100 znaky.")]
        public string Id_Focus { get; set; } // Fokus uživatele

        /// <summary>Status uživatele (např. offline, online).</summary>
        [Required]
        [Range(1, 10, ErrorMessage = "Hodnota musí být mezi 1 a 10.")]
        public int Status { get; set; } // Status uživatele

        /// <summary>Indikátor zamčení účtu uživatele.</summary>
        [Required]
        public bool IsLocked { get; set; } // Zámek na deaktivaci účtu

        /// <summary>Přezdívka uživatele.</summary>
        [Required]
        [MaxLength(255)]
        public string Nickname { get; set; } // Název uživatele

        /// <summary>Hash hesla uživatele.</summary>
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } // Heslo

        /// <summary>Email uživatele.</summary>
        [Required]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Neplatná emailová adresa.")]
        public string Email { get; set; } // Email

        /// <summary>Zdroje uživatele.</summary>
        public UserResources Resources { get; set; } // Zdroje uživatele (uživatel/záznamů 1:1)

        /// <summary>Boostery uživatele.</summary>
        public UserBoosters Boosters { get; set; } // Boostery uživatele (uživatel/záznamů 1:1)

        /// <summary>Flagy pro uživatele.</summary>
        public UserPermisions Flags { get; set; } // Flagy uživatele (uživatel/záznamů 1:1)

        // ###########  Ship    #############
        /// <summary>Množina ID lodí uživatele.</summary>
        public List<int> Id_List_UserShips { get; set; } // Množina jen uživatelových ID lodí

        /// <summary>Vybraná aktivovaná loď uživatele.</summary>
        public int Id_SelectedShip { get; set; } // Ukazatel na vybranou loď, se kterou hráč letí

        // ###########  Drones    #############
        /// <summary>Množina ID dronů uživatele.</summary>
        public List<int> Id_List_UserDrones { get; set; } // Množina jen uživatelových ID dronů

        /// <summary>Množina aktivovaných ID dronů uživatele.</summary>
        public List<int> Id_List_SelectedDrones { get; set; } // Množina jen aktivovaných uživatelových ID dronů

        public UserModel()
        {
            Id_List_UserShips = new List<int>();
            Id_List_UserDrones = new List<int>();
            Id_List_SelectedDrones = new List<int>();
        }
    }

    // Třída reprezentující zdroje uživatele
    public class UserResources : Base_ResourcesModel
    {
        // Obsahuje zdroje specifické pro uživatele, např. XP, Honor, Credits, SpaceCoin
    }

    // Třída reprezentující boostery uživatele
    public class UserBoosters
    {
        public bool Speed { get; set; } // Rychlost
        public bool Attack { get; set; } // Útok
        public bool Defense { get; set; } // Obrana
        public bool Colonization { get; set; } // Kolonizace
        public bool Construction { get; set; } // Výstavba
        public bool IndustrialProduction { get; set; } // Průmyslová produkce
    }

    // Třída reprezentující flagy uživatele
    public class UserPermisions
    {
        public bool IsAdmin { get; set; } // Flag pro administrátora
        public bool IsPremium { get; set; } // Flag pro prémiového uživatele
        public bool IsBanned { get; set; } // Flag pro zákaz účtu
    }

    public class UserFleet // tabulka pro max 9 slotů pro shiptype a veškerého jejího nastavení
    {
        // jaké typy lodí má hráč k dispozici
        public List<ShipType> AvailableShips { get; set; }

        public UserFleet()
        {
            AvailableShips = new List<ShipType>();
        }

        public void SetShip(ShipType shipType)
        {
            // Metoda pro nastavení vybrané lodi
            // Implementace logiky pro nastavení vybrané lodi
        }
    }

    public enum ShipType
    {
        ShipBattleAlpha,
        ShipBattleBeta,
        ShipExploratoryAlpha,
        ShipExploratoryBeta,
        ShipMiningAlpha,
        ShipMiningBeta,
        ShipTraderAlpha,
        ShipTraderBeta,
        ShipTransportAlpha,
        ShipTransportBeta
    }

    public class UserDroneFleet // pro každý záznam v AvailableShips jsou 2 nastavení pro formaci dronů
    {
        // jaké typy dronů má hráč k dispozici
        public List<DroneType> AvailableDrones { get; set; }

        public UserDroneFleet()
        {
            AvailableDrones = new List<DroneType>();
        }

        public void SetDrone(DroneType droneType)
        {
            // Metoda pro nastavení vybraného dronu
            // Implementace logiky pro nastavení vybraného dronu
        }
    }

    public enum DroneType
    {
        DronDeluxeAlpha,
        DronBattleAlpha,
        DronLavaAlpha,
        DronAquaAlpha,
        DronElectroAlpha
    }

    public class Base_ResourcesModel
    {
        // Common resources across different models
        public int XP { get; set; }
        public int Honor { get; set; }
        public int Credits { get; set; }
        public int SpaceCoin { get; set; }

        public int Metal { get; set; }
        public int Crystals { get; set; }
        public int Minerals { get; set; }
        public int Deuterium { get; set; }
        public int Antimatter { get; set; }
        public int DarkMatter { get; set; }

        // Minerály
        public int Prom { get; set; }
        public int Endu { get; set; }
        public int Terb { get; set; }
        public int Prom2 { get; set; }
        public int Endu2 { get; set; }
        public int Terb2 { get; set; }
        public int Xenomit { get; set; }
        public int Palladium { get; set; }
        public int Seprom { get; set; }
        public int Osmium { get; set; }

        // Koření
        public int SpiceRed { get; set; }
        public int SpiceYellow { get; set; }
        public int SpiceBlue { get; set; }
        public int SpicePurple { get; set; }
        public int SpiceGreen { get; set; }
        public int SpiceDark { get; set; }
    }
}
