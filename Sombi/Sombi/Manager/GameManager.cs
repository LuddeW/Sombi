using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class GameManager
    {
        PlayerManager playerManager;
        ContentManager contentManager;
        Vector2 testMapPos;
       // TextureLibrary textureLibrary;


        public GameManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            playerManager = new PlayerManager();
            //textureLibrary = new TextureLibrary();
            TextureLibrary.LoadContent(contentManager);
            testMapPos = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
            playerManager.Draw(spriteBatch);
        }
    }
}
