using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Painting
{
    class Label
    {
        protected Texture2D texture_;
        protected Vector2 position_;
        protected string name_;

        public Label(string name, Vector2 position)
        {
            name_ = name;
            position_ = position;
            texture_ = ContentLibrary.Get(name);
        }

        public void Draw()
        {
            DrawingLayer.Register(texture_, position_);
        }
    }
}
