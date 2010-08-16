using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SummerofXNA.Controls
{
    public abstract class Control
    {
        public float Width;
        public float Height;
        public float Layer;
        public Vector2 Position;
        public bool Visible;
        protected Vector4 _margin;
        public Vector4 Margin 
        {
            get 
            {
                return _margin;
            }

            set 
            {
                _margin = value;
            }
        }
        protected Rectangle _container;
        protected Rectangle Container
        {
            get
            {
                _container.X = (int)this.Position.X;
                _container.Y = (int)this.Position.Y;
                _container.Width = (int)this.Width;
                _container.Height = (int)this.Height;
                return _container;
            }
        }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { }
    }
}
