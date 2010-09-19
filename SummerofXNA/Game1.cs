using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SummerofXNA
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Fields

        GraphicsDeviceManager graphics;
        SummerofXNA.Managers.ScreenManager screenManager;

        public SummerofXNA.Managers.PlayerManager playerManager;
        public SummerofXNA.Managers.DeveloperInterfaceManager developerInterfaceManager;

        #endregion
        
        

        /// <summary>
        /// Constructor
        /// </summary>
        public Game1()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 853;
            graphics.PreferredBackBufferHeight = 480;

            // Create the screen manager component.
            screenManager = new SummerofXNA.Managers.ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens.
            screenManager.AddScreen(new SummerofXNA.Screens.BackgroundScreen(), null);
            screenManager.AddScreen(new SummerofXNA.Screens.MainMenuScreen(), null);

            playerManager = new SummerofXNA.Managers.PlayerManager(this);
            developerInterfaceManager = new SummerofXNA.Managers.DeveloperInterfaceManager(this);

            Components.Add(playerManager);
            Components.Add(developerInterfaceManager);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            // The real drawing happens inside the screen manager component.
            base.Draw(gameTime);
        }
    }
}
