using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painting
{
    static class Mailbox
    {
        //Int Boxes
        #region Int Boxes
        public enum Name
        {
            IncreaseBrushSize = 0,
            DecreaseBrushSize,
            ExitProgram,
            CloseActiveMenu,
            ExitMenuActivate,

            // Add all before this line
            MailboxCapacity
        }
        private static bool[] intMailbox = new bool[(int)Name.MailboxCapacity];
        #endregion

        //Stringbox
        public const string MenuOpenSuffix = "MenuOpen";
        public const string MenuCloseSuffix = "MenuClose";
        private static Dictionary<string, bool> stringBox = new Dictionary<string, bool>();
        

        public static void FlagMailbox(Name boxName)
        {
            intMailbox[(int)boxName] = true;
        }

        public static bool CheckMailbox(Name boxName)
        {
            int boxNumber = (int)boxName;

            if (intMailbox[boxNumber]){
                intMailbox[boxNumber] = false;
                return true;
            }
            else{
                return false;
            }
        }

        public static void FlagMailbox(string boxName)
        {
            stringBox.Add(boxName, true);
        }

        public static bool CheckMailbox(string boxName)
        {
            bool value;
            if (stringBox.TryGetValue(boxName, out value))
            {
                stringBox.Remove(boxName);
                return value;
            }

            return false;
        }
    }
}
