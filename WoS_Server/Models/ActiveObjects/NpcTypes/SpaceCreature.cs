namespace WoS_Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using WoS_Server.Models;

    public class SpaceCreature : Base_NpcsModel
    {
        public SpaceCreatureType SpaceCreatureType { get; set; }
        public float LevelMultiplier { get; set; } // Koeficient násobku levelu

        public SpaceCreature(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, SpaceCreatureType spaceCreatureType, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            SpaceCreatureType = spaceCreatureType;
            LevelMultiplier = levelMultiplier;

            // Initialize ActualCostResource with base values
            ActualCostResource = new Dictionary<ResourceType, int>
            {
                { ResourceType.Metal, (int)(500 * levelMultiplier) },
                { ResourceType.Crystals, (int)(300 * levelMultiplier) },
                { ResourceType.Deuterium, (int)(100 * levelMultiplier) },
                { ResourceType.XP, (int)(20 * levelMultiplier) },
                { ResourceType.Honor, (int)(10 * levelMultiplier) },
                { ResourceType.Credits, (int)(40 * levelMultiplier) },
                { ResourceType.SpaceCoin, (int)(2 * levelMultiplier) }
            };

            // Apply specific bonuses based on spaceCreatureType
            ApplyTypeSpecificBonuses(spaceCreatureType);
        }

        private void ApplyTypeSpecificBonuses(SpaceCreatureType spaceCreatureType)
        {
            switch(spaceCreatureType)
            {
                case SpaceCreatureType.Lordakia:
                ActualCostResource[ResourceType.Metal] += 100;
                ActualCostResource[ResourceType.Crystals] += 50;
                ActualCostResource[ResourceType.Deuterium] += 20;
                ActualCostResource[ResourceType.XP] += 10;
                ActualCostResource[ResourceType.Honor] += 5;
                ActualCostResource[ResourceType.Credits] += 20;
                ActualCostResource[ResourceType.SpaceCoin] += 1;
                break;

                case SpaceCreatureType.Saimon:
                ActualCostResource[ResourceType.Metal] += 200;
                ActualCostResource[ResourceType.Crystals] += 100;
                ActualCostResource[ResourceType.Deuterium] += 40;
                ActualCostResource[ResourceType.XP] += 20;
                ActualCostResource[ResourceType.Honor] += 10;
                ActualCostResource[ResourceType.Credits] += 40;
                ActualCostResource[ResourceType.SpaceCoin] += 2;
                break;

                case SpaceCreatureType.Mordon:
                ActualCostResource[ResourceType.Metal] += 300;
                ActualCostResource[ResourceType.Crystals] += 150;
                ActualCostResource[ResourceType.Deuterium] += 60;
                ActualCostResource[ResourceType.XP] += 30;
                ActualCostResource[ResourceType.Honor] += 15;
                ActualCostResource[ResourceType.Credits] += 60;
                ActualCostResource[ResourceType.SpaceCoin] += 3;
                break;

                case SpaceCreatureType.Devolarium:
                ActualCostResource[ResourceType.Metal] += 400;
                ActualCostResource[ResourceType.Crystals] += 200;
                ActualCostResource[ResourceType.Deuterium] += 80;
                ActualCostResource[ResourceType.XP] += 40;
                ActualCostResource[ResourceType.Honor] += 20;
                ActualCostResource[ResourceType.Credits] += 80;
                ActualCostResource[ResourceType.SpaceCoin] += 4;
                break;

                case SpaceCreatureType.Sibelon:
                ActualCostResource[ResourceType.Metal] += 500;
                ActualCostResource[ResourceType.Crystals] += 250;
                ActualCostResource[ResourceType.Deuterium] += 100;
                ActualCostResource[ResourceType.XP] += 50;
                ActualCostResource[ResourceType.Honor] += 25;
                ActualCostResource[ResourceType.Credits] += 100;
                ActualCostResource[ResourceType.SpaceCoin] += 5;
                break;

                case SpaceCreatureType.Sibelonit:
                ActualCostResource[ResourceType.Metal] += 600;
                ActualCostResource[ResourceType.Crystals] += 300;
                ActualCostResource[ResourceType.Deuterium] += 120;
                ActualCostResource[ResourceType.XP] += 60;
                ActualCostResource[ResourceType.Honor] += 30;
                ActualCostResource[ResourceType.Credits] += 120;
                ActualCostResource[ResourceType.SpaceCoin] += 6;
                break;

                case SpaceCreatureType.Lordakium:
                ActualCostResource[ResourceType.Metal] += 700;
                ActualCostResource[ResourceType.Crystals] += 350;
                ActualCostResource[ResourceType.Deuterium] += 140;
                ActualCostResource[ResourceType.XP] += 70;
                ActualCostResource[ResourceType.Honor] += 35;
                ActualCostResource[ResourceType.Credits] += 140;
                ActualCostResource[ResourceType.SpaceCoin] += 7;
                break;

                case SpaceCreatureType.Kristallin:
                ActualCostResource[ResourceType.Metal] += 800;
                ActualCostResource[ResourceType.Crystals] += 400;
                ActualCostResource[ResourceType.Deuterium] += 160;
                ActualCostResource[ResourceType.XP] += 80;
                ActualCostResource[ResourceType.Honor] += 40;
                ActualCostResource[ResourceType.Credits] += 160;
                ActualCostResource[ResourceType.SpaceCoin] += 8;
                break;

                case SpaceCreatureType.Kristallon:
                ActualCostResource[ResourceType.Metal] += 1000;
                ActualCostResource[ResourceType.Crystals] += 500;
                ActualCostResource[ResourceType.Deuterium] += 200;
                ActualCostResource[ResourceType.XP] += 100;
                ActualCostResource[ResourceType.Honor] += 50;
                ActualCostResource[ResourceType.Credits] += 200;
                ActualCostResource[ResourceType.SpaceCoin] += 10;
                break;
            }
        }
    }

    public class Lordakia : SpaceCreature
    {
        public Lordakia(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Lordakia, levelMultiplier)
        {
        }
    }

    public class Saimon : SpaceCreature
    {
        public Saimon(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Saimon, levelMultiplier)
        {
        }
    }

    public class Mordon : SpaceCreature
    {
        public Mordon(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Mordon, levelMultiplier)
        {
        }
    }

    public class Devolarium : SpaceCreature
    {
        public Devolarium(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Devolarium, levelMultiplier)
        {
        }
    }

    public class Sibelon : SpaceCreature
    {
        public Sibelon(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Sibelon, levelMultiplier)
        {
        }
    }

    public class Sibelonit : SpaceCreature
    {
        public Sibelonit(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Sibelonit, levelMultiplier)
        {
        }
    }

    public class Lordakium : SpaceCreature
    {
        public Lordakium(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Lordakium, levelMultiplier)
        {
        }
    }

    public class Kristallin : SpaceCreature
    {
        public Kristallin(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Kristallin, levelMultiplier)
        {
        }
    }

    public class Kristallon : SpaceCreature
    {
        public Kristallon(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth, float levelMultiplier)
            : base(idGlobal, idUser, spawnPlace, width, height, depth, SpaceCreatureType.Kristallon, levelMultiplier)
        {
        }
    }

}
