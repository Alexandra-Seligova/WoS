
//AL_ship
//AL_kanon

class AL_lod {                                                                   // třída loď
  ArrayList<Munice> ALstrely;
  PVector pozice;      //pozice
  PVector rychlost;      //velocity
  float rotace;  
  float zrychleni= 5;
  PVector cil = new PVector(0, 0), cill = new PVector(0, 0);
  boolean oznac = false;
  int ALpremisteni;
  int casPremisteni= int(random(5*1000, 7*1000));
  boolean jeZamereno =false;
  PVector zamereno;
  boolean agresivita;
  int casVystrelu;
  int velikostX, velikostY;  // velikost lodě
  int HP;  //strukturální integrita
  int MaxHP; 
  int shield;  //štít
  int MaxShield;
  int speed;
  int Mdemage; //max demage
  String oznaceni;
  int XP;
  int honor;
  int credits;
  int platina;
  float velikost=1.5;
  

  public AL_lod(PVector pozice_, float theta_, String ozn_) {

    oznaceni = ozn_;
    for (TableRow row : TShips.findRows(oznaceni, "Ship"))
    {
      velikostX=row.getInt("VelikostX");
      velikostY=row.getInt("VelikostY");
      HP=row.getInt("HP");
      shield=row.getInt("Shield");
      speed=row.getInt("Speed");
      Mdemage=row.getInt("Demage");
      XP=row.getInt("XP");
      honor=row.getInt("HONOR");
      credits=row.getInt("CREDITS");
      platina=row.getInt("PLATINA");
    }
    MaxHP=HP;
    MaxShield=shield;
    ALstrely = new ArrayList<Munice>();
    pozice = pozice_;
    rychlost = new PVector(0, 0);
    rotace = theta_;
    cil.set(pozice);
    cill.set(pozice);
    ALpremisteni=millis();
  } 

  void update() {

    AL();
    int dalkaCile;

    if (jeZamereno) {
      dalkaCile=150;
    } else {
      dalkaCile=15;
    }

    if (PVector.dist(pozice, cill)>= dalkaCile) {

      rychlost.set(cil);
      rychlost.normalize();
      rychlost.mult(zrychleni);
      rychlost.limit(3); 
      pozice.add(rychlost);       // k pozici se přičte rychlost
    }
  }

  void render() {                                              //renderování

    pushMatrix();
    shapeMode(CENTER);
    imageMode(CENTER);
    translate(pozice.x, pozice.y);     //posunutí na pozici
    rotate(rotace);                                            //rotace
    fill(0);   
    //  shape(Streuner, 0, 0, velikostX*2, velikostY*2);

    image(Streuner1, 0, 0, velikostX*2, velikostY*2);
    noFill();
    stroke(255, 0, 0);
    // ellipse(0, 0, 400, 400);    //detekční zóna

    popMatrix();

    shield();

    if (senzory) {
      renderBar(pozice.x, pozice.y, HP, shield, MaxHP, MaxShield);
    }
  }

  void shield() {
    if (shield>0) {
      pushMatrix();
      imageMode(CENTER);
      translate(pozice.x, pozice.y);     //posunutí na pozici

      if (velikostX>=velikostY) {
        image(stit, 0, 0, velikostX*2.5, velikostX*2.5);
      } else
      {
        image(stit, 0, 0, velikostY*2.5, velikostY*2.5);
      }
      popMatrix();
    }
  }

  void AL() {

    int r1=100, r2 = 400;
    if (PVector.dist(ship.pozice, pozice)<=200) {

      jeZamereno=true;
      zamereno=ship.pozice;
    }

    if (jeZamereno) {

      cil.set( ship.pozice);
      cill.set(cil);
      cil.sub(pozice);
      rotace=atan2(cill.y-pozice.y, cill.x-pozice.x)+PI/2;
      ALautomatickyKanon(pozice, ship.pozice);
    } else
      if (casOmezovac(ALpremisteni, casPremisteni)) {   

        int vzdalenost = int(random(r1, r2));
        cil= PVector.random2D();   
        cil.mult(vzdalenost);
        cill.set(cil);
        cill.add(pozice);
        rotace=atan2(cill.y-pozice.y, cill.x-pozice.x)+PI/2;
        ALpremisteni=millis();

        if ( cill.x<20 || cill.y<20 || cill.x>mapSirka-20 || cill.y>mapVyska-20) {
          ALpremisteni-=10000; 
          AL();
        }
      }
  }
  void ALautomatickyKanon(PVector poz_, PVector cil_) {

    if (casOmezovac(casVystrelu, 500)==true) {
      float radius = 200; // radius zaměřování

      if (PVector.dist(poz_, zamereno)<radius) {

        MuniceCil = new PVector(cil_.x, cil_.y);
        vychoziX=poz_.x;
        vychoziY=poz_.y;
        theta=atan2(cil_.y-vychoziY, cil_.x-vychoziX)+PI/2;
        ALstrely.add(new Munice(MuniceCil, theta, Mdemage, 200 ));

        casVystrelu=millis();
      }
    }
  }
  void zasah() {

    if (ALstrely.size()>0) {
      for (int i = ALstrely.size()-1; i >= 0; i--) {
        Munice munice = (Munice) ALstrely.get(i);

        if (PVector.dist(munice.pozice, ship.pozice)<30) {
           if (ship.shield>0) {
              ship.shield-=munice.dmg;
            } else {
              ship.HP-=munice.dmg;
            }
              
          println("ship HP: "+ ship.HP);

          if (ship.HP<=0) {
            ship.destroy();
          }
          ALstrely.remove(i);
        }
        if (munice.Ppozice.mag()>munice.dostrel) {
          ALstrely.remove(this);
        }
      }
      for (int i = ALstrely.size()-1; i >= 0; i--) {
        Munice munice = (Munice) ALstrely.get(i);
        munice.update();
        munice.render();

        if (PVector.dist(munice.Ppozice, munice.pozice)>munice.dostrel ) {  //pokud je munice za hranicí dostřelu zničí se

          ALstrely.remove(i);
        }
      }
    }
  }

  void destroy() {

    ARvybuchy.add (new Anime(pozice.x, pozice.y, 20, 8, millis()));
    println("destroyOOO");
    jeZamereno=false;
    uzivatel.XP_+=XP; //Body zkušenosti
    uzivatel.honor_+=honor; //čest
    uzivatel.kredity_+=credits;
    uzivatel.platina_+=platina;
    uzivatel.update();
  }
}


class ALKanon {
  PVector pozice = new PVector(0, 0);
  PVector cil = new PVector(0, 0);
  PVector ShipPoz = new PVector(0, 0);
  PVector Temp = new PVector(0, 0);
  float rotace;
  float delka;
  PVector v = new PVector(0, 0);
  int casVystrelu;
  String oznaceni;
  int dmg; 
  int weight;
  int dostrel;
  int nabDoba;


  ALKanon(float x_, float y_, String ozn_) {

    oznaceni=ozn_;
    for (TableRow row : TZbrane.findRows(oznaceni, "jmeno"))
    {
      dmg=row.getInt("DMG");
      weight=row.getInt("weight");
      dostrel=row.getInt("dostrel");
      nabDoba=row.getInt("nabijeni");
    }

    pozice= new PVector(x_*2, y_*2);
    cil= new PVector(0, 0);
    v.set(pozice);
    delka=v.mag();
    rotace=alfa-PI;
  }
  void update() {   

    pozice= PVector.fromAngle(alfa+PI/2);
    pozice.mult(delka);
    ShipPoz.set(ship.pozice);                           //pozice lodi
    pozice.add(ShipPoz);

    if ((druh_ozn==1 && utok) || (druh_ozn==4 && utok)) {
      rotace=atan2(oznObj.y-pozice.y, oznObj.x-pozice.x)-PI/2;
      Temp.set(pozice);
      automatickyKanon(Temp, oznObj);
    } else {
      rotace=alfa-PI;
    }
  }
  void render() {

    pushMatrix();
    translate(pozice.x, pozice.y);
    stroke(0, 255, 0);
    rotate(rotace+PI);
    image(delo1, 0, 0, 17, 23);
    popMatrix();
  }

  void automatickyKanon(PVector poz_, PVector cil_) {

    if (druh_ozn==1 || druh_ozn==4) {
      if (casOmezovac(casVystrelu, nabDoba)==true) {
        float radius = dostrel; // radius zaměřování

        if (PVector.dist(poz_, oznObj)<radius) {

          MuniceCil = new PVector(cil_.x, cil_.y);
          vychoziX=poz_.x;
          vychoziY=poz_.y;
          beta=atan2(cil_.y-vychoziY, cil_.x-vychoziX)+PI/2;
          ship.ARstrely.add(new Munice(MuniceCil, beta, dmg, dostrel ));    //ARlode

          casVystrelu=millis();
        }
      }
    }
  }
}