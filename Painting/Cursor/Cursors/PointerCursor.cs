using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Painting
{
    class PointerCursor:Cursor
    {
        public const string Type = "pointer";
        private Texture2D texture;

        public PointerCursor()
        {
            texture = ContentLibrary.Get(Type);
        }

        public override string GetCursorType()
        {
            return Type;
        }

        public override Vector2 Position()
        {
            return Input.MousePosition();
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(texture, Position(), Color.White);
        }
    }
}
