using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SummerofXNA.Classes.Base
{
    class Sprite
    {
        #region//Class-level variables + accessors

        protected Texture2D textureImage;
        protected Vector2 position;
        protected Point frameSize;
        int collisionOffset;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

        //Constructor
        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
        }

        //Dispose
        public virtual void Dispose()
        {
            textureImage.Dispose();
        }

        //Update
        public virtual void Update(GameTime gameTime)
        { }

        //Draw
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage, position, Color.White);            
        }

        //Collosion
        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                    (int)(position.X + collisionOffset),
                    (int)(position.Y + collisionOffset),
                    (int)(frameSize.X - (collisionOffset * 2)),
                    (int)(frameSize.Y - (collisionOffset * 2)));
            }
        }
    }
}
