namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class CometModel : Base_StaticObjectModel
    {
        public float TailLength { get; set; } // Délka ohonu komety v kilometrech

        public CometModel(
            int idGlobal,
            int idUser,
            Vector3 spawnPlace,
            int width, int height, int depth,
            float distanceFromSun,
            int diameter,
            float solarMassWeight,
            int gravity,
            bool hasAtmosphere,
            float tailLength,
            int age
        ) : base(idGlobal, idUser, "Comet", spawnPlace, width, height, depth, distanceFromSun, diameter, solarMassWeight, gravity, hasAtmosphere, false, age)
        {
            TailLength = tailLength;
        }
    }
}
