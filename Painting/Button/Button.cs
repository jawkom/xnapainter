using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Painting
{
    abstract class Button
    {
        enum ButtonState { Unselected, MouseOver, MousePress }
        ButtonState currentState;

        protected Texture2D unselectedTexture;
        protected Texture2D mouseOverTexture;
        protected Texture2D mousePressTexture;

        protected Rectangle bounds;
        protected string name;


        public abstract void UponSelect();


        public void Update()
        {
            //if mouse is over button
            if (bounds.Intersects(new Rectangle(Input.mouse.X, Input.mouse.Y, 1, 1)))
            {
                if (Input.MouseLeftPressed())
                {
                    currentState = ButtonState.MousePress;
                    DrawingLayer.Register(new DrawingObject(mousePressTexture, new Vector2(bounds.Location.X, bounds.Location.Y)));
                }
                else if (Input.MouseLeftPressAndRelease())
                {
                    UponSelect();
                    currentState = ButtonState.MouseOver;
                    DrawingLayer.Register(new DrawingObject(mouseOverTexture, new Vector2(bounds.Location.X, bounds.Location.Y)));
                }
                else
                {
                    currentState = ButtonState.MouseOver;
                    DrawingLayer.Register(new DrawingObject(mouseOverTexture, new Vector2(bounds.Location.X, bounds.Location.Y)));
                }
            }
            else
            {
                currentState = ButtonState.Unselected;
                DrawingLayer.Register(new DrawingObject(unselectedTexture, new Vector2(bounds.Location.X, bounds.Location.Y)));
            }
        }


        public void Draw()
        {
            switch (currentState)
            {
                case ButtonState.Unselected:
                    Game1.spriteBatch.Draw(unselectedTexture, new Vector2(bounds.Location.X, bounds.Location.Y), Color.White);
                    break;

                case ButtonState.MouseOver:
                    Game1.spriteBatch.Draw(mouseOverTexture, new Vector2(bounds.Location.X, bounds.Location.Y), Color.White);
                    break;

                case ButtonState.MousePress:
                    Game1.spriteBatch.Draw(mousePressTexture, new Vector2(bounds.Location.X, bounds.Location.Y), Color.White);
                    break;

            }
        }
    }
}
