using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WoS.Camera;
using WoS.Database;
using WoS.GUI;
using WoS.map;

namespace WoS
{
    public class Game1 : Game
    {
        private bool isGUIInteraction = false;  // Toto by měl být přepínač, který kontroluje, zda je aktivní interakce s GUI

        private GuiManager Gui; // Přidání instance GuiBasic
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont myFont;
        private Camera2D camera;

        private MapAlpha mapAlpha;              // Instance vaší mapy

        private Vector2 WindowPosition;         // Pozice okna GUI

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
            Gui = new GuiManager(Content, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight)); // Inicializace GuiBasic
            CreateMap Cmap = new CreateMap();
            // Cmap.CreateMapAndInsertToDatabase(); // Vytvoření mapy a vložení do databáze

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("cz");
            Localization.Instance.SetLanguage("cz"); // Pro změnu na češtinu

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
            WindowPosition = mapAlpha.UserFleets.ElementsList[0].ship.Position;

            Gui.Update(gameTime, WindowPosition); // Aktualizace GuiBasic
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

            // Přechodně posune SpriteBatch pro vykreslení GUI na pozici WindowPosition
            _spriteBatch.End();
            _spriteBatch.Begin(transformMatrix: Matrix.CreateTranslation(new Vector3(WindowPosition, 0)));

            Gui.Draw(_spriteBatch); // Vykreslení GuiBasic

            // Resetování SpriteBatch zpět na původní pozici
            _spriteBatch.End();
            // _spriteBatch.Begin(transformMatrix: Matrix.CreateTranslation(new Vector3(0, 0, 0)));

            // _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}