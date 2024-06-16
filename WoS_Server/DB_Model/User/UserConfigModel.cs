namespace WoS_Server.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserConfigModel
    {


        [Key]
        public int Id_User { get; set; } // id uživatele - Primární klíč
        public int Id_Config { get; set; } // id uživatele - Primární klíč

        public int Id_Permissions { get; set; } // id uživatele - Primární klíč
        public int Id_UserFocus { get; set; } // id uživatele - Primární klíč
        public int NickName { get; set; } // id uživatele - Primární klíč
        public int Password { get; set; } // id uživatele - Primární klíč
        public int Email { get; set; } // id uživatele - Primární klíč
        public int Id_SelectedFleet { get; set; } // id uživatele - Primární klíč
        public int Id_SelectedShip { get; set; } // id uživatele - Primární klíč
        public int Id_SelectedFormation { get; set; } // id uživatele - Primární klíč



    }
}
