using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WoS.Camera;
using WoS.map;
using WoS.ship;
using WoS.Database;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;
using System.Text;
using static WoS.Database.Database;

namespace WoS
{
    public class Game1 : Game
    {
        private MqttClient client;

        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont myFont;
        Camera2D camera;
        ShipBase ship;

        MapAlpha mapAlpha;              // Instance vaší mapy

        bool isGUIInteraction = false;  // Toto by měl být přepínač, který kontroluje, zda je aktivní interakce s GUI

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Nastavení rozlišení na Full HD
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            // graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            camera = new Camera2D(GraphicsDevice.Viewport);

        }

        protected override void Initialize()
        {
          //  Database Db = new Database();
            CreateMap Cmap = new CreateMap();
            // Cmap.CreateMapAndInsertToDatabase(); // Vytvoření mapy a vložení do databáze






            //InitializeMqtt();
            base.Initialize();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            myFont = Content.Load<SpriteFont>("Font/arial");
            //camera.LoadContent(Content, _spriteBatch);
            //Mapa
            Texture2D mapTexture = Content.Load<Texture2D>("maps/background/map1");     // Načtení textury pro mapu
            mapAlpha = new MapAlpha(mapTexture,1, new Vector2(0, 0), Content);                                        // Inicializace mapy
            //ship
            ship = new ShipEgla(Content, new Vector2(100, 100));              // Inicializace ship



        }

        protected override void Update(GameTime gameTime)
        {
            camera.UpdateZoom();

            if (!isGUIInteraction)
            {
                camera.Follow(new Vector2(100, 100));
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {

                // Získání aktuální pozice myši
                MouseState mouseState = Mouse.GetState();
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

                // Nastavení cílové pozice lodi na základě pozice myši
                //Mapa.MapElementGroup.elementInFleet[0] = ship;
                //mapAlpha.UserFleets.ElementsList[0].SetMouseTarget(mousePosition, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), camera.Position);

            }
            mapAlpha.UpdateMap(gameTime);
            // Aktualizace lodi
            ship.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix: camera.GetTransformation());
            //camera.DrawAxis(GraphicsDevice, myFont);
            // Vykreslení mapy
            mapAlpha.DrawMap(_spriteBatch);

            ship.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
        /*
        public void InitializeMqtt()
        {
            // Vytvořte nový MQTT klient a připojte se k brokeru.
            client = new MqttClient("192.168.0.167");
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // Předplaťte se k tématu, pokud chcete přijímat zprávy.
            client.Subscribe(new string[] { "/game/" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            // Přiřaďte události pro přijímání zpráv.
            client.MqttMsgPublishReceived += CallBack;
        }
        private void CallBack(object sender, MqttMsgPublishEventArgs e)
        {
            // Tady zpracujte přijaté zprávy.
            string receivedMessage = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine("Received: " + receivedMessage);
        }
        public void SendMqttMessage(string topic, string message)
        {
            client.Publish(topic, Encoding.UTF8.GetBytes(message));
        }
        protected override void UnloadContent()
        {
            client.Disconnect();
            base.UnloadContent();
        }
        */
    }
}