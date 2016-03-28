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

        Package package;
        // TextureLibrary textureLibrary;
        
        


        public GameManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            Grid.CreateGridFactory();
            playerManager = new PlayerManager();
            enemyManager = new EnemyManager();
            TextureLibrary.LoadContent(contentManager);
            testMapPos = Vector2.Zero;
            enemyManager.AddZombie(new Vector2(400, 500));  //Endast för TEST!!
            package = new Package(new Vector2(50,50));
        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
            enemyManager.Update(gameTime);
            package.Update(gameTime);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
            playerManager.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);
            package.Draw(spriteBatch); // Den svarta marken är package!
        }
    }
}
