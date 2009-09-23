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
        public const string Name = "Exit";

        IntBoxButton yesButton;
        IntBoxButton noButton;

        Texture2D background;

        public ExitMenu()
        {
            yesButton = new IntBoxButton("yesButton", Mailbox.Name.ExitProgram, 200, 100);
            noButton = new IntBoxButton("noButton", Mailbox.Name.CloseActiveMenu, 300, 100);
            List<Button> buttonList = new List<Button>(2);
            buttonList.Add(noButton);
            buttonList.Add(yesButton);            

            background = ContentLibrary.Get("background70");
            base.RegisterButtons(buttonList);
        }

        public override string InstanceName()
        {
            return Name;
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            base.Draw();
        }
    }
}
