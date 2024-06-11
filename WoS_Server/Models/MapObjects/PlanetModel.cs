namespace WoS_Server.Models
{
    using Microsoft.Xna.Framework;

    // dědíme z Base_Module protože je to nezničitelný objekt mapy
    // Model pro Planety
    public class PlanetModel : Base_StaticObjectModel
    {
        public PlanetModel(
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
        ) : base(idGlobal, idUser, "Planet", spawnPlace, width, height, depth, distanceFromSun, diameter, solarMassWeight, gravity, hasAtmosphere, habitable, age)
        {
        }
    }

    /// <summary>Definuje typy planet.</summary>
    public enum PlanetType
    {
        /// <summary>Terestrická planeta - skalnatá planeta, podobná Zemi.</summary>
        Terrestrial,

        /// <summary>Plynný obr - velká planeta, která je složena především z plynů.</summary>
        GasGiant,

        /// <summary>Ledový obr - velká planeta, která obsahuje větší množství ledu a plynu.</summary>
        IceGiant,

        /// <summary>Trpasličí planeta - menší planeta, která nesplňuje všechna kritéria pro plnohodnotné planety.</summary>
        SmallDwarfPlanet
    }


}
