class Stanice {

  PVector pozice = new PVector(0, 0);
  int velikost;
  PImage obrazek;
  boolean Ustanice;
  boolean potvrzTab=false;


  Stanice(int x_, int y_) {
    pozice.x=x_;
    pozice.y=y_;
    velikost= 300;
    obrazek= loadImage("stanice.png");
  }

  void update() {                       //  detekce lodi u stanice
    if (PVector.dist(pozice, ship.pozice)<velikost*1.5) {
      Ustanice= true;
    } else {
      Ustanice= false;
    }
  }


  void render() {                       //  vykreslení obrázku stanice
    update();
    pushStyle();
    pushMatrix();
    shapeMode(CENTER);
    imageMode(CENTER);
    translate(pozice.x, pozice.y);     //posunutí na pozici
    rotate(0);                         //rotace
    fill(0);
    image(obrazek, 0, 0, 450, 337);
    popMatrix();
    popStyle();
  }

  void tlacitko() {                     //  tlačítko vstupu do stanice
    if (Ustanice) {
      rect(width-250, height-125, 200, 100);
      pushStyle();
      textAlign(CENTER, CENTER);
      textFont(f, 30);
      fill(255, 0, 0);
      text("Do stanice", width-250+100, height-125+50);
      popStyle();
    }
  }
}