namespace WoS_Server.Models
{
    using Microsoft.Xna.Framework;


    // Model pro Trpasličí Planety
    public class DwarfPlanetModel : Base_StaticObjectModel
    {
        public DwarfPlanetModel(
            int idGlobal,
            int idUser,
            Vector3 spawnPlace,
            int width, int height, int depth,
            float distanceFromSun,
            int diameter,
            float solarMassWeight,
            int gravity,
            bool hasAtmosphere,
            bool habitable,
            int age
        ) : base(idGlobal, idUser, "DwarfPlanet", spawnPlace, width, height, depth, distanceFromSun, diameter, solarMassWeight, gravity, hasAtmosphere, habitable, age)
        {
        }
    }
    /// <summary>Definuje typy trpasličích planet.</summary>
    public enum DwarfPlanetType
    {
        /// <summary>Klasický typ trpasličí planety.</summary>
        Classical,

        /// <summary>Ledový typ trpasličí planety.</summary>
        Ice,

        /// <summary>Skalnatý typ trpasličí planety.</summary>
        Rocky,

        /// <summary>Typ trpasličí planety s hustou atmosférou.</summary>
        DenseAtmosphere
    }

}