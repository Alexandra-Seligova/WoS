namespace WoS_Server.DataModel
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
        /*

        public int Id_User { get; set; } = 0; // id serveru
        public int Id_Map { get; set; } = 1;  // Unikátní identifikátor mapy
        public int Id_StaticObject { get; set; }

        /// <summary>Průměr objektu v kilometrech.</summary>
        public int Diameter { get; set; }

        /// <summary>Hmotnost objektu v solárních hmotnostech.</summary>
        public float SolarMassWeight { get; set; }

        /// <summary>Gravitace na povrchu objektu v m/s².</summary>
        public float Gravity { get; set; }

        /// <summary>Oběžná doba kolem slunce v dnech.</summary>
        public float OrbitalPeriod { get; set; }

        /// <summary>Doba rotace kolem vlastní osy v hodinách.</summary>
        public int RotationPeriod { get; set; }

        /// <summary>Indikátor, zda má objekt atmosféru.</summary>
        public bool HasAtmosphere { get; set; }

        /// <summary>Indikátor, zda je objekt obyvatelný.</summary>
        public bool Habitable { get; set; }

        /// <summary>Věk objektu v milionech let.</summary>
        public int Age { get; set; } = 4600;

        */
        public int Id_Asteroid { get; set; }

        public int Id_Asteroid_Type { get; set; }

        public string Name { get; set; }  // Název mapy
        public int Width { get; set; }  // Velikost mapy
        public int Height { get; set; }  // Velikost mapy

        public AsteroidModel()
        {
        }
    }
}
