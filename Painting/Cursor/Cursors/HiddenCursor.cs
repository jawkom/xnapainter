using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Painting
{
    class HiddenCursor:Cursor
    {
        public const string Type = "hidden";

        public HiddenCursor()
        {

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
        }
    }
}
