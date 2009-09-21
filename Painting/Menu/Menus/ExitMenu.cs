using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Painting
{
    class ExitMenu:Menu
    {
        EventButton yesButton;
        EventButton noButton;

        Texture2D background;

        public ExitMenu()
        {
            yesButton = new EventButton("yesButton", Mailbox.Name.ExitProgram, 200, 100);
            noButton = new EventButton("noButton", Mailbox.Name.CloseActiveMenu, 300, 100);
            List<Button> buttonList = new List<Button>(2);
            buttonList.Add(yesButton);
            buttonList.Add(noButton);

            background = ContentLibrary.Get("background70");
            base.Initialize("Exit", noButton, buttonList);
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            base.Draw();
        }
    }
}
