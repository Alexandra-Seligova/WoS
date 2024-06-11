// samostatný kód
//balíček pro nakupování itemů a lodí v rámci GUI shop
// pro otevření GUI_shop slouží příkaz "GUIshop();"



void GUIshop() {  // GUI pro bránu
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


  textAlign(CENTER, CENTER);
  textFont(f, 40);
  text("SHOP", width/2, 55);

  popMatrix();
  popStyle();

  switch(shopUR) {
  case 0:
    GuiItem(1, "LODĚ", 2);
    GuiItem(2, "ZBRANĚ", 2);
    GuiItem(3, "ŠTÍTY", 2);
    GuiItem(4, "POHONY", 2);
    break;
  case 1:   //GuiItem(int cislo, String s, int i_, int sloup)
    GuiItem(1, "Egla", 4);
    GuiItem(2, "Fodienda", 4);
    GuiItem(3, "Lod_3", 4);
    GuiItem(4, "Lod_4", 4);
    GuiItem(5, "Lod_5", 4);
    GuiItem(6, "Lod_6", 4);
    GuiItem(7, "Lod_7", 4);
    GuiItem(8, "Lod_8", 4);
    break;
  case 2:
    GuiItem(1, "kanon1", 4);
    GuiItem(2, "kanon2", 4);
    GuiItem(3, "kanon3", 4);
    GuiItem(4, "kanon4", 4);
    GuiItem(5, "raketomet1", 4);
    GuiItem(6, "raketomet2", 4);
    GuiItem(7, "raketomet3", 4);
    GuiItem(8, "raketomet4", 4);
    break;
  case 3:
    GuiItem(1, "stit1", 4);
    GuiItem(2, "stit2", 4);
    GuiItem(3, "stit3", 4);
    break;
  case 4:
    GuiItem(1, "pohon1", 4);
    GuiItem(2, "pohon2", 4);
    GuiItem(3, "pohon3", 4);
    break;

  default:
    break;
  }
  if (okno) {
    if (uzivatel.volInven-gEdit.fullZbra-gEdit.fullGene!=0 ) {
    potvrzTab.update();
    }else{
      stanice.potvrzTab=false;
    }
  }
  
  if (tlacitko(Cx+width-95, Cy+15, 80, 80)) {
    shopUR=0;
    mx=0;
    my=0;
    GS=0;
  }
}



void GuiItem(int cislo, String s, int sloup) {
  int sirkaPole, vyskaPole;  // šířka a výška okna
  int poleX, poleY;           // pozice okna 
  String jmeno;
  int oznaceni;
  int cenaK, cenaP;



  sirkaPole=(width-(50*sloup+50))/sloup;
  vyskaPole=(height-150-110)/2;
  if ((cislo%2) ==0) {
    poleY=110+100+vyskaPole;
    poleX=50+((cislo/2)-1)*(sirkaPole+50);
  } else {
    poleY=110+50;
    poleX=50+(cislo/2)*(sirkaPole+50);
  }
  jmeno=s;
  oznaceni=cislo;

  pushStyle();              // XP čára
  pushMatrix();

  stroke(0, 255, 0);
  noFill();
  translate(poleX, poleY);
  rect(0, 0, sirkaPole, vyskaPole);

  textAlign(CENTER, CENTER);
  textFont(f, 50);   
  text(jmeno, (sirkaPole/2), (vyskaPole/2));

  //  text(, (sirkaPole/2), (vyskaPole/2)+60);

  popMatrix();
  popStyle();

  if (stanice.potvrzTab==false) {

    if (tlacitko(Cx+poleX, Cy+poleY, sirkaPole, vyskaPole)) {
      println("tlacitko"+cislo);
      if (shopUR==0) {
        shopUR=cislo;
      } else
        if (shopUR>0) {
          okno=true;
          cisOkno=oznaceni;
          vytvorOkno=true;
        }
      mx=0;
      my=0;
    }


    if (okno&& cisOkno==oznaceni&& vytvorOkno==true) {
      println("x: "+(uzivatel.volInven-gEdit.fullZbra-gEdit.fullGene));
     // if (uzivatel.volInven-gEdit.fullZbra-gEdit.fullGene!=0 ) {
         println("pokracuju");
        switch(shopUR) {  //když kliknu
        case 0:


          shopUR=oznaceni;
          println(shopUR);

          break;
        case 1: //loďe


          break;
        case 2: //zbraně



          {
            TableRow row = TZbrane.getRow(oznaceni-1);
            cenaK=row.getInt("cena_kredity");
            cenaP=row.getInt("cena_platina");
            if (cenaK>0) {
              println(cenaK);
              potvrzTab=new PotvrzTab(cenaK, 0, oznaceni);
            } else { 
              potvrzTab=new PotvrzTab(cenaP, 1, oznaceni);
            }
          }
          break;
        case 3: //štít
          {
            TableRow row = TStity.getRow(oznaceni-1);
            cenaK=row.getInt("cena_kredity");
            cenaP=row.getInt("cena_platina");
            if (cenaK>0) {
              println(cenaK);
              potvrzTab=new PotvrzTab(cenaK, 0, oznaceni+8);
            } else { 
              potvrzTab=new PotvrzTab(cenaP, 1, oznaceni+8);
            }
          }
          break;
        case 4:  //pohon
          {
            TableRow row = TPohony.getRow(oznaceni-1);
            cenaK=row.getInt("cena_kredity");
            cenaP=row.getInt("cena_platina");
            if (cenaK>0) {
              println(cenaK);
              potvrzTab=new PotvrzTab(cenaK, 0, oznaceni+8+3); //+8+3 prvnich 8+3 itemů
            } else { 
              potvrzTab=new PotvrzTab(cenaP, 1, oznaceni+8+3);
            }
          }
          break;
        }
        println("pokracuju 2");
   //   }
      mx=0;
      my=0;
      vytvorOkno=false;
    }
  }
}