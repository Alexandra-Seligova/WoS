
void prostrediMapa() {

  LodX=ship.pozice.x;
  LodY=ship.pozice.y;


  Ox1=camX-width+LodX;
  Ox2=camX+LodX;
  Oy1=camY-LodY;
  Oy2=camY+height-LodY;


  ortho(Ox1, Ox2, Oy1, Oy2);

  mapa.render();
  stanice.render();
}


/*
void prostredi() {   // vykreslování mapy, prostredi atd...


  LodX=ship.pozice.x;
  LodY=ship.pozice.y;


  Ox1=camX-width+LodX;
  Ox2=camX+LodX;
  Oy1=camY-LodY;
  Oy2=camY+height-LodY;


  ortho(Ox1, Ox2, Oy1, Oy2);


  MapaPlanety();
}

void prostrediSystem() {

  LodX=ship.pozice.x;
  LodY=ship.pozice.y;

  Ox1=(camX-width+LodX);
  Ox2=(camX+LodX);
  Oy1=(camY-LodY);
  Oy2=(camY+height-LodY);
  
 //  Ox1=(camX-width*2.5+SysSirka/2);  // pro náhled celé soustavy
 //   Ox2=(camX+SysSirka/2+width*1.5);
 //   Oy1=(camY-SysVyska/2-height*1.5);
 //   Oy2=(camY+height*2.5-SysVyska/2);
   
  ortho(Ox1, Ox2, Oy1, Oy2);

  planetSystem.render();
}
*/
