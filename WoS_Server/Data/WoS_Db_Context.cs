using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using WoS_Server.Models;
using WoS_Server.Models.ActiveObjects;
using WoS_Server.Models.MapObjects;

namespace WoS_Server.Data
{
    public class WoS_Db_Context : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserResources> Resources { get; set; }
        public DbSet<UserBoosters> Boosters { get; set; }
        public DbSet<ResearchModel> Researches { get; set; }//ok


        public DbSet<ShipModel> Ships { get; set; }
        public DbSet<DroneModel> Drones { get; set; }
        public DbSet<NpcModel> Npcs { get; set; }


        public DbSet<MapModel> Maps { get; set; }



        public DbSet<SunModel> Suns { get; set; }
        public DbSet<PlanetModel> Planets { get; set; }
        public DbSet<DwarfPlanetModel> DwarfPlanets { get; set; }
        public DbSet<CometModel> Comets { get; set; }
        public DbSet<AsteroidModel> Asteroids { get; set; }
        public DbSet<MeteoroidModel> Meteoroids { get; set; }
        public DbSet<BlackHoleModel> BlackHoles { get; set; }
        public DbSet<EnergyFieldModel> EnergyFields { get; set; }
        public DbSet<NebulaModel> Nebulas { get; set; }
        public DbSet<QuasarModel> Quasars { get; set; }
        public DbSet<AdditionalBuilding> AdditionalBuildings { get; set; }
        public DbSet<DefenseBuilding> DefenseBuildings { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<MiningBuilding> MiningBuildings { get; set; }
        public DbSet<SpaceStationModule> SpaceStationModules { get; set; }
        public DbSet<StorageBuilding> StorageBuildings { get; set; }
        public DbSet<BoxModel> Boxes { get; set; }
        public DbSet<AmmunitionModel> Ammunitions { get; set; }
        public DbSet<ArtifactModel> Artifacts { get; set; }
        public DbSet<RuinModel> Ruins { get; set; }
        public DbSet<SpaceGateModel> SpaceGates { get; set; }
        public DbSet<SpaceStationModel> SpaceStations { get; set; }
        /*
                #region User
                public DbSet<UserModel> Users { get; set; }
                public DbSet<UserResources> Resources { get; set; }
                public DbSet<UserBoosters> Boosters { get; set; }
                #endregion

                #region Map
                public DbSet<MapModel> Maps { get; set; }
                // neživé objekty mapy
                public DbSet<SunModel> Suns { get; set; }
                public DbSet<PlanetModel> Planets { get; set; }
                public DbSet<DwarfPlanetModel> DwarfPlanets { get; set; }
                public DbSet<CometModel> Comets { get; set; }
                public DbSet<AsteroidModel> Asteroids { get; set; }
                public DbSet<MeteoroidModel> Meteoroids { get; set; }
                public DbSet<BlackHoleModel> BlackHoles { get; set; }
                public DbSet<EnergyFieldModel> EnergyFields { get; set; }
                public DbSet<NebulaModel> Nebulas { get; set; }
                public DbSet<QuasarModel> Quasars { get; set; }

                // aktivní objekty mapy

                public DbSet<ShipModel> Ships { get; set; }
                public DbSet<Base_NpcsModel> Npcs { get; set; }
                public DbSet<DroneModel> Drons { get; set; }
                public DbSet<AmmunitionModel> Ammunitions { get; set; }
                public DbSet<BoxModel> Boxes { get; set; }

                public DbSet<SpaceStationModule> SpaceStations { get; set; }
                public DbSet<SpaceGateModel> SpaceGates { get; set; }
                public DbSet<RuinModel> Ruins { get; set; }
                public DbSet<ArtifactModel> Artifacts { get; set; }


                // Pasivní objekty mapy budovy

                #endregion

                public DbSet<ShipModel> Ships { get; set; } // Přidání DbSet pro lodě
                public DbSet<DroneModel> Drones { get; set; } // Přidání DbSet pro drony
                public DbSet<NpcModel> Npcs { get; set; } // Přidání DbSet pro NPC
                public DbSet<Contract> Contracts { get; set; } // Přidání DbSet pro kontrakty
                public DbSet<Research> Researches { get; set; } // Přidání DbSet pro výzkumy
        */


        #region Ship

        #endregion


        #region Npc

        #endregion

        #region Map

        #endregion


        public WoS_Db_Context(DbContextOptions<WoS_Db_Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            // Konfigurace modelu pro ResearchModel
            modelBuilder.Entity<ResearchModel>(entity =>
            {
                entity.HasKey(e => e.Id_Research);                                      // Nastavení primárního klíče pro tabulku ResearchModels
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);   // Název výzkumu je povinný a má maximální délku 255 znaků
                entity.Property(e => e.Id_Research_Type).IsRequired();                  // Typ výzkumu je povinný
                entity.Property(e => e.Research_level).IsRequired();                    // Úroveň výzkumu je povinná
            });
            // Konfigurace modelu pro UserModel
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Id_Global); // Primární klíč
                entity.Property(e => e.Id_User).IsRequired(); // ID uživatele
                entity.Property(e => e.Id_Type).IsRequired(); // Typ uživatele
                entity.Property(e => e.Id_Focus).HasMaxLength(255); // Fokus uživatele
                entity.Property(e => e.Status).IsRequired(); // Status uživatele
                entity.Property(e => e.IsLocked).IsRequired(); // Zamčení účtu
                entity.Property(e => e.Nickname).IsRequired().HasMaxLength(255); // Přezdívka
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255); // Hash hesla
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255); // Email
                entity.OwnsOne(e => e.Resources); // Zdroje uživatele
                entity.OwnsOne(e => e.Boosters); // Boostery uživatele
                entity.OwnsOne(e => e.Flags); // Flagy uživatele
            });

            // Konfigurace pro UserResources
            modelBuilder.Entity<UserResources>(entity =>
            {
                // Zde můžete přidat konfigurace pro UserResources
            });

            // Konfigurace pro UserBoosters
            modelBuilder.Entity<UserBoosters>(entity =>
            {
                // Zde můžete přidat konfigurace pro UserBoosters
            });

            // Konfigurace pro UserPermisions
            modelBuilder.Entity<UserPermisions>(entity =>
            {
                // Zde můžete přidat konfigurace pro UserPermisions
            });










            // Configuring the relationships between MapModel and its related entities
            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Suns)
                .WithOne()
                .HasForeignKey(s => s.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Planets)
                .WithOne()
                .HasForeignKey(p => p.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.DwarfPlanets)
                .WithOne()
                .HasForeignKey(dp => dp.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Comets)
                .WithOne()
                .HasForeignKey(c => c.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Asteroids)
                .WithOne()
                .HasForeignKey(a => a.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Meteoroids)
                .WithOne()
                .HasForeignKey(me => me.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.BlackHoles)
                .WithOne()
                .HasForeignKey(bh => bh.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.EnergyFields)
                .WithOne()
                .HasForeignKey(ef => ef.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Nebulas)
                .WithOne()
                .HasForeignKey(n => n.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Quasars)
                .WithOne()
                .HasForeignKey(q => q.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.AdditionalBuildings)
                .WithOne()
                .HasForeignKey(ab => ab.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.DefenseBuildings)
                .WithOne()
                .HasForeignKey(db => db.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Factories)
                .WithOne()
                .HasForeignKey(f => f.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.MiningBuildings)
                .WithOne()
                .HasForeignKey(mb => mb.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.SpaceStationModules)
                .WithOne()
                .HasForeignKey(ssm => ssm.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.StorageBuildings)
                .WithOne()
                .HasForeignKey(sb => sb.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Npcs)
                .WithOne()
                .HasForeignKey(npc => npc.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Ships)
                .WithOne()
                .HasForeignKey(s => s.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Drones)
                .WithOne()
                .HasForeignKey(d => d.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Boxes)
                .WithOne()
                .HasForeignKey(b => b.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Ammunitions)
                .WithOne()
                .HasForeignKey(am => am.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Artifacts)
                .WithOne()
                .HasForeignKey(ar => ar.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.Ruins)
                .WithOne()
                .HasForeignKey(r => r.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.SpaceGates)
                .WithOne()
                .HasForeignKey(sg => sg.MapModelId);

            modelBuilder.Entity<MapModel>()
                .HasMany(m => m.SpaceStations)
                .WithOne()
                .HasForeignKey(ss => ss.MapModelId);

            // Additional configurations for other entities can be added here
        }
    }
}
