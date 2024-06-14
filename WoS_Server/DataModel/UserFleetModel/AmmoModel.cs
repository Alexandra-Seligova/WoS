namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WoS_Server.Models;
    using Microsoft.Xna.Framework;
    using System.ComponentModel.DataAnnotations;

    public class AmmoModel : Base_Module
    {
        public int Id_User { get; set; } // id serveru
        public int Id_Fleet { get; set; } // Identifikátor letky, ke které dron patří

        [Key]
        public int Id_Ammo { get; set; } // Unikátní identifikátor munice

        public int Id_Ammo_Type { get; set; } // Unikátní identifikátor munice



        public StaticParameters StaticParameters { get; set; } // Statické parametry lodi
        public ActualParameters ActualParameters { get; set; } // Dynamické parametry lodi




        public AmmoModel(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
         : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            // Default constructor logic here
        }
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

    public class AmmoConfigurations
    {

        public int Id_User { get; set; } // id serveru
        public int Id_Ship { get; set; } // Unikátní identifikátor lodi
        [Key]
        public int Id_Ammo { get; set; } // Unikátní identifikátor munice

        // Vlastnosti munice
        public float Size { get; set; } = 5; // Velikost munice
        public int Damage { get; set; } // Poškození způsobené municí
        public int Range { get; set; } // Dostřel munice

        public AmmunitionType Type { get; set; } // Typ munice
        public PenetrationType Penetration { get; set; } // Typ průraznosti


    }
}
