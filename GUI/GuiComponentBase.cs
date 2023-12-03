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
    public abstract class GuiComponentBase
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }


        public GuiComponentBase(int id, Vector2 position, ContentManager content)
        {
            Id = id;
            Position = position;
            Visible = true;

        }
        public void LoaderTexture2D(string path, ContentManager content)
        {
            Texture = content.Load<Texture2D>(path);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
                ComponentDraw();
            }
        }
        public virtual void ComponentDraw()
        {

        }
        public void IsClickedOnMe()
        {
            if (Visible)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (Mouse.GetState().X >= Position.X && Mouse.GetState().X <= Position.X + Width)
                    {
                        if (Mouse.GetState().Y >= Position.Y && Mouse.GetState().Y <= Position.Y + Height)
                        {
                            OnClick();
                        }
                    }
                }
            }


        }
        public abstract void OnClick();
        public virtual void SetComponentConfig()
        {

        }

    }
}


