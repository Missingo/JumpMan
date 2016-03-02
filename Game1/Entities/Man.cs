using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1.Entities
{
    public class Man
    {
        public Texture2D texture, powerTexture;
        public Vector2 position;
        public float ySpeed;
        public bool airborn = false;
        public bool poweredUp = false;
        public double powerUpCounter = 0;
        public int powerUpTimer = 5000;
        public float xSpeed = 0;       
        public int jumpTimer = 500;
        public int jumpElapsed = 0;

        public Man()
        {
            ySpeed = 0;
            powerUpCounter = 0;
            this.position = new Vector2(475, 650);
            texture = Statics.CONTENT.Load<Texture2D>("Textures/Man");
            powerTexture = Statics.CONTENT.Load<Texture2D>("Textures/ManPowerUp");
        }

        public void Update()
        {
            //Rests character on the floor, bounces if powered up, or adds falling speed if airborne
            if (this.position.Y >= 650)
            {
                if (!poweredUp)
                {
                    ySpeed = 0;
                }
                else
                {
                    ySpeed = -15;
                }

            }
            else
            {
                ySpeed += .4f;
            }

            //"bounces" character off ceiling. Setting to 0 makes it stick for a second
            if (this.position.Y <= 75)
            {
                ySpeed = .01f;
            }

            //jump
            if ((Statics.INPUT.isKeyPressed(Keys.W) || Statics.INPUT.isKeyPressed(Keys.Space)))
            {
                ySpeed = -10;
                airborn = true;
            }

            // L&R movement
            if (Statics.INPUT.currentState().IsKeyDown(Keys.D) && this.position.X < 950)
            {
                xSpeed = 6;                
            }
            if (Statics.INPUT.currentState().IsKeyDown(Keys.A) && this.position.X > 0)
            {
                xSpeed = -6;
            }
            if (Statics.INPUT.currentState().IsKeyDown(Keys.D) && Statics.INPUT.currentState().IsKeyDown(Keys.A))
            {
                xSpeed = 0;
            }
            
            
            //Inputs character movements
            this.position.X += xSpeed;
            xSpeed = 0; //Stops L&R movement after the key is released
            this.position.Y += ySpeed;

            //Keeps character within vertical bounds
            if (this.position.Y > 650)
            {
                this.position.Y = 650;
            }
            if (this.position.Y < 75)
            {
                this.position.Y = 75;
            }

            //Timer for Power Up
            if (poweredUp)
            {
                powerUpCounter += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
                if (powerUpCounter > powerUpTimer)
                {
                    poweredUp = false;
                    powerUpCounter = 0;
                }
            }
        }

        public void Fly()
        {
            //Makes the character fly off screen after game ends
            if (this.position.Y >= 650)
            {
                ySpeed = -50;
            }
            else if (this.position.Y > 0)
            {
                ySpeed += .4f;
            }

            if (this.position.Y > -50)
            {
                this.position.Y += ySpeed;
            }

            if (this.position.Y > 650)
            {
                this.position.Y = 650;
            }
        }

        public Rectangle Bound
        {
            get
            {
                return new Rectangle((int)this.position.X
                                    , (int)this.position.Y - 75, 50, 75);
            }
        }

        public void Draw()
        {
            if (poweredUp)
            {
                Statics.SPRITEBATCH.Draw(powerTexture, new Vector2(position.X, position.Y - 75), Color.White);
            }
            else
            {
                Statics.SPRITEBATCH.Draw(texture, new Vector2(position.X, position.Y - 75), Color.White);
            }
        }

    }
}
