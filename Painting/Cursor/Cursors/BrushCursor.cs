using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Painting
{
    class BrushCursor:Cursor
    {
        private Texture2D texture;
        private Stroke stroke;

        public const string Type = "brush";
        public Color Colour = Color.White;

        public BrushCursor()
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
            stroke = StrokeManager.GetActiveStroke();
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(stroke.Brush, Input.MousePosition(), new Rectangle(0, 0, stroke.Brush.Width, stroke.Brush.Height), stroke.Colour, 0f, stroke.Origin, stroke.Scale, SpriteEffects.None, 0);
        }



        public void SetColor(Color newColor)
        {
            Colour = newColor;
        }

        public Color GetColor()
        {
            return Colour;
        }
    }
}
