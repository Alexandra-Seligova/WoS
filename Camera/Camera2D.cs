using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Camera
{
    public class Camera2D
    {
        public Vector2 Position { get; private set; }
        public float Zoom { get; set; }

        private Viewport _viewport;

        public Camera2D(Viewport viewport)
        {
            _viewport = viewport;
            Zoom = 1.0f;
        }

        public void Follow(Vector2 position)
        {
            Position = position; // Nyní je střed kamery v pozici, kterou sleduje
        }

        public Matrix GetTransformation()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0)) *
                   Matrix.CreateScale(Zoom, Zoom, 1) *
                   Matrix.CreateTranslation(new Vector3(_viewport.Width * 0.5f, _viewport.Height * 0.5f, 0));
        }
    }
}
