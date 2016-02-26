using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Managers.InputManager input;

        public Entities.Man Man;
        public List<Entities.Ball> Balls;
        public List<Entities.Coin> Coins;
        public Texture2D background;
        public Texture2D gameover;
        public Texture2D startScreen;
        public SpriteFont Font;
        public bool gameOver = false, started = false;
        public double ballCounter = 3000, coinCounter = 0;
        public int ballTimer = 3000, coinTimer = 1000;
        public int score = 0;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            input = new Managers.InputManager();

            Statics.CONTENT = Content;
            Statics.GRAPHICSDEVICE = GraphicsDevice;
            Statics.INPUT = input;
            

            this.graphics.PreferredBackBufferHeight = Statics.GAME_HEIGHT;
            this.graphics.PreferredBackBufferWidth = Statics.GAME_WIDTH;
            this.Window.Title = Statics.GAME_TITLE;
            this.graphics.ApplyChanges();

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

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);           
            Statics.SPRITEBATCH = spriteBatch;
            background = Statics.CONTENT.Load<Texture2D>("Textures/background2x");
            gameover = Statics.CONTENT.Load<Texture2D>("Textures/gameover");
            startScreen = Statics.CONTENT.Load<Texture2D>("Textures/startscreen");
            Font = Statics.CONTENT.Load<SpriteFont>("Fonts/fontx");
            Statics.PIXEL = Content.Load<Texture2D>("Textures/pixel");

            Reset();

            // TODO: use this.Content to load your game content here
        }
        public void Reset()
        {
            Man = new Entities.Man();
            Balls = new List<Entities.Ball>();
            Coins = new List<Entities.Coin>();
            ballCounter = 3000;
            coinCounter = 0;
            score = 0;        
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            Statics.GAMETIME = gameTime;
            Statics.INPUT.Update();
           

            //Handles Updating for all moving elements. Adds balls and coins
            if (!gameOver && started)
            {                
                foreach (Entities.Ball Ball in Balls)
                {
                    Ball.Update();
                }
                foreach (Entities.Coin Coin in Coins)
                {
                    Coin.Update();
                }
                Man.Update();
                if (Man.airborn)
                {
                    if (Balls.Count <= 10)
                        ballCreator();
                    coinCreator();
                }
            }

            //Starting game
            if (!started)
            {
                if (Statics.INPUT.isKeyPressed(Keys.Space))
                {
                    started = true;
                }
            }

            //Checks if a Ball is hit
            foreach (Entities.Ball Ball in Balls)
            {
                if (Man.Bound.Intersects(Ball.Bound) && Ball.live)
                {
                    gameOver = true;
                }               
            }

            //Checks if a coin is collected or hits the ground
            for (int i = Coins.Count-1; i >= 0; i--)
            {
                if (Man.Bound.Intersects(Coins[i].Bound))
                {
                    Coins.RemoveAt(i);
                    score++;
                }
                else if (Coins[i].position.Y >= 600)
                {
                    Coins.RemoveAt(i);
                }
            }

            //checks for a game over by hitting the ground
            if (Man.position.Y >= 650 && Man.airborn)
            {
                gameOver = true;
            }            

            //Reset game
            if (Statics.INPUT.isKeyPressed(Keys.R) && gameOver)
            {
                gameOver = false;
                Reset();
            }
                       

            base.Update(gameTime);
        }

        public void ballCreator()
        {
            ballCounter += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;

            if (ballCounter > ballTimer)
            {
                Balls.Add(new Entities.Ball());
                ballCounter = 0;
            }
        }

        public void coinCreator()
        {
            coinCounter += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (Statics.RANDOM.Next(50) == 1 && coinCounter > coinTimer)
            {
                Coins.Add(new Entities.Coin());
                coinCounter = 0;
            }
        }

        

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            Statics.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);
            Statics.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);
            Man.Draw();
            foreach (Entities.Ball Ball in Balls)
            {
                Ball.Draw();
            }
            foreach (Entities.Coin Coin in Coins)
            {
                Coin.Draw();
            }
            
            Statics.SPRITEBATCH.DrawString(this.Font, "Score : " + this.score.ToString(), new Vector2(10, 10), Color.Black);

            if (!started)
            {
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, new Rectangle(0, 0, Statics.GAME_WIDTH, Statics.GAME_HEIGHT), new Color((int)0 , 0, 20, 5));
                Statics.SPRITEBATCH.Draw(this.startScreen, new Vector2(0, 0), Color.White);
            }
            if (gameOver)
            {
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, new Rectangle(0, 0, Statics.GAME_WIDTH, Statics.GAME_HEIGHT), new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(this.gameover, new Vector2(0, 0), Color.White);
            }

            Statics.SPRITEBATCH.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
