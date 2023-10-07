using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WoS.Camera;
using WoS.map;
using WoS.ship;

namespace WoS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;

        Camera2D camera;
        ShipBase ship;
        Texture2D shipTexture;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Mapa
            Texture2D mapTexture = Content.Load<Texture2D>("maps/background/map1");     // Načtení textury pro mapu
            mapAlpha = new MapAlpha(mapTexture);                                        // Inicializace mapy
            //ship
            shipTexture = Content.Load<Texture2D>("spaceShips/Egla");                   // Načtení textury pro ship
            ship = new ShipEgla(shipTexture, new Vector2(100, 100), 100f);              // Inicializace ship



        }

        protected override void Update(GameTime gameTime)
        {
            if (!isGUIInteraction)
            {
                camera.Follow(ship.PositionOnMap);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {

                // Získání aktuální pozice myši
                MouseState mouseState = Mouse.GetState();
                Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

                // Nastavení cílové pozice lodi na základě pozice myši
                ship.SetMouseTarget(mousePosition, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), camera.Position);

            }

            // Aktualizace lodi
            ship.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix: camera.GetTransformation());

            // Vykreslení mapy
            mapAlpha.Draw(_spriteBatch);
            // Vykreslení ship
            ship.Draw(_spriteBatch);



            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}