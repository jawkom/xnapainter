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
        //DefaultButton
        public Button DefaultButton { get { return defaultButton; } }
        private Button defaultButton;

        //Traits that each menu will have to initialize.
        private List<Button> buttonList; //extending classes should register their buttons with the ButtonList

        public abstract string InstanceName();

        protected void RegisterButtons(List<Button> buttonList)
        {
            if (buttonList.Count > 0)
                this.defaultButton = buttonList[0];

            this.buttonList = buttonList;
        }

        virtual public void Update()
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
