namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Reprezentuje model lodi, který dědí základní vlastnosti z Base_Module.
    /// </summary>
    public class ShipModel
    {

        public int Id_Ship { get; set; } // Unikátní identifikátor lodi


        // Základní vlastnosti lod
        public float Acceleration { get; set; } = 50;


        // Vlastnosti zdraví a štítu


        // Stav lodi
        public bool IsTransforming { get; set; } = false;
        public int Seq { get; set; }
        public bool WillTransform { get; set; } = false;
        public bool IsTransformed { get; set; } = false;
        public bool EndTransform { get; set; } = true;
        public bool IsCollected { get; set; } = false;

        // Počet modulů
        public int GeneratorsCount { get; set; } = 1;
        public int WeaponsCount { get; set; } = 1;
        public int ExtensionsCount { get; set; } = 1;
        public int AmmosCount { get; set; } = 1;
        public int AnimationsCount { get; set; } = 1;

        // Stavová proměnná a zpráva
        public bool FirstRun { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public ShipModel()
    : base()
        {

        }
    }
}
