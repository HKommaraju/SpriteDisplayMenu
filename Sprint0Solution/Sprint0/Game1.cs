using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Classes;
using Sprint0.Interfaces;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont ariel22;
        private Texture2D sheet;
        private int rows = 3;
        private int columns = 8;
        private Vector2 centerscreen;

        private int timeSincelastFrame = 0;
        private int millisecondsperframe = 80;
        private readonly text_Sprite drawText = new text_Sprite();

        private bool opt1sel = false;
        private bool opt2sel = false;
        private bool opt3sel = false;
        private bool opt4sel = false;
        private bool beginning = true;

        private stillSprite stillspriteobj;//number 1, non moving non animated
        private nonmovinganimated nonmovinganimatedobj;//= new nm_a_Sprite();// number 2, non moving animated
        private movingnonanimatedSprite movingnonanimatedobj;//number 3, moving non animated
        private movinganimatedSprite movinganimatedobj;//number 4, moving animated

        private KeyboardController keyboardcontroller = new KeyboardController();
        private MouseController mousecontroller = new MouseController();
        private int keycommand;
        private int mousecommand;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ariel22 = Content.Load<SpriteFont>("ariel22");
            sheet = Content.Load<Texture2D>("Rollov4");

            centerscreen.X = (GraphicsDevice.Viewport.Width - (sheet.Width/columns))/2;
            centerscreen.Y = GraphicsDevice.Viewport.Height / 4;
        }

        protected override void Update(GameTime gameTime)
        {
            if (beginning)
            {   keycommand = 1;
                mousecommand = 1;
                beginning = false;
            }

            else
            {
                KeyboardState currentkeyboard = Keyboard.GetState();
                MouseState currentmouse = Mouse.GetState();
                keycommand = keyboardcontroller.CommandFromKey(currentkeyboard,currentmouse,GraphicsDevice);
                mousecommand = mousecontroller.CommandFromKey(currentkeyboard,currentmouse, GraphicsDevice);
            }

            if(keycommand == 0 || mousecommand ==0)
            {
                Exit();
            }
            else if(keycommand == 1 || mousecommand == 1)
            {
                /*fixed position fixed frame:still*/
                keycommand = 1;mousecommand = 1;
                rows = 4; columns = 7;
                centerscreen.X = (GraphicsDevice.Viewport.Width - (sheet.Width / columns)) / 2;
                stillspriteobj = new stillSprite(sheet, rows, columns);
                opt1sel = true; opt2sel = false; opt3sel = false; opt4sel = false;
            }
            else if(keycommand == 2 || mousecommand == 2)
            {
                /*fixed position animated*/
                keycommand = 2; mousecommand = 2;
                rows = 4; columns = 7;
                centerscreen.X = (GraphicsDevice.Viewport.Width - (sheet.Width / columns)) / 2;
                nonmovinganimatedobj = new nonmovinganimated(sheet, rows, columns);
                opt1sel = false; opt2sel = true; opt3sel = false; opt4sel = false;
            }
            else if(keycommand == 3 || mousecommand == 3)
            {
                /*moving position fixed frame*/
                keycommand = 3; mousecommand = 3;
                rows = 4; columns = 7;
                movingnonanimatedobj = new movingnonanimatedSprite(sheet, rows, columns, GraphicsDevice);
                opt1sel = false; opt2sel = false; opt3sel = true; opt4sel = false;
            }

            else if(keycommand == 4 || mousecommand == 4)
            {
                /*moving and animated*/
                keycommand = 4; mousecommand = 4;
                rows = 4; columns = 10;
                movinganimatedobj = new movinganimatedSprite(sheet, rows, columns, GraphicsDevice);
                opt1sel = false; opt2sel = false; opt3sel = false; opt4sel = true;
            }
         
            
            if (opt2sel)
            {
                timeSincelastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if(timeSincelastFrame>millisecondsperframe)
                {
                    timeSincelastFrame = 0;
                    nonmovinganimatedobj.Update();
                }
            }

            else if(opt3sel)
            {
                timeSincelastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSincelastFrame > (millisecondsperframe/7))
                {
                    timeSincelastFrame = 0;
                    movingnonanimatedobj.Update();
                }
            }

            else if(opt4sel)
            {
                timeSincelastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSincelastFrame > (millisecondsperframe))
                {
                    timeSincelastFrame = 0;
                    movinganimatedobj.Update();
                }
            }
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if(opt1sel)
            {
                stillspriteobj.Draw(GraphicsDevice,_spriteBatch,ariel22,centerscreen);
            }
            else if (opt2sel)
            {
                nonmovinganimatedobj.Draw(GraphicsDevice, _spriteBatch, ariel22, centerscreen);
            }

            else if(opt3sel)
            {
                movingnonanimatedobj.Draw(GraphicsDevice, _spriteBatch, ariel22, centerscreen);
            }
            else if(opt4sel)
            {
                movinganimatedobj.Draw(GraphicsDevice, _spriteBatch, ariel22, centerscreen);
            }

            _spriteBatch.Begin();
            drawText.Draw(GraphicsDevice, _spriteBatch, ariel22, centerscreen);
            _spriteBatch.End();
            
            
            base.Draw(gameTime);
        }
    }
}
