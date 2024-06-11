namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using WoS_Server.Models;

    public class Replicator : Base_NpcsModel
    {
        public ReplicatorType ReplicatorType { get; set; }
        public float LevelMultiplier { get; set; } // Koeficient násobku levelu

        public Replicator(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, ReplicatorType replicatorType, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            ReplicatorType = replicatorType;
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

            // Apply specific bonuses based on replicatorType
            ApplyTypeSpecificBonuses(replicatorType);
        }

        private void ApplyTypeSpecificBonuses(ReplicatorType replicatorType)
        {
            switch(replicatorType)
            {
                case ReplicatorType.Ship:
                ActualCostResource[ResourceType.Metal] += 2000;
                ActualCostResource[ResourceType.Crystals] += 1000;
                ActualCostResource[ResourceType.Deuterium] += 300;
                ActualCostResource[ResourceType.XP] += 40;
                ActualCostResource[ResourceType.Honor] += 20;
                ActualCostResource[ResourceType.Credits] += 60;
                ActualCostResource[ResourceType.SpaceCoin] += 3;
                break;

                case ReplicatorType.AdvancedShip:
                ActualCostResource[ResourceType.Metal] += 4000;
                ActualCostResource[ResourceType.Crystals] += 2000;
                ActualCostResource[ResourceType.Deuterium] += 700;
                ActualCostResource[ResourceType.XP] += 80;
                ActualCostResource[ResourceType.Honor] += 40;
                ActualCostResource[ResourceType.Credits] += 120;
                ActualCostResource[ResourceType.SpaceCoin] += 6;
                break;
            }
        }
    }

    public class ReplicatorShip : Replicator
    {
        public ReplicatorShip(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, ReplicatorType.Ship, levelMultiplier)
        {
        }
    }

    public class ReplicatorAdvancedShip : Replicator
    {
        public ReplicatorAdvancedShip(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, ReplicatorType.AdvancedShip, levelMultiplier)
        {
        }
    }
}
