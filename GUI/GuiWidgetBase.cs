using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.GUI
{
    public abstract class GuiWidgetBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Seznam komponent
        public List<GuiComponentBase> components;

        public GuiWidgetBase(ContentManager content)
        {
            components = new List<GuiComponentBase>();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components)
            {
                if (component.Visible)
                {
                    component.Draw(spriteBatch);
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                // Implementace update logiky
                component.Update(gameTime);
            }
        }
    }
}