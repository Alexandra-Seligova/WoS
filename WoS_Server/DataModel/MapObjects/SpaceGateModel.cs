namespace WoS_Server.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;

    public class SpaceGateModel : Base_Building
    {
        public SpaceGateType SpaceGateModuleType { get; set; }

        public SpaceGateModel()
            : base()
        {
        }
    }


    public enum SpaceGateType
    {
        Alpha, // Alfa modul
        Beta, // Beta modul
        Gamma, // Gama modul
        Delta // Delta modul
    }
}
