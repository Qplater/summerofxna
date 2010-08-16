using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SummerofXNA.Controls
{
    class Pane:Control
    {
        public Texture2D textureImage;
        public Vector2 origin;
        protected List<Control> _childcontrols;

        public Pane(Texture2D textureImage, Vector2 position, Vector2 origin, float width, float height)
        {
            this.textureImage = textureImage;
            this.Position = position;
            this.origin = origin;
            this.Width = width;
            this.Height = height;
            Layer = 0;
            Visible = true;
            _childcontrols = new List<Control>();

        }

        public override void Update(GameTime gameTime)
        { }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(textureImage, Position, null, Color.White, 0, origin, 1,
                                 SpriteEffects.None, Layer);
                foreach (Control cont in _childcontrols) 
                {
                    if (cont.Visible)
                    {
                        if (cont.Position.X < (Container.Left + Margin.X))
                            cont.Position.X = Container.Left + Margin.X;

                        if (cont.Position.X > (Container.Right - Margin.X))
                            cont.Position.X = Container.Right + cont.Width - Margin.X;

                        if (cont.Position.Y < (Container.Top + Margin.Y))
                            cont.Position.Y = Container.Top + Margin.Y;

                        if (cont.Position.Y > (Container.Bottom - Margin.Y))
                            cont.Position.Y = Container.Bottom - cont.Height + Margin.Y;

                        if (cont.Layer < this.Layer)
                            cont.Layer += (this.Layer - cont.Layer) + 0.1f;

                        cont.Draw(gameTime, spriteBatch);
                    }
                }
            }
        }

        public void AddControl(Control item) 
        {
            _childcontrols.Add(item);
        }

        public void DeleteControl(Control item) 
        {
            _childcontrols.Remove(item);
        }

        public bool ContainsControl(Control item) 
        {
            if (_childcontrols.Contains(item))
                return true;
            else
                return false;
        }
    }
}
