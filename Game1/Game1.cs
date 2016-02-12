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
        public Texture2D background;
        public Texture2D gameover;
        public bool gameOver = false;
        public double ballCounter = 0;
        public int ballTimer = 5000;

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
            Statics.PIXEL = Content.Load<Texture2D>("Textures/pixel");

            Reset();

            // TODO: use this.Content to load your game content here
        }
        public void Reset()
        {
            Man = new Entities.Man();
            Balls = new List<Entities.Ball>();
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            Statics.GAMETIME = gameTime;
            Statics.INPUT.Update();


            ballCreator();
            if (!gameOver)
            {                
                foreach (Entities.Ball Ball in Balls)
                {
                    Ball.Update();
                }
                Man.Update();
            }
            foreach (Entities.Ball Ball in Balls)
            {
                if (Man.Bound.Intersects(Ball.Bound))
                {
                    gameOver = true;
                }
            }

            if (Statics.INPUT.isKeyPressed(Keys.R))
            {
                gameOver = false;
                Reset();
            }


            // TODO: Add your update logic here

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
