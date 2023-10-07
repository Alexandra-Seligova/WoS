using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoS.Utility;  // Přidáno pro přístup k třídě AutomaticMovement
using Microsoft.Xna.Framework;  // Pro použití Vector2
namespace WoS.npc
{
    public class NpcBase : AutomaticMovement
    {
        // Základní konstruktor, který deleguje na nadřazený konstruktor.
        // Pokud AutomaticMovement vyžaduje konstruktor s parametry, měli bychom je přidat zde.
        public NpcBase(Vector2 position) : base(position)
        {
            // Zde můžete inicializovat vlastnosti specifické pro NpcBase
        }

        // Další metody a vlastnosti týkající se NpcBase můžete přidat sem...
    }
}