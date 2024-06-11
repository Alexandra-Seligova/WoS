namespace WoS_Server.Models.MapObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    // Model pro Asteroidy
    public class AsteroidModel : Base_StaticObjectModel
    {
        public AsteroidModel(
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
        ) : base(idGlobal, idUser, "Asteroid", spawnPlace, width, height, depth, distanceFromSun, diameter, solarMassWeight, gravity, hasAtmosphere, habitable, age)
        {
        }
    }
}
