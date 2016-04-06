using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sombi
{
    enum GameState
    {
        Menu,
        Playing,
        Paused,
    }
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
        MenuManager menuManager;
        GameState currentGameState = GameState.Menu;
        KeyboardState currentKeyboard;
        KeyboardState oldKeyboard;

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
            enemyManager.AddZombie(new Vector2(800, 200));  //TEST
            enemyManager.AddZombie(new Vector2(900, 100));      //SPAWNAR ZOMBIES HÄR!!
            enemyManager.AddZombie(new Vector2(100, 600));          //DOM FÅR INTE SPAWNA PÅ VARANDRA
            enemyManager.AddZombie(new Vector2(100, 500));
            enemyManager.AddZombie(new Vector2(900, 500));
            enemyManager.AddZombie(new Vector2(900, 700));
            enemyManager.AddZombie(new Vector2(900, 800));
            enemyManager.AddZombie(new Vector2(500, 500));


            menuManager = new MenuManager(playerManager.players);
            packageManager = new PackageManager();
        }

        public void Update(GameTime gameTime)
        {
            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();
            switch (currentGameState)
            {
                case GameState.Menu:
                    {
                        menuManager.Update(gameTime);
                        playerManager.Update(gameTime);
                        StartGame();
                        break;
                    }

                case GameState.Playing:
                    {
                        if (currentKeyboard.IsKeyDown(Keys.P) && !oldKeyboard.IsKeyDown(Keys.P))
                        {
                            currentGameState = GameState.Paused;
                        }
                        enemyManager.Update(gameTime, playerManager.weaponManager.bulletManager.bullets);
                        playerManager.Update(gameTime);
                        packageManager.Update(gameTime, playerManager.players);
                        hudManager.Update(gameTime);
                        fpsManager.Update(gameTime);
                        CheckPlayerZombieCollisions();
                        CheckPlayerBulletCollisions();
                        ResetGame();               
                        if (playerManager.GameOver())
                        {
                            currentGameState = GameState.Menu;
                            highscoreManager.WriteScore();
                        }
                        break;
                    }

                case GameState.Paused:
                    {
                        if (currentKeyboard.IsKeyDown(Keys.P) && !oldKeyboard.IsKeyDown(Keys.P))
                        {
                            currentGameState = GameState.Playing;
                        }
                        break;
                    }

            }




        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (playerManager.GameOver())
            {
                spriteBatch.DrawString(TextureLibrary.HUDText, "Bajs-curious", new Vector2(450, 500), Color.Black);
            }
            switch (currentGameState)
            {
                case GameState.Menu:
                {
                    menuManager.Draw(spriteBatch);
                    playerManager.Draw(spriteBatch);
                    break;               
                }
                case GameState.Playing:
                {
                    packageManager.Draw(spriteBatch);
                    spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
                    enemyManager.Draw(spriteBatch);
                    fpsManager.Draw(spriteBatch);
                    playerManager.Draw(spriteBatch);
                    hudManager.Draw(spriteBatch);
                    break;
                }
                case GameState.Paused:
                {
                    packageManager.Draw(spriteBatch);
                    spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
                    enemyManager.Draw(spriteBatch);
                    fpsManager.Draw(spriteBatch);
                    playerManager.Draw(spriteBatch);
                    hudManager.Draw(spriteBatch);
                    spriteBatch.DrawString(TextureLibrary.HUDText, "PAUSED - PRESS P TO UNPAUSE", new Vector2(400, 500), Color.Red);
                    break;
                }
            }
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

        private void StartGame()
        {
            if (menuManager.start)
            {
                currentGameState = GameState.Playing;
            }
        }

        private void ResetGame()
        {
            if (playerManager.players[0].dead && playerManager.players[0].dead)
            {
                menuManager.start = false;
                currentGameState = GameState.Menu;
                playerManager.players[0].dead = false;
                playerManager.players[1].dead = false;
            }
        }
    }
}