namespace WoS.User
{
    internal class UserBase
    {

        public int Id { get; set; }
        public bool IsLocked { get; set; }
        public string Nickname { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public string UserFocus { get; set; } // Possible values: "Bojovník", "Průzkumník", "Stavitel", "Težař"

        public Boosters Boosters { get; set; }

        public Resources Resources { get; set; }


        public UserBase()
        {
            Resources = new Resources();
            Boosters = new Boosters();
        }
    }

    public class Resources
    {
        public int Kov { get; set; }
        public int Krystaly { get; set; }
        public int Mineraly { get; set; }
        public int Deuterium { get; set; }
        public int Antihmota { get; set; }
        public int TemnaHmota { get; set; }
        public int Kredity { get; set; }
        public int Uridium { get; set; }
    }

    public class Boosters
    {
        public bool Rychlosti { get; set; }
        public bool Utoku { get; set; }
        public bool Obrany { get; set; }
        public bool Kolonizace { get; set; }
        public bool Vystavby { get; set; }
        public bool ProdukcePrumyslu { get; set; }
    }

}