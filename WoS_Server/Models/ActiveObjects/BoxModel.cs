namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class BoxModel : Base_Module
    {
        public int Id { get; set; } // Unikátní identifikátor boxu

        // Pozice
        public Vector2 Position { get; set; } = new Vector2(0, 0); // Pozice boxu
        public Vector2 Velocity { get; set; } = new Vector2(0, 0); // Rychlost boxu

        // Vlastnosti boxu
        public float Size { get; set; } = 5; // Velikost boxu
        public BoxType Type { get; set; } // Typ boxu
        public Dictionary<ResourceType, int> Contents { get; set; } // Obsah boxu
        public int UserId { get; set; } // ID uživatele, který box vytvořil

        public BoxModel(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, BoxType type)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            Type = type;
            Contents = new Dictionary<ResourceType, int>();
        }
    }

    public enum BoxType
    {
        Basic,         // Základní
        Rare,          // Vzácný
        Epic,          // Epický
        Legendary,     // Legendární
        Event          // Událostní
    }

}
