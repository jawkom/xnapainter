using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Painting
{
    class DrawingObject
    {
        private Texture2D texture_;
        public Texture2D Texture { get { return texture_; } }

        private Vector2 position_;
        public Vector2 Position { get { return position_; } }

        private Color color_;
        public Color Color { get { return color_; } }

        private double rotation_;
        public double Rotation { get { return rotation_; } }

        #region Constructors
        public DrawingObject()
        {
        }

        public DrawingObject(Texture2D texture, Vector2 position) : this(texture, position, 0)
        {
        }

        public DrawingObject(Texture2D texture, Vector2 position, double rotation)
            : this(texture, position, rotation, Color.White)
        {
        }

        public DrawingObject(Texture2D texture, Vector2 position, double rotation, Color color)
        {
            Initialize(texture, position, rotation, color);
        }
        #endregion

        public void Initialize(Texture2D texture, Vector2 position, double rotation, Color color)
        {
            texture_ = texture;
            position_ = position;
            rotation_ = rotation;
            color_ = color;
        }
    }
}
