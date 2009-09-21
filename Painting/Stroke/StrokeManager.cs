using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painting
{
    class StrokeManager
    {
        static Stroke[] strokeList;
        static int currentStroke;

        public StrokeManager()
        {
            strokeList = new Stroke[5];
            currentStroke = 0;
            for(int i=0; i<strokeList.Length; i++)
                strokeList[i] = new Stroke();
            strokeList[currentStroke].Activate();
        }

        public void Update()
        {
            //Check Input
            if (Input.Save())
            {
                for(int i=0; i<strokeList.Length; i++)
                {
                    strokeList[i].Export(i);
                }
            }

            if (Input.Load())
            {
                for(int i=0; i<strokeList.Length; i++)
                {
                    strokeList[i] = Stroke.Import(i);
                    if (strokeList[i] == null)
                        strokeList[i] = new Stroke();
                }
            }

            if (Input.Delete())
                Stroke.Delete(0);

            if (Input.Clear())
                strokeList[currentStroke].Clear();

            if (Input.Toggle4())
                SetActiveStroke(0);

            if (Input.Toggle5())
                SetActiveStroke(1);


            //Check Mailboxes
            if(Mailbox.CheckMailbox(Mailbox.Name.IncreaseBrushSize))
            {
                strokeList[currentStroke].ScaleChange(1);
            }

            if (Mailbox.CheckMailbox(Mailbox.Name.DecreaseBrushSize))
            {
                strokeList[currentStroke].ScaleChange(-1);
            }

            if (!MenuManager.IsMenuActive())
            {
                for (int i = 0; i < strokeList.Length; i++)
                    strokeList[i].Update();

                if (CursorManager.GetCursorType() != BrushCursor.Type)
                {
                    CursorManager.SetCursorType(BrushCursor.Type);
                }
            }
        }

        public void Draw()
        {
            for(int i=0; i<strokeList.Length; i++)
                strokeList[i].Draw();
        }

        //////////////////////////////////////////
        //// Other Functions
        //////////////////////////////////////////

        public static void ChangeStrokeSize(int change)
        {
            if (strokeList[currentStroke] != null)
                strokeList[currentStroke].ScaleChange(change);
        }

        public static Stroke GetActiveStroke()
        {
            return strokeList[currentStroke];
        }

        public static void SetActiveStroke(int strokeNumber)
        {
            if (strokeNumber < strokeList.Length)
            {
                strokeList[currentStroke].Deactivate();
                currentStroke = strokeNumber;
                strokeList[currentStroke].Activate();
            }
        }
    }
}
