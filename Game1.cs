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

        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont myFont;
        Camera2D camera;


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
            mapAlpha = new MapAlpha(1, new Vector2(0, 0), Content);      // Inicializace mapy


        }

        protected override void Update(GameTime gameTime)
        {
            camera.UpdateZoom();

            if (!isGUIInteraction)
            {
                camera.Follow(mapAlpha.UserFleets.ElementsList[0].ship.PositionOnMap);
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
                mapAlpha.UserFleets.ElementsList[0].ship.SetMouseTarget(mousePosition, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), camera.Position);

            }







            mapAlpha.UpdateMap(gameTime);
            // Aktualizace lodi



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix: camera.GetTransformation());
            //camera.DrawAxis(GraphicsDevice, myFont);
            // Vykreslení mapy
            mapAlpha.DrawMap(_spriteBatch);



            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}