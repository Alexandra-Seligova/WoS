


namespace WoS_Server.Models
{
    using Microsoft.Xna.Framework;
    using WoS_Server.Models.ActiveObjects;
    using WoS_Server.Models.MapObjects;

    public class MapModel : Base_Module
    {
        public int Id { get; set; }  // Unikátní identifikátor mapy
        public string Name { get; set; }  // Název mapy
        public Vector2 Size { get; set; }  // Velikost mapy

        // Navigační vlastnosti pro vztahy 1:N
        public ICollection<SunModel> Suns { get; set; }
        public ICollection<PlanetModel> Planets { get; set; }
        public ICollection<DwarfPlanetModel> DwarfPlanets { get; set; }
        public ICollection<CometModel> Comets { get; set; }
        public ICollection<AsteroidModel> Asteroids { get; set; }
        public ICollection<MeteoroidModel> Meteoroids { get; set; }
        public ICollection<BlackHoleModel> BlackHoles { get; set; }
        public ICollection<EnergyFieldModel> EnergyFields { get; set; }
        public ICollection<NebulaModel> Nebulas { get; set; }
        public ICollection<QuasarModel> Quasars { get; set; }

        public ICollection<AdditionalBuilding> AdditionalBuildings { get; set; }
        public ICollection<DefenseBuilding> DefenseBuildings { get; set; }
        public ICollection<Factory> Factories { get; set; }
        public ICollection<MiningBuilding> MiningBuildings { get; set; }
        public ICollection<SpaceStationModule> SpaceStationModules { get; set; }
        public ICollection<StorageBuilding> StorageBuildings { get; set; }

        public ICollection<NpcModel> Npcs { get; set; }

        public ICollection<ShipModel> Ships { get; set; }
        public ICollection<DroneModel> Drones { get; set; }
        public ICollection<BoxModel> Boxes { get; set; }
        public ICollection<AmmunitionModel> Ammunitions { get; set; }
        public ICollection<ArtifactModel> Artifacts { get; set; }
        public ICollection<RuinModel> Ruins { get; set; }
        public ICollection<SpaceGateModel> SpaceGates { get; set; }
        public ICollection<SpaceStationModel> SpaceStations { get; set; }

        // Konstruktor
        public MapModel()
        {
            Suns = new List<SunModel>();
            Planets = new List<PlanetModel>();
            DwarfPlanets = new List<DwarfPlanetModel>();
            Comets = new List<CometModel>();
            Asteroids = new List<AsteroidModel>();
            Meteoroids = new List<MeteoroidModel>();
            BlackHoles = new List<BlackHoleModel>();
            EnergyFields = new List<EnergyFieldModel>();
            Nebulas = new List<NebulaModel>();
            Quasars = new List<QuasarModel>();

            AdditionalBuildings = new List<AdditionalBuilding>();
            DefenseBuildings = new List<DefenseBuilding>();
            Factories = new List<Factory>();
            MiningBuildings = new List<MiningBuilding>();
            SpaceStationModules = new List<SpaceStationModule>();
            StorageBuildings = new List<StorageBuilding>();

            Npcs = new List<NpcModel>();

            Ships = new List<ShipModel>();
            Drones = new List<DroneModel>();
            Boxes = new List<BoxModel>();
            Ammunitions = new List<AmmunitionModel>();
            Artifacts = new List<ArtifactModel>();
            Ruins = new List<RuinModel>();
            SpaceGates = new List<SpaceGateModel>();
            SpaceStations = new List<SpaceStationModel>();
        }
    }
}
/*

Mapa může obsahovat tyto objekty:

Suns             - Slunce, centrální hvězdy v solární soustavě.
Planets          - Planety obíhající kolem slunce.
DwarfPlanets     - Trpasličí planety, které obíhají kolem slunce, ale nesplňují všechna kritéria pro plnohodnotné planety.
Comets           - Komety, ledová tělesa, která při přiblížení ke slunci vyvíjí ohony.
Asteroid belt    - Pás asteroidů, oblast plná malých skalnatých těles mezi Marsem a Jupiterem.
Asteroids        - Jednotlivé asteroidy, malé skalnaté objekty v solární soustavě.
Meteoroids       - Malé částice skal a kovů, které mohou při vstupu do atmosféry způsobit meteory.

Black holes      - Černé díry, velmi hmotné objekty s extrémní gravitací, které mohou ovlivnit herní prostředí a fyziku.
Energy fields    - Energetická pole, oblasti ve vesmíru s vysokou energetickou aktivitou, které mohou ovlivnit lodě a herní mechaniky.
Nebulas          - Oblasti ve vesmíru s vysokou koncentrací plynu a prachu, které mohou ovlivnit viditelnost a senzorové systémy.
Quasars          - Velmi jasné a energetické objekty, které mohou mít vliv na herní prostředí.

Ruins            - Ruiny a opuštěné struktury, které mohou obsahovat poklady nebo nebezpečí.
Artifacts        - Mimozemské artefakty, starobylé nebo pokročilé technologie mimozemského původu.

Ships            - Lodě, které hráči ovládají nebo potkávají ve vesmíru.
Npcs             - Nehráčské postavy (Non-Player Characters), které mohou interagovat s hráčem.
Boxes            - Boxy, které mohou obsahovat různé odměny nebo zdroje.
Space stations   - Vesmírné stanice, velké struktury, které slouží jako základny, obchodní uzly nebo místa pro opravy a tankování lodí.
Space docks      - Vesmírné doky, místa pro stavbu, údržbu a opravy vesmírných lodí.
MiningTechnology stations  - Těžební stanice, struktury určené k těžbě zdrojů z asteroidů, planet nebo měsíců.
Satellites       - Satelity, malé objekty obíhající kolem planet, které mohou sloužit pro komunikaci, průzkum nebo sledování.
Space gates      - Vesmírné brány, zařízení, která umožňují rychlé cestování mezi vzdálenými místy ve vesmíru.


*/

/*
#region Listy objektů mapy

//MapObjects

public List<SunModel> Suns { get; set; }
public List<PlanetModel> Planets { get; set; }
public List<DwarfPlanetModel> DwarfPlanets { get; set; }
public List<CometModel> Comets { get; set; }
public List<AsteroidModel> Asteroids { get; set; }
public List<MeteoroidModel> Meteoroids { get; set; }
public List<BlackHoleModel> BlackHoles { get; set; }
public List<EnergyFieldModel> EnergyFields { get; set; }
public List<NebulaModel> Nebulas { get; set; }
public List<QuasarModel> Quasars { get; set; }

//ActiveObjects

public List<ShipModel> Ships { get; set; }
public List<Base_NpcsModel> Npcs { get; set; }
public List<DroneModel> Drons { get; set; }
public List<AmmunitionModel> Ammunitions { get; set; }
public List<BoxModel> Boxes { get; set; }

public List<SpaceStationModule> SpaceStations { get; set; }
public List<SpaceGateModel> SpaceGates { get; set; }


// PasiveObjects - OnObjectBuildings

public List<RuinModel> Ruins { get; set; }
public List<ArtifactModel> Artifacts { get; set; }




#endregion


#region celkové počty prvků

public int SunsCount => Suns?.Count ?? 0;
public int PlanetsCount => Planets?.Count ?? 0;
public int DwarfPlanetsCount => DwarfPlanets?.Count ?? 0;
public int CometsCount => Comets?.Count ?? 0;
public int AsteroidsCount => Asteroids?.Count ?? 0;
public int MeteoroidsCount => Meteoroids?.Count ?? 0;
public int BlackHolesCount => BlackHoles?.Count ?? 0;
public int EnergyFieldsCount => EnergyFields?.Count ?? 0;
public int NebulasCount => Nebulas?.Count ?? 0;
public int QuasarsCount => Quasars?.Count ?? 0;
public int RuinsCount => Ruins?.Count ?? 0;
public int ArtifactsCount => Artifacts?.Count ?? 0;
public int SpaceStationsCount => SpaceStations?.Count ?? 0;
public int SpaceGatesCount => SpaceGates?.Count ?? 0;
public int ShipsCount => Ships?.Count ?? 0;
public int NpcsCount => Npcs?.Count ?? 0;
public int DronsCount => Drons?.Count ?? 0;
public int AmmunitionsCount => Ammunitions?.Count ?? 0;
public int BoxesCount => Boxes?.Count ?? 0;

#endregion

#region Pozice všech prvků

public Vector2[] SunsPosition { get; set; }
public Vector2[] PlanetsPosition { get; set; }
public Vector2[] DwarfPlanetsPosition { get; set; }
public Vector2[] CometsPosition { get; set; }
public Vector2[] AsteroidsPosition { get; set; }
public Vector2[] MeteoroidsPosition { get; set; }
public Vector2[] BlackHolesPosition { get; set; }
public Vector2[] EnergyFieldsPosition { get; set; }
public Vector2[] NebulasPosition { get; set; }
public Vector2[] QuasarsPosition { get; set; }
public Vector2[] RuinsPosition { get; set; }
public Vector2[] ArtifactsPosition { get; set; }
public Vector2[] SpaceStationsPosition { get; set; }
public Vector2[] SpaceGatesPosition { get; set; }
public Vector2[] ShipsPosition { get; set; }
public Vector2[] NpcsPosition { get; set; }
public Vector2[] DronsPosition { get; set; }
public Vector2[] AmmunitionsPosition { get; set; }
public Vector2[] BoxesPosition { get; set; }

#endregion



public MapModel(string name, string type, string designation, string description,
    int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
: base(idGlobal, idUser, spawnPlace, width, height, depth)
{
    Id_Global = 0; //  prvních 100 pro mapy?
    Id_User = 0; // server
    Id_Type = 0; // defaultní typ mapy

    SpawnPlace = new Vector3(0, 0, 0);
    Position = new Vector3(0, 0, 0);
    PositionOnMap = new Vector2(0, 0);
    TargetPosition = new Vector2(0, 0);

    Rotation = 0;
    Velocity = new Vector2(0, 0);
    Acceleration = 0;
    Width = 0;
    Height = 0;
    CanBeDestroyed = false;

    ImageSize = new Vector2(Width, Height);
    MapWidth = Width;
    MapHeight = Height;


}
}
}
*/
