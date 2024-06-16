namespace WoS_Server.DB_Model
{
    using System.ComponentModel.DataAnnotations;
    public class MapModel
    {
        [Key]
        public int Id_Map { get; set; }
        public int Id_Map_Type { get; set; }

        public int Id_GalaxyPosition { get; set; }// Odkaz do tabulky [GalaxyPosition] 
        public int Id_MapObjectConfig { get; set; }

        public string Name { get; set; }




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
