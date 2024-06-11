namespace WoS_Server.Models.ActiveObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using WoS_Server.Models;

    public class SpaceGateModel : Base_Building
    {
        public SpaceGateType SpaceGateModuleType { get; set; }

        public SpaceGateModel(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, SpaceGateType spaceStationModuleType)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            SpaceGateModuleType = spaceStationModuleType;
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
