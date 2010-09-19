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

        public int Speed;
        const int defaultSpeed = 3;

        #endregion

        //Constructors
        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset)
            : base(textureImage, position, frameSize, collisionOffset)
        {
            this.Speed = defaultSpeed;
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            int speed)
            : base(textureImage, position, frameSize, collisionOffset)
        {
            this.Speed = speed;
        }

        //Direction
        public Vector2 Direction;

        //Update
        public override void Update(GameTime gameTime)
        {

            Position += this.Direction;

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
