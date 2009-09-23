using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Painting
{
    class IntBoxButton:Button
    {
        Mailbox.Name intMailbox;

        public IntBoxButton(string name, Mailbox.Name mailbox, int xPosition, int yPosition)
        {
            intMailbox = mailbox;

            this.unselectedTexture = ContentLibrary.Get(name);
            this.mouseOverTexture = unselectedTexture;
            this.mousePressTexture = unselectedTexture;

            this.bounds = new Rectangle(xPosition, yPosition, 100, 50);
        }

        public override void UponSelect()
        {
            Mailbox.FlagMailbox(intMailbox);
        }
    }
}
