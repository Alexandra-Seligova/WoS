using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoS.Utility;
using Microsoft.Xna.Framework;  // Potřebné pro Vector2 a další třídy
using System.Collections.Generic;  // Potřebné pro List<T>


namespace WoS.map.Planet
{
    public abstract class PlanetBase : OrbitalMovement
    {
        // Identifikační a referenční proměnné
        public int Id { get; set; }
        public int MapId { get; set; }
        public int TypeId { get; set; }
        public int OwnerId { get; set; }

        // Pozice a rozměry planety
        public Vector2 Position { get; set; }  // In MonoGame, Vector2 is commonly used for 2D instead of PVector
        public float Size { get; set; } = 200;
        public float PlanetSize { get; set; } = 400;
        // Ostatní atributy planety
        public int PlanetLevel { get; set; }
        public float PlanetHp { get; set; }
        public int[] PlanetPrice { get; set; } = { 0, 100, 200, 500, 2000, 10000 };
        public int[] MaxPlanetHp { get; set; } = { 0, 1000, 1200, 1500, 2000, 3000, 5000 };
        public int Timer { get; set; } = 0;

        // Seznam elementů planety (předpokládám, že PlanetaElement je jiná třída, kterou máte definovanou)
        public List<PlanetElement> PlanetElementList { get; set; }

        // Další atributy
        public bool AtPlanet { get; set; }
        public int MoonCount { get; set; } = 1;

        // Konstruktor třídy Planeta
        public PlanetBase(int id)
        {

        }

        // Metoda pro naplnění seznamu elementů (tuto metodu je třeba dále definovat)
        public void PopulateElementList()
        {
            // Implementation of method to populate the list of elements
        }

    }
}
