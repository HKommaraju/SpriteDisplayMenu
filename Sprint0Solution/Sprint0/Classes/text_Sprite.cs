using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Classes;

namespace Sprint0.Classes
{
    public class text_Sprite: ISprite
    {
        
        private string info = "Credits\nProgram made by: Harshitha Kommaraju\n Sprites from: https://opengameart.org/content/rollo-the-hero-character";


        public void Update() { }
        public void Draw(GraphicsDevice gd, SpriteBatch sb, SpriteFont font, Vector2 location)
        {
            
            Vector2 sizeOfText = font.MeasureString(info);
            sb.DrawString(font, info, new Vector2((gd.Viewport.Width - sizeOfText.X) / 2, (gd.Viewport.Height * 3) / 4), Color.White);
            
        }

        
    }
}
