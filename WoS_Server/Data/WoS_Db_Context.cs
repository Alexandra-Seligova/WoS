using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using WoS_Server.DataModel;

namespace WoS_Server.Data
{
    public class WoS_Db_Context : DbContext
    {
        #region Map

        public DbSet<MapModel> Maps { get; set; }                      // Načtu z DB mapu a její nastavení
        // Id_User, Id_Server, Id_Map, Id_Map_Type, Name, Width, Height

        public DbSet<SunModel> Suns { get; set; }                      //
        // Base_StaticObjectModel => Id_User, Id_Map, Name, Width, Height, Diameter, SolarMassWeight, Gravity, OrbitalPeriod, RotationPeriod,HasAtmosphere,Habitable,Age
        //                           Id_Sun, Id_Sun_Type,
        public DbSet<PlanetModel> Planets { get; set; }                //
        // Base_StaticObjectModel => Id_Planet, Id_Planet_Type,
        public DbSet<DwarfPlanetModel> DwarfPlanets { get; set; }      //
        // Base_StaticObjectModel => Id_Planet, Id_Planet_Type,
        public DbSet<CometModel> Comets { get; set; }                  //
        // Base_StaticObjectModel => Id_Comet, Id_Comet_Type, CometTailLength

        public DbSet<AsteroidModel> Asteroids { get; set; }            //
        // Base_StaticObjectModel => Id_Planet, Id_Asteroid_Type,
        public DbSet<MeteoroidModel> Meteoroids { get; set; }          //
        // Base_StaticObjectModel => Id_Planet, Id_Meteoroid_Type,
        public DbSet<BlackHoleModel> BlackHoles { get; set; }          //
        // Base_StaticObjectModel => Id_Planet, Id_BlackHole_Type,
        public DbSet<EnergyFieldModel> EnergyFields { get; set; }      //
        // Base_StaticObjectModel => Id_Planet, Id_EnergyField_Type,
        public DbSet<NebulaModel> Nebulas { get; set; }                //
        // Base_StaticObjectModel => Id_Planet, Id_Planet_Type,
        public DbSet<QuasarModel> Quasars { get; set; }                //
        // Base_StaticObjectModel => Id_Planet, Id_Planet_Type,




        public DbSet<BoxModel> Boxes { get; set; }                     //
        // Id_Map, Id_Box, Position, Size, Type, Contents

        public DbSet<ArtifactModel> Artifacts { get; set; }            //

        public DbSet<SpaceBuildingModel> SpaceBuildings { get; set; }  //

        public DbSet<NpcsModel> Npcs { get; set; }                     //
                                                                       // DbSet pro modely lodí
        public DbSet<ShipModel> User_AutomaticShips { get; set; }       // transportéry mezi planetama, obranné stíhačky atd



        #endregion


        #region User

        // DbSety pro jednotlivé modely
        public DbSet<UserModel> Users { get; set; }
        // Sloupce: Id_User, Id_User_Type, Id_User_Focus, Status, IsLocked, Nickname, PasswordHash, Email,
        // Id_List_UserShips, Id_SelectedShip, Id_List_UserDrones, Id_List_SelectedDrones

        public DbSet<ResourcesModel> Resources { get; set; }
        // Sloupce: Id_User, XP, Honor, Credits, SpaceCoin, Metal, Crystals, Minerals, Deuterium, Antimatter, DarkMatter, Prom, Endu, Terb, Prom2, Endu2, Terb2, Xenomit, Palladium, Seprom, Osmium,
        // SpiceRed, SpiceYellow, SpiceBlue, SpicePurple, SpiceGreen, SpiceDark

        public DbSet<UserBoostersModel> Boosters { get; set; }
        // Sloupce: Id_User, Speed, Attack, Defense, Colonization, Construction, IndustrialProduction

        public DbSet<PermisionsModel> Permissions { get; set; }
        // Sloupce: Id_User, IsAdmin, IsPremium, IsBanned
        public DbSet<UserResearchModel> Research { get; set; }
        // Sloupce: Id_User, IsAdmin, IsPremium, IsBanned
        public DbSet<FleetModel> fleet { get; set; }
        // Sloupce: Id_User, IsAdmin, IsPremium, IsBanned

        #endregion



        #region Ship

        // DbSet pro modely lodí
        public DbSet<ShipModel> Ships { get; set; }
        // Sloupce: Id_User, Id_Fleet, Id_Fleet_Formation, Id_Fleet_FormationPosition, Id_Ship, Id_Ship_Type, Name, Level, Designation, StaticParametersModel, ActualParametersModel, Configurations

        public DbSet<AmmoModel> Ammunitions { get; set; }              //
        // Id_User, Id_Ammo, Id_Ammo_Type, StaticParametersModel() , ActualParametersModel(), AmmoConfigurations()

        public DbSet<ShipConfigurations> ShipConfigurations { get; set; }
        // Sloupce: Id_User, Id_Ship, Generators, Weapons, Extensions, Ammos, Animations

        public DbSet<ShipComponentModel> ShipComponents { get; set; }
        // Sloupce: Id_User, Id_Ship, Id_Ship_Component, Id_Ship_Component_Type, Name, Type, PositionOnShip

        public DbSet<StaticParameters> StaticParameters { get; set; }
        // Sloupce: Id_User, Id_Ship, Id_StaticParameters, Name, CanBeDestroyed, SpawnPlace, MaxHP, MaxArmor, MaxStructuralIntegrity, MaxShield, MaxShieldLeft, MaxShieldRight, MaxShieldFront, MaxShieldBack, MaxSpeed, MaxHealth, MaxAttackPower, Description

        public DbSet<ActualParametersModel> ActualParameters { get; set; }
        // Sloupce: Id_User, Id_Ship, Id_Ammo_ActualParameters, Id_Ammo_Target, Id_Ammo_TargetType, Position, PositionOnMap, TargetPosition, IsTarget, IsAutomaticTarget, Rotation, Velocity, Acceleration, HP, Armor, StructuralIntegrity, Shield, ShieldLeft, ShieldRight, ShieldFront, ShieldBack, Speed

        public DbSet<DroneModel> Drones { get; set; }

        #endregion









        public WoS_Db_Context(DbContextOptions<WoS_Db_Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User
            // Konfigurace pro UserModel
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Id_User);
                entity.Property(e => e.Id_User_Type).IsRequired();
                entity.Property(e => e.Id_User_OnMap).IsRequired();
                entity.Property(e => e.Id_User_Focus).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Id_SelectedFleetConfig).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.Nickname).HasMaxLength(255).IsRequired();
                entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(255).IsRequired();

                entity.HasOne(e => e.Resources).WithOne().HasForeignKey<ResourcesModel>(e => e.Id_User);
                entity.HasOne(e => e.Boosters).WithOne().HasForeignKey<UserBoostersModel>(e => e.Id_User);
                entity.HasOne(e => e.Permissions).WithOne().HasForeignKey<PermisionsModel>(e => e.Id_User);
                entity.HasOne(e => e.Research).WithOne().HasForeignKey<UserResearchModel>(e => e.Id_User);
                entity.HasOne(e => e.Fleet).WithOne().HasForeignKey<FleetModel>(e => e.Id_User);
                entity.HasOne(e => e.Ammo).WithOne().HasForeignKey<AmmoModel>(e => e.Id_User);
            });

            // Konfigurace pro ResourcesModel
            modelBuilder.Entity<ResourcesModel>(entity =>
            {
                entity.HasKey(e => e.Id_User);
                entity.Property(e => e.XP).IsRequired();
                entity.Property(e => e.Honor).IsRequired();
                entity.Property(e => e.Credits).IsRequired();
                entity.Property(e => e.SpaceCoin).IsRequired();
                entity.Property(e => e.Metal).IsRequired();
                entity.Property(e => e.Crystals).IsRequired();
                entity.Property(e => e.Minerals).IsRequired();
                entity.Property(e => e.Deuterium).IsRequired();
                entity.Property(e => e.Antimatter).IsRequired();
                entity.Property(e => e.DarkMatter).IsRequired();
                entity.Property(e => e.Prom).IsRequired();
                entity.Property(e => e.Endu).IsRequired();
                entity.Property(e => e.Terb).IsRequired();
                entity.Property(e => e.Prom2).IsRequired();
                entity.Property(e => e.Endu2).IsRequired();
                entity.Property(e => e.Terb2).IsRequired();
                entity.Property(e => e.Xenomit).IsRequired();
                entity.Property(e => e.Palladium).IsRequired();
                entity.Property(e => e.Seprum).IsRequired();
                entity.Property(e => e.Osmium).IsRequired();
                entity.Property(e => e.SpiceRed).IsRequired();
                entity.Property(e => e.SpiceYellow).IsRequired();
                entity.Property(e => e.SpiceBlue).IsRequired();
                entity.Property(e => e.SpicePurple).IsRequired();
                entity.Property(e => e.SpiceGreen).IsRequired();
                entity.Property(e => e.SpiceDark).IsRequired();
            });

            // Konfigurace pro UserBoostersModel
            modelBuilder.Entity<UserBoostersModel>(entity =>
            {
                entity.HasKey(e => e.Id_User);
                entity.Property(e => e.Speed).IsRequired();
                entity.Property(e => e.Attack).IsRequired();
                entity.Property(e => e.Defense).IsRequired();
                entity.Property(e => e.Colonization).IsRequired();
                entity.Property(e => e.Construction).IsRequired();
                entity.Property(e => e.IndustrialProduction).IsRequired();
            });

            // Konfigurace pro PermissionsModel
            modelBuilder.Entity<PermisionsModel>(entity =>
            {
                entity.HasKey(e => e.Id_User);
                entity.Property(e => e.IsAdmin).IsRequired();
                entity.Property(e => e.IsPremium).IsRequired();
                entity.Property(e => e.IsBanned).IsRequired();
            });

            // Konfigurace pro UserResearchModel
            modelBuilder.Entity<UserResearchModel>(entity =>
            {
                entity.HasKey(e => e.Id_User);
                entity.Property(e => e.ResearchType).IsRequired();
                entity.Property(e => e.Level).IsRequired();
            });

            // Konfigurace pro FleetModel
            modelBuilder.Entity<FleetModel>(entity =>
            {
                entity.HasKey(e => e.Id_User);
                entity.Property(e => e.Id_Ship).IsRequired();
                entity.Property(e => e.Id_Fleet).IsRequired();
                entity.Property(e => e.Id_Fleet_Formation).IsRequired();
                entity.Property(e => e.Id_Fleet_FormationPosition).IsRequired();
                entity.Property(e => e.Configurations).IsRequired();
            });

            // Konfigurace pro AmmoModel
            modelBuilder.Entity<AmmoModel>(entity =>
            {
                entity.HasKey(e => e.Id_User);
                entity.Property(e => e.AmmoType).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
            });
            #endregion User


            #region Ship

            // Konfigurace pro ShipModel
            modelBuilder.Entity<ShipModel>(entity =>
            {
                entity.HasKey(e => e.Id_Ship);
                entity.Property(e => e.Id_User).IsRequired();
                entity.Property(e => e.Id_Fleet).IsRequired();
                entity.Property(e => e.Id_Fleet_Formation).IsRequired();
                entity.Property(e => e.Id_Fleet_FormationPosition).IsRequired();
                entity.Property(e => e.Id_Ship_Type).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Level).IsRequired();
                entity.Property(e => e.Designation).HasDefaultValue("Ship");

                entity.HasOne(e => e.StaticParameters).WithOne().HasForeignKey<StaticParameters>(e => e.Id_Ship);
                entity.HasOne(e => e.ActualParameters).WithOne().HasForeignKey<ActualParametersModel>(e => e.Id_Ship);
                entity.HasOne(e => e.Configurations).WithOne().HasForeignKey<ShipConfigurations>(e => e.Id_Ship);
            });

            // Konfigurace pro ShipConfigurations
            modelBuilder.Entity<ShipConfigurations>(entity =>
            {
                entity.HasKey(e => e.Id_Ship);
                entity.Property(e => e.Id_User).IsRequired();
                entity.HasMany(e => e.Generators);
                entity.HasMany(e => e.Weapons);
                entity.HasMany(e => e.Extensions);
                entity.HasMany(e => e.Ammos);
                entity.HasMany(e => e.Animations);
            });

            // Konfigurace pro ShipComponentModel
            modelBuilder.Entity<ShipComponentModel>(entity =>
            {
                entity.HasKey(e => e.Id_Ship_Component);
                entity.Property(e => e.Id_User).IsRequired();
                entity.Property(e => e.Id_Ship).IsRequired();
                entity.Property(e => e.Id_Ship_Component_Type).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.PositionOnShip).IsRequired();
            });

            // Konfigurace pro StaticParametersModel
            modelBuilder.Entity<StaticParameters>(entity =>
            {
                entity.HasKey(e => e.Id_Ship);
                entity.Property(e => e.Id_User).IsRequired();
                entity.Property(e => e.Id_StaticParameters).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.CanBeDestroyed).HasDefaultValue(true);
                entity.Property(e => e.SpawnPlace).IsRequired();
                entity.Property(e => e.MaxHP).IsRequired();
                entity.Property(e => e.MaxArmor).IsRequired();
                entity.Property(e => e.MaxStructuralIntegrity).IsRequired();
                entity.Property(e => e.MaxShield).IsRequired();
                entity.Property(e => e.MaxShieldLeft).IsRequired();
                entity.Property(e => e.MaxShieldRight).IsRequired();
                entity.Property(e => e.MaxShieldFront).IsRequired();
                entity.Property(e => e.MaxShieldBack).IsRequired();
                entity.Property(e => e.MaxSpeed).IsRequired();
                entity.Property(e => e.MaxHealth).IsRequired();
                entity.Property(e => e.MaxAttackPower).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });

            // Konfigurace pro ActualParametersModel
            modelBuilder.Entity<ActualParametersModel>(entity =>
            {
                entity.HasKey(e => e.Id_Ship);
                entity.Property(e => e.Id_User).IsRequired();
                entity.Property(e => e.Id_Ammo_ActualParameters).IsRequired();
                entity.Property(e => e.Id_Ammo_Target).IsRequired();
                entity.Property(e => e.Id_Ammo_TargetType).IsRequired();
                entity.Property(e => e.Position).IsRequired();
                entity.Property(e => e.PositionOnMap).IsRequired();
                entity.Property(e => e.TargetPosition).IsRequired();
                entity.Property(e => e.IsTarget).IsRequired();
                entity.Property(e => e.IsAutomaticTarget).IsRequired();
                entity.Property(e => e.Rotation).IsRequired();
                entity.Property(e => e.Velocity).IsRequired();
                entity.Property(e => e.Acceleration).IsRequired();
                entity.Property(e => e.HP).IsRequired();
                entity.Property(e => e.Armor).IsRequired();
                entity.Property(e => e.StructuralIntegrity).IsRequired();
                entity.Property(e => e.Shield).IsRequired();
                entity.Property(e => e.ShieldLeft).IsRequired();
                entity.Property(e => e.ShieldRight).IsRequired();
                entity.Property(e => e.ShieldFront).IsRequired();
                entity.Property(e => e.ShieldBack).IsRequired();
                entity.Property(e => e.Speed).IsRequired();
            });

            #endregion
        }



        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            // Konfigurace modelu pro UserResearchModel
            modelBuilder.Entity<UserResearchModel>(entity =>
            {
                entity.HasKey(e => e.Id_Research);                                      // Nastavení primárního klíče pro tabulku ResearchModels
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);   // Název výzkumu je povinný a má maximální délku 255 znaků
                entity.Property(e => e.Id_Research_Type).IsRequired();                  // Typ výzkumu je povinný
                entity.Property(e => e.Research_level).IsRequired();                    // Úroveň výzkumu je povinná
            });
            /*
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
        }*/
    }
}
