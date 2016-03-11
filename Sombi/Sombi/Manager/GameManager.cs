using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sombi
{
    class GameManager
    {

        //Texture2D testMap;
        Vector2 testMapPos = Vector2.Zero;
        TextureLibrary textureLibrary = new TextureLibrary();
        PlayerManager playerManager;

        public void LoadContent(ContentManager Content)
        {
            //testMap = textureLibrary.testMapTex;
        }
        public GameManager()
        {
            playerManager = new PlayerManager();
        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            playerManager.Draw(spriteBatch);
            spriteBatch.Draw(textureLibrary.testMapTex, testMapPos, Color.White);
        }
    }
}
