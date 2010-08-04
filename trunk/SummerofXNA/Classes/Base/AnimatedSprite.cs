using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SummerofXNA.Classes.Base
{
    class AnimatedSprite : Sprite
    {
        #region Class-level variables + accessors        
        Point currentFrame;
        Point sheetSize;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame;

        protected const int defaultMillisecondsPerFrame = 80;

        protected float scale = 1;

        public Vector2 Position
        {
            get { return position; }
        }

        #endregion

        //Constructors
        public AnimatedSprite(Texture2D textureImage, Vector2 position, Point frameSize,
                      int collisionOffset, Point currentFrame, Point sheetSize)
            : base(textureImage, position, frameSize, collisionOffset)
        {
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.millisecondsPerFrame = defaultMillisecondsPerFrame;
        }

        public AnimatedSprite(Texture2D textureImage, Vector2 position, Point frameSize,
                      int collisionOffset, Point currentFrame, Point sheetSize, int milliSecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffset)
        {
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.millisecondsPerFrame = milliSecondsPerFrame;
        }

        //Update
        public virtual void Update(GameTime gameTime)
        {
            //Animate the sprite
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }
        }

        //Draw
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage,
                             position,
                             new Rectangle(currentFrame.X * frameSize.X,
                                           currentFrame.Y * frameSize.Y,
                                           frameSize.X,
                                           frameSize.Y),
                             Color.White,
                             0,
                             Vector2.Zero,
                             scale,
                             SpriteEffects.None,
                             0);
        }
    }
}
