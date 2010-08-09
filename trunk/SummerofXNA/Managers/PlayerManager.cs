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
    public class PlayerManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Class-level variables        

        SpriteBatch spriteBatch;        

        #endregion

        //Constructor
        public PlayerManager(Game game)
            : base(game)
        {}

        //Initialize
        public override void Initialize()
        {                        
            base.Initialize();
        }

        //LoadContent
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            base.LoadContent();
        }

        //Dispose
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}