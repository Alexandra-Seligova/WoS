/*
  client.publish("/hra/uzivatel/x",str(pozice.x));
 client.publish("/hra/uzivatel/y",str(pozice.y));
 client.publish("/hra/uzivatel/r",str(alfa));
 */


void messageReceived(String topic, byte[] payload) {

  payload_= new String(payload);

  println("payload: "+payload_);
  if (topic.equals("/uzivatel/ship/pozice_X")) {
    online_x=float(payload_);
  } 
  if (topic.equals("/uzivatel/ship/pozice_Y")) {
    online_y=float(payload_);
  }
  if (topic.equals("/uzivatel/ship/rotace")) {
    online_r=float(payload_);
  }
}



// umístění setup() ; spuštění komunikace se serverem
void MQTT_start() {  
  client = new MQTTClient(this);
  client.connect(MQTT_SERVER, "Uzivatel2");//client.connect("mqtt://www.scribonia.cz", "processing1");
  client.subscribe("/hra");
  client.subscribe("/uzivatel/ship/pozice_X");
  client.subscribe("/uzivatel/ship/pozice_Y");
  client.subscribe("/uzivatel/ship/rotace");
}


void renderOnline(float x_, float y_, float r_) {                                              //renderování
 
  pushMatrix();
  shapeMode(CENTER);
  imageMode(CENTER);
  translate(x_, y_);     //posunutí na pozici
  rotate(r_);                                            //rotace
  fill(0);
  // shape(Egla, 0, 0, velikostX*2, velikostY*2);
  image(Fodienda, 0, 0, ship.velikostX*2, ship.velikostY*2);
  popMatrix();


}
