using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1.Entities
{
    public class Ball
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector3 pos;
        public float ySpeed = 3;
        public float xSpeed = 4;
        public int bounceCount = 0;
        public bool live = false;
        public double liveCounter = 0;

        public Ball()
        {
            texture = Statics.CONTENT.Load<Texture2D>("Textures/ball");
            this.position = new Vector2(Statics.RANDOM.Next(940), Statics.RANDOM.Next(540));
        }

        public void Update()
        {
            if (this.position.X >= 950)
            {
                xSpeed = xSpeed * -1;
                bounceCount++;
            }
            else if (this.position.X <= 0)
            {
                xSpeed = xSpeed * -1;
                bounceCount++;
            }

            if (this.position.Y >= 600)
            {
                ySpeed = ySpeed * -1;
                bounceCount++;
            }
            else if (this.position.Y <= 0)
            {
                ySpeed = ySpeed * -1;
                bounceCount++;
            }

            if (liveCounter < 1000)
            {
                liveCounter += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            }
            else if (!live)
            {
                live = true;
            }

            this.position.X += xSpeed;
            this.position.Y += ySpeed;
        }
       
        public BoundingSphere Bound2
        {
            get
            {
                return new BoundingSphere(new Vector3(this.position.X+25, this.position.Y+25, 0), 25);
            }
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
            Statics.SPRITEBATCH.Draw(texture, position, Color.White);
        }


    }
}
