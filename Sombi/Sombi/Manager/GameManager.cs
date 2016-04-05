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
        HUDManager hudManager;
        FPSManager fpsManager;
        Vector2 testMapPos;
        PackageManager packageManager;
        HighscoreManager highscoreManager;

        public GameManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            TextureLibrary.LoadContent(contentManager);
            SoundLibrary.LoadContent(contentManager);
            Grid.CreateGridFactory();
            playerManager = new PlayerManager();
            enemyManager = new EnemyManager();
            hudManager = new HUDManager(playerManager.players);
            fpsManager = new FPSManager();
            highscoreManager = new HighscoreManager();
            

            testMapPos = Vector2.Zero;

            enemyManager.AddZombie(new Vector2(400, 500));  //Endast för TEST!!
            enemyManager.AddZombie(new Vector2(100, 200));  //TEST
            enemyManager.AddZombie(new Vector2(100, 100));      //SPAWNAR ZOMBIES HÄR!!
            enemyManager.AddZombie(new Vector2(100, 400));          //DOM FÅR INTE SPAWNA PÅ VARANDRA
            enemyManager.AddZombie(new Vector2(100, 500));
            enemyManager.AddZombie(new Vector2(900, 500));
            enemyManager.AddZombie(new Vector2(900, 700));
            enemyManager.AddZombie(new Vector2(900, 800));
            enemyManager.AddZombie(new Vector2(500, 500));



            packageManager = new PackageManager();
        }

        public void Update(GameTime gameTime)
        {
            
            enemyManager.Update(gameTime, playerManager.weaponManager.bulletManager.bullets);
            playerManager.Update(gameTime);
            packageManager.Update(gameTime, playerManager.players);
            hudManager.Update(gameTime);
            fpsManager.Update(gameTime);


            CheckPlayerZombieCollisions();
          
            CheckPlayerBulletCollisions();



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            packageManager.Draw(spriteBatch);
            spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
            enemyManager.Draw(spriteBatch);
            fpsManager.Draw(spriteBatch);
            playerManager.Draw(spriteBatch);

            hudManager.Draw(spriteBatch);

        }

        public void CheckPlayerZombieCollisions()
        {
            for (int i = 0; i < enemyManager.zombies.Count; i++)
            {
                for (int j = 0; j < playerManager.players.Count; j++)
                {
                    if (enemyManager.zombies[i].GetHitbox().Intersects(playerManager.players[j].HitBox))
                    {
                        playerManager.players[j].handleBulletHit(1000);
                    }

                    if (Vector2.Distance(enemyManager.zombies[i].pos, playerManager.players[j].position) < enemyManager.zombies[i].activationRange)
                    {
                        enemyManager.zombies[i].SetChasingDirection(playerManager.players[j].position);
                        
                    }
                    else if (Vector2.Distance(enemyManager.zombies[i].pos, playerManager.players[j].position) > enemyManager.zombies[i].activationRange)
                    {
                        enemyManager.zombies[i].ResetTarget();

                    }

                }
            }
        }

        public void CheckPlayerBulletCollisions()
        {
            for (int i = 0; i < playerManager.players.Count; i++)
            {
                for (int k = 0; k < playerManager.weaponManager.bulletManager.bullets.Count; k++)
                {
                    if (playerManager.players[i].HitBox.Contains(playerManager.weaponManager.bulletManager.bullets[k].Pos) && playerManager.players[i].ID != playerManager.weaponManager.bulletManager.bullets[k].ID)
                    {
                        playerManager.players[i].handleBulletHit(playerManager.weaponManager.bulletManager.bullets[k].damage);
                        playerManager.weaponManager.bulletManager.bullets.RemoveAt(k);
                    }
                }
            }
        }
    }
}