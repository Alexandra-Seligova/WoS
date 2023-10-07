using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.map
{
    public class MapAlpha : MapBase
    {
        // Konstruktor pro MapAlpha s předdefinovanými hodnotami
        public MapAlpha(Texture2D backgroundImage)
        : base(backgroundImage, 1920, 1080, "Alpha Map", "This is the description for the Alpha map.")
        {

            // Nastavení pozice mapy na (0,0)
            this.Position = new Vector2(0, 0);

            // Zde můžete přidat další konkrétní nastavení pro MapAlpha, pokud je potřebujete

        }

    }

}
