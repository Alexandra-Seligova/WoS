

class Mapa {
  int cislo;
  String jmenoMapy;
  int GpozX, GpozY; //galaktické souřadnice
  int sirka, vyska;
  float x, y;
  float Xvel, Yvel, rozloha;  //XYvel velikost pro obrázek
  String l1, l2, l3, l4; // loď, počet
  int  p1=0, p2=0, p3=0, p4=0;
  int pocBoxu, pocAsteroidu;
  int casOmezovac=0;

  Mapa(String l1_) {
    // sirka=32000;
    // vyska=18000;
    l1=l1_;;

    sirka=6400;
    vyska=3600;

    rozloha=(sirka*vyska)/1000000;  // v 1000p čtverečních
    p1=int(rozloha/2); //počet lodí typu 1
    pocBoxu=int(rozloha/2);       //1 box na 1000p čtverečních
    pocAsteroidu=int(rozloha/2);  //1 asteroid na 2000p čtverečních

    Xvel=1920*2;
    Yvel=1080*2;
    vytvorit();
  }
  
  Mapa(String l1_, int p1_, String l2_, int p2_) {  // vícenásobný konstruktor příprava
    // sirka=32000;
    // vyska=18000;
    l1=l1_;
    p1=p1_;
    l2=l2_;
    p2=p2_;


    sirka=6400;
    vyska=3600;
    rozloha=sirka*vyska;


    Xvel=1920*2;
    Yvel=1080*2;
    vytvorit();
  }


  void update() {                         //  detekce lodě mimo arénu | udržování()
    casOmezovac+=1;
    if (casOmezovac>=FPS) {
     
      if (ship.pozice.x<-200 || ship.pozice.x>sirka+200 ||ship.pozice.y<-200 ||ship.pozice.y>vyska+200) { //lod je mimo mapu
        ship.HP-=ship.MaxHP/15;
      }
      casOmezovac=0;
    }


    x=(ship.pozice.x-width/2)-((ship.pozice.x/sirka)*(Xvel-width)) ;
    y=(ship.pozice.y-height/2)-((ship.pozice.y/vyska)*(Yvel-height)) ;
    udrzovani();
  }


  void render() {                         //  vykreslení obrázku mapy
    update();
    strokeWeight(20);
    noFill();
    stroke(255);
    rect (0, 0, sirka, vyska);
    pushStyle();
    pushMatrix();

    translate(x, y);
    imageMode(CORNER);
    image(map1, 0, 0, Xvel, Yvel );

    popMatrix();
    popStyle();
  }


  void vytvorit() {                       // vytvoření objektů mapy      boxy | NPC lodě | asteroidy
    ARlode= new ArrayList<AL_lod>();
    ARkameni= new ArrayList<Asteroid> ();
    AR_Boxy = new ArrayList<Box>();

    println("vytvarim");

    for (int i=0; i< pocBoxu; i++) {
      AR_Boxy.add(new Box(new PVector(random(sirka/10, sirka-sirka/10), random(vyska/10, vyska-vyska/10)), blueBox));
      println("pridavam box: "+i);
    } 

    for (int i=0; i< p1; i++) {
      ARlode.add(new AL_lod(new PVector(random(sirka/10, sirka-sirka/10), random(vyska/10, vyska-vyska/10)), 0, l1));
      println("pridavam lod: "+i);
    }

    for (int i=0; i< pocAsteroidu; i++) {
      ARkameni.add(new Asteroid(random(sirka/2, sirka-sirka/10), random(vyska/10, vyska-vyska/10), 0, 0, 0, int(random(0, 4)), p));
      println("pridavam asteroid: "+i);
    }
  }


  void udrzovani() {                    //  automatické doplňování      sebraného | zničeného   
    if (AR_Boxy.size()-1<pocBoxu) {
      AR_Boxy.add(new Box(new PVector(random(sirka/10, sirka-sirka/10), random(vyska/10, vyska-vyska/10)), blueBox));
    }

    if (ARlode.size()-1<p1) {
      ARlode.add(new AL_lod(new PVector(random(sirka/10, sirka-sirka/10), random(vyska/10, vyska-vyska/10)), 0, l1));
    }

    if (ARkameni.size()-1<pocAsteroidu) {
      ARkameni.add(new Asteroid(random(sirka/2, sirka-sirka/10), random(vyska/10, vyska-vyska/10), 0, 0, 0, int(random(0, 4)), p));
    }
  }
}