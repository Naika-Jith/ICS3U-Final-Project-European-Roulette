using System;
using System.Collections.Generic;
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
            BlackwoodCastle,
            Main,
            Howtoplay,
            Letter,
            Ballroom,
            Exit
        }

        Screen currentScreen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;



        List<Texture2D> Cards;

        Texture2D shownCard;

        Random rng = new Random();

        int money = 100;

        int currentBet = 0;

        bool showCard = false;
        bool hasBet = false;

        int cardValue;

        SpriteFont font;

        // screens
        Texture2D introTexture;
        Texture2D blackwoodcastleTexture;
        Texture2D mainTexture;
        Texture2D howtoplayTexture;
        Texture2D letterTexture;
        Texture2D ballroomTexture;
        Texture2D exitTexture;


        Rectangle introRect;
        Rectangle blackwoodcastleRect;
        Rectangle mainRect;
        Rectangle howtoplayRect;
        Rectangle letterRect;
        Rectangle ballroomRect;
        Rectangle exitRect;

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

        Texture2D gobackTexture;
        Rectangle gobackRect;

        Texture2D proceedTexture;
        Rectangle proceedRect;

        //Cards
        Texture2D cardBackTexture;
        Rectangle cardRect;

        Texture2D cardFrameTexture;
        Rectangle cardFrameRect;

        MouseState mouseState;
        MouseState previousMouse;

        // Riddles
        Texture2D riddle1Texture;
        Rectangle riddle1Rect;

        //Other
        Texture2D invitationTexture;
        Rectangle invitationRect;

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
            blackwoodcastleRect = new Rectangle(0, 0, 950, 600);
            howtoplayRect = new Rectangle(0, 0, 950, 600);
            mainRect = new Rectangle(0, 0, 950, 600);
            letterRect = new Rectangle(0, 0, 950, 600);
            ballroomRect = new Rectangle(0, 0, 950, 600);
            exitRect = new Rectangle(0, 0, 950, 600);



            beginthenightRect = new Rectangle(600, 50, 325, 115);
            stepoutsideRect = new Rectangle(600, 170, 325, 115);
            blackwoodcastlebtnRect = new Rectangle(600, 280, 325, 140);
            gobackRect = new Rectangle(23, 14, 325, 115);
            proceedRect = new Rectangle(625, 0, 325, 115);

            //Riddles

            riddle1Rect = new Rectangle(119, 100, 700, 290);

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
            cardFrameRect = new Rectangle(405, 115, 193, 309);

            //Other
            invitationRect = new Rectangle(0, 0, 670, 500);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            introTexture = Content.Load<Texture2D>("intro");
            blackwoodcastleTexture = Content.Load<Texture2D>("blackwood castle");
            mainTexture = Content.Load<Texture2D>("main");
            howtoplayTexture = Content.Load<Texture2D>("howtoplay");
            letterTexture = Content.Load<Texture2D>("letter");
            ballroomTexture = Content.Load<Texture2D>("ballroom");
            exitTexture = Content.Load<Texture2D>("exit");


            beginthenightTexture = Content.Load<Texture2D>("begin the night");
            stepoutsideTexture = Content.Load<Texture2D>("step outside");
            blackwoodcastlebtnTexture = Content.Load<Texture2D>("blackwood castlebtn");
            gobackTexture = Content.Load<Texture2D>("goback");
            proceedTexture = Content.Load<Texture2D>("proceed");

            bet20Texture = Content.Load<Texture2D>("bet20");
            bet40Texture = Content.Load<Texture2D>("bet40");
            bet100Texture = Content.Load<Texture2D>("bet100");

            highTexture = Content.Load<Texture2D>("high");
            lowTexture = Content.Load<Texture2D>("low");

            //Riddles

            riddle1Texture = Content.Load<Texture2D>("riddle1");

            //font
            font = Content.Load<SpriteFont>("font");

            //Other
            invitationTexture = Content.Load<Texture2D>("invitation");

            //Cards

            Cards = new List<Texture2D>();

            cardBackTexture = Content.Load<Texture2D>("card_back");
            cardFrameTexture = Content.Load<Texture2D>("card_frame");

            // Clubs
            Cards.Add(Content.Load<Texture2D>("card_clubs_02"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_03"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_04"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_05"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_06"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_07"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_08"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_09"));
            Cards.Add(Content.Load<Texture2D>("card_clubs_10"));

            // Diamonds
            Cards.Add(Content.Load<Texture2D>("card_diamonds_02"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_03"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_04"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_05"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_06"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_07"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_08"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_09"));
            Cards.Add(Content.Load<Texture2D>("card_diamonds_10"));

            // Hearts
            Cards.Add(Content.Load<Texture2D>("card_hearts_02"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_03"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_04"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_05"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_06"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_07"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_08"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_09"));
            Cards.Add(Content.Load<Texture2D>("card_hearts_10"));

            // Spades
            Cards.Add(Content.Load<Texture2D>("card_spades_02"));
            Cards.Add(Content.Load<Texture2D>("card_spades_03"));
            Cards.Add(Content.Load<Texture2D>("card_spades_04"));
            Cards.Add(Content.Load<Texture2D>("card_spades_05"));
            Cards.Add(Content.Load<Texture2D>("card_spades_06"));
            Cards.Add(Content.Load<Texture2D>("card_spades_07"));
            Cards.Add(Content.Load<Texture2D>("card_spades_08"));
            Cards.Add(Content.Load<Texture2D>("card_spades_09"));
            Cards.Add(Content.Load<Texture2D>("card_spades_10"));

            shownCard = Cards[rng.Next(Cards.Count)];
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            previousMouse = mouseState;
            mouseState = Mouse.GetState();

            this.Window.Title = mouseState.Position.ToString();

            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
                {

                    if (beginthenightRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.Letter;
                    }


                    if (stepoutsideRect.Contains(mouseState.Position)) // Had to switch from step outside to How to Play
                    {
                        currentScreen = Screen.Howtoplay;
                    }


                    if (blackwoodcastlebtnRect.Contains(mouseState.Position))
                    {
                        currentScreen = Screen.BlackwoodCastle;
                    }

                }

            }

            else if (currentScreen == Screen.BlackwoodCastle)
            {
                if (mouseState.LeftButton == ButtonState.Pressed & previousMouse.LeftButton == ButtonState.Released && gobackRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.Intro;
                }
            }

            else if (currentScreen == Screen.Howtoplay)
            {
                if (mouseState.LeftButton == ButtonState.Pressed & previousMouse.LeftButton == ButtonState.Released && gobackRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.Intro;
                }
            }

            else if (currentScreen == Screen.Letter)
            {
                if (mouseState.LeftButton == ButtonState.Pressed & previousMouse.LeftButton == ButtonState.Released && proceedRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.Ballroom;
                }
            }

            else if (currentScreen == Screen.Ballroom)
            {
                if (mouseState.LeftButton == ButtonState.Pressed & previousMouse.LeftButton == ButtonState.Released && proceedRect.Contains(mouseState.Position))
                {
                    currentScreen = Screen.Main;
                }
            }

            else if (currentScreen == Screen.Main)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released && bet20Rect.Contains(mouseState.Position))
                    {
                        currentBet = 20;
                        hasBet = true;
                    }

                    else if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released && bet40Rect.Contains(mouseState.Position))
                    {
                        currentBet = 40;
                        hasBet = true;
                    }

                    else if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released && bet100Rect.Contains(mouseState.Position))
                    {
                        currentBet = 100;
                        hasBet = true;
                    }

                    if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released && highRect.Contains(mouseState.Position))
                    {
                        if (hasBet)
                        {
                            int randomCard = rng.Next(0, 36);

                            shownCard = Cards[randomCard];  //Picks one random card image from the deck and display it
                            showCard = true;
                            cardValue = randomCard % 9 + 2;

                            if (cardValue == 6)
                            {
                                money -= currentBet;
                            }
                            else if (cardValue > 6)
                            {
                                money += currentBet;
                            }
                            else
                            {
                                money -= currentBet;
                            }

                            hasBet = false;
                        }

                    }

                    if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released && lowRect.Contains(mouseState.Position))
                    {
                        if (hasBet)
                        {
                            int randomCard = rng.Next(0, 36);

                            shownCard = Cards[randomCard]; //Picks one random card image from the deck and display it
                            showCard = true;
                            cardValue = randomCard % 9 + 2;

                            if (cardValue == 6)
                            {
                                money -= currentBet;
                            }
                            else if (cardValue < 6)
                            {
                                money += currentBet;
                            }
                            else
                            {
                                money -= currentBet;
                            }

                            hasBet = false;
                        }
                    }

                    else if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
                    {

                        if (proceedRect.Contains(mouseState.Position))
                        {
                            currentScreen = Screen.Exit;
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

            else if (currentScreen == Screen.Letter)
            {
                _spriteBatch.Draw(letterTexture, letterRect, Color.White);
                _spriteBatch.Draw(invitationTexture, invitationRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
            }

            else if (currentScreen == Screen.Ballroom)
            {
                _spriteBatch.Draw(ballroomTexture, ballroomRect, Color.White);
                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);
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

                //Bet

                _spriteBatch.DrawString(font, "Money: $" + money, new Vector2(20, 500), Color.Gold);

                _spriteBatch.DrawString(font, "Bet: $" + currentBet, new Vector2(20, 540), Color.White);

                _spriteBatch.Draw(cardFrameTexture, cardFrameRect, Color.White);

                _spriteBatch.Draw(proceedTexture, proceedRect, Color.White);

            }

            else if (currentScreen == Screen.Exit)
            {
                _spriteBatch.Draw(exitTexture, exitRect, Color.White);
            }


            else if (currentScreen == Screen.Howtoplay)
            {
                _spriteBatch.Draw(howtoplayTexture, howtoplayRect, Color.White);
                _spriteBatch.Draw(gobackTexture, gobackRect, Color.White);
            }

            else if (currentScreen == Screen.BlackwoodCastle) //Description
            {
                _spriteBatch.Draw(blackwoodcastleTexture, blackwoodcastleRect, Color.White);
                _spriteBatch.Draw(gobackTexture, gobackRect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}