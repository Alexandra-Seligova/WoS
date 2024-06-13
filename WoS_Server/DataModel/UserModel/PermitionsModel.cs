namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // Třída reprezentující flagy uživatele
    public class PermisionsModel
    {
        [Key]
        [Required(ErrorMessage = "Toto pole je povinné.")]
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public bool IsAdmin { get; set; } // Flag pro administrátora
        public bool IsPremium { get; set; } // Flag pro prémiového uživatele
        public bool IsBanned { get; set; } // Flag pro zákaz účtu     
        public bool IsLocked { get; set; } // Zámek na deaktivaci účtu

    }
}
