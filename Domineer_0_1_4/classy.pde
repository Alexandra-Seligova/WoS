// Uživatel
// PotvrzTab
// Munice
// Kanon
// Anime
// Box
// Asteroid

class Uzivatel {
  String jmeno_;
  int XP_; //Body zkušenosti
  float XPbar_;  // xp bar == velikost xp čáry
  int XPc; // celkový součet xp
  int honor_; //čest
  int kredity_;
  int platina_;
  int lvl_; // level
  boolean platba=false;
  int velInven=28;
  int pouzInven=0;
  int volInven=0;

  int ze, vo, du, kr, hl, uh, ur, di;

  Uzivatel() {

    TableRow row = table.getRow(0); 
    jmeno_=row.getString("jmeno");
    kredity_=row.getInt("kredity");
    platina_=row.getInt("platina");
    XP_=row.getInt("XP");
    honor_=row.getInt("honor");
    lvl_=row.getInt("lvl");


    for (float i=0; i<100; i++) {
      XPc+=i*i*100;
      if (XPc>XP_) {
        lvl_=int(i);
        XPbar_=1-((XPc-XP_)/(i*i*100));

        i=1000;
      }
    }
  }

  void pocInventar() {
    pouzInven=0;
    for ( GuiEditOkno okno : AReditOk) {
      if (okno.Full==true) {
        pouzInven+=1;
      }
    }
   
    println("pouz okna: "+pouzInven);
  }


  void update() {
    XPc=0;
    for (float i=0; i<100; i++) {
      XPc+=i*i*100;
      if (XPc>XP_) {
        lvl_=int(i);
        XPbar_=1-((XPc-XP_)/(i*i*100));
        println(XPbar_);
        i=1000;
      }
    }

    ze=ship.surovina[0];
    vo=ship.surovina[1];
    du=ship.surovina[2];
    kr=ship.surovina[3];
    hl=ship.surovina[4];
    uh=ship.surovina[5];
    ur=ship.surovina[6];
    di=ship.surovina[7];

    TableRow row = table.getRow(0); 
    row.setInt("kredity", kredity_);
    row.setInt("platina", platina_);
    row.setInt("XP", XP_);
    row.setInt("lvl", lvl_);

    row.setInt("fe", ze);
    row.setInt("h", vo);
    row.setInt("n", du);
    row.setInt("si", kr);
    row.setInt("al", hl);
    row.setInt("c", uh);
    row.setInt("u", ur);
    row.setInt("di", di);



    saveTable(table, "data/Uzivatel.csv");
  }

  void platba(int cena_, int druh_, int ozn_) {   // placení v shopu  druh= 0-kredity  1-platina

    if (druh_==0) {

      if (cena_<= kredity_) {

        kredity_-=cena_;
        println("cena: "+cena_);
        println("zustatek: "+kredity_);
        println("platba byla úspěšná");
        TableRow row = myModuly.getRow(ozn_-1);
        int poc=row.getInt("pocet");
        poc+=1;
        row.setInt("pocet", poc);
        saveTable(myModuly, "data/naklad.csv");
      } else {
        println("cena: "+cena_);
        println("zustatek: "+kredity_);
        println("není dostatek kreditů");
      }
    } else if (druh_==1) {
      if (cena_<= platina_) {
        platina_-=cena_;
        println("cena: "+cena_);
        println("zustatek: "+platina_);
        println("platba byla úspěšná");
        TableRow row = myModuly.getRow(ozn_-1);
        int poc=row.getInt("pocet");
        poc+=1;
        row.setInt("pocet", poc);
        saveTable(myModuly, "data/naklad.csv");
      } else {
        println("cena: "+cena_);
        println("zustatek: "+platina_);
        println("není dostatek platiny");
      }
    }
    update();
  }
  
  
  void prodej(int cena){
   kredity_+=cena;
    update();
  
  }
  
  
  
  
}

class PotvrzTab {
  String mena;
  int cena, druh, ozn;
  
  PotvrzTab(int cena_, int druh_, int ozn_) {
    stanice.potvrzTab=true;
    cena=cena_;
    druh=druh_;
    ozn=ozn_;
    mena="";
    if (druh_==0) {  //kredity
      mena="kreditů";
    } else { 
      mena="platiny";
    }
  }

  void update() {

    pushStyle();
    pushMatrix();
    textFont(f, 30); 
    textAlign(CENTER, CENTER);
    rectMode(CENTER);
    fill(255);
    rect(width/2, height/2, 600, 300);
    rect(width/2-200, height/2+300-60, 200, 80);
    rect(width/2+200, height/2+300-60, 200, 80);
    fill(0);
    text("potvrzení transakce: "+cena+mena, width/2, height/2-100);
    text("potvrzení", width/2-200, height/2+300-60);
    text("zrušení", width/2+200, height/2+300-60); 
    popMatrix();
    popStyle();

    if (tlacitko(Cx+width/2-200-100, Cy+height/2+300-60-40, 200, 80)) {
      println("potvrzení");
      uzivatel.platba(cena, druh, ozn);
      okno=false;
      mx=0;
      my=0;
      gEdit.reload();
      stanice.potvrzTab=false;
    }
    if (tlacitko(Cx+width/2+200-100, Cy+height/2+300-60-40, 200, 80)) {
      println("zrušení");
      okno=false;

      mx=0;
      my=0;
      stanice.potvrzTab=false;
    }
  }
}



class Munice {    // třída Munice           Update | render

  PVector pozice= new PVector(0, 0);      //pozice
  PVector rychlost= new PVector(0, 0);      //velocity
  PVector Ppozice= new PVector(0, 0);
  PVector cil= new PVector(0, 0);
  float rotace;  
  float r = 5;       //velikost lodi
  int druh;
  int dmg;
  int dostrel;

  public Munice(PVector cil_, float theta_, int dmg_, int dostrel_) {

    pozice = new PVector(vychoziX, vychoziY);
    Ppozice.set(pozice);
    rychlost = new PVector(0, 0);
    rotace = theta_;
    cil= cil_;
    cil.sub(pozice);
    dmg=dmg_;
    dostrel = dostrel_;
  } 

  void update() {                 // výpočet nové pozice
    cil.normalize();
    rychlost.set(cil);
    rychlost.mult(50);
    rychlost.limit(15); 
    pozice.add(rychlost);       // k pozici se přičte rychlost
  }


  void render() {                 // vykreslení nové pozice

    pushMatrix();
    imageMode(CENTER);
    translate(pozice.x, pozice.y);     //posunutí na pozici
    rotate(rotace);                                            //rotace
    fill(0);
    image(rocket, -r, -r*1.5, 2*r, 3*r); 
    popMatrix();
  }
}



class Anime {    // třída Anime            render

  float x, y;
  int pocObr;
  int seqObr;
  int poc;
  int i;

  Anime(float x_, float y_, int seqObr_, int pocObr_, int poc_) {
    x=x_;
    y=y_;
    pocObr=pocObr_;
    seqObr=seqObr_;
    poc= poc_;
    i=1;
  }

  void render() {

    if (i<=pocObr) {
      if ( casOmezovac(poc, 1000/seqObr)) {
        i++;
        poc=millis();
      }
      if (i!=pocObr+1) {
        pushMatrix();
        imageMode(CENTER);
        translate(x, y); 
        PGbum.beginDraw();
        PGbum.background(255, 0);
        PGbum.imageMode(CENTER);
        PGbum.image(bum[i], 100, 100, 50, 50);
        PGbum.endDraw();
        image(PGbum, 0, 0, 200, 200);
        // println("ren"+i);
        // println(millis());
        popMatrix();
      } else {        
        if (i==25)ARvybuchy.remove(this);
      }
    }
  }
}

class Box {       //  třída Box            render | sbíráno | obsah
  PVector pozice; 
  PImage obrazek;
  int r = 15; // velikost
  float scale=1;
  int seq=0;
  int pcas;
  boolean projeti=true;

  public Box(PVector poz_, PImage obr_) {
    pozice = poz_;
    obrazek = obr_;
  }
  void render() {  

    pushMatrix();
    imageMode(CENTER);
    translate(pozice.x, pozice.y);     //posunutí na pozici
    scale(scale);
    // rotate(theta);                                            //rotace
    fill(0);
    image(obrazek, 0, 0, 2*r, 2*r); 

    popMatrix();

    if (seq>0) {
      sbirano();
    }
  }


  void sbirano() {


    if (seq==1) {       //první seq při transportu
      pozice.y-=2;
      if (scale>0.1) scale-=0.03;

      if (projeti) {
        obsah();
        projeti=false;
      }
      seq=2;
    } else if (seq==26) {    //poslední 26 seq při transportu 
      AR_Boxy.remove(this);
      ship.seq=0;
    } else  if (seq>1 && seq<26) {    //do 26 seq při transportu
      if (casOmezovac(pcas, int(1000/30))) {

        seq+=1;
        pozice.y-=2;
        if (scale>0.1) scale-=0.02;
        pcas=millis();
      }
    }
  }


  void obsah() {

    int i = int(random(50, 100));
    uzivatel.kredity_+=i;
    uzivatel.update();
  }
}


class Asteroid {    //  třída Asteroid            tříštění | render | sbíráno | obsah
  int HP;
  int MaxHP;
  PVector pozice; 
  float  a, v, r, w, s;
  int typ;
  int ze, vo, du, kr, hl, uh, ur, di; //železo,vodík,dusík,křemík,hliník,uhlík,uran,dilithium
  int[] surovina = new int [7];
  float scale=1;
  float velikost=1;
  float[] vertx = new float[16];
  float[] verty = new float[16];
  int seq=0;
  int pcas;
  boolean projeti=true;


  Asteroid(float x_, float y_, float a_, float v_, float w_, int t_, int[] sur) {

    pozice=new PVector(x_, y_);
    a = a_;    //úhel letu
    v = v_;   //rychlost
    r = 0;  // rotace
    w = w_;   //rychlost rotace
    typ = t_;  //typ kamene
    surovina = sur;

    switch(typ) {
    case 1: 
      s=20;  // velikost (size)
      velikost=1;
      if (vel(float(sur))==true) {
        surovina[int(random(0, 7))]= int(random(10, 20));
      }
      break;
    case 2: 
      s=40;// velikost (size)
      HP=2000;
      MaxHP=HP;
      velikost=2.5;
      if (vel(float(surovina))==true) {
        surovina[int(random(0, 7))]= int(random(10, 20));
        surovina[int(random(0, 7))]= int(random(10, 20));
      }
      break;
    case 3: 

      s=60;// velikost (size)
      HP=4000;
      MaxHP=HP;
      velikost=3;
      if (vel(float(surovina))==true) {
        for (int i = 0; i<6; i++) {

          surovina[int(random(0, 7))]= int(random(10, 20));
        }
      }
      break;
    case 4: 

      s=100;// velikost (size)
      HP=8000;
      MaxHP=HP;
      velikost=5;
      if (vel(float(surovina))==true) {

        for (int i = 0; i<10; i++) {

          surovina[int(random(0, 7))]= int(random(10, 20));
        }
      }

      break;
    }

    // Nastaví vrcholy asteroidu na náhodné 16 stranný polygon
    for (int i = 0; i < 16; i++) {

      vertx[i] = sin(i*PI/8)*(s + random(-s/4, s/4));
      verty[i] = cos(i*PI/8)*(s + random(-s/4, s/4));
    }
    p = new int [20];  // problém že dokáže přepsat konstantu
  }

  void tristeni() {
    println("tris");
    float[] su = new float [20];

    switch(typ) {
    case 1: 

      break;
    case 2: 
      if (HP<=0) {
        for (int i=0; i <surovina.length; i++) {
          su[i]+=surovina[i]/2;
        }       

        ARkameni.add(new Asteroid(pozice.x+random(-30, 10), pozice.y+random(-30, 10), 0, 0, 0, 1, int(su)));
        ARkameni.add(new Asteroid(pozice.x+random(-10, 30), pozice.y+random(-10, 30), 0, 0, 0, 1, int(su)));
      }

      break;
    case 3: 
      if (HP<=0) {
        for (int i=0; i <surovina.length; i++) {
          su[i]+=surovina[i]/3;
        } 
        ARkameni.add(new Asteroid(pozice.x+random(-30, 10), pozice.y+random(-30, 10), 0, 0, 0, 1, int(su)));
        ARkameni.add(new Asteroid(pozice.x+random(-10, 30), pozice.y+random(-10, 30), 0, 0, 0, 1, int(su)));
        ARkameni.add(new Asteroid(pozice.x+random(-30, 10), pozice.y+random(-30, 10), 0, 0, 0, 1, int(su)));
      }
      break;
    case 4: 
      if (HP<=0) {
        for (int i=0; i <surovina.length; i++) {
          su[i]+=surovina[i]/2;
        }       

        ARkameni.add(new Asteroid(pozice.x+random(-30, 10), pozice.y+random(-30, 10), 0, 0, 0, 2, int(su)));
        ARkameni.add(new Asteroid(pozice.x+random(-10, 30), pozice.y+random(-10, 30), 0, 0, 0, 2, int(su)));
      }
      break;
    }
    ARkameni.remove(this);
  }

  void render() {
    fill(0);
    switch(typ) {
    case 1: 
      // White
      stroke(255);
      break;
    case 2: 
      // Yellow
      stroke(32, 255, 255);
      break;
    case 3: 
      // Purple
      stroke(192, 255, 255);
      break;
    case 4: 
      // Blue
      stroke(128, 255, 255);
      break;
    }

    // Renders the asteroid
    pushMatrix();
    strokeWeight(1);
    rotate(r);
    translate(pozice.x, pozice.y);
    scale(scale);
    beginShape();
    for (int i = 0; i < 16; i++) {
      vertex(vertx[i], verty[i]);
    }
    vertex(vertx[0], verty[0]);
    endShape();
    rotate(-r);
    popMatrix();

    if (senzory) {
      renderBar(pozice.x, pozice.y, HP, 0, MaxHP, 0);
    }

    if (seq>0) {
      sbirano();
    }
  }


  void sbirano() {


    if (seq==1) {       //první seq při transportu
      pozice.y-=2;
      if (scale>0.1) scale-=0.03;


      if (projeti) {
        obsah();
        projeti=false;
      }

      seq=2;
    } else if (seq==26) {    //poslední 26 seq při transportu 
      ARkameni.remove(this);
      println("smazani asteroidu");
      ship.seq=0;
    } else  if (seq>1 && seq<26) {    //do 26 seq při transportu
      if (casOmezovac(pcas, int(1000/30))) {

        seq+=1;
        pozice.y-=2;
        if (scale>0.1) scale-=0.02;
        pcas=millis();
      }
    }
  }

  void obsah() {

    for (int i =0; i<7; i++) {
      ship.surovina[i]+=surovina[i] ;
    }
    uzivatel.update();
  }
}