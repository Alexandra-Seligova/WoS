

namespace WoS_Server
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using WoS_Server.DataModel;
    using WoS_Server.Data;
    using Microsoft.Xna.Framework;

    class Program
    {
        static void Main(string[] args)
        {
            // Nastavení poskytovatele služeb a DbContext
            var serviceProvider = new ServiceCollection()
            .AddDbContext<WoS_Db_Context>(options =>
                options.UseInMemoryDatabase("WoSDatabase"))
            .BuildServiceProvider();

            // Vytvoření dvou uživatelů
            CreateUser(serviceProvider, 1, "PlayerOne", "hashed_password1", "playerone@example.com");
            CreateUser(serviceProvider, 2, "PlayerTwo", "hashed_password2", "playertwo@example.com");

            // Vytvoření NPC
            CreateNpc(serviceProvider, 1, "Trader", new Vector3(100, 100, 0), 200, 200);



        }

        public static void CreateUser(IServiceProvider serviceProvider, int id, string nickname, string passwordHash, string email)
        {
            // Získání instance DbContext
            using(var context = serviceProvider.GetService<WoS_Db_Context>())
            {
                // Vytvoření nové instance lodě
                var newShip = new ShipModel
                {

                    Type = "Battle",
                    Designation = "Ship",
                    Position = new Vector3(0, 0,0),
                    Velocity = new Vector2(0, 0),

                    Acceleration = 50,

                    Width = 100,
                    Height = 100,
                  /*  HP = 100,
                    MaxHP = 100,
                    Armor = 100,
                    MaxArmor = 100,
                    StructuralIntegrity = 100,
                    MaxStructuralIntegrity = 100,
                    Shield = 100,
                    MaxShield = 100,*/
                    IsTransforming = false,
                    Seq = 0,
                    WillTransform = false,
                    IsTransformed = false,
                    EndTransform = true,
                    IsCollected = false,
                    GeneratorsCount = 1,
                    WeaponsCount = 1,
                    ExtensionsCount = 1,
                    AmmosCount = 1,
                    AnimationsCount = 1,
                    FirstRun = true,
                    Message = string.Empty
                };

                // Vytvoření nové instance dronu
                var newDrone = new DroneModel
                {
                    Id = id + 1000, // Použití unikátního ID pro dron
                    Name = "DroneOne",
                //    Type = "Battle",
                    Speed = 100,
                    Armor = 50,
                    WeaponPower = 20
                };

                // Vytvoření nové instance uživatele
                var newUser = new UserModel
                {
                    Id = id, // Použití poskytnutého ID
                    IsLocked = false,
                    Nickname = nickname,
                    PasswordHash = passwordHash,
                    Email = email,
                    Resources = new UserResources
                    {
                        Metal = 1000,
                        Crystals = 500,
                        Minerals = 300,
                        Deuterium = 200,
                        Antimatter = 50,
                        DarkMatter = 10,
                        Prom = 50,
                        Endu = 30,
                        Terb = 20,
                        Prom2 = 10,
                        Endu2 = 5,
                        Terb2 = 2,
                        Xenomit = 1,
                        Palladium = 0,
                        Seprom = 0,
                        Osmium = 0,
                        SpiceRed = 5,
                        SpiceYellow = 5,
                        SpiceBlue = 5,
                        SpicePurple = 5,
                        SpiceGreen = 5,
                        SpiceDark = 5
                    },
                    Id_Focus = "Warrior", // Možné hodnoty: "Warrior", "Explorer", "Builder", "Miner"
                    Boosters = new UserBoosters
                    {
                        Speed = false,
                        Attack = false,
                        Defense = false,
                        Colonization = false,
                        Construction = false,
                        IndustrialProduction = false
                    },
                    Name = nickname,

                    XP = 100,
                    Credits = 10000,
                    SpaceCoin = 500,
                    Honor = 50,
                };

                // Přidání lodě, dronu a uživatele do kontextu
                context.Ships.Add(newShip);
                context.Drones.Add(newDrone);
                context.Users.Add(newUser);

                // Uložení změn do databáze
                context.SaveChanges();
            }
        }


        public static void CreateNpc(IServiceProvider serviceProvider, int id, string npcType, Vector3 position, int width, int height)
        {
            // Získání instance DbContext
            using(var context = serviceProvider.GetService<WoS_Db_Context>())
            {
                // Vytvoření nové instance NPC
                var newNpc = new NpcsModel
                {
                    Id = id,
                    NpcType = npcType,
                    Position = VectorExtensions.ToVector2( position),
                    PositionOnMap = VectorExtensions.ToVector2( position),
                    PositionOnScreen = VectorExtensions.ToVector2( position),
                    Rotation = 0,
                    Width = width,
                    Height = height,
                    Hp = 100,
                    HpMax = 100,
                    Shield = 50,
                    ShieldMax = 50,
                    Velocity = new Vector2(0, 0),
                    Speed = 10,
                    Acceleration = 50,
                    MaxSpeed = 20,
                    NpcWidth = width,
                    NpcHeight = height,
                    TargetPosition = VectorExtensions.ToVector2(position),
                    SpawnPlace = VectorExtensions.ToVector2( position)
                };

                // Přidání NPC do kontextu
                context.Npcs.Add(newNpc);

                // Uložení změn do databáze
                context.SaveChanges();
            }


        }


    }
    public static class VectorExtensions
    {
        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.X, vector3.Y);
        }
    }
}


/*
Tabulka aplikace vylepšení a aktuálních prvků:
Vylepšení / Aktuální Prvky  DataModel   DatamodelInsert DataModelMiddle Konečné Modely (herní logika)
Použití rozhraní (Interfaces)   Navrženo    Navrženo    Navrženo    Navrženo
Závislostí (Dependency Injection)   Navrženo    Navrženo    Navrženo    Navrženo
Oddělení logiky do samostatných služeb  Ne  Ne  Navrženo    Navrženo
DTOs (Data Transfer Objects) a AutoMapper   Ne  Ne  Navrženo    Navrženo
Unit a Integration Testy    Navrženo    Navrženo    Navrženo    Navrženo
Implementace CQRS a MediatR Ne  Ne  Navrženo    Navrženo
Entity Framework    Aktuálně implementováno Aktuálně implementováno Aktuálně implementováno Aktuálně implementováno
Property reprezentující tabulky Ano Ano Ano Ano
Konstruktor pro inicializaci objektů    Ano Ano Ano Ano
Metody pro CRUD operace Ano Ano Ano Ano
Modely herní logiky Ne  Ne  Částečně    Ano
Validace dat    Částečně    Částečně    Navrženo    Navrženo
Vysvětlení tabulky:
Entity Framework: Aktuálně implementováno na všech úrovních pro přístup k databázi.
Property reprezentující tabulky: Definované vlastnosti pro tabulky jsou přítomny ve všech úrovních modelu.
Konstruktor pro inicializaci objektů: Konstruktor pro inicializaci objektů je přítomen na všech úrovních modelu.
Metody pro CRUD operace: Metody pro Create, Read, Update, Delete jsou přítomny na všech úrovních modelu.
Modely herní logiky: Herní logika je aktuálně implementována hlavně v konečných modelech.
Validace dat: Validace dat je částečně implementována na nižších úrovních a je navrženo pro vyšší úrovně.
*/