using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Painting
{
    class StringBoxButton:Button
    {
        string stringMailbox;

        public StringBoxButton(string name, string mailbox, int xPosition, int yPosition)
        {
            stringMailbox = mailbox;

            this.unselectedTexture = ContentLibrary.Get(name);
            this.mouseOverTexture = unselectedTexture;
            this.mousePressTexture = unselectedTexture;

            this.bounds = new Rectangle(xPosition, yPosition, 100, 50);
        }

        public override void UponSelect()
        {
            Mailbox.FlagMailbox(stringMailbox);
        }
    }
}
