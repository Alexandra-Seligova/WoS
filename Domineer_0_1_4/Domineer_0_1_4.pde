//ctrl + shift + b  spuštění
//spojeni tabulek pro lod, uzivatel; kanonu mimo stred; sber boxů //<>// //<>//



//MQTT
import mqtt.*;
MQTTClient client;
String MQTT_SERVER ="mqtt://192.168.0.168/" ;//192.168.0.104
String payload_;



// OBJEKTY
Uzivatel uzivatel;
Ship ship;
AL_lod terc;
Kanon kan1, kan2;
Anime anime;

Mapa mapa;
Asteroid asteroid;
Stanice stanice;
PotvrzTab potvrzTab;
GuiEdit gEdit;
GuiEditOkno gEditOk;
//
//Ship ship2;



//ARRAY LISTY
ArrayList<AL_lod> ARlode;
ArrayList<Anime> ARvybuchy;
ArrayList<Asteroid> ARkameni; 
ArrayList<Box> AR_Boxy;
ArrayList<Kanon> ARkan;
ArrayList<Zpravy> AR_zpravy;
//ArrayList<Pozemky> ARpozemky;
//ArrayList<Planeta> ARplanety;
ArrayList<GuiEditOkno>  AReditOk;




// OBECNÉ
float mx, my;
int FPS=200;
float MouseUhel;
PImage pozadi;
float camX, camY, camSirka, camVyska, mapSirka, mapVyska;
int frame = 1;


// LODĚ

int druh_ozn; // 0 = nic, 1 = lod, 2 = box, 3 = asteroid, 4 = velký asteroid
float shipRychlost = 2;
float uhelRotace = .1; 
PVector Mvect, MuniceCil;
PVector Mvect2=new PVector(0, 0);
float vychoziX, vychoziY;
boolean let = false;
boolean utok = false;
float LodX, LodY;
float alfa, beta, theta; //alfa lod; beta munice; theta terce;
PVector oznObj;
int oznObjC ;
int pocMereni, doba;
int q;//počet projetí instancí


float online_x=400;
float online_y=300;
float online_r=0;
// PROSTŘEDÍ


// PImage
PImage rocket, oznaceni;
PImage bum[];
PImage images[]; 
PImage ozn;
PImage Egla;

PImage map1, map2;
PImage blueBox, redBox, goldBox; 
PImage n1;
PImage stit;
PImage delo1;
PImage Streuner1, Fodienda;
PImage Planeta1;
PShape Pzakladna, Pextraktor, Phangar, Plaborator, Preaktor, Psklad, Pstit;
PImage IPObuild, IPOinfo, IPOpresunuti, IPOupgrade, IPOzniceni;
PImage GUIsenzory, GUIbase, GUIattack;



// PShape
PShape Streuner;
PShape Ic, Pt, Imenu, Iship, Isklad, Inastav;
PShape Gsklad, Gship;
PShape zelezo, vodik, dusik, kremik, hlinik, uhlik, uran, dilithium;
PShape lab1, lab2, lab3;

// POLE

// TABULKY
Table table;
Table TShips;
Table TZbrane, TStity, TPohony;
Table Txp;
Table shipConfMod;  //konfigurace modulů v lod ( jaké moduly se v lodi nacházejí
Table moduly;       //seznam modulů
Table myModuly;     // Moduly které vlastním (mám je nakoupené)
Table Tcnfg;  // celkový seznam poctu daných itemů
Table TcfgLod; //konfigurační soubor pro danou loď

// PGraphics
PGraphics PGbum;
PGraphics PGpozadi;

// FONT
PFont f;

// OSTATNÍ
String PCcesta = "/data/";
String ANDcesta = "//sdcard/hra/";
float  Ox1, Ox2, Oy1, Oy2;
int Cx;
int Cy;
boolean pause;




//GUI
int GS; // gui switch
float RSs; //reálná šířka skladu
float RVs; //
int sL=1, sP=1; //sklad nastavení levé a pravé strany
int lL=1, lP=1; //lodnastavení levé a pravé strany

int[] p = new int [20];
boolean senzory=true;
boolean lodRestart;
int casRestart;

float rot;
boolean Uzakladna=false;   // jsem u zakladny
boolean modeZakladna=false;
boolean Mpressed=false;
int pozemekOzn=-1;
int GUIpozeC=0;  // gui pozemky cislo akce (info,build...)
boolean GUIpozePrem=false; // gui pozemky přemístění
boolean GUIpozeInfo=false; // gui pozemky info

float[][] sourPozemku={{0, 0}, 
  {0, 1}, //souřadnice pozemku
  {1, 0.5}, 
  {1, -0.5}, 
  {0, -1}, 
  {-1, -0.5}, 
  {-1, 0.5}, 
  {1, 1.5}, 
  {1, -1.5}, 
  {-2, 0}, 
  {-1, 1.5}, 
  {2, 0}, 
  {-1, -1.5}, 
  {-2, -1}, 
  {0, 2}, 
  {2, -1}, 
  {0, -2}, 
  {-2, 1}, //17
  {2, 1}, //18
};  //souřadnice pozemku






// solární systém

PImage SysPozadi,Splan1, Splan2, Splan3, Sslunce1;
int SysSirka, SysVyska;
int[] Porbity={0, 450, 700, 1000, 1400, 1900, 2600, 3300}; // vzdálenost orbity od slunce;
int[] PplanVelikost={0, 75, 100, 125, 150, 175, 200, 300, 400};  // 1- 75; 4-150; 6-200;  plyn obři 7-300; 8-400


boolean Uplanety=false;
int CoznPlanety=-1;

int GuiBrana=1;   // gui vrstvy pro Galaktickou bránu
boolean Ubrany=false;
int GUIbranaList=0;

int shopUR=0;  // 0-základní rozdělení, 1-lodě, 2-zbraně, 3-štít, 4-pohon

boolean okno=false; //platební dotazovací okno
boolean vytvorOkno=false;
int cisOkno;


// NASTAVENÍ SVĚTA
int Prostor=3; // 1= MAPA; 2=Sol. Systém; 3= mapa



void setup() {                                              // SETUP //
  
  MQTT_start();  // zahájení komunikace
  size(1600, 1000, P3D);
  orientation(LANDSCAPE);
  //  size(displayWidth,displayHeight,P3D);
  frameRate(100);
  f = createFont ("Arial", 20, true);

  //definování mapy
  camX=0;
  camY=0;
  camSirka=width;
  camVyska=height; 

  mapSirka=6400;
  mapVyska=3600;
  SysSirka=6400;
  SysVyska=3600;

  //GUI
  RSs=width-160;
  RVs=height-230;
  PGbum = createGraphics(200, 200);
  // PGpozadi=createGraphics(int(mapSirka),int(mapVyska));


  // ARRAY LISTY
  AR_Boxy = new ArrayList<Box>();
  ARlode = new ArrayList<AL_lod>();
  ARvybuchy = new ArrayList<Anime>();
  ARkameni= new ArrayList<Asteroid> ();
  AR_zpravy= new ArrayList<Zpravy> ();
  //  ARpozemky= new ArrayList<Pozemky>();   
  //  ARplanety= new ArrayList<Planeta>();

  // TABULKY
  TZbrane = loadTable("ModulyZbrane.csv", "header");
  TShips = loadTable("Ships.csv", "header");
  table = loadTable("Uzivatel.csv", "header");
  Txp= loadTable("XP.csv", "header");
  shipConfMod= loadTable("ShipConfMod.csv", "header");
  moduly= loadTable("Moduly.csv", "header");
  myModuly= loadTable("naklad.csv", "header");

  TStity= loadTable("ModulyStit.csv", "header");
  TPohony= loadTable("ModulyPohon.csv", "header");
  Tcnfg= loadTable("cnfg.csv", "header");


// načtení grafiky
  bum = new PImage[25];
  for (int i =1; i<=8; i++) {
    String cislo = "expl" + i+".png";
    bum[i]=loadImage(cislo);
  }

  images = new PImage[25];
  for (int i =1; i<=12; i++) {
    String cislo = "x" + i+".png";
    images[i]=loadImage(cislo);
  }
  for (int i =23; i>12; i--) {
    String cislo = "x" + (i-12)+".png";
    images[i]=loadImage(cislo);
  }


  Fodienda= loadImage("tezebniLod.png");
  delo1= loadImage("delo2.png");
  Streuner1= loadImage("Streuner.png");
  pozadi=loadImage("vesmir.jpg");
  Planeta1= loadImage("Planeta11.png");
  blueBox = loadImage("blue-cube.png");
  redBox = loadImage("red-cube.png");
  goldBox = loadImage("gold-cube.png");
  oznaceni = loadImage("ozn.png");
  rocket = loadImage("Rocket.png"); 
  n1=loadImage("n1.png");
  Egla=loadImage("Egla.png");

  Streuner=loadShape("Streuner.svg");
  stit=loadImage("Csh.png");
  Ic=loadShape("Icr.svg");
  Pt=loadShape("Pt.svg");
  Imenu=loadShape("Imenu.svg");
  Iship=loadShape("Iship.svg");
  Isklad=loadShape("Isklad.svg");
  Inastav=loadShape("Inastav.svg");
  Gsklad = loadShape("GuiSklad.svg");
  Gship = loadShape("GuiLod.svg");

  zelezo=loadShape("fe.svg");
  vodik=loadShape("h.svg");
  dusik=loadShape("n.svg");
  kremik=loadShape("si.svg");
  hlinik=loadShape("al.svg");
  uhlik=loadShape("c.svg");
  uran=loadShape("u.svg");
  dilithium=loadShape("di.svg");

  lab1=loadShape("lab1.svg");
  lab2=loadShape("lab2.svg");
  lab3=loadShape("lab3.svg");

  Pzakladna=loadShape("Pzakladna.svg");
  Pextraktor=loadShape("Pextraktor.svg");
  Phangar=loadShape("Phangar.svg");
  Plaborator=loadShape("Plaborator.svg");
  Preaktor=loadShape("Preaktor.svg");
  Psklad=loadShape("Psklad.svg");
  Pstit=loadShape("Pstit.svg");

  IPObuild= loadImage("build.png");
  IPOinfo= loadImage("info.png");
  IPOpresunuti= loadImage("move.png");
  IPOupgrade= loadImage("upgrade.png");
  IPOzniceni= loadImage("Destroy.png");

  GUIsenzory= loadImage("sensors.png");
  GUIbase= loadImage("base.png");
  GUIattack= loadImage("attack.png");  // 600x300

  SysPozadi= loadImage("Spozadi.jpg");
  Splan1= loadImage("planeta1.5.png");
  Splan2= loadImage("planeta2.5.png");
  Splan3= loadImage("planeta3.5.png");
  Sslunce1= loadImage("slunce1.png");

  map1=loadImage("map2.jpg");
  // map2=loadImage("map2.jpg");





  ////    DEFINOVÁNÍ SVĚTA A OBJEKTŮ V NĚM    ////
  vychoziX=width/2;
  vychoziY=height/2;
  Mvect = new PVector(width/2, height/2); 

  /*
  zakladna = new Zakladna(new PVector(mapSirka/2, mapVyska/2), "Zakladna_1");
   for (int i=0; i<=6; i++) { 
   ARpozemky.add(new Pozemky(i, 5));  //cislo pozemku, velikost
   }
   */

  uzivatel = new Uzivatel(); 
  String cf="cfg_";
  cf+="Fodienda"+".csv";
  TcfgLod= loadTable(cf, "header");  // načtení daného konfiguračního souboru pro danou loď
  ship  = new Ship(new PVector(500, 500), 0, "Fodienda");  //  PI/2
 // ship2  = new Ship(new PVector(500, 300), 0, "Fodienda");  


  gEdit=new GuiEdit();
  stanice = new Stanice(500, 500);
  //ship  = new Ship(new PVector(mapSirka/2, mapVyska/2), 0, "Fodienda");  //  PI/2


  /*
  galaxy = new Galaxy();
   Galaktickabrana("sou1");   //uzivatel.soustava_
   vytvorGuiSouList();
   */

  mapa = new Mapa("Streuner");   // loď, počet

  GS=0;


  // načtení grafiky při prvním vykreslení
  //image(pozadi,0,0);
  image(Planeta1, 0, 0);
  image(oznaceni, 0, 0);
  image(rocket, 0, 0);
  background(0);
}

//---------------------------------------------------------------------------------DRAW----------------------------------
void draw() {
  //println(frameRate);
  // println("počátek intance "+q);

  background(0); 

  /*
  switch (Prostor) {
   case 1:
   prostrediSystem();
   prostredi();
   zakladna.render();
   break;
   case 2:
   prostrediSystem();
   break;
   case 3:
   prostrediMapa();
   break;
   }
   */





  if (GS==0) {
    prostrediMapa();
    if (let) {  
      mys();
    }


    if (druh_ozn==1) {   

      AL_lod terc = (AL_lod) ARlode.get(oznObjC);
      oznObj=terc.pozice;


      oznac(terc.velikost);
    } else if (druh_ozn==4) {   
      Asteroid asteroid = (Asteroid) ARkameni.get(oznObjC);
      oznObj=asteroid.pozice;
      oznac(asteroid.velikost);
    }

    if (druh_ozn==3 ||druh_ozn==4) {
      if (senzory) {
        okno();
      }
    }

    for (int y = ARkameni.size()-1; y >= 0; y--) {
      Asteroid asteroid = (Asteroid) ARkameni.get(y);
      asteroid.render();
    }




    if ( PVector.dist(ship.pozice, Mvect)>5 ) {
      ship.update();
    } else {

      if (ship.budeTran) {
        ship.transport();
      }
    }

    for (int y = AR_Boxy.size()-1; y >= 0; y--) {
      Box box = (Box) AR_Boxy.get(y);
      box.render();
    }



//?????????????????????????????????????????????
    if ( PVector.dist(ship.pozice, Mvect)>10 ) {
      ship.update();
    }

    ship.render();
    ship.zasah();
    ship.destroy();
    ship.zbranovySystem();
    
    if (utok) {  
      for (int y = ARkan.size()-1; y >= 0; y--) {
        Kanon kan = (Kanon) ARkan.get(y);
        kan.automatickyKanon(kan.pozice, oznObj);
      }
    }

    for ( AL_lod terc : ARlode) {

      terc.update();
      terc.render();
      terc.zasah();
    }
    for (int y = ARkan.size()-1; y >= 0; y--) {
      Kanon kan = (Kanon) ARkan.get(y);
      kan.update();
      kan.render();
    }

    for (int i = ARvybuchy.size()-1; i >= 0; i--) {

      Anime anime = (Anime) ARvybuchy.get(i);
      anime.render();
    }
  }
renderOnline(online_x,online_y,online_r);


  pushMatrix();
  translate(LodX-width/2, LodY-height/2);
  GUI();
  text(frameRate, width-100, height-50);
  popMatrix();
  /*
  if (Prostor==1) { 
   Azakladna();
   Gprostredi();
   } else if (Prostor==2) {
   Aplaneta();
   if (GS==0) {
   Abrana();
   }
   }
   */

  /*
  fill(255, 0, 0);
   ellipse(mx, my, 5, 5);   // ukazatel nakliknutí
   */

  // Mpressed=false;
  //    println("konec instance "+ q);   q+=1;  /*if(q==10){noLoop();}*/
}

//----------------------------------------------------------DRAW---------------------------------
