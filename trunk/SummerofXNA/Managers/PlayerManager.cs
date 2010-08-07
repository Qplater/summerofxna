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
        Classes.Character.Playable.UserControlledAnimatedSprite playerOne;

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

            playerOne = new SummerofXNA.Classes.Character.Playable.UserControlledAnimatedSprite(
                Game.Content.Load<Texture2D>(@"Images\Character\Misc\skullball"), new Vector2(30,30),
                new Point(75,75), 10, new Point(0,0), new Point(6,8));

            base.LoadContent();
        }

        //Dispose
        protected override void UnloadContent()
        {
            playerOne.Dispose();

            base.UnloadContent();
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            playerOne.Update(gameTime);
            
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            playerOne.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}