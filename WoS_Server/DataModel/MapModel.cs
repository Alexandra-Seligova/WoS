


namespace WoS_Server.DataModel
{
    using Microsoft.Xna.Framework;
    public class MapModel
    {
        public int Id_User { get; set; } = 0; // id serveru
        public int Id_Map { get; set; } = 1;  // Unikátní identifikátor mapy
        public int Id_Map_Type { get; set; } = 1; // Typ mapy

        public string Name { get; set; }  // Název mapy
        public int Width { get; set; }  // Velikost mapy
        public int Height { get; set; }  // Velikost mapy

        // Navigační vlastnosti pro vztahy 1:N
        //Kolekce prvků získaná pomocí kombinace [Id_User,Id_Map] v dané vtabulce prvků 
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
        public ICollection<StorageBuilding> StorageBuildings { get; set; }

        public ICollection<NpcsModel> Npcs { get; set; }

        public ICollection<ShipModel> Ships { get; set; }
        public ICollection<DroneModel> Drones { get; set; }
        public ICollection<BoxModel> Boxes { get; set; }
        public ICollection<AmmoModel> Ammunitions { get; set; }
        public ICollection<ArtifactModel> Artifacts { get; set; }
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
            StorageBuildings = new List<StorageBuilding>();

            Npcs = new List<NpcsModel>();

            Ships = new List<ShipModel>();
            Drones = new List<DroneModel>();
            Boxes = new List<BoxModel>();
            Ammunitions = new List<AmmoModel>();
            Artifacts = new List<ArtifactModel>();
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
