using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painting
{
    static class MenuManager
    {
        public static Menu ActiveMenu { 
            get {
                if (activeMenuList.Count > 0){
                    return activeMenuList[activeMenuList.Count - 1];
                }
                else{
                    return null;
                }
            }
        }
        public static Button CurrentButton;

        private static Dictionary<string,Menu> menuList = new Dictionary<string,Menu>(10);
        private static List<Menu> activeMenuList = new List<Menu>(10);

        public static void Update()
        {
            if (Input.Menu() || Mailbox.CheckMailbox(Mailbox.Name.CloseActiveMenu))
            {
                if (IsMenuActive())
                {
                    Deactivate(ActiveMenu);
                }
                else if ( Input.Menu() )
                {
                    //If no menu is active and the menu button is pressed,
                    //try to open the main menu.
                    Activate("Main");
                    CursorManager.SetCursorType(PointerCursor.Type);
                }
            }

            foreach (KeyValuePair<string, Menu> kvp in menuList)
            {
                if (Mailbox.CheckMailbox(kvp.Value.Name + Mailbox.MenuOpenSuffix))
                    Activate(kvp.Value);

                if (Mailbox.CheckMailbox(kvp.Value.Name + Mailbox.MenuCloseSuffix))
                    Deactivate(kvp.Value);
            }

            if (IsMenuActive())
                ActiveMenu.Update();
        }

        public static void Draw()
       {
            for(int i=0; i<activeMenuList.Count; i++)
                activeMenuList[i].Draw();
        }

        public static bool IsMenuActive()
        {
            if (ActiveMenu == null)
                return false;
            else
                return true;
        }

        public static void Register(Menu menu)
        {
            if (menu.Name == null)
                throw new Exception("Menu was not initialized before registering.");

            menuList.Add(menu.Name, menu);
        }

        public static void Activate(Menu menu)
        {
            Activate(menu.Name);
        }

        public static void Activate(string name)
        {
            Menu temp;
            if (menuList.TryGetValue(name, out temp))
                activeMenuList.Add(temp);
        }

        public static void Deactivate(Menu menu)
        {
            Deactivate(menu.Name);
        }

        public static void Deactivate(string name)
        {
            for (int i = 0; i < activeMenuList.Count; i++)
                if (activeMenuList[i].Name == name)
                    activeMenuList.RemoveAt(i);
        }
    }
}
