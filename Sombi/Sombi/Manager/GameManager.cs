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

            enemyManager.AddZombie(new Vector2(100, 100));
            enemyManager.AddZombie(new Vector2(700, 500));

            

            package = new Package(new Vector2(50,50));

        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
            enemyManager.Update(gameTime);

            CheckForBulletCollisions();

            package.Update(gameTime);

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
            playerManager.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);
            package.Draw(spriteBatch); // Den svarta marken är package!
        }
        public void CheckForBulletCollisions()      //Vet inte om den ska ligga här?
        {
            for (int i = 0; i < enemyManager.zombies.Count; i++)
            {
                for (int k = 0; k < playerManager.weaponManager.bulletManager.bullets.Count; k++)
                {
                    if (enemyManager.zombies[i].GetHitbox().Contains(playerManager.weaponManager.bulletManager.bullets[k].Pos))
                    {
                        enemyManager.zombies[i].handleBulletHit(playerManager.weaponManager.bulletManager.bullets[k].damage);
               
                        playerManager.weaponManager.bulletManager.bullets.RemoveAt(k);
                     
                        
                    }
                }
            }
        }

    }
}
