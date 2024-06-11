namespace WoS_Server.Models
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Reprezentuje základní třídu pro statické objekty na mapě.
    /// Dědí z Base_Module a přidává specifické vlastnosti pro statické objekty.
    /// </summary>
    public abstract class Base_StaticObjectModel : Base_Module
    {
        /// <summary>Průměr objektu v kilometrech.</summary>
        public int Diameter { get; set; }

        /// <summary>Průměr objektu v tisících kilometrech.</summary>
        public float DiameterInThousands
        {
            get => Diameter / 1000f;
        }

        /// <summary>Hmotnost objektu v solárních hmotnostech.</summary>
        public float SolarMassWeight { get; set; }

        /// <summary>Gravitace na povrchu objektu v m/s².</summary>
        public int Gravity { get; set; }

        /// <summary>Gravitace na povrchu objektu v desítkách m/s².</summary>
        public float GravityInTens
        {
            get => Gravity / 10f;
        }

        /// <summary>Oběžná doba kolem slunce v dnech.</summary>
        public int OrbitalPeriod { get; set; }

        /// <summary>Oběžná doba kolem slunce v letech.</summary>
        public float OrbitalPeriodInYears
        {
            get => OrbitalPeriod / 365f;
        }

        /// <summary>Doba rotace kolem vlastní osy v hodinách.</summary>
        public int RotationPeriod { get; set; }

        /// <summary>Doba rotace kolem vlastní osy v dnech.</summary>
        public float RotationPeriodInDays
        {
            get => RotationPeriod / 24f;
        }

        /// <summary>Indikátor, zda má objekt atmosféru.</summary>
        public bool HasAtmosphere { get; set; }

        /// <summary>Indikátor, zda je objekt obyvatelný.</summary>
        public bool Habitable { get; set; }

        /// <summary>Věk objektu v milionech let.</summary>
        public int Age { get; set; } = 4600;

        /// <summary>Věk objektu v miliardách let.</summary>
        public float AgeInBillions
        {
            get => Age / 1000f;
        }

        /// <summary>Vzdálenost objektu od slunce v kilometrech.</summary>
        public float DistanceFromSun { get; set; }

        public Base_StaticObjectModel(
            int idGlobal,
            int idUser,
            string type,
            Vector3 spawnPlace,
            //TODO: Dopat do potomků
            int width, int height, int depth,
            float distanceFromSun,
            int diameter,
            float solarMassWeight,
            int gravity,
            bool hasAtmosphere,
            bool habitable,
            int age
        ) : base(idGlobal, idUser, spawnPlace, width, height, depth)//
        {
            Id_Global = idGlobal;
            Id_User = idUser;
            Id_Type = 0; // Typ objektu je nastaven na 0 jako výchozí, může být přepsán ve specifických třídách.

            Type = type;

            SpawnPlace = spawnPlace;
            Position = spawnPlace;
            PositionOnMap = new Vector2(Position.X, Position.Y);
            TargetPosition = PositionOnMap;
            Rotation = 0;

            Name = type;
            Designation = Name;

            Diameter = diameter;
            SolarMassWeight = solarMassWeight;
            Gravity = gravity;
            DistanceFromSun = distanceFromSun;

            OrbitalPeriod = CalculateOrbitalPeriod(distanceFromSun);
            RotationPeriod = CalculateRotationPeriod(diameter, gravity);

            Velocity = CalculateVelocity(distanceFromSun);
            Width = Height = Depth = diameter;
            Acceleration = Velocity.Length();

            HasAtmosphere = hasAtmosphere;
            Habitable = habitable;
            Age = age;

            CanBeDestroyed = false;
        }
    }
}
