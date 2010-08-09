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
        Vector2 positionValue;
        Vector2 originValue;
        protected Point frameSize;
        int collisionOffset;

        public Vector2 Position
        {
            set
            {
                positionValue = value;
            }
            get
            {
                return positionValue;
            }
        }

        public Vector2 Origin
        {
            set
            {
                originValue = value;
            }
            get
            {
                return originValue;
            }
        }

        #endregion

        //Constructor
        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset)
        {
            this.textureImage = textureImage;
            this.positionValue = position;
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
            spriteBatch.Draw(textureImage, positionValue, null, Color.White, 0, originValue, 1,
                             SpriteEffects.None, 0f);
        }

        //Collosion
        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                    (int)(positionValue.X + collisionOffset),
                    (int)(positionValue.Y + collisionOffset),
                    (int)(frameSize.X - (collisionOffset * 2)),
                    (int)(frameSize.Y - (collisionOffset * 2)));
            }
        }
    }
}
