using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ICS3U_Final_Project_European_Roulette
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            Letter,
            BlackwoodCastle
        }

        Screen currentScreen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        // screens
        Texture2D introTexture;
        Texture2D letterTexture;
        Texture2D blackwoodcastleTexture;
       
        Rectangle introRect;
        Rectangle letterRect;
        Rectangle blackwoodcastleRect;

        // Buttons
        Texture2D beginthenightTexture;
        Rectangle beginthenightRect;

        Texture2D blackwoodcastlebtnTexture;
        Rectangle blackwoodcastlebtnRect;

        Texture2D stepoutsideTexture;
        Rectangle stepoutsideRect;

        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 950, 600);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            currentScreen = Screen.Intro;

            introRect = new Rectangle(0, 0, 950, 600);
            letterRect = new Rectangle(0, 0, 950, 600);
            blackwoodcastleRect =new Rectangle(0, 0, 950, 600);

            beginthenightRect = new Rectangle(600, 50, 325, 115);
            stepoutsideRect = new Rectangle(600, 170, 325, 115);
            blackwoodcastlebtnRect = new Rectangle(600, 290, 325, 140);
          

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introTexture = Content.Load<Texture2D>("intro");
            letterTexture = Content.Load<Texture2D>("letter");
            blackwoodcastleTexture = Content.Load<Texture2D>("blackwood castle");

            beginthenightTexture = Content.Load<Texture2D>("begin the night");
            stepoutsideTexture = Content.Load<Texture2D>("step outside");
            blackwoodcastlebtnTexture = Content.Load<Texture2D>("blackwood castlebtn");
            
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           
            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                  
                    if (beginthenightRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.Letter;
                    }

                   
                    if (stepoutsideRect.Contains(mouseState.Position))
                    {
                        Exit();   
                    }


                    if (blackwoodcastlebtnRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.BlackwoodCastle;
                    }

                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (currentScreen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.Draw(beginthenightTexture, beginthenightRect, Color.White);
                _spriteBatch.Draw(stepoutsideTexture, stepoutsideRect, Color.White);
                _spriteBatch.Draw(blackwoodcastlebtnTexture, blackwoodcastlebtnRect, Color.White);
            }
            else if (currentScreen == Screen.Letter)
            {
                _spriteBatch.Draw(letterTexture, letterRect, Color.White);
            }

            else if (currentScreen == Screen.BlackwoodCastle)
            {
                _spriteBatch.Draw(blackwoodcastleTexture, blackwoodcastleRect, Color.White);

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}