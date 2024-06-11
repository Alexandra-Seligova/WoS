namespace WoS_Server.Models
{
    using Google.Protobuf.WellKnownTypes;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Reprezentuje základní třídu pro všechny moduly ve hře.
    /// Obsahuje společné vlastnosti, které sdílejí všechny prvky herního světa.
    /// Tato třída je abstraktní a je určena pro dědění od konkrétnějších prvků hry, jako jsou slunce, planety, boxy, asteroidy a měsíce.
    /// </summary>
    public abstract class Base_Module
    {
        /// <summary>Jedinečná identifikace objektu.</summary>
        public int Id_Global { get; set; }

        /// <summary>Identifikace uživatele, pod kterého objekt spadá.</summary>
        public int Id_User { get; set; }

        /// <summary>Typ objektu (např. "Battle", "Exploration", "MiningTechnology", "Transport").</summary>
        public int Id_Type { get; set; }

        public int Status { get; set; }

        /// <summary>Název objektu.</summary>
        public string Name { get; set; }

        /// <summary>Typ objektu (např. "Battle", "Exploration", "MiningTechnology", "Transport").</summary>
        public string Type { get; set; }

        /// <summary>Označení objektu. Výchozí hodnota je "Ship".</summary>
        public string Designation { get; set; } = "Ship";

        /// <summary>Popis objektu.</summary>
        public string Description { get; set; }

        /// <summary>Místo, kde se objekt objevil ve 3D prostoru.</summary>
        public Vector3 SpawnPlace { get; set; }

        /// <summary>Pozice objektu ve 3D prostoru.</summary>
        public Vector3 Position { get; set; }

        /// <summary>Globální pozice objektu na mapě.</summary>
        public Vector2 PositionOnMap { get; set; }

        /// <summary>Cílová pozice objektu.</summary>
        public Vector2 TargetPosition { get; set; }

        /// <summary>Rotace objektu v prostoru.</summary>
        public float Rotation { get; set; }

        /// <summary>Rychlost objektu.</summary>
        public Vector2 Velocity { get; set; }

        // Základní vlastnosti lodi
        public float Acceleration { get; set; }

        /// <summary>Šířka objektu (X-osa).</summary>
        public int Width { get; set; }

        /// <summary>Výška objektu (Y-osa).</summary>
        public int Height { get; set; }

        /// <summary>Hloubka objektu (Z-osa).</summary>
        public int Depth { get; set; }

        public int Weight { get; set; }

        private bool _canBeDestroyed;

        /// <summary>Objekt, vůči kterému je objekt svázaný gravitačním polem.</summary>
        public Vector3 GravityCenter { get; set; }

        /// <summary>Objekt, okolo kterého se objekt otáčí.</summary>
        public Vector3 OrbitalCenter { get; set; }

        public Base_Module(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
        {
            // Default constructor logic here
        }

        public bool CanBeDestroyed
        {
            get => _canBeDestroyed;
            set
            {
                _canBeDestroyed = value;
                if(!_canBeDestroyed)
                {
                    throw new InvalidOperationException("není podporováno");
                    // nezničitelný typ objektu, například pozadí hry, čistě ozdobné efekty atd
                    // není potřeba uchovávat informace o životech a dalších hodnotách
                }
            }
        }
        public int CalculateOrbitalPeriod(float distanceFromSun)
        {
            // Implementace výpočtu oběžné doby kolem slunce na základě vzdálenosti od slunce
            return (int)(Math.Sqrt(Math.Pow(distanceFromSun / 150e6, 3)) * 365); // Příklad výpočtu pro Zemi
        }

        public int CalculateRotationPeriod(int diameter, int gravity)
        {
            // Implementace výpočtu doby rotace kolem vlastní osy
            return (int)(24 * (diameter / 12742f) / (gravity / 9.8f)); // Příklad výpočtu pro Zemi
        }

        public Vector2 CalculateVelocity(float distanceFromSun)
        {
            // Implementace výpočtu rychlosti na základě vzdálenosti od slunce
            float velocity = (float)Math.Sqrt(1.327e20 / distanceFromSun); // Příklad výpočtu pro Zemi
            return new Vector2(velocity, velocity);
        }





    }
}
