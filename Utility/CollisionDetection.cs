using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WoS;

namespace WoS.Utility
{
    public abstract class CollisionDetection : MovementBase
    {
        // Zde můžete přidat specifické vlastnosti a metody pro CollisionDetection

        // Konstruktor pro inicializaci pozice.
        public CollisionDetection(Vector2 position)
        {
            Position = position;
        }

        // Další metody a vlastnosti týkající se detekce kolize můžete přidat sem...
    }
}