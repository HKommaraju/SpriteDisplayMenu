using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;

namespace Sprint0.Classes
{
    class MouseController: IController
    {
        private MouseState lastmousestate;
        public int CommandFromKey(KeyboardState keystate, MouseState currentmousestate, GraphicsDevice graphicsdevice)
        {
            int command = 5;
            if (lastmousestate.RightButton == ButtonState.Released && currentmousestate.RightButton == ButtonState.Pressed)
            { command = 0; }

            else if (lastmousestate.LeftButton == ButtonState.Released && currentmousestate.LeftButton == ButtonState.Pressed)
            {
                if(currentmousestate.Position.X < graphicsdevice.Viewport.Width/2)
                {
                    if(currentmousestate.Position.Y< graphicsdevice.Viewport.Height/2)
                    {
                        command = 1;
                    }
                    else 
                    {
                        command = 3;
                    }
                }
                else if(currentmousestate.Position.X > graphicsdevice.Viewport.Width/2)
                {
                    if (currentmousestate.Position.Y < graphicsdevice.Viewport.Height / 2)
                    {
                        command = 2;
                    }
                    else 
                    {
                        command = 4;
                    }
                }
            }
            lastmousestate = currentmousestate;
            return command;
        }

    }
}
