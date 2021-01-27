using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Classes
{
    class nonmovinganimated: ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int TotalFrames;

        public nonmovinganimated(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = 1 * Columns;
            //System.Diagnostics.Debug.WriteLine("Rows: "+Rows+"Columns: "+Columns);
        }

        public void Update()
        {
            
            CurrentFrame++;
            //System.Diagnostics.Debug.WriteLine("CurrentFrame 1: "+CurrentFrame);
            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
            
        }

        public void Draw(GraphicsDevice gd, SpriteBatch sb, SpriteFont font, Vector2 location)
        {
            
            int width = Texture.Width / Columns; // width of individual frame
            int height = Texture.Height / Rows;  // height of individual frame
            int row = (int)((float)CurrentFrame / (float)Columns); // calculate which row the frame to draw is in
            int column = CurrentFrame % Columns; // calculate which column the frame to draw is in 

            Rectangle sourceRectangle = new Rectangle(width * column, height * 1, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            //System.Diagnostics.Debug.WriteLine("CurrentFrame: "+CurrentFrame+ "Row: "+row+" Column: "+column);
            sb.Begin();
            sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            sb.End();
        }
    }
}
