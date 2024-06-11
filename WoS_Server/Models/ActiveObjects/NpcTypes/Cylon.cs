namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using WoS_Server.Models;

    public class Cylon : Base_NpcsModel
    {
        public CylonType CylonType { get; set; }
        public float LevelMultiplier { get; set; } // Koeficient násobku levelu

        public Cylon(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, CylonType cylonType, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            CylonType = cylonType;
            LevelMultiplier = levelMultiplier;

            // Initialize ActualCostResource with base values
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, (int)(1000 * levelMultiplier) },
                { ResourceType.Crystals, (int)(500 * levelMultiplier) },
                { ResourceType.Deuterium, (int)(200 * levelMultiplier) },
                { ResourceType.XP, (int)(10 * levelMultiplier) },
                { ResourceType.Honor, (int)(5 * levelMultiplier) },
                { ResourceType.Credits, (int)(20 * levelMultiplier) },
                { ResourceType.SpaceCoin, (int)(1 * levelMultiplier) }
            };

            // Apply specific bonuses based on cylonType
            ApplyTypeSpecificBonuses(cylonType);
        }

        private void ApplyTypeSpecificBonuses(CylonType cylonType)
        {
            switch(cylonType)
            {
                case CylonType.Raider:
                ActualCostResource[ResourceType.Metal] += 2000;
                ActualCostResource[ResourceType.Crystals] += 1000;
                ActualCostResource[ResourceType.Deuterium] += 300;
                ActualCostResource[ResourceType.XP] += 40;
                ActualCostResource[ResourceType.Honor] += 20;
                ActualCostResource[ResourceType.Credits] += 60;
                ActualCostResource[ResourceType.SpaceCoin] += 3;
                break;

                case CylonType.HeavyRaider:
                ActualCostResource[ResourceType.Metal] += 4000;
                ActualCostResource[ResourceType.Crystals] += 2000;
                ActualCostResource[ResourceType.Deuterium] += 700;
                ActualCostResource[ResourceType.XP] += 80;
                ActualCostResource[ResourceType.Honor] += 40;
                ActualCostResource[ResourceType.Credits] += 120;
                ActualCostResource[ResourceType.SpaceCoin] += 6;
                break;

                case CylonType.Basestar:
                ActualCostResource[ResourceType.Metal] += 8000;
                ActualCostResource[ResourceType.Crystals] += 5000;
                ActualCostResource[ResourceType.Deuterium] += 2000;
                ActualCostResource[ResourceType.XP] += 150;
                ActualCostResource[ResourceType.Honor] += 70;
                ActualCostResource[ResourceType.Credits] += 300;
                ActualCostResource[ResourceType.SpaceCoin] += 15;
                break;

                case CylonType.ResurrectionShip:
                ActualCostResource[ResourceType.Metal] += 6000;
                ActualCostResource[ResourceType.Crystals] += 3000;
                ActualCostResource[ResourceType.Deuterium] += 1000;
                ActualCostResource[ResourceType.XP] += 100;
                ActualCostResource[ResourceType.Honor] += 50;
                ActualCostResource[ResourceType.Credits] += 180;
                ActualCostResource[ResourceType.SpaceCoin] += 10;
                break;
            }
        }
    }

    public class Raider : Cylon
    {
        public Raider(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, CylonType.Raider, levelMultiplier)
        {
        }
    }

    public class HeavyRaider : Cylon
    {
        public HeavyRaider(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, CylonType.HeavyRaider, levelMultiplier)
        {
        }
    }

    public class Basestar : Cylon
    {
        public Basestar(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, CylonType.Basestar, levelMultiplier)
        {
        }
    }

    public class ResurrectionShip : Cylon
    {
        public ResurrectionShip(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, CylonType.ResurrectionShip, levelMultiplier)
        {
        }
    }
}