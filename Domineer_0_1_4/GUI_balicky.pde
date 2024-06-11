
void Gstanice() {   //  vykreslení prvního okna stanice               Oprava | Shop | editace
  int o1x =width/2-700;
  int o2x =width/2-200;
  int o3x =width/2+300;
  int oy=390;
  int osirka=400;
  int ovyska=300;

  rect(o1x, oy, osirka, ovyska);
  rect(o2x, oy, osirka, ovyska);
  rect(o3x, oy, osirka, ovyska);



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
  text("STANICE", width/2, 55);

  popMatrix();
  popStyle(); 



  if (tlacitko(Cx+width-95, Cy+15, 80, 80)) {
    mx=0;
    my=0;
    GS=0;
  }

  rect(o1x, oy, osirka, ovyska);
  rect(o2x, oy, osirka, ovyska);
  rect(o3x, oy, osirka, ovyska);

  textAlign(CENTER, CENTER);
  textFont(f, 40);
  text("Oprava", o1x+osirka/2, oy+ovyska/2);
  text("Shop", o2x+osirka/2, oy+ovyska/2);
  text("Editace", o3x+osirka/2, oy+ovyska/2);




  if (tlacitko(Cx+o1x, Cy+oy, osirka, ovyska)) {  //oprava
    mx=0;
    my=0;
    ship.oprava();
  }    
  if (tlacitko(Cx+o2x, Cy+oy, osirka, ovyska)) {  //shop
    mx=0;
    my=0;
    GS=3;
  } 
  if (tlacitko(Cx+o3x, Cy+oy, osirka, ovyska)) {  //editace
    mx=0;
    my=0;
    GS=4;
  }
}



void Gzakladni() {  //  vykreslení GUI grafiky lodi                   XP bar | kredity | HP | shield



  strokeWeight(2);


  fill(70, 105, 115, 220); // výplň
  stroke(30, 250, 255); // obrys

  beginShape();       //vlevo nahoře jmeno
  vertex(0, 0);
  vertex(200, 0);
  vertex(200, 10);
  vertex(180, 30);
  vertex(20, 30);
  vertex(0, 50);
  endShape(CLOSE);

  textAlign(LEFT);
  textFont(f, 20);                 
  fill(13, 255, 87);                        
  text(uzivatel.jmeno_+"  "+uzivatel.lvl_, 10, 20); 

  pushStyle();              // XP čára
  pushMatrix();
  strokeWeight(1);
  noFill();             // výplň
  stroke(30, 250, 255); // obrys
  translate(200, 2);
  rect(0, 0, width-380, 10);
  fill(30, 250, 255);
  //noStroke();
  strokeWeight(4);
  line(2, 5, (width-380-200)*uzivatel.XPbar_, 5 );   // XPbar
  popMatrix();
  popStyle();

  pushMatrix();                     //  v pravonahoře ikonky
  shapeMode(CORNER);
  translate(width-110, 0);
  shape(Inastav, 0, 0, 50, 50);
  translate(60, 0);
  shape(Imenu, 0, 0, 50, 50);
  popMatrix();

  pushStyle();                 // kredity platina
  pushMatrix();
  textFont(f, 16);  
  shapeMode(CENTER);
  noFill();
  stroke(30, 250, 255); // obrys
  translate(10, 35);
  quad(15, 0, 185, 0, 170, 15, 0, 15);
  shape(Ic, 25, 7, 8, 10);            // kredity ikona
  text(uzivatel.kredity_, 50, 13); 
  translate(0, 20);
  quad(15, 0, 185, 0, 170, 15, 0, 15);
  shape(Pt, 25, 7, 10, 10);           // Platina ikona
  text(uzivatel.platina_, 50, 13); 
  popMatrix();
  popStyle();




  pushMatrix();                     // hp a shield ukazatele
  noFill();
  translate(width-172, 60);   //HP
  if (ship.HP>0) {
    pushStyle();
    fill(0, 255, 0);
    noStroke();
    quad( 162, 0, 150, 15, 150-((ship.HP/ship.MaxHP)*150), 15, 162-((ship.HP/ship.MaxHP)*150), 0);

    popStyle();
  }
  quad(12, 0, 162, 0, 150, 15, 0, 15);



  translate(0, 30);   //štít
  if (ship.shield>0) {
    pushStyle();
    fill(0, 0, 255);
    stroke(0);
    quad( 162, 0, 150, 15, 150-((ship.shield/ship.MaxShield)*150), 15, 162-((ship.shield/ship.MaxShield)*150), 0);
    popStyle();
  }

  quad(12, 0, 162, 0, 150, 15, 0, 15);

  translate(0, 30);    //krabice
  quad(12, 0, 162, 0, 150, 15, 0, 15);
  popMatrix();






  pushMatrix();              // kříž

  translate(width-70, 52);
  fill(0, 255, 0); // výplň
  stroke(0, 200, 0); // obrys
  beginShape();
  vertex(0, 10);
  vertex(10, 10);
  vertex(10, 0);
  vertex(20, 0);
  vertex(20, 10);
  vertex(30, 10);
  vertex(30, 20);
  vertex(20, 20);
  vertex(20, 30);
  vertex(10, 30);
  vertex(10, 20);
  vertex(0, 20);
  endShape(CLOSE);

  translate(0, 30);           // štít
  fill(0, 0, 255); // výplň
  stroke(0, 0, 200); // obrys
  beginShape();
  vertex(0, 0);
  vertex(30, 0);
  vertex(30, 10);
  vertex(15, 30);
  vertex(0, 10);
  endShape(CLOSE);

  translate(0, 35);        //krabice
  fill(250, 150, 0); // výplň
  stroke(255); // obrys
  rect(0, 0, 20, 20);
  quad(0, 0, 20, 0, 25, -5, 5, -5);
  quad(20, 0, 25, -5, 25, 15, 20, 20);
  popMatrix();
} 



void Gtlacitka() {  //  vykreslení GUI grafiky lodi ovládání         útok | senzory

  pushStyle();

  imageMode(CORNER);                

  pushMatrix();

  translate(50, height-250);  // tlacitko senzoru
  image(GUIsenzory, 0, 0, 200, 100);
  popMatrix();

  pushMatrix();
  translate(50, height-375);  // tlacitko útoku
  image(GUIattack, 0, 0, 200, 100);


  popMatrix();

  popStyle();
}



void Gsenzory() {   //  ikona senzorů


  if (!senzory) { 
    senzory=true;
  } else { 
    senzory=false;
    println("senzory");
  }
}



void Gattack() {    //  ikona útoku 


  if (!utok) { 
    utok=true;
  } else { 
    utok=false;
    println("attack");
  }
}



void oznac(float vel_) {  //  označení cíle - vykreslení

  int r=15;
  pushMatrix();
  shapeMode(CENTER);

  translate(oznObj.x, oznObj.y);     //posunutí na pozici  
  fill(0);
  scale(vel_);
  image(oznaceni, 0, 0, r*3.5, r*3.5); 
  popMatrix();
}

  

void renderBar(float pozX, float pozY, float HP, float shield, float MaxHP, float MaxShield) {  //  vykreslení GUI grafiky lodi vykreslení        HP bar | Shield bar


  pushMatrix();
  translate(pozX, pozY-50);     //posunutí na pozici

  if (HP>0) {
    fill(0, 255, 0);
    noStroke();
    rect(-20, 0, (HP/MaxHP)*40, 3);
  }

  if (shield>0) {
    fill(0, 0, 255);
    noStroke();
    rect(-20, 4, (shield/MaxShield)*40, 3);
  }
  popMatrix();
}



void okno() {       // GUI okno info pro asteroid
  Asteroid asteroid = (Asteroid) ARkameni.get(oznObjC);

  float celkem=0;
  int pocR=1;
  String s="";
  float h=asteroid.HP;
  float MaxH=asteroid.MaxHP;
  int hp_=int((h/MaxH)*100);

  pushStyle();
  pushMatrix();
  textFont(f, 16);  
  textAlign(CENTER, CENTER);


  for (int i=0; i <asteroid.surovina.length; i++) {
    celkem+=int(asteroid.surovina[i]);
    if ( asteroid.surovina[i]>0) {
      pocR+=1;
    }
  }


  translate(LodX-width/2+50, LodY-height/2+150);
  noStroke();
  fill(70, 105, 115, 220);
  ellipse(0, 0, 60, 60);
  stroke(0, 237, 237);
  strokeWeight(2);
  arc(0, 0, 60, 60, -PI/2-QUARTER_PI/2, +PI); 
  arc(0, 0, 50, 50, 0, PI/2*3);  

  beginShape();
  vertex(30, 0);
  vertex(200, 0);
  vertex(225, 25);
  vertex(17, 25);
  endShape(OPEN);

  beginShape();
  vertex(210, 0);
  vertex(250, 0);
  vertex(275, 25);
  vertex(235, 25);
  endShape(CLOSE);

  rect(0, 30, 275, 30+30*pocR);

  for (int i=1; i<=pocR+1; i++) {
    line(0, 30*i, 275, 30*i);
  }

  fill(0, 255, 0);
  for (int i=0; i <asteroid.surovina.length; i++) {
    if ( asteroid.surovina[i]>0) {

      switch(i) {
      case 0:
        s="železo";
        break;
      case 1:
        s="vodík";
        break;
      case 2:
        s="dusík";
        break;
      case 3:
        s="křemík"; 
        break;
      case 4:
        s="hliník";
        break;
      case 5:
        s="uhlík";
        break;
      case 6:
        s="uran";
        break;
      case 7:
        s="dilithium";
        break;
      }
      text(s+": "+asteroid.surovina[i], 275/2, 45+30*pocR);
      pocR-=1;
    }
  }

  text(hp_+"%", 0, 0);
  text(asteroid.typ, 242, 12);
  text("Asteroid", 275/2, 12);

  text("HP: "+int(MaxH), 275/2, 45);
  text("váha: "+int(celkem), 285/2, 75);

  popMatrix();
  popStyle();
}