

namespace WoS_Server
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using WoS_Server.DB_Model;
    using Microsoft.Xna.Framework;

    class Program
    {
        static void Main(string[] args)
        {
            /* // Nastavení poskytovatele služeb a DbContext
             var serviceProvider = new ServiceCollection()
             .AddDbContext<WoS_Db_Context>(options =>
                 options.UseInMemoryDatabase("WoSDatabase"))
             .BuildServiceProvider();

             */

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