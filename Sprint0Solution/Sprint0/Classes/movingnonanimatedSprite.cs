using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Classes
{
    class movingnonanimatedSprite: ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int TotalFrames;
        private Vector2 drawlocation;
        private float lowerBoundary;
        private bool movingup;

        public movingnonanimatedSprite(Texture2D texture, int rows, int columns, GraphicsDevice gd)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            drawlocation.X = (gd.Viewport.Width - (texture.Width / columns)) / 2;
            lowerBoundary = gd.Viewport.Height / 4;
            drawlocation.Y = gd.Viewport.Height / 4;
            movingup = true;
        }

        public void Update()
        {
            if(movingup && drawlocation.Y >= 1)
            {
                drawlocation.Y--;
                if(drawlocation.Y<1)
                {
                    movingup = false;
                }
            }
            else if(!movingup && drawlocation.Y<lowerBoundary)
            {
                drawlocation.Y++;
                if(drawlocation.Y >= lowerBoundary)
                {
                    movingup = true;
                }
            }
        }

        public void Draw(GraphicsDevice gd, SpriteBatch sb, SpriteFont font, Vector2 location)
        {
            int width = Texture.Width / Columns; // width of individual frame
            int height = Texture.Height / Rows;  // height of individual frame
            int row = (int)((float)CurrentFrame / (float)Columns); // calculate which row the frame to draw is in
            int column = CurrentFrame % Columns; // calculate which column the frame to draw is in 

            Rectangle sourceRectangle = new Rectangle(width * 1, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)drawlocation.X, (int)drawlocation.Y, width, height);

            //System.Diagnostics.Debug.WriteLine("CurrentFrame: "+CurrentFrame+ "Row: "+row+" Column: "+column);
            sb.Begin();
            sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            sb.End();
        }
    }
}
