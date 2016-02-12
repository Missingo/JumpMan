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
        public float ySpeed = 3;
        public float xSpeed = 4;

        public Ball()
        {
            texture = Statics.CONTENT.Load<Texture2D>("Textures/ball");
            this.position = new Vector2(Statics.RANDOM.Next(750), Statics.RANDOM.Next(450));
        }

        public void Update()
        {
            if (this.position.X >= 750)
            {
                xSpeed = -4;
            }
            else if (this.position.X <= 0)
            {
                xSpeed = 4;
            }

            if (this.position.Y >= 400)
            {
                ySpeed = -3;
            }
            else if (this.position.Y <= 0)
            {
                ySpeed = 3;
            }

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
            Statics.SPRITEBATCH.Draw(texture, position, Color.White);
        }


    }
}
