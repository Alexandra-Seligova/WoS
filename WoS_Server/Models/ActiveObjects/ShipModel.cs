namespace WoS_Server.Models
{

    using Microsoft.Xna.Framework;
    using WoS_Server.Models.ActiveObjects;

    /// <summary>
    /// Reprezentuje model lodi, který dědí základní vlastnosti z Base_Module.
    /// </summary>
    public class ShipModel : Base_Module
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

        public ShipModel(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, ArtifactType artifactType)
    : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {

        }
    }
}

