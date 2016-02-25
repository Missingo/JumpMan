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
    public class Coin
    {
        public Texture2D texture;
        public Vector2 position;
        public float ySpeed = 4;

        public Coin()
        {
            texture = Statics.CONTENT.Load<Texture2D>("Textures/coin");
            this.position = new Vector2(Statics.RANDOM.Next(800)+100, -50);
        }

        public void Update()
        {
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
