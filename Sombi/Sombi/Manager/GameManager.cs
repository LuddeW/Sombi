using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sombi
{
    class GameManager
    {
        const int TILE_SIZE = 50;
        PlayerManager playerManager;
        ContentManager contentManager;
        EnemyManager enemyManager;
        Vector2 testMapPos;
        // TextureLibrary textureLibrary;
        
        


        public GameManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            Grid.CreateGridFactory();
            playerManager = new PlayerManager();
            enemyManager = new EnemyManager();
            TextureLibrary.LoadContent(contentManager);
            testMapPos = Vector2.Zero;
            enemyManager.AddZombie(new Vector2(400, 100));  //Endast för TEST!!
        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
            enemyManager.Update(gameTime);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
            playerManager.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);
        }
    }
}
