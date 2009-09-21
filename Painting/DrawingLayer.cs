using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Painting
{
    static class DrawingLayer
    {
        private static Queue<DrawingObject> usedList_ = new Queue<DrawingObject>(200);
        private static Queue<DrawingObject> unusedList_ = new Queue<DrawingObject>(200);

        public static void Register(DrawingObject obj)
        {
            Transform(obj);
            usedList_.Enqueue(obj);
        }

        public static void Register(Texture2D texture, Vector2 position, double rotation, Color color)
        {
            if (unusedList_.Count == 0)
            {
                unusedList_.Enqueue(new DrawingObject());
            }

            DrawingObject temp = unusedList_.Dequeue();
            temp.Initialize(texture, position, rotation, color);
            Register(temp);
        }

        public static void Register(Texture2D texture, Vector2 position, double rotation)
        {
            Register(texture, position, rotation, Color.White);
        }

        public static void Register(Texture2D texture, Vector2 position)
        {
            Register(texture, position, 0);
        }

        private static void Transform(DrawingObject obj)
        {
            // Todo: Object-space to pixel-space transformations.
        }

        public static void Draw(SpriteBatch sb)
        {
            foreach(DrawingObject d in usedList_)
            {
                sb.Draw(d.Texture, d.Position, d.Color); 
            }
            if (usedList_.Count > 0)
            {
                unusedList_.Enqueue(usedList_.Dequeue());
            }
        }
    }
}
