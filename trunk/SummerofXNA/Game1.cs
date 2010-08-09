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
        Classes.Character.Playable.UserControlledSprite playerOne;
        Classes.Base.Sprite backgroundSprite;

        Classes.Camera.Camera2D camera;
        Vector2 screenCenter;

        public Managers.PlayerManager playerManager;
        public Managers.DeveloperInterfaceManager developerInterfaceManager;        

        public Vector2 ClientBounds
        {
            get { return clientBounds; }
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
           
            playerManager = new SummerofXNA.Managers.PlayerManager(this);
            developerInterfaceManager = new SummerofXNA.Managers.DeveloperInterfaceManager(this);            

            Components.Add(playerManager);
            Components.Add(developerInterfaceManager);

            base.Initialize();
        }

        //LoadCOntent
        protected override void LoadContent()
        {
            screenCenter = new Vector2(
                (float)graphics.GraphicsDevice.Viewport.Width / 2f,
                (float)graphics.GraphicsDevice.Viewport.Height / 2f);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerOne = new Classes.Character.Playable.UserControlledSprite(Content.Load<Texture2D>(@"Images\Character\Misc\Bubble"), new Vector2(60, 60), new Point(64, 64), 10);

            backgroundSprite = new Classes.Base.Sprite(Content.Load<Texture2D>(@"Images\Background\wpshrine_Clannad_208_1280x800"),
                               new Vector2(0, 0), new Point(1280, 800), 0);

            camera = new Classes.Camera.Camera2D();

            ResetToInitialPositions();
        }

        //UnloadContent
        protected override void UnloadContent()
        {
            playerOne.Dispose();
            backgroundSprite.Dispose();
        }

        private void ResetToInitialPositions()
        {
            camera.Position = screenCenter;

            playerOne.Position = screenCenter;

            camera.ResetChanged();
        }

        //Update
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
            {
                camera.MoveLeft(-3);
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.D))
            {
                camera.MoveRight(3);
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.W))
            {
                camera.MoveUp(3);
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.S))
            {
                camera.MoveDown(-3);
            }

            playerOne.Origin = (camera.Position - playerOne.Position);
            backgroundSprite.Origin = (camera.Position - backgroundSprite.Position);

            playerOne.Update(gameTime);
            backgroundSprite.Update(gameTime);

            camera.ResetChanged();


            if (camera.IsChanged)
            {
                camera.ResetChanged();
            }

            base.Update(gameTime);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            backgroundSprite.Draw(gameTime, spriteBatch);

            playerOne.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
