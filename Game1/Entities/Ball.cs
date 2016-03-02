using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1.Entities
{
    public class Ball
    {
        public Texture2D texture, texture2;
        public Vector2 position;
        public Vector3 pos;
        public float ySpeed = Statics.RANDOM.Next(3)+2;
        public float xSpeed = Statics.RANDOM.Next(3)+3;
        public bool live = false, tex2 = true;
        public double liveCounter = 0;

        public Ball()
        {
            texture = Statics.CONTENT.Load<Texture2D>("Textures/ball");
            texture2 = Statics.CONTENT.Load<Texture2D>("Textures/ball2");
            this.position = new Vector2(Statics.RANDOM.Next(940), Statics.RANDOM.Next(540));
        }

        public void Update()
        {
            //Bounces off L&R walls
            if (this.position.X >= 950)
            {
                xSpeed = xSpeed * -1;
                tex2 = false;
            }
            else if (this.position.X <= 0)
            {
                xSpeed = xSpeed * -1;
                tex2 = true;
            }

            //Bounces off floor and ceiling
            if (this.position.Y >= 600)
            {
                ySpeed = ySpeed * -1;
            }
            else if (this.position.Y <= 0)
            {
                ySpeed = ySpeed * -1;
            } 

            //Makes the ball go "live" after a second. Collisions with player will not occur in this first second
            //to avoid deaths from spawning directly on top of or next to the player
            if (liveCounter < 1000)
            {
                liveCounter += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            }
            else if (!live)
            {
                live = true;
            }

            //Inputs movements
            this.position.X += xSpeed;
            this.position.Y += ySpeed;
        }
       
        
        public Rectangle Bound
        {
            get
            {
                return new Rectangle((int)this.position.X
                                    , (int)this.position.Y, 50, 50);
            }
        }

        public void Draw()
        {
            if (!tex2)
                Statics.SPRITEBATCH.Draw(texture, position, Color.White);
            else if (tex2)
                Statics.SPRITEBATCH.Draw(texture2, position, Color.White);
        }


    }
}
