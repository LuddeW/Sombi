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
        EnemyManager enemyManager;

        Vector2 testMapPos;


        public GameManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            playerManager = new PlayerManager();
            enemyManager = new EnemyManager();
            TextureLibrary.LoadContent(contentManager);
            testMapPos = Vector2.Zero;


            enemyManager.AddZombie(new Vector2(50, 50));  //Endast för TEST!!
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
