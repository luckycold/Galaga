using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Galaga
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Background[] starArray;
        Texture2D starTexture;
        SpriteFont scoreFont, endFont;
        int screenWidth, screenHeight, timer, seconds;
        Current_Score currentScore;
        End_Screen endScreen;
        Texture2D enemyTex;
        bool gameStatus;
        Enemies enemy;
        List<Rectangle> eList;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 224*3;
            graphics.PreferredBackBufferHeight = 288*3;
            graphics.ApplyChanges();

            this.Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            starArray = new Background[100];
            for (int i = 0; i < starArray.Length; i++)
                starArray[i] = new Background();
            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;
            currentScore = new Current_Score();
            endScreen = new End_Screen();
            gameStatus = true;
            timer = 0;
            seconds = 0;
            enemy = new Enemies(enemyTex);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            starTexture = this.Content.Load<Texture2D>("Star");
            scoreFont = this.Content.Load<SpriteFont>("CurrentScore");
            endFont = this.Content.Load<SpriteFont>("EndScreen");
            enemyTex = this.Content.Load<Texture2D>("Enemy");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kb.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            timer++;
            seconds = timer % 60;
            for(int i = 0; i < starArray.Length;i++)
            {
                starArray[i].starMove();
            }
            eList = enemy.move();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if(gameStatus)
            {
                for (int i = 0; i < starArray.Length; i++)
                    spriteBatch.Draw(starTexture, new Rectangle(starArray[i].getPosX(), starArray[i].getPosY(), starArray[i].getWidth(), starArray[i].getHeight()), starArray[i].getColor());

                spriteBatch.DrawString(scoreFont, currentScore.getCurrentScoreText(), new Vector2(20, 0), Color.Red);
                spriteBatch.DrawString(scoreFont, "" + currentScore.getCurrentScore(), new Vector2(30, 30), Color.White);
            }
            else //gameStatus = false, means that the player ran out of lives and died --> game over
            {
                spriteBatch.DrawString(endFont, endScreen.getGameOver(), new Vector2(screenWidth / 2, screenHeight / 2), Color.AliceBlue);
                spriteBatch.DrawString(endFont, endScreen.getResult(), new Vector2(screenWidth / 2, screenHeight / 2), Color.Red);
                spriteBatch.DrawString(endFont, endScreen.getShotsFired(), new Vector2(screenWidth / 2, screenWidth / 2 + 50), Color.Yellow);
                spriteBatch.DrawString(endFont, endScreen.getNumOfHits(), new Vector2(screenWidth / 2, screenHeight / 2 + 100), Color.Yellow);
                spriteBatch.DrawString(endFont, endScreen.getHitMissRatio(), new Vector2(screenWidth / 2, screenHeight / 2 + 150), Color.White);
            }
            for(int i = 0; i < eList.Count;i++)
            {
                spriteBatch.Draw(enemyTex, eList[i], Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
