using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Interfaces
{
    interface IController
    {
        /*
         * The method takes in the current mousestate, keystate and graphics device and returns the sprite option to be displayed
         */
        public int CommandFromKey(KeyboardState keyboard, MouseState mouseState, GraphicsDevice graphicsDevice);
    }
}
