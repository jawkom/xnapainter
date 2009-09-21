using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


using System.Text;

namespace Painting
{
    static class Input
    {
        private const int MAX_QUEUE = 5;

        public static KeyboardState keyboard;
        public static GamePadState gamepad;
        public static MouseState mouse;
        private static LimitedQueue<KeyboardState> Kqueue = new LimitedQueue<KeyboardState>(MAX_QUEUE);
        private static LimitedQueue<GamePadState> Gqueue = new LimitedQueue<GamePadState>(MAX_QUEUE);
        private static LimitedQueue<MouseState> Mqueue = new LimitedQueue<MouseState>(MAX_QUEUE);

        public static void Update()
        {
            gamepad = GamePad.GetState(PlayerIndex.One);
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();

            Kqueue.Push(keyboard);
            Gqueue.Push(gamepad);
            Mqueue.Push(mouse);
        }

        public static bool KeyDown(Keys key)
        {
            bool temp = false;

            try
            {
                temp = keyboard.IsKeyDown(key) && Kqueue.Peek(1).IsKeyUp(key);
            }
            catch { }

            return temp;
        }


        /////////////////////////////////////////////////////////////////////
        ///// FUNCTIONS
        /////////////////////////////////////////////////////////////////////

        public static bool Exit()
        {
            bool temp;

            temp = gamepad.IsButtonDown(Buttons.Back);
            temp |= keyboard.IsKeyDown(Keys.Escape);
            
            return temp;
        }

        public static bool Save()
        {
            return KeyDown(Keys.S);
        }

        public static bool Load()
        {
            return KeyDown(Keys.L);
        }

        public static bool Delete()
        {
            return KeyDown(Keys.D);
        }

        public static bool Clear()
        {
            return KeyDown(Keys.C);
        }

        public static bool Menu()
        {
            return KeyDown(Keys.M);
        }



        /////////////////////////////////////////////////////////////////////
        ///// TOGGLES
        /////////////////////////////////////////////////////////////////////

        public static bool Toggle1()
        {
            bool temp;
            
            temp = gamepad.IsButtonDown(Buttons.Start);
            temp |= keyboard.IsKeyDown(Keys.D1);
            
            return temp;
        }

        public static bool Toggle2()
        {
            bool temp;
            
            temp = gamepad.IsButtonDown(Buttons.LeftShoulder);
            temp |= keyboard.IsKeyDown(Keys.D2);
            
            return temp;
        }

        public static bool Toggle3()
        {
            bool temp;

            temp = gamepad.IsButtonDown(Buttons.RightShoulder);
            temp |= keyboard.IsKeyDown(Keys.D3);

            return temp;
        }

        public static bool Toggle4()
        {
            bool temp;

            //temp = gamepad.IsButtonDown(Buttons.RightShoulder);
            temp = keyboard.IsKeyDown(Keys.D4);

            return temp;
        }

        public static bool Toggle5()
        {
            bool temp;

            //temp = gamepad.IsButtonDown(Buttons.RightShoulder);
            temp = keyboard.IsKeyDown(Keys.D5);

            return temp;
        }

        /////////////////////////////////////////////////////////////////////
        ///// MOUSE
        /////////////////////////////////////////////////////////////////////

        public static Vector2 MousePosition(int numFramesAgo)
        {
            return new Vector2(Mqueue.Peek(numFramesAgo).X, Mqueue.Peek(numFramesAgo).Y);
        }

        public static Vector2 MousePosition()
        {
            return new Vector2(mouse.X, mouse.Y);
        }

        public static bool MouseLeftPressed()
        {
            return (mouse.LeftButton == ButtonState.Pressed);
        }

        public static bool MouseLeftPressed(int numFramesAgo)
        {
            return (Mqueue.Peek(numFramesAgo).LeftButton == ButtonState.Pressed);
        }

        public static bool MouseLeftPressAndRelease()
        {
            bool temp = false;

            try
            {
                temp = (Mqueue.Peek(1).LeftButton == ButtonState.Pressed ) && (mouse.LeftButton == ButtonState.Released);
            }
            catch { };

            return temp;
        }
    }
}
