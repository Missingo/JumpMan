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
        public bool airborn = false;
        public float xSpeed = 0;       
        public int jumpTimer = 500;
        public int jumpElapsed = 0;

        public Man()
        {
            ySpeed = 0;
            this.position = new Vector2(475, 600);
            texture = Statics.CONTENT.Load<Texture2D>("Textures/bird1");
        }

        public void Update()
        {
            if (this.position.Y >= 650 || this.position.Y < 50)
            {                
                ySpeed = 0;
            }
            else
            {
                ySpeed += .4f;
            }

            if ((Statics.INPUT.isKeyPressed(Keys.W) || Statics.INPUT.isKeyPressed(Keys.Space)))
            {
                ySpeed = -10;
                airborn = true;
            }

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
            

            this.position.X += xSpeed;
            xSpeed = 0;

            this.position.Y += ySpeed;
            if (this.position.Y > 650)
            {
                this.position.Y = 650;
            }
            if (this.position.Y < 50)
            {
                this.position.Y = 50;
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
