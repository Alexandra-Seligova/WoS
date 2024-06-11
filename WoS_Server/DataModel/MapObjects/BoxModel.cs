namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;


    public class BoxModel
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

        public BoxModel()

        {
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
