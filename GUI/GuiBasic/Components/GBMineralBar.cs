using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WoS.GUI.GuiBasic.Components
{
    public class GBMineralBar : GuiComponentBase
    {
        private class Bar
        {
            public int Id;                 // id Bar
            public Texture2D Texture;     // textura
            public Texture2D MineralTexture;
            public string Name;           // název minerálu
            public Vector2 Position;      // pozice
            public int MineralCount;     //počet minerálů
            private const float SCALE_FACTOR = 0.05f;
            private const float SCALE_FACTOR2 = 0.05f;
            public Bar(int id, Vector2 position, string name, ContentManager content)
            {
                Id = id;
                Position = position;
                Name = name;
                LoadTexture2D(content);

                // Předpokládá se, že User.Minerals je již definováno
                MineralCount = 10;

            }
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Texture, Position + Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR, SpriteEffects.None, 0);
                //  spriteBatch.Draw(MineralTexture, Position + Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR2, SpriteEffects.None, 0);

            }
            public void SetBarMineralCount(int mineralCount)
            {
                MineralCount = mineralCount;
            }
            public void LoadTexture2D(ContentManager content)
            {
                Texture = content.Load<Texture2D>("GUI/GBMineralBar");
                string MineralPath = "GUI/Minerals/" + Name;                   //TODO: přidat Obrázky minerálů

                // MineralTexture = content.Load<Texture2D>(MineralPath);
            }
        }





        private List<Bar> bars = new List<Bar>();

        public int MineralBarCount;

        public GBMineralBar(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            Position = position;
            SetComponentConfig(content);
        }

        public void SetComponentConfig(ContentManager content)
        {
            MineralBarCount = 10;

            Width = 500;
            Height = 100;

            int zacatek = 100;
            int roztec = 50;
            int y = 5;
            //Vector2 barPosition = new Vector2(100, 10);



            // Příklad vložení objektu
            bars.Add(new Bar(0, new Vector2(zacatek + roztec * 0, y), "Iron", content));
            bars.Add(new Bar(1, new Vector2(zacatek + roztec * 1, y), "Copper", content));
            bars.Add(new Bar(2, new Vector2(zacatek + roztec * 2, y), "Gold", content));
            bars.Add(new Bar(3, new Vector2(zacatek + roztec * 3, y), "Silver", content));
            bars.Add(new Bar(4, new Vector2(zacatek + roztec * 4, y), "Platinum", content));
            bars.Add(new Bar(5, new Vector2(zacatek + roztec * 5, y), "Uranium", content));
            bars.Add(new Bar(6, new Vector2(zacatek + roztec * 6, y), "Titanium", content));
            bars.Add(new Bar(7, new Vector2(zacatek + roztec * 7, y), "Diamond", content));
            bars.Add(new Bar(8, new Vector2(zacatek + roztec * 8, y), "Emerald", content));
            bars.Add(new Bar(9, new Vector2(zacatek + roztec * 9, y), "Ruby", content));


        }

        public override void OnClick()
        {
            // Zpracování události kliknutí
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Aktualizační smyčka pro každý Bar
            foreach (var bar in bars)
            {
                //  bar.SetBarMineralCount( User.Minerals[bar.Id]);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                ComponentDraw(spriteBatch);
            }
        }

        protected override void ComponentDraw(SpriteBatch spriteBatch)
        {
            foreach (var bar in bars)
            {
                bar.Draw(spriteBatch);
                //spriteBatch.Draw(bar.Texture, Position + bar.Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR, SpriteEffects.None, 0);
                // Zde by mohl být přidán kód pro vykreslení MineralCount nebo dalších informací
            }
        }
    }
}
