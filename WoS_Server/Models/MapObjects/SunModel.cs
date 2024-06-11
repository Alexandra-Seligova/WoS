namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    //dědíme z Base_Module protože je to nezničitelný obekt mapy
    // Model pro Slunce
    public class SunModel : Base_StaticObjectModel
    {
        public SunModel(
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
        ) : base(idGlobal, idUser, "Sun", spawnPlace, width, height, depth, distanceFromSun, diameter, solarMassWeight, gravity, hasAtmosphere, habitable, age)
        {
        }
    }

}