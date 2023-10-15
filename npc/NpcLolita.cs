
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoS.npc;  // Přidáno pro přístup k třídě NpcBase (pokud je v jiném souboru v tomto namespace)

using Microsoft.Xna.Framework;  // Pro použití Vector2

namespace WoS.npc
{
    public class NpcLolita : NpcBase
    {
        // Základní konstruktor, který deleguje na nadřazený konstruktor.
        // Pokud NpcBase vyžaduje konstruktor s parametry, měli bychom je přidat zde.
        public NpcLolita(Vector2 position, int id) : base(position)
        {
            // Zde můžete inicializovat vlastnosti specifické pro NpcStreuner
        }

        // Další metody a vlastnosti týkající se NpcStreuner můžete přidat sem...
    }
}
