void mys() {                                                          // přepočítání souřadnic | zadání nového cílu letu | vypočítání úhlu

  mx=LodX+mouseX-width*0.5;
  my=LodY+mouseY-height*0.5;
  Mvect = new PVector(mx, my);
  ship.cil = new PVector(mx, my);
  ship.cil.sub(ship.pozice);
  alfa=atan2(my-ship.pozice.y, mx-ship.pozice.x)+PI/2;
}



boolean casOmezovac(int pocatek, int cas) {                           //cas ==jaká má být časová prodleva, Zmillis == začátek počítání

  if (millis()-pocatek>=cas) {
    return true;
  } else {
    return false;
  }
}



boolean tlacitko(float x_, float y_, float sirka_, float vyska_) {    //  všeobecná funkce tlačítko
  if (mx>x_ && mx<x_+sirka_ && my>y_ && my<y_+vyska_) {
    return true;
  } else {
    return false;
  }
}



boolean vel(float[] pole) {                                           //  je pole prázdné?      true | false
  float Xx=0;
  for (int i=0; i <pole.length; i++) {
    Xx+=pole[i];
  }
  if (Xx==0) {
    return true;
  } else {
    return false;
  }
}



/*
void Galaktickabrana(String jm) {

  ARplanety= new ArrayList<Planeta>();


  planetSystem= new PlanetSystem(0, 0, jm);
}
*/