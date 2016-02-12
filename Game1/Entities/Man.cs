using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1.Entities
{
    public class Man
    {
        public Texture2D texture;
        public Vector2 position;
        public float ySpeed;
        public bool jumpTrue = true;
        public float xSpeed = 0;       
        public int jumpTimer = 500;
        public int jumpElapsed = 0;

        public Man()
        {
            ySpeed = 0;
            this.position = new Vector2(300, 400);
            texture = Statics.CONTENT.Load<Texture2D>("Textures/bird1");
        }

        public void Update()
        {
            if (this.position.Y >= 450)
            {                
                ySpeed = 0;
                jumpTrue = true;
            }
            else
            {
                ySpeed += .4f;
            }

            if ((Statics.INPUT.currentState().IsKeyDown(Keys.W) || Statics.INPUT.currentState().IsKeyDown(Keys.Space)) && jumpTrue)
            {
                ySpeed = -12;
                jumpTrue = false;
            }

            if (Statics.INPUT.currentState().IsKeyDown(Keys.D) && this.position.X < 750)
            {
                xSpeed = 5;                
            }
            if (Statics.INPUT.currentState().IsKeyDown(Keys.A) && this.position.X > 0)
            {
                xSpeed = -5;
            }
            

            this.position.X += xSpeed;
            xSpeed = 0;

            this.position.Y += ySpeed;
            if (this.position.Y > 450)
            {
                this.position.Y = 450;
            }
        }

        public Rectangle Bound
        {
            get
            {
                return new Rectangle((int)this.position.X
                                    , (int)this.position.Y - 50, 50, 50);
            }
        }

        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(texture, new Vector2(position.X, position.Y-50), Color.White);
        }

    }
}
