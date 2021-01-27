using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;

namespace Sprint0.Classes
{
    class KeyboardController: IController
    {
        public int CommandFromKey(KeyboardState keyboardstate, MouseState mousestate, GraphicsDevice graphicsdevice)
        {
            int command = 5;
            if(keyboardstate.IsKeyDown(Keys.NumPad0))
            {command= 0;}

            else if (keyboardstate.IsKeyDown(Keys.NumPad1) || keyboardstate.IsKeyDown(Keys.D1))
            {command= 1;}

            else if (keyboardstate.IsKeyDown(Keys.NumPad2) || keyboardstate.IsKeyDown(Keys.Down) || keyboardstate.IsKeyDown(Keys.D2))
            {command =2;}

            else if (keyboardstate.IsKeyDown(Keys.NumPad3) || keyboardstate.IsKeyDown(Keys.D3))
            {command = 3;}

            else if (keyboardstate.IsKeyDown(Keys.NumPad4) || keyboardstate.IsKeyDown(Keys.Left) || keyboardstate.IsKeyDown(Keys.D4))
            {command = 4;}
            return command;
        }
    }
}
