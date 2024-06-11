

void GUI() {  // Grafické Uživatelské Rozhraní  //je potřeba k souřadnicím připočíst Cx a Cy
  strokeWeight(20);
  noFill();
  stroke(255);
  switch (GS) {   // GS gui switch    pokud je otevřená instance některé gui, tak se přikreslí. Pokud je GS=0 tak nic nedokresluje;
  case 0:
    Gzakladni();   // jméno, xp bar, menu, životy, štít, nákladový
    Gtlacitka();  // attack, senzory
    stanice.tlacitko();
    break;
  case 1:     //gui stanice     
    Gstanice();
    break;
  case 2:        //oprava


    break;
  case 3:          //shop 
    GUIshop(); 

    break;
  case 4:         // edit
    gEdit.update();
    break;
  case 5:         // zakladna

    break;
  case 6:    // Galaktická brána

    break;
  case 7:   
    break;
  } // switch GS gui
}  // vykreslovací smyčka GUI

boolean kontrolaGUI() {   //  detekce kliknutí na GUI       senzory | útok | do stanice              

  if (tlacitko(Cx+50, Cy+height-250, 200, 100)) {
    Gsenzory();
    println("sen");
    return true;
  } else
    if (tlacitko(Cx+50, Cy+height-375, 200, 100)) {
      Gattack();
      println("att");
      return true;
    } else if (stanice.Ustanice && tlacitko(Cx+width-250, Cy+height-125, 200, 100)) {
      println("do stanice");
      GS=1;
      mx=0;
      my=0;
      return true;
    } else

    {
      GS=0;
      return false;
    }
}