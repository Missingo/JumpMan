using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Game1.Entities
{
    public class Powerup
    {
        public Texture2D texture;
        public Vector2 position;
        public float ySpeed = 0;

        public Powerup()
        {
            texture = Statics.CONTENT.Load<Texture2D>("Textures/powerup");
            this.position = new Vector2(Statics.RANDOM.Next(800) + 100, -50);
        }

        public void Update()
        {
            //Power up falls
            this.position.Y += ySpeed;
        }

        //This object isn't created and deleted like coins and balls, since there can only ever be one at a time.
        //Instead it uses Reset() and Go() to control spawning and collecting
        public void Reset()
        {            
            this.position = new Vector2(Statics.RANDOM.Next(800) + 100, -50);
            ySpeed = 0;
        }

        public void Go()
        {
            ySpeed = 4;
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
