using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Painting
{
    class EventButton:Button
    {
        enum EventType { intMailbox, stringMailbox };
        EventType eventType;

        Mailbox.Name intMailbox;
        string stringMailbox;

        public EventButton(string name, Mailbox.Name mailbox, int xPosition, int yPosition)
        {
            this.intMailbox = mailbox;
            this.eventType = EventType.intMailbox;

            this.unselectedTexture = ContentLibrary.Get(name);
            this.mouseOverTexture = unselectedTexture;
            this.mousePressTexture = unselectedTexture;

            this.bounds = new Rectangle(xPosition, yPosition, 100, 50);
        }

        public EventButton(string name, string mailbox, int xPosition, int yPosition)
        {
            this.stringMailbox = mailbox;
            this.eventType = EventType.stringMailbox;

            this.unselectedTexture = ContentLibrary.Get(name);
            this.mouseOverTexture = unselectedTexture;
            this.mousePressTexture = unselectedTexture;

            this.bounds = new Rectangle(xPosition, yPosition, 100, 50);
        }

        public override void UponSelect()
        {
            switch (eventType)
            {
                case EventType.intMailbox:
                    Mailbox.FlagMailbox(intMailbox);
                    break; 

                case EventType.stringMailbox:
                    Mailbox.FlagMailbox(stringMailbox);
                    break;
            }
        }
    }
}
