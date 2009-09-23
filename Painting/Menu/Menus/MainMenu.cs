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
        public const string Name = "Main";

        IntBoxButton increaseSize;
        IntBoxButton decreaseSize;
        StringBoxButton exitButton;

        Texture2D background;

        public MainMenu()
        {
            increaseSize = new IntBoxButton("plusButton", Mailbox.Name.IncreaseBrushSize, 400, 200);
            decreaseSize = new IntBoxButton("minusButton", Mailbox.Name.DecreaseBrushSize, 200, 200);
            exitButton = new StringBoxButton("exitButton", "ExitMenuOpen", 0, 0);
            List<Button> buttonList = new List<Button>(3);
            buttonList.Add(increaseSize);
            buttonList.Add(decreaseSize);
            buttonList.Add(exitButton);

            background = ContentLibrary.Get("background70");;
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
