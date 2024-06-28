namespace WoS_Server.DB_Model
{
    using System.ComponentModel.DataAnnotations;

    public class AmmoModel
    {
        public int Id_User { get; set; } // id serveru
                                         // public int Id_Fleet { get; set; } // Identifikátor letky, ke které dron patří

        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        [Key]
        public int Id_Ammo { get; set; } // Unikátní identifikátor munice

        public int Id_Ammo_Type { get; set; } // Unikátní identifikátor munice
        public int Id_Ammo_Penetration_Type { get; set; } // Unikátní identifikátor munice

        public int Id_Ammo_Config { get; set; } // Unikátní identifikátor munice
        public int Id_Position { get; set; } // Unikátní identifikátor munice

        public MapPositionModel AmmoPosition { get; set; }

        public AmmoConfigModel AmmoConfig { get; set; }

        // Prázdný konstruktor
        public AmmoModel() { }

        // Konstruktor s argumenty
        public AmmoModel(int id_User, int id_Ship, int id_Ammo, int id_Ammo_Type, int id_Ammo_Penetration_Type, int id_Ammo_Config, int id_Position)
        {
            Id_User = id_User;
            Id_Ship = id_Ship;
            Id_Ammo = id_Ammo;
            Id_Ammo_Type = id_Ammo_Type;
            Id_Ammo_Penetration_Type = id_Ammo_Penetration_Type;
            Id_Ammo_Config = id_Ammo_Config;
            Id_Position = id_Position;
            AmmoPosition = new MapPositionModel();
            AmmoConfig = new AmmoConfigModel();
        }
    }

    public enum AmmunitionType
    {
        Bullet = 1,      // Kulka
        Laser = 2,       // Laser
        Missile = 3,     // Raketa
        Plasma = 4,      // Plazma
        Explosive = 5,   // Výbušnina
        EMP = 6,         // EMP
        Railgun = 7      // Railgun
    }

    public enum PenetrationType
    {
        Steel = 1,       // Ocel
        Silver = 2,      // Stříbro
        Gold = 3,        // Zlato
        LightBlue = 4,   // Světle modrá
        Green = 5,       // Zelená
        Orange = 6,      // Oranžová
        Purple = 7,      // Fialová
        Red = 8          // Červená
    }



}
