using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;  // Pro použití Vector2

namespace WoS.Utility
{
    public abstract class AutomaticMovement : CollisionDetection
    {
        // Konstruktor, který přebírá pozici a deleguje ji na nadřazený konstruktor.
        public AutomaticMovement(Vector2 position) : base(position)
        {
            // Zde můžete inicializovat další vlastnosti a metody pro AutomaticMovement
        }

        // Další metody a vlastnosti týkající se automatického pohybu můžete přidat sem...
    }
}
