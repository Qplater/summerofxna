using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SummerofXNA.Controls
{
    class Button:Control
    {
        public Texture2D TextureImage;
        public SpriteFont FontStyle;
        public Color TextColor;
        public Vector2 TextPosition;
        public Vector2 origin;
        private MouseState _mouse;
        public string Text;
        public bool ShowText;
        public bool ShowImage;
        private bool _pressed;
        public bool IsPressed 
        {
            get 
            {
                return _pressed;
            }
        }

        public Button(Texture2D textureImage, Vector2 position, Vector2 origin, float width, float height)
        {
            this.TextureImage = textureImage;
            this.Position = position;
            this.origin = origin;
            this.Width = width;
            this.Height = height;
            Layer = 0;
            ShowImage = true;
            ShowText = true;
            TextPosition.X = Margin.X;
            TextPosition.Y = Margin.Y;
            _mouse = new MouseState();
            Visible = true;
            Text = "";
            TextColor = Color.Black;
        }

        public override void Update(GameTime gameTime)
        {
            _mouse = Mouse.GetState();

            if (_mouse.LeftButton == ButtonState.Pressed) 
            {
                if(Container.Contains(_mouse.X,_mouse.Y))
                    _pressed=true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(TextureImage, Position, null, Color.White, 0, origin, 1,
                                 SpriteEffects.None, Layer);
                if (ShowText)
                {
                    if (TextPosition.X < (Container.Left + Margin.X))
                        TextPosition.X = Container.Left + Margin.X;

                    if (TextPosition.X > (Container.Right - Margin.X))
                        TextPosition.X = Container.Width / 2;

                    if (TextPosition.Y < (Container.Top + Margin.Y))
                        TextPosition.Y = Container.Top + Margin.Y;

                    if (TextPosition.Y > (Container.Bottom - Margin.Y))
                        TextPosition.Y = Container.Height / 2;
                    spriteBatch.DrawString(FontStyle, Text, TextPosition, TextColor,
                                     0, new Vector2(0, 0), 1, SpriteEffects.None, Layer + 0.1f);
                }
            }
        }

    }
}
