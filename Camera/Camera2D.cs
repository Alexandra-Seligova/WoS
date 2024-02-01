using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WoS.Camera
{
    // Třída reprezentující 2D kameru v enginu XNA/MonoGame.
    public class Camera2D
    {
        // Vektor pozice kamery v 2D prostoru.
        public Vector2 Position { get; private set; }

        private const float ZoomSpeed = 0.01f;

        // Zoom kamery. 1.0f je normální velikost, menší hodnoty přibližují a větší hodnoty oddalují.
        public float Zoom { get; set; }

        // Viewport reprezentuje oblast na obrazovce, kam je vykreslován obsah.
        private Viewport _viewport;

        // Konstruktor kamery, který přijímá viewport.
        public Camera2D(Viewport viewport)
        {
            _viewport = viewport;
            Zoom = 1.0f; // Nastaví se výchozí hodnota zoomu na 1.0f (normální velikost).
        }

        // Metoda, která nastaví pozici kamery na danou pozici v 2D prostoru.
        public void Follow(Vector2 position)
        {
            Position = position; // Nyní je střed kamery v pozici, kterou sleduje.
        }

        // Vrací transformační matici pro kameru.
        // Tato matice je vytvořena složením translace (posunutí), změny měřítka (zoomu) a další translace.
        public Matrix GetTransformation()
        {
            // 1. Posun kameru na opačnou pozici (tím se vytvoří efekt, že kamera sleduje objekt).
            // 2. Aplikuje zoom.
            // 3. Posune kameru zpět na střed viewportu.
            return Matrix.CreateTranslation(new Vector3(-Position, 0)) *
                   Matrix.CreateScale(Zoom, Zoom, 1) *
                   Matrix.CreateTranslation(new Vector3(_viewport.Width * 0.5f, _viewport.Height * 0.5f, 0));
        }

        public void UpdateZoom()
        {
            // Získá aktuální stav myši.
            MouseState mouseState = Mouse.GetState();

            // Zkontroluje pohyb kolečka myši.
            if (mouseState.ScrollWheelValue > 0)
            {
                Zoom += ZoomSpeed; // Přibližuje kameru.
            }
            else if (mouseState.ScrollWheelValue < 0)
            {
                Zoom -= ZoomSpeed; // Oddaluje kameru.
            }

            // Omezení hodnoty zoomu, aby nedošlo k přílišnému přiblížení nebo oddálení.
            Zoom = MathHelper.Clamp(Zoom, 0.1f, 5f);
        }
    }
}