using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WoS.Camera
{
    public class Camera3D
    {
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Up { get; set; }

        private Viewport _viewport;
        private float _zoomSpeed = 0.5f; // Rychlost zoomu - můžete upravit podle potřeby.

        private SpriteBatch _spriteBatch;
        private SpriteFont _font;

        public Camera3D(Viewport viewport)
        {
            _viewport = viewport;
            Position = new Vector3(0, 0, -10);  // Pozice kamery za plátnem v osách Z.
            Target = Vector3.Zero;             // Kamera "kouká" na střed scény.
            Up = Vector3.Up;                   // Vertikální směr kamery je "nahoru".
        }

        // Přidejte tento konstruktor, pokud již nemáte nějaký podobný mechanismus pro načítání obsahu.
        public void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            _font = content.Load<SpriteFont>("Font/arial");  // Nahraďte "YourFontAssetName" jménem svého fontového assetu.
        }

        public void Follow(Vector3 position)
        {
            Position = new Vector3(position.X, position.Y, Position.Z);  // Posun kamery v X a Y, ale zachovává stejnou vzdálenost v osách Z.
            Target = position;  // Kamera kouká na danou pozici.
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateLookAt(Position, Target, Up);
        }

        public Matrix GetProjectionMatrix()
        {
            float fieldOfView = MathHelper.ToRadians(45f);
            float aspectRatio = _viewport.AspectRatio;
            float nearPlaneDistance = 0.1f;
            float farPlaneDistance = 1000f;

            return Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);
        }

        public void UpdateZoom()
        {
            MouseState mouseState = Mouse.GetState();
            float wheelChange = mouseState.ScrollWheelValue; // Hodnota změny kolečka myši.

            // Aktualizujte pozici kamery podle hodnoty změny kolečka myši.
            Position += new Vector3(0, 0, wheelChange * _zoomSpeed);
        }

        public void DrawAxis(GraphicsDevice graphicsDevice, SpriteFont font)
        {
            BasicEffect basicEffect = new BasicEffect(graphicsDevice);

            basicEffect.World = Matrix.Identity;
            basicEffect.View = GetViewMatrix();
            basicEffect.Projection = GetProjectionMatrix();

            basicEffect.VertexColorEnabled = true;

            Vector3 xAxisEnd = Position + Vector3.Right * 5;  // 5 je délka osy. Můžete upravit.
            Vector3 yAxisEnd = Position + Vector3.Up * 5;
            Vector3 zAxisEnd = Position + Vector3.Forward * 5;

            VertexPositionColor[] vertices = new VertexPositionColor[6];
            vertices[0] = new VertexPositionColor(Position, Color.Red);
            vertices[1] = new VertexPositionColor(xAxisEnd, Color.Red);
            vertices[2] = new VertexPositionColor(Position, Color.Green);
            vertices[3] = new VertexPositionColor(yAxisEnd, Color.Green);
            vertices[4] = new VertexPositionColor(Position, Color.Blue);
            vertices[5] = new VertexPositionColor(zAxisEnd, Color.Blue);

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, vertices, 0, 3);
            }

            _spriteBatch.DrawString(font, "X", new Vector2(xAxisEnd.X, xAxisEnd.Y), Color.Red);
            _spriteBatch.DrawString(font, "Y", new Vector2(yAxisEnd.X, yAxisEnd.Y), Color.Green);
            _spriteBatch.DrawString(font, "Z", new Vector2(zAxisEnd.X, zAxisEnd.Y), Color.Blue);
        }
    }
}