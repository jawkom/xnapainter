using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painting
{
    static class CursorManager
    {
        private static Cursor cursor = new HiddenCursor();

        public static void SetCursorType(string cursorType)
        {
            switch(cursorType)
            {
                case BrushCursor.Type:
                    {
                        cursor = new BrushCursor();
                        break;
                    }
                case HiddenCursor.Type:
                    {
                        cursor = new HiddenCursor();
                        break;
                    }

                case PointerCursor.Type:
                    {
                        cursor = new PointerCursor();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public static string GetCursorType()
        {
            return cursor.GetCursorType();
        }

        public static void Update()
        {
            cursor.Update();
        }

        public static void Draw()
        {
            cursor.Draw();
        }
    }
}
