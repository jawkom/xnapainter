using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Painting
{
    class MainMenu:Menu
    {
        EventButton increaseSize;
        EventButton decreaseSize;
        EventButton exitButton;

        Texture2D background;

        public MainMenu()
        {
            increaseSize = new EventButton("plusButton", Mailbox.Name.IncreaseBrushSize, 400, 200);
            decreaseSize = new EventButton("minusButton", Mailbox.Name.DecreaseBrushSize, 200, 200);
            exitButton = new EventButton("exitButton", "ExitMenuOpen", 0, 0);
            List<Button> buttonList = new List<Button>(3);
            buttonList.Add(increaseSize);
            buttonList.Add(decreaseSize);
            buttonList.Add(exitButton);

            background = ContentLibrary.Get("background70");
            base.Initialize("Main", exitButton, buttonList);
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            base.Draw();
        }
    }
}
