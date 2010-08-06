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

        #endregion

        //Constructor
        public DeveloperInterfaceManager(Game game)
            : base(game)
        {
            fPS = 0;
            lastFPS = 0;
            timeSinceLastSecond = 0;
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

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}