using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Classes
{
    class movinganimatedSprite: ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int CurrentFrameleft;
        private int CurrentFrameright;
        private int TotalFrames;
        private Vector2 drawlocation;
        private float Boundary;
        private bool movingright;

        public movinganimatedSprite(Texture2D texture, int rows, int columns, GraphicsDevice gd)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrameleft = 30;
            CurrentFrameright = 20;
            TotalFrames = 1 * Columns;
            drawlocation.X = 0;
            Boundary = gd.Viewport.Width-(Texture.Width/Columns);
            drawlocation.Y = gd.Viewport.Height / 4;
            movingright = true;
        }

        public void Update()
        {
            CurrentFrameleft++;
            CurrentFrameright++;

            if (CurrentFrameleft == 39 || CurrentFrameright == 29)
            {
                CurrentFrameleft = 30;
                CurrentFrameright = 20;
            }

            if (movingright && drawlocation.X < Boundary)
            {
                drawlocation.X+=10;
                if (drawlocation.X >=Boundary)
                {
                    movingright = false;
                }
            }
            else if (!movingright && drawlocation.X >=1)
            {
                drawlocation.X-=10;
                if (drawlocation.X <= 1)
                {
                    movingright = true;
                }
            }
        }

        public void Draw(GraphicsDevice gd, SpriteBatch sb, SpriteFont font, Vector2 location)
        {
            int width = Texture.Width / Columns; // width of individual frame
            int height = Texture.Height / Rows;  // height of individual frame

            if(movingright)
            { CurrentFrame = CurrentFrameright; }

            else { CurrentFrame = CurrentFrameleft; }

            int row = (int)((float)CurrentFrame / (float)Columns); // calculate which row the frame to draw is in
            int column = CurrentFrame % Columns; // calculate which column the frame to draw is in 

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)drawlocation.X, (int)drawlocation.Y, width, height);

            System.Diagnostics.Debug.WriteLine("CurrentFrame: "+CurrentFrame+ "Movingright: "+movingright);
            sb.Begin();
            sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            sb.End();
        }
    }
}
