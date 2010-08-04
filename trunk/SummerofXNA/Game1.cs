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

namespace SummerofXNA
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        #region//Class-level variables

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #endregion

        //Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Initialize
        protected override void Initialize()
        {
            base.Initialize();
        }

        //LoadCOntent
        protected override void LoadContent()
        {
        }

        //UnloadContent
        protected override void UnloadContent()
        {
        }

        //Update
        protected override void Update(GameTime gameTime)
        {
            //Exit, when [esc] is pressed
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            base.Update(gameTime);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
