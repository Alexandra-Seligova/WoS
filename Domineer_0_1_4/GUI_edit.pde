// samostatný kód
//balíček pro editaci konfigurace lodě, instalování nových komponent nebo jejich odebrání
//GUI funguje jako objekt a proto je potřeba ho vytvořit: GuiEdit gEdit; GuiEditOkno gEditOk;   
// gEdit=new GuiEdit();
// pro otevření GUI_edit slouží příkaz "gEdit.update();"

class GuiEdit {

  int druhOzn;                            // 0=inventář, 1= zbraně, 2= generátory;
  int cisOzn;                             // číslo označeného políčka
  int fullInv=0, fullZbra=0, fullGene=0;  //
  int volInv=0, volZbra=0, volGene=0;     //
  int zacInv=0;                           //
  float block1, block2, block3;           //
  float okno, spka;                       //okno = okno pro item, spka = šipky pro procházení inventářem
  float Vmez, Mmez, Omez;                 // Vmez = velká mezera, Mmez = malá; Omez = mezera mezi okny
  float velikost=1920;                    //
  float N;                                // násobek pro upravení vůči displeji
  float gEditGenY;                        //vyska pro okna a nápis generatory
  boolean JeOzn=false;                    //nějaké políčko je označeno
  

  GuiEdit() {
    N=width/velikost;
    okno=100*N;
    Mmez=20*N;
    Vmez=50*N;
    spka=60*N;
    Omez=10*N;

    block3=Mmez+spka+2*Vmez+4*okno+3*Omez  ;
    block2=2*Vmez+7*okno+6*Omez  ;
    block1=width-(block2+block3)  ;
    vytvorOkna();
  }

  void vytvorOkna() {                       //
    int cisloARokna=-1;
    AReditOk=new ArrayList<GuiEditOkno>();

    TableRow rowS = TShips.findRow(ship.oznaceni, "Ship");
    int pocZ=rowS.getInt("Zbrane");
    int pocG=rowS.getInt("Generatory");


    for (int i=1; i<=pocZ; i++) {   // zbraně
      cisloARokna+=1;
      AReditOk.add(new GuiEditOkno(block1, 110, i, cisloARokna, okno, Omez, 1));
      volZbra+=1;
    }

    int dalsi=0;
    for (int i=0; i<rowS.getInt("Zbrane"); i++) {  //naplni zbrane
      TableRow row =TcfgLod.getRow(i); 
      String s=row.getString("zbrane");
      String s2="0";

      if (s.equals(s2)==false) {
        TableRow roww = Tcnfg.findRow(s, "jmeno");
        GuiEditOkno okno = (GuiEditOkno) AReditOk.get(dalsi);
        okno.Full=true;
        okno.druh=roww.getInt("druh");
        okno.jmeno=roww.getString("jmeno");
        okno.ozn=roww.getString("oznaceni");
        fullZbra+=1;
      } else {    //místo je prázdné
      }
      dalsi+=1;
    }


    gEditGenY=110+75;
    gEditGenY+= ((20/7)+1)* (okno+Omez);
    //  gEditGenY+=75;

    for (int i=1; i<=pocG; i++) {  // generátory
      cisloARokna+=1;
      AReditOk.add(new GuiEditOkno(block1, gEditGenY, i, cisloARokna, okno, Omez, 2));
      volGene+=1;
    } 

    dalsi=pocZ;
    for (int i=8; i<Tcnfg.getRowCount(); i++) {  //naplni generatory
      TableRow row =Tcnfg.getRow(i); 

      int pocItemu=row.getInt("pocet");
      for (int y=0; y<pocItemu; y++) {

        GuiEditOkno okno = (GuiEditOkno) AReditOk.get(dalsi);
        okno.Full=true;
        okno.druh=row.getInt("druh");
        okno.jmeno=row.getString("jmeno");
        okno.ozn=row.getString("oznaceni");
        dalsi+=1;
        fullGene+=1;
      }
    }


    for (int i=1; i<=28; i++) { //inventar  zacina na 35.
      cisloARokna+=1;
      AReditOk.add(new GuiEditOkno(block1+block2, 110, i, cisloARokna, okno, Omez, 0));
      volInv+=1;
    }


    dalsi=pocZ+pocG;
    for (int i=0; i<myModuly.getRowCount(); i++) {  //naplni inventar
      TableRow row =myModuly.getRow(i); 

      int pocItemu=row.getInt("pocet");
      for (int y=0; y<pocItemu; y++) {
        GuiEditOkno okno = (GuiEditOkno) AReditOk.get(dalsi);
        okno.Full=true;
        okno.druh=row.getInt("druh");
        okno.jmeno=row.getString("jmeno");
        okno.ozn=row.getString("oznaceni");
        dalsi+=1;

        fullInv+=1;
      }
    }



    volInv-=fullInv;
    volZbra-=fullZbra;
    volGene-=fullGene;



    uzivatel.pocInventar();  //zapise status inventare
    uzivatel.volInven=volInv;
  } //vytvor okna a napln je

  void update() {

    for (int i = AReditOk.size()-1; i >= 0; i--) {  

      GuiEditOkno okno = (GuiEditOkno) AReditOk.get(i);
      if (okno.Full) {
        if (okno.onClick()) {
          println("je kliknuto na porzici AR: ", i);
          println("je kliknuto na okno s cislem: ", okno.cisloOk);
          println("je kliknuto na Gokno s cislem: ", okno.cisloGok);
          println("status JsemOzn: ", okno.JsemOzn);

          if (okno.JsemOzn==false) {
            for (int y = AReditOk.size()-1; y >= 0; y--) {
              GuiEditOkno okn = (GuiEditOkno) AReditOk.get(y);
              okn.JsemOzn=false;
            }
            okno.JsemOzn=true;
            JeOzn=true;
            druhOzn=okno.pozB;
            cisOzn=i;
          } else {
            okno.JsemOzn=false;
            JeOzn=false;
          }
        }
      }
    }

    if (tlacitko(Cx+0, Cy+height-110-60, block1/2, 60)) {
      println("nainstaluj");
      mx=0;
      my=0;
      if (druhOzn==0) {
        nainstaluj();
      } else {
        odinstaluj();
      }
    } else if (tlacitko(Cx+block1/2, Cy+height-110-60, block1/2, 60)) {
      GuiEditOkno okno = (GuiEditOkno) AReditOk.get(cisOzn);
      if (JeOzn && okno.pozB==0) {
        println("prodej");
        prodej();
        mx=0;
        my=0;
      }
    } else if (tlacitko(Cx+width-95, Cy+15, 80, 80)) {
      mx=0;
      my=0;
      GS=0;
    }
    render();
  }


  void render() {

    pushStyle();             
    pushMatrix();

    strokeWeight(1);
    fill(6, 19, 63);             // výplň
    noStroke();                  // obrys
    rect(0, 0, width, 110);
    rect(height-110, 0, width, height);
    fill(13, 138, 155);            
    rect(0, 110, width, height-110);

    stroke(255, 0, 0);
    fill(0, 237, 237);
    rect(width-95, 15, 80, 80);        // křížek
    fill(255, 0, 0);
    line(width-20, 20, width-90, 90);
    line(width-20, 90, width-90, 20);

    line(0, height-110, width, height-110);

    strokeWeight(3);
    line(block1, 110, block1, height-110);
    line(0, 110+block1, block1, 110+block1);
    line(block1+block2, 110, block1+block2, height-110);

    strokeWeight(1);


    textAlign(CENTER, CENTER);
    textFont(f, 40);
    text("EDIT", width/2, 55);
    textAlign(LEFT, CENTER);
    textFont(f, 35);
    text("ZBRANĚ", block1+70, 110+37); 
    text("GENERÁTORY", block1+70, gEditGenY+37);
    text("INVENTÁŘ", block1+block2+70, 110+37);

    if (JeOzn) {
      line(0, height-110-60, block1, height-110-60);
      line(0, height-110-120, block1, height-110-120);
      line(block1/2, height-110-60, block1/2, height-110);
      textAlign(CENTER, CENTER);

      text("cena", block1/2, height-200);
      if (druhOzn==0) {
        text("instalovat", block1/4, height-140);
      } else {
        text("odinstalovat", block1/4, height-140);
      }
      GuiEditOkno okno = (GuiEditOkno) AReditOk.get(cisOzn);
      if (JeOzn && okno.pozB==0) {
        text("prodej", block1/4*3, height-140);
      }
    }
    popMatrix();
    popStyle();



    pushStyle();            // info o lodi    
    pushMatrix();

    translate(0, block1+110);

    textAlign(CORNER, CENTER);
    textFont(f, 35);
    text("Info o lodi", 20, 100);

    textFont(f, 25);
    text("Jméno: "+ship.oznaceni, 20, 150); 
    text("HP: "+ship.MaxHP, 20, 180);
    text("Shield: "+ship.MaxShield, 20, 210);
    text("Speed: "+ship.speed, 20, 240);




    popMatrix();
    popStyle();

    for ( GuiEditOkno okno : AReditOk) {
      okno.render();
    }
  }



  void prodej() {
    GuiEditOkno okno = (GuiEditOkno) AReditOk.get(cisOzn);
    TableRow rowI = myModuly.findRow(okno.jmeno, "jmeno");
    TableRow rowS = TShips.findRow(ship.oznaceni, "Ship");  
    String s=okno.jmeno;
    int cena=0;

    println("v prodeji");
    println("druh: "+okno.druh);

    if (okno.pozB==0) {  //pozice bloku je inventář
      if (okno.druh%2==1 ) {//pokud je to zbran
        println("prodávám zbran: "+ s);

        TableRow row = TZbrane.findRow(s, "jmeno");
        cena=row.getInt("prodej");
      } else if (okno.druh%2==0 ) {//pokud je to Generátor
        println("prodávám Generátor");  

        if (s.charAt(0)=='s') {                       // je to štít

          TableRow row = TStity.findRow(s, "jmeno");
          cena=row.getInt("prodej");
        } else {                                      // je to pohon
          TableRow row = TPohony.findRow(s, "jmeno");
          cena=row.getInt("prodej");
        }
      }
      int pocetI=rowI.getInt("pocet");
      pocetI-=1;
      rowI.setInt("pocet", pocetI);



      saveTable(myModuly, "data/naklad.csv");
      saveTable(Tcnfg, "data/cnfg.csv");
      String uloz="data/"+"cfg_"+"Fodienda"+".csv";
      saveTable(TcfgLod, uloz);


      println("cena: "+cena);

      uzivatel.prodej(cena);
      reload();
    }
  }



  void nainstaluj() { // nainstalování itemu do lodě
    int b=0;
    GuiEditOkno okno = (GuiEditOkno) AReditOk.get(cisOzn);
    TableRow rowI = myModuly.findRow(okno.jmeno, "jmeno");
    TableRow rowC = Tcnfg.findRow(okno.jmeno, "jmeno");
    TableRow rowS = TShips.findRow(ship.oznaceni, "Ship");




    if (okno.druh%2==1 && rowS.getInt("Zbrane")>ship.nainsZbrani ) {//pokud je to zbran
      println("instaluji zbran");
      if (volZbra>0) {
        b=1;

        for (int i=0; i<rowS.getInt("Zbrane"); i++) {
          TableRow rowCl = TcfgLod.getRow(i);
          String s=rowCl.getString("zbrane");
          String s2="0";
          if (s.equals(s2)==true) {
            println("prazdne misto");
            rowCl.setString("zbrane", okno.jmeno);
            break;
          }
        }
        ship.nainsZbrani+=1;
        TableRow roww = TcfgLod.getRow(0);
        roww.setInt("insZbrani", ship.nainsZbrani);
      }
    } else if (okno.druh%2==0 && rowS.getInt("Generatory")>ship.nainsGene ) {//pokud je to Generátor
      println("instaluji generator");
      if (volGene>0) {
        b=1;
        for (int i=0; i<rowS.getInt("Generatory"); i++) {
          TableRow rowCl = TcfgLod.getRow(i);
          String s=rowCl.getString("generatory");
          String s2="0";
          if (s.equals(s2)==true) {
            println("prazdne misto");
            rowCl.setString("generatory", okno.jmeno);
            break;
          }
        }
        ship.nainsGene+=1;
        TableRow roww = TcfgLod.getRow(0);
        roww.setInt("insGene", ship.nainsGene);
      }
    }

    if (b==1) {  // pokud opravdu došlo k instalaci itemu  zapiš ho do configurací
      int pocetI=rowI.getInt("pocet");
      pocetI-=1;
      rowI.setInt("pocet", pocetI);

      int pocetC=rowC.getInt("pocet");
      pocetC+=1;
      rowC.setInt("pocet", pocetC);
    }






    saveTable(myModuly, "data/naklad.csv");
    saveTable(Tcnfg, "data/cnfg.csv");


    String uloz="data/"+"cfg_"+"Fodienda"+".csv";

    saveTable(TcfgLod, uloz);
    ship.napln();
    reload();
  }

  void odinstaluj() {

    GuiEditOkno okno = (GuiEditOkno) AReditOk.get(cisOzn);

    TableRow rowI = myModuly.findRow(okno.jmeno, "jmeno");
    TableRow rowC = Tcnfg.findRow(okno.jmeno, "jmeno");
    TableRow rowS = TShips.findRow(ship.oznaceni, "Ship");
    int pocetI=rowI.getInt("pocet");
    pocetI+=1;
    rowI.setInt("pocet", pocetI);

    int pocetC=rowC.getInt("pocet");
    pocetC-=1;
    rowC.setInt("pocet", pocetC);



    if (okno.druh%2==1) {//pokud je to zbran
      println("odinstaluji zbran");

      TableRow rowCl = TcfgLod.getRow(okno.cisloOk-1);
      rowCl.setString("zbrane", "0");
      ship.nainsZbrani-=1;
      TableRow roww = TcfgLod.getRow(0);
      roww.setInt("insZbrani", ship.nainsZbrani);
    } else {//pokud je to Generátor
      println("odinstaluji generator");

      TableRow rowCl = TcfgLod.getRow(okno.cisloOk-1);
      rowCl.setString("generatory", "0");
      ship.nainsGene-=1;
      TableRow roww = TcfgLod.getRow(0);
      roww.setInt("insGene", ship.nainsGene);
    }


    saveTable(myModuly, "data/naklad.csv");
    saveTable(Tcnfg, "data/cnfg.csv");
    String uloz="data/"+"cfg_"+"Fodienda"+".csv";
    saveTable(TcfgLod, uloz);
    ship.napln();
    reload();
  }

  void reload() {
    gEdit=new GuiEdit();
  }
}






class GuiEditOkno {                        // jednotlivá okýnka pro databázi v GUI brány
  float velikost, mezera;

  int cisloGok, cisloOk;  //cisloGok==cislo v ARlistu, cisloOk= cislo okna v daném bloku
  String jmeno, ozn;
  float pozXz, pozYz, pozX, pozY;  //pozXz pozice X základní 
  int pozB; //pozice bloku ve kterém se vykresluje, 0=inventář, 1= zbraně, 2= generátory;
  int pocVrade;
  boolean JsemOzn=false;  //políčko je označeno
  boolean Full=false;  //jestli je okno obsazené
  int druh;  // liché=zbraně, sudé=generátory



  GuiEditOkno(float x_, float y_, int cislo, int cisG, float vel, float mezera_, int pozBlock) {

    velikost=vel;
    mezera=mezera_;
    cisloOk=cislo;
    cisloGok=cisG;
    pozB=pozBlock;

    switch(pozBlock) {
    case 0:
      pozXz=x_+50;
      pozYz=y_+70;
      break;
    case 1:

      pozXz=x_+50;
      pozYz=y_+70;
      break;
    case 2:
      pozXz=x_+50;
      pozYz=y_+70;
      break;
    }


    if (pozB==0) {
      pocVrade=4;
    } else {
      pocVrade=7;
    }
    if (cisloOk==0) {
      pozX=pozXz;
      pozY=pozYz;
    } else {
      for (int i=0; i<cisloOk; i++) {
        if ((i%pocVrade)!=0) {
          pozX+= velikost+mezera;
        } else {
          pozX=0;
        }
        pozY= (i/pocVrade)* (velikost+mezera);
      }
      pozX+=pozXz;
      pozY+=pozYz;
      /*
      if((pozY+velikost)>gEditGenY){
       gEditGenY=pozY+velikost;
       }
       */
    }
  }


  void render() {


    pushStyle();              // XP čára
    pushMatrix();

    stroke(0, 255, 0);
    noFill();
    translate(pozX, pozY);
    if (Full) {
      if (JsemOzn==true && gEdit.JeOzn && gEdit.cisOzn==cisloGok) {
        strokeWeight(2);
        stroke(255, 0, 0);
      } else {
        strokeWeight(1);
        stroke(0, 255, 0);
      }
    } else {
      strokeWeight(1);
      stroke(0, 200, 0);
    }
    rect(0, 0, velikost, velikost);

    textAlign(CENTER, CENTER);
    textFont(f, 20); 
    if (Full) {
      text(ozn, velikost/2, velikost/2);
    }
    fill(0, 255, 0);  


    popMatrix();
    popStyle();
  }

  boolean onClick() {

    if (tlacitko(Cx+pozX, Cy+pozY, velikost, velikost)==true) {
      mx=0;
      my=0;
      return true;
    } else {
      return false;
    }
  }
}