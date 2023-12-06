using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;



namespace WoS.GUI
{
    /// <summary>
    /// Základní třída pro GUI komponenty.
    /// </summary>
    public abstract class GuiComponentBase
    {
        // Vlastnosti
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }

        public readonly SpriteFont myFont;

        // Konstruktor
        public GuiComponentBase(int id, Vector2 position, ContentManager content)
        {
            myFont = content.Load<SpriteFont>("Font/arial");

            Id = id;
            Position = position;
            Visible = true;
        }

        // Načte texturu pro komponentu
        public void LoadTexture2D(string path, ContentManager content)
        {
            Texture = content.Load<Texture2D>(path);
        }

        // Vykreslí komponentu
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
                ComponentDraw(spriteBatch);
            }
        }

        // Specifické vykreslení komponenty, má být přepsáno v odvozených třídách
        protected virtual void ComponentDraw(SpriteBatch spriteBatch) { }


        public virtual void Update(GameTime gameTime)
        {
            IsClickedOnMe();
        }



        // Zkontroluje, zda bylo na komponentu kliknuto
        public void IsClickedOnMe()
        {
            if (Visible && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                var mouseState = Mouse.GetState();
                if (mouseState.X >= Position.X && mouseState.X <= Position.X + Width &&
                    mouseState.Y >= Position.Y && mouseState.Y <= Position.Y + Height)
                {
                    OnClick();
                }
            }
        }

        // Abstraktní metoda pro zpracování kliknutí, musí být implementována v odvozených třídách
        public abstract void OnClick();

        // Metoda pro nastavení konfigurace komponenty, může být přepsána v odvozených třídách
        public virtual void SetComponentConfig() { }
    }
}
