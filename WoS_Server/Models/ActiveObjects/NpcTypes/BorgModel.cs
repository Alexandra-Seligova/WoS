namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using WoS_Server.Models;

    public class Borg : Base_NpcsModel
    {
        public BorgType BorgType { get; set; }
        public float LevelMultiplier { get; set; } // Koeficient násobku levelu

        public Borg(int idGlobal, Vector3 spawnPlace, int width, int height, int depth, BorgType borgType, float levelMultiplier)
            : base(idGlobal, spawnPlace, width, height, depth)
        {
            BorgType = borgType;

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

            // Apply specific bonuses based on borgType
            ApplyTypeSpecificBonuses(borgType);
        }

        private void ApplyTypeSpecificBonuses(BorgType borgType)
        {
            switch(borgType)
            {
                case BorgType.Cube:
                ActualCostResource[ResourceType.Metal] += 4000;
                ActualCostResource[ResourceType.Crystals] += 2500;
                ActualCostResource[ResourceType.Deuterium] += 800;
                ActualCostResource[ResourceType.XP] += 90;
                ActualCostResource[ResourceType.Honor] += 45;
                ActualCostResource[ResourceType.Credits] += 180;
                ActualCostResource[ResourceType.SpaceCoin] += 9;
                break;

                case BorgType.Sphere:
                ActualCostResource[ResourceType.Metal] += 2000;
                ActualCostResource[ResourceType.Crystals] += 1500;
                ActualCostResource[ResourceType.Deuterium] += 500;
                ActualCostResource[ResourceType.XP] += 60;
                ActualCostResource[ResourceType.Honor] += 25;
                ActualCostResource[ResourceType.Credits] += 130;
                ActualCostResource[ResourceType.SpaceCoin] += 6;
                break;

                case BorgType.Scout:
                ActualCostResource[ResourceType.Metal] += 0;
                ActualCostResource[ResourceType.Crystals] += 0;
                ActualCostResource[ResourceType.Deuterium] += 0;
                ActualCostResource[ResourceType.XP] += 20;
                ActualCostResource[ResourceType.Honor] += 5;
                ActualCostResource[ResourceType.Credits] += 30;
                ActualCostResource[ResourceType.SpaceCoin] += 2;
                break;

                case BorgType.Diamond:
                ActualCostResource[ResourceType.Metal] += 6000;
                ActualCostResource[ResourceType.Crystals] += 4500;
                ActualCostResource[ResourceType.Deuterium] += 1800;
                ActualCostResource[ResourceType.XP] += 140;
                ActualCostResource[ResourceType.Honor] += 65;
                ActualCostResource[ResourceType.Credits] += 280;
                ActualCostResource[ResourceType.SpaceCoin] += 14;
                break;
            }
        }
    }

    public class BorgCube : Borg
    {


        public BorgCube(int idGlobal, Vector3 spawnPlace)
            : base(idGlobal, spawnPlace, 100, 100, 100, BorgType.Cube, (float)0.2)
        {




        }
    }
    /*
    public class BorgSphere : Borg
    {
        public BorgSphere(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BorgType.Sphere, levelMultiplier)
        {
        }
    }

    public class BorgScout : Borg
    {
        public BorgScout(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BorgType.Scout, levelMultiplier)
        {
        }
    }

    public class BorgDiamond : Borg
    {
        public BorgDiamond(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, BorgType.Diamond, levelMultiplier)
        {
        }
    }*/
}