using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SummerofXNA.Classes.Character.Playable
{
    class UserControlledSprite : Classes.Base.Sprite
    {

        #region Class-level variable
        int speed;
        const int defaultSpeed = 3;
        #endregion

        //Constructors
        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset)
            : base(textureImage, position, frameSize, collisionOffset)
        {
            this.speed = defaultSpeed;
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            int speed)
            : base(textureImage, position, frameSize, collisionOffset)
        {
            this.speed = speed;
        }

        //Direction
        public Vector2 direction
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    inputDirection.X -= 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    inputDirection.X += 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    inputDirection.Y -= 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    inputDirection.Y += 1;

                return inputDirection * speed;
            }
        }

        //Update
        public override void Update(GameTime gameTime)
        {

            position += this.direction;

            //if (position.X < 0)
            //    position.X = 0;
            //if (position.Y < 0)
            //    position.Y = 0;
            //if (position.X > ((Game1)Game).ClientBounds.X - frameSize.X)
            //    position.X = ((Game1)Game).ClientBounds.X - frameSize.X;
            //if (position.Y > ((Game1)Game).ClientBounds.Y - frameSize.Y)
            //    position.Y = ((Game1)Game).ClientBounds.Y - frameSize.Y;

            base.Update(gameTime);
        }
    }
}
