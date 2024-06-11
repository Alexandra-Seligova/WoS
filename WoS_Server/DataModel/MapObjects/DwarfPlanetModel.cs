namespace WoS_Server.DataModel
{
    using Microsoft.Xna.Framework;


    // Model pro Trpasličí Planety
    public class DwarfPlanetModel : Base_StaticObjectModel
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
        public int Id_DwarfPlanet { get; set; }

        public int Id_DwarfPlanet_Type { get; set; }

        public string Name { get; set; }  // Název mapy
        public int Width { get; set; }  // Velikost mapy
        public int Height { get; set; }  // Velikost mapy

        public DwarfPlanetModel()
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