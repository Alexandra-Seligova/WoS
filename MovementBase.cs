using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WoS
{
    public abstract class MovementBase : ElementBase
    {
        // Název či označení lodi
        public string Designation { get; set; }

        // Rotace lodi v prostoru
        public float Rotation { get; set; }

        // Fyzikální parametry lodi
        public Vector2 Velocity { get; set; }          // Aktuální rychlost lodi
        public float Acceleration { get; set; } = 50;  // Zrychlení lodi
        public int MaxSpeed { get; set; }              // Maximální rychlost lodi

        // Velikost lodi
        public float ShipWidth { get; set; }           // Šířka lodi
        public float ShipHeight { get; set; }          // Výška lodi

        // Zdraví a štíty lodi
        public float Health { get; set; }              // Aktuální zdraví lodi
        public float MaxHealth { get; set; }           // Maximální zdraví lodi
        public float Shield { get; set; }              // Aktuální hodnota štítu lodi
        public float MaxShield { get; set; }           // Maximální hodnota štítu lodi

        // Cíl lodi pro pohyb
        public Vector2 Target { get; set; }

        // Místo, kde se loď objevila
        public Vector2 SpawnPlace { get; set; }

        // Další vlastnosti a metody mohou být přidány podle potřeby
    }
}
