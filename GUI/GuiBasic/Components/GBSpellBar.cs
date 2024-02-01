using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WoS.GUI
{
    public class GBSpellBar : GuiComponentBase
    {
        private const int SpellCount = 9;
        private List<SpellSlot> spellSlots = new List<SpellSlot>();
        private SpriteFont font;

        public GBSpellBar(int id, Vector2 position, ContentManager content) : base(id, position, content)
        {
            font = content.Load<SpriteFont>("Font/arial");
            InitializeSpellSlots(content);
        }

        private void InitializeSpellSlots(ContentManager content)
        {
            for (int i = 0; i < SpellCount; i++)
            {
                Vector2 slotPosition = new Vector2(Position.X + i * 100, Position.Y);
                spellSlots.Add(new SpellSlot(i, slotPosition, content, font));
            }
        }

        public override void OnClick()
        {
            var mouseState = Mouse.GetState();
            foreach (var slot in spellSlots)
            {
                if (slot.IsClicked(mouseState))
                {
                    // Aktivujte nebo změňte spell v závislosti na pozici kliknutí
                    slot.ActivateOrSetSpell(mouseState);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                foreach (var slot in spellSlots)
                {
                    slot.Draw(spriteBatch);
                }
            }
        }

        public void Update()
        {
        }

        private class SpellSlot
        {
            public Vector2 Position;
            public SpellBase CurrentSpell;
            private Texture2D Texture;
            private SpriteFont font;
            private string SpellName;
            private const float SCALE_FACTOR = 0.09f; // 9% z původní velikosti
            private int IdSlot;

            public SpellSlot(int idSlot, Vector2 position, ContentManager content, SpriteFont font)
            {
                IdSlot = idSlot;
                Position = position;
                this.font = font;
                Texture = content.Load<Texture2D>("GUI/GBSpellBar");
                // Nastavení výchozího spellu
                CurrentSpell = new SpellExample(content); // Předpokládá, že SpellExample je odvozen od SpellBase
                SpellName = "Spell " + IdSlot; // Defaultní název spellu
            }

            public bool IsClicked(MouseState mouseState)
            {
                // Logika pro zjištění, zda bylo na slot kliknuto
                return false;
            }

            public void ActivateOrSetSpell(MouseState mouseState)
            {
                // Zjistí, zda se kliklo na pravý horní roh pro nastavení spellu, nebo na jinou část pro aktivaci
            }

            public void SetSpell(int idSpellType)
            {
                // Nastaví spell podle zadaného ID typu spellu
                // Tato metoda bude vyžadovat logiku pro výběr správného spellu podle ID
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Texture, Position, null, Color.White, 0, new Vector2(0, 0), SCALE_FACTOR, SpriteEffects.None, 0);
                // Vykreslení názvu spellu
                spriteBatch.DrawString(font, SpellName, new Vector2(Position.X + 10, Position.Y + Texture.Height * SCALE_FACTOR - 20), Color.White);
            }
        }

        public abstract class SpellBase
        {
            public string Name { get; protected set; }
            public Texture2D Image { get; protected set; }
            // Další vlastnosti a metody pro spell

            public abstract void Activate(); // Aktivace spellu
        }

        public class SpellExample : SpellBase
        {
            public SpellExample(ContentManager content)
            {
                Name = "Example Spell";
                // Image = content.Load<Texture2D>("Spells/ExampleSpellImage");
            }

            public override void Activate()
            {
                // Logika pro aktivaci tohoto konkrétního spellu
            }
        }
    }
}