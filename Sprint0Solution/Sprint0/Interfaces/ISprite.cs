using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ISprite
    {
        /*
         * Implementing classes update the position of the sprite image and the frame of the sprite image to be drawn
         */
        public void Update();

        /*
         * The method draws the calculated frame at the paramter location using the spritebatch. In the case of a text sprite 
         * the font is used to draw the text. The graphics device is passed in to calculate the center of screen and relative
         * positions with respect to the screen and texture.
         * 
         */
        public void Draw(GraphicsDevice gd, SpriteBatch sb, SpriteFont font, Vector2 location);
    }
}
