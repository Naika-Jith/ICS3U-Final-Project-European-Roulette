using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ICS3U_Final_Project_European_Roulette
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            BlackwoodCastle,
            Main
        }

        Screen currentScreen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D[] cards = new Texture2D[36];

        Texture2D shownCard;

        Random rng = new Random();

        int money = 100;

        int currentBet = 0;

        bool showCard = false;

        int cardValue;

        SpriteFont font;

        // screens
        Texture2D introTexture;
        Texture2D blackwoodcastleTexture;
        Texture2D mainTexture;
       
        Rectangle introRect;
        Rectangle blackwoodcastleRect;
        Rectangle mainRect;

        // Buttons
        Texture2D beginthenightTexture;
        Rectangle beginthenightRect;

        Texture2D blackwoodcastlebtnTexture;
        Rectangle blackwoodcastlebtnRect;

        Texture2D stepoutsideTexture;
        Rectangle stepoutsideRect;

        Texture2D bet20Texture;
        Rectangle bet20Rect;

        Texture2D bet40Texture;
        Rectangle bet40Rect;

        Texture2D bet100Texture;
        Rectangle bet100Rect;

        Texture2D highTexture;
        Texture2D lowTexture;

        Rectangle highRect;
        Rectangle lowRect;

        //Cards
        Texture2D cardBackTexture;
        Rectangle cardRect;


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
            blackwoodcastleRect =new Rectangle(0, 0, 950, 600);
            mainRect = new Rectangle(0, 0, 950, 600);


            beginthenightRect = new Rectangle(600, 50, 325, 115);
            stepoutsideRect = new Rectangle(600, 170, 325, 115);
            blackwoodcastlebtnRect = new Rectangle(600, 290, 325, 140);

            //Main Game

            // left side buttons
            bet20Rect = new Rectangle(30, 50, 150, 90);
            bet40Rect = new Rectangle(30, 130, 150, 90);
            bet100Rect = new Rectangle(30, 210, 150, 90);

            // card in middle
            cardRect = new Rectangle(350, 100, 300, 330);

            // buttons under card
            highRect = new Rectangle(70, 300, 500, 450);
            lowRect = new Rectangle(260, 190, 500, 450);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introTexture = Content.Load<Texture2D>("intro");
            blackwoodcastleTexture = Content.Load<Texture2D>("blackwood castle");
            mainTexture = Content.Load<Texture2D>("main");

            beginthenightTexture = Content.Load<Texture2D>("begin the night");
            stepoutsideTexture = Content.Load<Texture2D>("step outside");
            blackwoodcastlebtnTexture = Content.Load<Texture2D>("blackwood castlebtn");

            bet20Texture = Content.Load<Texture2D>("bet20");
            bet40Texture = Content.Load<Texture2D>("bet40");
            bet100Texture = Content.Load<Texture2D>("bet100");

            highTexture = Content.Load<Texture2D>("high");
            lowTexture = Content.Load<Texture2D>("low");

            //font
            font = Content.Load<SpriteFont>("font");

            //Cards

            cardBackTexture = Content.Load<Texture2D>("card_back");
            cards[0] = Content.Load<Texture2D>("card_clubs_02");
            cards[1] = Content.Load<Texture2D>("card_clubs_03");
            cards[2] = Content.Load<Texture2D>("card_clubs_04");
            cards[3] = Content.Load<Texture2D>("card_clubs_05");
            cards[4] = Content.Load<Texture2D>("card_clubs_06");
            cards[5] = Content.Load<Texture2D>("card_clubs_07");
            cards[6] = Content.Load<Texture2D>("card_clubs_08");
            cards[7] = Content.Load<Texture2D>("card_clubs_09");
            cards[8] = Content.Load<Texture2D>("card_clubs_10");

            cards[9] = Content.Load<Texture2D>("card_diamonds_02");
            cards[10] = Content.Load<Texture2D>("card_diamonds_03");
            cards[11] = Content.Load<Texture2D>("card_diamonds_04");
            cards[12] = Content.Load<Texture2D>("card_diamonds_05");
            cards[13] = Content.Load<Texture2D>("card_diamonds_06");
            cards[14] = Content.Load<Texture2D>("card_diamonds_07");
            cards[15] = Content.Load<Texture2D>("card_diamonds_08");
            cards[16] = Content.Load<Texture2D>("card_diamonds_09");
            cards[17] = Content.Load<Texture2D>("card_diamonds_10");

            cards[18] = Content.Load<Texture2D>("card_hearts_02");
            cards[19] = Content.Load<Texture2D>("card_hearts_03");
            cards[20] = Content.Load<Texture2D>("card_hearts_04");
            cards[21] = Content.Load<Texture2D>("card_hearts_05");
            cards[22] = Content.Load<Texture2D>("card_hearts_06");
            cards[23] = Content.Load<Texture2D>("card_hearts_07");
            cards[24] = Content.Load<Texture2D>("card_hearts_08");
            cards[25] = Content.Load<Texture2D>("card_hearts_09");
            cards[26] = Content.Load<Texture2D>("card_hearts_10");

            cards[27] = Content.Load<Texture2D>("card_spades_02");
            cards[28] = Content.Load<Texture2D>("card_spades_03");
            cards[29] = Content.Load<Texture2D>("card_spades_04");
            cards[30] = Content.Load<Texture2D>("card_spades_05");
            cards[31] = Content.Load<Texture2D>("card_spades_06");
            cards[32] = Content.Load<Texture2D>("card_spades_07");
            cards[33] = Content.Load<Texture2D>("card_spades_08");
            cards[34] = Content.Load<Texture2D>("card_spades_09");
            cards[35] = Content.Load<Texture2D>("card_spades_10");

            shownCard = cards[rng.Next(0, 36)]; // pick a cards from all 36
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            this.Window.Title = mouseState.Position.ToString();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           
            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                  
                    if (beginthenightRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.Main;
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

            if (currentScreen == Screen.Main)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (bet20Rect.Contains(mouseState.Position))
                    {
                        currentBet = 20;
                    }

                    if (bet40Rect.Contains(mouseState.Position))
                    {
                        currentBet = 40;
                    }

                    if (bet100Rect.Contains(mouseState.Position))
                    {
                        currentBet = 100;    
              
                    }

                    if (highRect.Contains(mouseState.Position))
                    {
                        int randomCard = rng.Next(0, 36);

                        shownCard = cards[randomCard];

                        cardValue = (randomCard % 9) + 2;

                        showCard = true;

                        if (cardValue >= 6)
                        {
                            money = money + currentBet;
                        }
                        else
                        {
                            money = money - currentBet;
                        }
                    }



                }
       
            
            
            
            }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (currentScreen == Screen.Intro)  //Intro screen
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
                _spriteBatch.Draw(beginthenightTexture, beginthenightRect, Color.White);
                _spriteBatch.Draw(stepoutsideTexture, stepoutsideRect, Color.White);
                _spriteBatch.Draw(blackwoodcastlebtnTexture, blackwoodcastlebtnRect, Color.White);
            }
            else if (currentScreen == Screen.Main)
            {
                _spriteBatch.Draw(mainTexture, mainRect, Color.White);

                // bet buttons
                _spriteBatch.Draw(bet20Texture, bet20Rect, Color.White);
                _spriteBatch.Draw(bet40Texture, bet40Rect, Color.White);
                _spriteBatch.Draw(bet100Texture, bet100Rect, Color.White);

                // card
                if (showCard == false)
                {
                    _spriteBatch.Draw(cardBackTexture, cardRect, Color.White);
                }
                else
                {
                    _spriteBatch.Draw(shownCard, cardRect, Color.White);
                }
                // high low buttons
                _spriteBatch.Draw(highTexture, highRect, Color.White);
                _spriteBatch.Draw(lowTexture, lowRect, Color.White);
            }

            else if (currentScreen == Screen.BlackwoodCastle) //Description
            {
                _spriteBatch.Draw(blackwoodcastleTexture, blackwoodcastleRect, Color.White);

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}