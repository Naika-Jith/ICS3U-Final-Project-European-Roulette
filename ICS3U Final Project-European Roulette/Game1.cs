using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

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

        int currentRiddle;

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

        Texture2D riddle2Texture;
        Rectangle riddle2Rect;

        Texture2D riddle3Texture;
        Rectangle riddle3Rect;

        // Riddle Answers (Correct)
        Texture2D adeckofcardsTexture;
        Rectangle adeckofcardsRect;

        Texture2D chanceTexture;
        Rectangle chanceRect;

        Texture2D luckTexture;
        Rectangle luckRect;

        //Riddle Answers (Wrong) 
        Texture2D thefoursuitsTexture;
        Rectangle thefoursuitsRect;

        Texture2D fateTexture;
        Rectangle fateRect;

        Texture2D destinyTexture;
        Rectangle destinyRect;

        Texture2D quitTexture;
        Rectangle quitRect;


        //Other
        Texture2D invitationTexture;
        Rectangle invitationRect;

        //Music
        SoundEffect introMusic;
        SoundEffect swanLakeMusic;
        SoundEffect endMusic;

        SoundEffect currentMusic;
        SoundEffectInstance musicInstance;
        SoundEffect lastMusic;

        void PlayMusic(SoundEffect sound)
        {
            if (lastMusic == sound)
                return;

            lastMusic = sound;

            if (musicInstance != null)
                musicInstance.Stop();

            musicInstance = sound.CreateInstance();
            musicInstance.IsLooped = true;
            musicInstance.Play();
        }

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
            riddle2Rect = new Rectangle(119, 100, 700, 290);
            riddle3Rect = new Rectangle(119, 100, 700, 290);

            adeckofcardsRect = new Rectangle(150, 420, 250, 80);
            thefoursuitsRect = new Rectangle(520, 420, 250, 80);

            chanceRect = new Rectangle(150, 420, 250, 80);
            fateRect = new Rectangle(520, 420, 250, 80);

            luckRect = new Rectangle(150, 420, 250, 80);
            destinyRect = new Rectangle(520, 420, 250, 80);

            //Main Game

            // left side buttons
            bet20Rect = new Rectangle(30, 50, 150, 90);
            bet40Rect = new Rectangle(30, 130, 150, 90);
            bet100Rect = new Rectangle(30, 210, 150, 90);

            // card in middle
            cardRect = new Rectangle(350, 100, 300, 330);

            // buttons under card
            highRect = new Rectangle(250, 470, 180, 100);
            lowRect = new Rectangle(500, 470, 180, 100);
            cardFrameRect = new Rectangle(405, 115, 193, 309);

            //Other
            invitationRect = new Rectangle(0, 0, 670, 500);
            quitRect = new Rectangle(625, 0, 325, 115);

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
            quitTexture = Content.Load<Texture2D>("quit");


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
            riddle2Texture = Content.Load<Texture2D>("riddle2");
            riddle3Texture = Content.Load<Texture2D>("riddle3");

            //Riddle Answers (Correct)

            adeckofcardsTexture = Content.Load<Texture2D>("adeckofcards");
            chanceTexture = Content.Load<Texture2D>("chance");
            luckTexture = Content.Load<Texture2D>("luck");

            //Riddle Answers (Wrong)

            thefoursuitsTexture = Content.Load<Texture2D>("thefoursuits");
            fateTexture = Content.Load<Texture2D>("fate");
            destinyTexture = Content.Load<Texture2D>("destiny");

            //font
            font = Content.Load<SpriteFont>("font");

            //Other
            invitationTexture = Content.Load<Texture2D>("invitation");

            //Muisc
            introMusic = Content.Load<SoundEffect>("arabian");
            swanLakeMusic = Content.Load<SoundEffect>("swanlake");
            endMusic = Content.Load<SoundEffect>("end");



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

            if (currentScreen == Screen.Intro)
            {
                PlayMusic(introMusic);
            }
            else if (currentScreen == Screen.Letter)
            {
                PlayMusic(introMusic); // or arabian
            }
            else if (currentScreen == Screen.Ballroom)
            {
                PlayMusic(swanLakeMusic);
            }
            else if (currentScreen == Screen.Main)
            {
                PlayMusic(introMusic);
            }
            else if (currentScreen == Screen.Exit)
            {
                PlayMusic(endMusic);
            }
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
                    if (mouseState.LeftButton == ButtonState.Pressed & previousMouse.LeftButton == ButtonState.Released && proceedRect.Contains(mouseState.Position))
                    {
                        currentRiddle = rng.Next(1, 4);
                        currentScreen = Screen.Ballroom;
                    }
                }
            }

            else if (currentScreen == Screen.Ballroom)
            {
              

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released)
                {
                    // RIDDLE 1
                    if (currentRiddle == 1)
                    {
                        if (adeckofcardsRect.Contains(mouseState.Position))
                        {
                            currentScreen = Screen.Main;
                        }

                        if (thefoursuitsRect.Contains(mouseState.Position))
                        {
                            currentRiddle = rng.Next(1, 4);
                        }
                    }

                    // RIDDLE 2
                    else if (currentRiddle == 2)
                    {
                        if (chanceRect.Contains(mouseState.Position))
                        {
                            currentScreen = Screen.Main;
                        }
                        if (fateRect.Contains(mouseState.Position))
                        {
                            currentRiddle = rng.Next(1, 4);
                        }
                    }

                    // RIDDLE 3
                    else if (currentRiddle == 3)
                    {
                        if (luckRect.Contains(mouseState.Position))
                        {
                            currentScreen = Screen.Main;
                        }

                        if (destinyRect.Contains(mouseState.Position))
                        {
                            currentRiddle = rng.Next(1, 4);
                        }
                    }
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
                else if (currentScreen == Screen.Exit)
                    if (mouseState.LeftButton == ButtonState.Pressed &&
    previousMouse.LeftButton == ButtonState.Released &&
    quitRect.Contains(mouseState.Position))
                    {
                        Exit();
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
                if (currentScreen == Screen.Ballroom)
                {
                    _spriteBatch.Draw(ballroomTexture, ballroomRect, Color.White);

                    if (currentRiddle == 1)
                    {
                        _spriteBatch.Draw(riddle1Texture, riddle1Rect, Color.White);

                        _spriteBatch.Draw(adeckofcardsTexture, adeckofcardsRect, Color.White);
                        _spriteBatch.Draw(thefoursuitsTexture, thefoursuitsRect, Color.White);
                    }

                    else if (currentRiddle == 2)
                    {
                        _spriteBatch.Draw(riddle2Texture, riddle2Rect, Color.White);

                        _spriteBatch.Draw(chanceTexture, chanceRect, Color.White);
                        _spriteBatch.Draw(fateTexture, fateRect, Color.White);
                    }

                    else if (currentRiddle == 3)
                    {
                        _spriteBatch.Draw(riddle3Texture, riddle3Rect, Color.White);

                        _spriteBatch.Draw(luckTexture, luckRect, Color.White);
                        _spriteBatch.Draw(destinyTexture, destinyRect, Color.White);
                    }
                }
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
                _spriteBatch.Draw(quitTexture, quitRect, Color.White);

                _spriteBatch.DrawString(
                    font,
                    "Final Money: $" + money,
                    new Vector2(28, 72),
                    Color.Gold
                );
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