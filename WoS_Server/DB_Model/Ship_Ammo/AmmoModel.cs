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

    }

    public enum AmmunitionType
    {
        Bullet,      // Kulka
        Laser,       // Laser
        Missile,     // Raketa
        Plasma,      // Plazma
        Explosive,   // Výbušnina
        EMP,         // EMP
        Railgun      // Railgun
    }

    public enum PenetrationType
    {
        Steel,       // Ocel
        Silver,      // Stříbro
        Gold,        // Zlato
        LightBlue,   // Světle modrá
        Green,       // Zelená
        Orange,      // Oranžová
        Purple,       // Fialová
        Red
    }


}
