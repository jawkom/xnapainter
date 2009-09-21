using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Painting
{
    abstract class Menu
    {
        //Name
        public string Name { get { return name; } }
        private string name;

        //DefaultButton
        public Button DefaultButton { get { return defaultButton; } }
        private Button defaultButton;

        //Traits that each menu will have to initialize.
        private List<Button> buttonList; //extending classes should register their buttons with the ButtonList

        protected void Initialize(string name, Button defaultButton, List<Button> buttonList)
        {
            this.name = name;
            this.defaultButton = defaultButton;
            this.buttonList = buttonList;
        }

        public void Update()
        {
            for (int i = 0; i < buttonList.Count; i++)
                buttonList[i].Update();
        }

        virtual public void Draw()
        {
            for (int i = 0; i < buttonList.Count; i++)
                buttonList[i].Draw();
        }
    }
}
