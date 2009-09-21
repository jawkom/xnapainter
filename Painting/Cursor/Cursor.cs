using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Painting
{
    public abstract class Cursor
    {
        public abstract string GetCursorType();
        public abstract Vector2 Position();
        public abstract void Update();
        public abstract void Draw();
    }
}
