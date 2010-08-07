using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace SummerofXNA.Managers
{
    public class DeveloperInterfaceManager : Microsoft.Xna.Framework.DrawableGameComponent
    {

        #region Class-level variables
        
        SpriteBatch spriteBatch;
        SpriteFont developerUIFont;

        float fPS;
        float lastFPS;
        float timeSinceLastSecond;

        bool isMouseVisible;

        MouseState prevMouseState;
        Vector2 mouseCoords;

        KeyboardState prevKeyboardState;
        KeyboardState currentKeyboardState;

        #endregion

        //Constructor
        public DeveloperInterfaceManager(Game game)
            : base(game)
        {
            fPS = 0;
            lastFPS = 0;
            timeSinceLastSecond = 0;
            isMouseVisible = false;
        }

        //Initialize
        public override void Initialize()
        {                        
            base.Initialize();
        }

        //LoadContent
        protected override void LoadContent()
        {
            
            developerUIFont = Game.Content.Load<SpriteFont>(@"Fonts\DeveloperInterfaceFont");

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            base.LoadContent();
        }

        //Update
        public override void Update(GameTime gameTime)
        {

            MouseState currMouseState = Mouse.GetState();
            if (currMouseState.X != prevMouseState.X ||
                currMouseState.Y != prevMouseState.Y)
            {
                mouseCoords = new Vector2(currMouseState.X, currMouseState.Y);
            }
            prevMouseState = currMouseState;

            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.F12) && prevKeyboardState.IsKeyUp(Keys.F12))
            {
                ((Game1)Game).IsMouseVisible ^= true;
                isMouseVisible ^= true;     
            }
            prevKeyboardState = currentKeyboardState;
            
            timeSinceLastSecond += gameTime.ElapsedGameTime.Milliseconds;            

            if (timeSinceLastSecond > 1000)
            {
                timeSinceLastSecond = 0;
                lastFPS = fPS;
                fPS = 0;                
            }
            
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            fPS++;

            spriteBatch.Begin();
            
            spriteBatch.DrawString(developerUIFont, "FPS: " + lastFPS,
                                new Vector2(5, 5),
                                Color.Blue);

            spriteBatch.DrawString(developerUIFont, "Mouse visibility: " + isMouseVisible + " (F12)",
                                new Vector2(5, 20),
                                Color.Blue);

            spriteBatch.DrawString(developerUIFont, "Mouse coords: (x: " + mouseCoords.X + ", y: " + mouseCoords.Y + ")",
                                new Vector2(5, 35),
                                Color.Blue);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}