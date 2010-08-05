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
        
        Classes.Base.AnimatedSprite PlayerOne;

        SpriteBatch spriteBatch;

        #endregion

        public PlayerManager(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {                        
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            PlayerOne = new SummerofXNA.Classes.Base.AnimatedSprite(
                Game.Content.Load<Texture2D>(@"Images\Character\Playable\run"),
                new Vector2(50,50), new Point(512, 512), 0, new Point(0,0), new Point(6,1), 0.4);            

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            PlayerOne.Update(gameTime);
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            PlayerOne.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}