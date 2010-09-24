using System;
using System.Threading;
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
using SummerofXNA.Managers;

namespace SummerofXNA.Screens
{
    /// <summary>
    /// This screen implements the actual game logic. It is just a
    /// placeholder to get the idea across: you'll probably want to
    /// put some more interesting gameplay in here!
    /// </summary>
    class GameplayScreen : GameScreen
    {
        #region Fields

        ContentManager content;
        SpriteFont gameFont;

        Vector2 playerPosition = new Vector2(100, 100);
        Vector2 enemyPosition = new Vector2(100, 100);

        Random random = new Random();

        #endregion

        #region Class-level variables

        SummerofXNA.Classes.Character.Playable.UserControlledSprite playerOne;
        SummerofXNA.Classes.Base.Sprite backgroundSprite;

        SummerofXNA.Classes.Camera.Camera2D camera;
        Vector2 screenCenter;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            //clientBounds = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }


        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {
            if (content == null)
                content = ScreenManager.Game.Content;

            gameFont = content.Load<SpriteFont>("Fonts/DeveloperInterfaceFont");

            // A real game would probably have more content than this sample, so
            // it would take longer to load. We simulate that by delaying for a
            // while, giving you a chance to admire the beautiful loading screen.
            Thread.Sleep(1000);
            screenCenter = new Vector2(
                (float)ScreenManager.GraphicsDevice.Viewport.Width / 2f,
                (float)ScreenManager.GraphicsDevice.Viewport.Height / 2f);

            playerOne = new SummerofXNA.Classes.Character.Playable.UserControlledSprite(content.Load<Texture2D>(@"Images\Character\Misc\Bubble"), new Vector2(60, 60), new Point(64, 64), 10);

            backgroundSprite = new SummerofXNA.Classes.Base.Sprite(content.Load<Texture2D>(@"Images\Background\wpshrine_Clannad_208_1280x800"),
                               new Vector2(0, 0), new Point(1280, 800), 0);

            camera = new SummerofXNA.Classes.Camera.Camera2D();

            ResetToInitialPositions();

            ScreenManager.Game.ResetElapsedTime();
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void UnloadContent()
        {
            playerOne.Dispose();
            backgroundSprite.Dispose();
            content.Unload();
        }

        private void ResetToInitialPositions()
        {
            camera.Position = screenCenter;

            playerOne.Position = screenCenter;

            camera.ResetChanged();
        }

        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            playerOne.Origin = (camera.Position - playerOne.Position);
            backgroundSprite.Origin = (camera.Position - backgroundSprite.Position);

            playerOne.Update(gameTime);
            backgroundSprite.Update(gameTime);

            camera.ResetChanged();


            if (camera.IsChanged)
            {
                camera.ResetChanged();
            }

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }


        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];

            if (input.IsPauseGame(ControllingPlayer))
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else
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

                playerOne.Direction = inputDirection * playerOne.Speed;

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
            }
        }

        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // This game has a blue background. Why? Because!
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.CornflowerBlue, 0, 0);

            // Our player and enemy are both actually just text strings.
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            backgroundSprite.Draw(gameTime, spriteBatch);

            playerOne.Draw(gameTime, spriteBatch);

            spriteBatch.End();


            // If the game is transitioning on or off, fade it out to black.
            if (TransitionPosition > 0)
                ScreenManager.FadeBackBufferToBlack(255 - TransitionAlpha);
        }


        #endregion
    }
}
