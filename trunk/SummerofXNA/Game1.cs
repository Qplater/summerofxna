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
        Vector2 clientBounds;

        Vector2 uICoord;

        //Texture2D backgroundTexture;
        //Texture2D uIBackgroundTexture;

        public Managers.PlayerManager playerManager;
        public Managers.DeveloperInterfaceManager developerInterfaceManager;

        public Vector2 ClientBounds
        {
            get { return clientBounds; }
        }

        public Vector2 UICoord
        {
            get { return uICoord; }
        }

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

            clientBounds = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            uICoord = new Vector2(0, 500);
           
            playerManager = new SummerofXNA.Managers.PlayerManager(this);
            developerInterfaceManager = new SummerofXNA.Managers.DeveloperInterfaceManager(this);

            Components.Add(playerManager);
            Components.Add(developerInterfaceManager);

            base.Initialize();
        }

        //LoadCOntent
        protected override void LoadContent()
        {

            //backgroundTexture = Content.Load<Texture2D>(@"Images\Background\groundTest");
            //uIBackgroundTexture = Content.Load<Texture2D>(@"Images\Background\ui_bg2");
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        //UnloadContent
        protected override void UnloadContent()
        {
            //backgroundTexture.Dispose();
            //uIBackgroundTexture.Dispose();
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

            //Draw the background image
            //spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Window.ClientBounds.Width,
            //                 (int)uICoord.Y), null, Color.White, 0, Vector2.Zero,
            //                 SpriteEffects.None, 0);

            //spriteBatch.Draw(uIBackgroundTexture, new Rectangle((int)uICoord.X, (int)uICoord.Y, 800, 100), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
