
//ship
//kanon


class Ship {   // třída loď
  ArrayList<Munice> ARstrely;
  PVector pozice;      //pozice
  PVector rychlost;      //velocity
  float rotace;  
  float zrychleni= 50;
  PVector cil;
  int pcas;
  int i;
  boolean tran=false;
  int seq;
  boolean budeTran=false;
  boolean jeTran=false;
  boolean konecTran=true;
  boolean sebrano=false;
  float velikostX, velikostY;  // velikost lodě
  float HP;  //strukturální integrita
  float MaxHP; 
  float shield;  //štít
  float MaxShield;
  int speed;
  int Mdemage; //max demage
  int vaha; //váha
  int Smoduly; //standartní moduly = generátory
  int Tmoduly; //útočné moduly = zbraně
  int cargo; // nákladový prostor
  String oznaceni;
  int dmg;
  int[] surovina = new int [20];

  int energie;
  int Vsoustave=1;
  int Vmape=1;

  int nainsZbrani=0;
  int nainsGene=0;
  boolean prvnitran=false;
  
  int modZamereni=0;
  
  

  public Ship(PVector pozice_, float rotace_, String ozn_) {

    oznaceni=ozn_;
    for (TableRow row : TShips.findRows(oznaceni, "Ship"))
    {
      velikostX=row.getInt("VelikostX");
      velikostY=row.getInt("VelikostY");
      HP=row.getInt("HP");
      speed=row.getInt("Speed");
      Smoduly=row.getInt("Generatory");
      Tmoduly=row.getInt("Zbrane");
      cargo=row.getInt("Cargo");
    }

    TableRow row = table.getRow(0); 
    surovina[0]=row.getInt("fe");
    surovina[1]=row.getInt("h");
    surovina[2]=row.getInt("n");
    surovina[3]=row.getInt("si");
    surovina[4]=row.getInt("al");
    surovina[5]=row.getInt("c");
    surovina[6]=row.getInt("u");
    surovina[7]=row.getInt("di");

    lodRestart=false;
    MaxHP=HP;
    MaxShield=shield;
    ARstrely = new ArrayList<Munice>();
    pozice = pozice_; //println(pozice);
    rychlost = new PVector(0, 0);
    alfa = rotace_;
    cil= pozice; //println(cil);
    Mvect= pozice; //println(Mvect);




    for (int i=0; i<Smoduly; i++) {
      TableRow row1 = shipConfMod.getRow(i);
      String mod=row1.getString("jmeno");

      for (TableRow row2 : moduly.findRows(mod, "jmeno"))
      {
        energie+=row2.getInt("energie");
        String bon=row2.getString("bonus");

        if (bon.equals("shield")) {
          shield=row2.getInt("shield");
        } else if (bon.equals("speed")) {
          speed+=row2.getInt("speed");
        }
      }
    }
    TableRow rowCnf = TcfgLod.getRow(0);
    nainsZbrani=rowCnf.getInt("insZbrani");
    nainsGene=rowCnf.getInt("insGene");

    napln();
  } 

  void napln() {                     // naplní zbraně, generátory a přepočítá statusy
    ARkan= new ArrayList<Kanon>(); 
    TableRow rowS = TShips.findRow(oznaceni, "Ship");

    for (int i=0; i<rowS.getInt("Zbrane"); i++) {
      TableRow rowCl = TcfgLod.getRow(i);
      String s=rowCl.getString("zbrane");


      String s2="0";
      if (s.equals(s2)==false) {
        println("zaplnene misto");
        int x=rowCl.getInt("z_x");
        int y=rowCl.getInt("z_y");
        ARkan.add(new Kanon(x, y, s)); // umisteni kanonu na ship
      }
    }

    int zakladSh= rowS.getInt("Shield");              //načte základní hodnoty a nastaví je potom přičte podle generátorů
    int zakladSp= rowS.getInt("Speed");

    MaxShield=zakladSh;                                 
    speed=zakladSp;

    for (int i=0; i<rowS.getInt("Generatory"); i++) {
      TableRow rowCl = TcfgLod.getRow(i);
      String s=rowCl.getString("generatory");

      String s2="0";
      if (s.equals(s2)==false) {
        println("zaplnene misto");
        if (s.charAt(0)=='s') {                       // je to štít

          TableRow row = TStity.findRow(s, "jmeno");
          MaxShield+=row.getInt("stit");
          shield=MaxShield;
        } else {                                      // je to pohon
          TableRow row = TPohony.findRow(s, "jmeno");
          speed+=row.getInt("pohon");
        }
      }
    }
  }


  void update() {

    cil.normalize();
    rychlost.set(cil);
    rychlost.mult(zrychleni);
    rychlost.limit(speed/60);
    pozice.add(rychlost);       // k pozici se přičte rychlost
    
  }

  void render() {                                              //renderování

    if ((druh_ozn==1 && utok) || (druh_ozn==4 && utok)) {
      alfa=atan2(oznObj.y-pozice.y, oznObj.x-pozice.x)+PI/2; 
    }


    pushMatrix();
    shapeMode(CENTER);
    imageMode(CENTER);
    translate(pozice.x, pozice.y);     //posunutí na pozici
    rotate(alfa);                                            //rotace
    fill(0);
    // shape(Egla, 0, 0, velikostX*2, velikostY*2);
    image(Fodienda, 0, 0, velikostX*2, velikostY*2);
    popMatrix();

    shield();

    renderBar(pozice.x, pozice.y, HP, shield, MaxHP, MaxShield);
     client.publish("/hra/uzivatel/x",str(pozice.x));
      client.publish("/hra/uzivatel/y",str(pozice.y));
       client.publish("/hra/uzivatel/r",str(alfa));
  }

   

  void zbranovySystem() {

    for (int y = ARkan.size()-1; y >= 0; y--) {
      Kanon kan = (Kanon) ARkan.get(y);
      kan.update();
      kan.render();
    }
  }
  
  void shield() {
    if (shield>0) {
      pushMatrix();

      imageMode(CENTER);
      translate(pozice.x, pozice.y);     //posunutí na pozici
      //rotace
      if (velikostX>=velikostY) {
        image(stit, 0, 0, velikostX*2+50, velikostX*2+50);
      } else
      {
        image(stit, 0, 0, velikostY*2+50, velikostY*2+50);
      }
      popMatrix();
    }
  }

  void transport() {

    if (budeTran) {


      if (casOmezovac(pcas, int(1000/6))) {
        println("bude tran"+seq);
        seq+=1;
        frame=frame +1;
        pcas=millis();
      }

      if (seq!=23) {
        pushMatrix();
        imageMode(CENTER);
        translate(pozice.x, pozice.y+30); 
        image(images[frame], 0, 0, 13*2, 20*2);
        popMatrix();
      } else {
        konecTran=true;
        budeTran=false;
        println("konec transportu");
        i=0;
        seq=0;
        frame=1;
      }

      if (seq==1) {
        println("vyber druhu");
        if (druh_ozn==2) {
          Box box = (Box) AR_Boxy.get(oznObjC);
          box.seq=1;
        } else
          if (druh_ozn==3) {    
            Asteroid asteroid = (Asteroid) ARkameni.get(oznObjC);
            asteroid.seq=1;
          }
        druh_ozn=0;
      }


      println("seq: "+frame);
    }
  }



  void zasah() {

    if (ARstrely.size()>0) {

      for (int y = ARlode.size()-1; y >= 0; y--) {
        AL_lod terc = (AL_lod) ARlode.get(y);

        for (int i = ARstrely.size()-1; i >= 0; i--) {
          Munice munice = (Munice) ARstrely.get(i);

          if (PVector.dist(munice.pozice, terc.pozice)<30) {
            if (terc.shield>0) {
              terc.shield-=munice.dmg;
            } else {
              terc.HP-=munice.dmg;
            }


            if (terc.HP<=0) {
              terc.destroy();
              ARlode.remove(y);
              if (oznObj==terc.pozice) {
                druh_ozn=0;
                oznObj=new PVector (0, 0);
                oznObjC=0;
                utok=false;
              }
            }

            ARstrely.remove(i);

            break;
          }
        }
      } // if jestli je munice



      //_________________________ asteroid


      for (int y = ARkameni.size()-1; y >= 0; y--) {
        Asteroid asteroid = (Asteroid) ARkameni.get(y);

        for (int i = ARstrely.size()-1; i >= 0; i--) {
          Munice munice = (Munice) ARstrely.get(i);

          if (PVector.dist(munice.pozice, asteroid.pozice)<30) {
            if (asteroid.HP>0) {
              asteroid.HP-=munice.dmg;
            }
            if (asteroid.typ>1) {
              if (asteroid.HP<=0) {
                println("znicen");
                asteroid.tristeni();
                println("po tristeni");
                if (oznObj==asteroid.pozice) {
                  druh_ozn=0;
                  oznObj=new PVector (0, 0);
                  oznObjC=0;
                  utok=false;
                }
              }
            }
            ARstrely.remove(i);

            break;
          }
        }
      } // if jestli je munice

      for (int i = ARstrely.size()-1; i >= 0; i--) {
        Munice munice = (Munice) ARstrely.get(i);
        munice.update();
        munice.render();

        if (PVector.dist(munice.Ppozice, munice.pozice)>munice.dostrel ) {  //pokud je munice za hranicí dostřelu zničí se

          ARstrely.remove(i);
        }
      }
    }
  }

  void destroy() {

    if (HP<=0) {

      ship  = new Ship(new PVector(width/2, height/2), 0, "Fodienda");

      druh_ozn=0;
      oznObj=new PVector (0, 0);
      oznObjC=0;
      utok=false;
      for (int y = ARlode.size()-1; y >= 0; y--) {
        AL_lod terc = (AL_lod) ARlode.get(y);
        terc.jeZamereno=false;
      }
    }
  }

  void oprava() {
    HP=MaxHP;
    shield=MaxShield;
  }
}


class Kanon {
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
  float x, y;

  Kanon(float x_, float y_, String ozn_) {
    x=x_;
    y=y_;
    oznaceni=ozn_;
    for (TableRow row : TZbrane.findRows(oznaceni, "jmeno"))
    {
      dmg=row.getInt("dmg");
      //    weight=row.getInt("weight");
      dostrel=300;
      nabDoba=row.getInt("nabijeni");
    }

    pozice= new PVector(x*2, y*2);
    cil= new PVector(0, 0);
    v.set(pozice);
    delka=v.mag();
    rotace=alfa-PI;
  }
  void update() {   

    // pozice= PVector.fromAngle(alfa+PI/2);
    float u=atan2(y, x);
    pozice= PVector.fromAngle(alfa+u);
    pozice.mult(delka);
    ShipPoz.set(ship.pozice);
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
          ship.ARstrely.add(new Munice(MuniceCil, beta, dmg, dostrel ));

          casVystrelu=millis();
        }
      }
    }
  }
}
