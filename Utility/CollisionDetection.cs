using Microsoft.Xna.Framework.Graphics;

namespace WoS.Utility
{
    public abstract class CollisionDetection : ElementBase
    {


        public override void Update()
        {
            // Implementation of method to update the planet
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // Implementation of method to draw the planet
        }

        public virtual bool IsCollidingWith(ElementBase other)
        {
            if(Position.X + Width > other.Position.X &&
                Position.X < other.Position.X + other.Width &&
                Position.Y + Height > other.Position.Y &&
                Position.Y < other.Position.Y + other.Height)
            {
                return true;
            }
            return false;
        }

        // Další metody a vlastnosti týkající se detekce kolize můžete přidat sem...
    }
}
