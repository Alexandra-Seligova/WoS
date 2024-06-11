void mousePressed() {
  client.publish("/hra/mx","1");



  pocMereni=millis();
  Mpressed=true;   //kliklo se


  mx=LodX+mouseX-width*0.5;
  my=LodY+mouseY-height*0.5;
  Cx=int(LodX-width*0.5);
  Cy=int(LodY-height*0.5);

  Mvect2 = new PVector(mx, my);
  // PVector M = new PVector(mx, my);

  int l=0;




  if (GS==0) { 
    if ( kontrolaGUI()==false) {  //zkontrolování tlačítek

      for (int y = ARlode.size()-1; y >= 0; y--) {
        AL_lod terc = (AL_lod) ARlode.get(y);

        if (dist(mx, my, terc.pozice.x, terc.pozice.y)<35) {
          druh_ozn = 1;
          oznObj=terc.pozice;
          oznObjC=y;
        } else {
          l+=1;
        }
      } // ARlodě arraylist
      if (l!=ARlode.size()-1) { 
        let=true;

        l=0;
        for (int i = AR_Boxy.size()-1; i >= 0; i--) {
          Box box = (Box) AR_Boxy.get(i);

          if (PVector.dist(box.pozice, Mvect2)< 20) {    //  l1

            druh_ozn = 2; //označení pro box;
            Mvect = new PVector(box.pozice.x, box.pozice.y-60);
            ship.cil = new PVector(box.pozice.x, box.pozice.y-60);
            ship.cil.sub(ship.pozice);
            alfa=atan2(box.pozice.y-60-ship.pozice.y, box.pozice.x-ship.pozice.x)+PI/2;
            let=false;
            ship.budeTran=true;
            ship.konecTran=false;
            frame=0;
            ship.seq=0;
            oznObj=box.pozice;
            oznObjC=i ;
          } else {
            l+=1;    //rozhoduje jestli jeden boxík souhlasí s kliknutím
          }
        }

        if (l!=AR_Boxy.size()-1) { 
          ship.budeTran=false;
          frame=1;



          l=0;
          for (int i = ARkameni.size()-1; i >= 0; i--) {
            Asteroid asteroid = (Asteroid) ARkameni.get(i);

            if (PVector.dist(asteroid.pozice, Mvect2)< 20*asteroid.velikost) {

              if (asteroid.typ>1) {
                druh_ozn = 4;
                oznObj=asteroid.pozice;
                oznObjC=i;
                let=false;
              } else {


                druh_ozn = 3; //označení pro asteroid;
                Mvect = new PVector(asteroid.pozice.x, asteroid.pozice.y-60);
                ship.cil = new PVector(asteroid.pozice.x, asteroid.pozice.y-60);
                ship.cil.sub(ship.pozice);
                alfa=atan2(asteroid.pozice.y-60-ship.pozice.y, asteroid.pozice.x-ship.pozice.x)+PI/2;
                let=false;
                ship.budeTran=true;
                ship.konecTran=false;
                frame=0;
                ship.seq=0;
                oznObj=asteroid.pozice;
                oznObjC=i ;
              }
            } else {
              l+=1;    //rozhoduje jestli jeden boxík souhlasí s kliknutím
            }
          }

          if (l!=ARkameni.size()-1) { 
            ship.budeTran=false;
            ship.konecTran=true;
            frame=1;
          }
        }
      }
    }
  }
  /*
  else if (GS==5) {
   for (int i = ARpozemky.size()-1; i >= 0; i--) {
   Pozemky poz = (Pozemky) ARpozemky.get(i);
   poz.oznac();
   }
   }
   */
}

void mouseDragged() {
}
void mouseMoved() {
}
void mouseReleased() {
  // println("released");
  let=false;
}

/*
void keyPressed() {
 if (key=='i') {
 }
 if (key=='s') {
 senzory=true;
 }
 if (key=='d') {
 senzory=false;
 }
 if (key == CODED) {
 
 
 if (keyCode == CONTROL) {
 if (!utok) { 
 utok=true;
 } else { 
 utok=false;
 }
 }
 }
 }
 */