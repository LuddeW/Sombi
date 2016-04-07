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
        PackageManager packageManager;
        HighscoreManager highscoreManager;
        MenuManager menuManager;
        FloatingTextures floatingTextures;
        GameState currentGameState = GameState.Menu;
        KeyboardState currentKeyboard;
        KeyboardState oldKeyboard;
        float fadePercentage = 1;

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
            floatingTextures = new FloatingTextures();
            highscoreManager = new HighscoreManager();
            menuManager = new MenuManager(playerManager.players);
            packageManager = new PackageManager();
           

            enemyManager.AddZombie(new Vector2(400, 500));  //Endast för TEST!!
            enemyManager.AddZombie(new Vector2(800, 200));  //TEST
            enemyManager.AddZombie(new Vector2(900, 100));      //SPAWNAR ZOMBIES HÄR!!
            enemyManager.AddZombie(new Vector2(100, 600));          //DOM FÅR INTE SPAWNA PÅ VARANDRA
            enemyManager.AddZombie(new Vector2(100, 500));
            enemyManager.AddZombie(new Vector2(900, 500));
            enemyManager.AddZombie(new Vector2(900, 700));
            enemyManager.AddZombie(new Vector2(900, 800));
            enemyManager.AddZombie(new Vector2(500, 500));

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
                        floatingTextures.Update();
                        StartGame();
                        break;
                    }
                case GameState.Playing:
                    {
                        fadePercentage -= 0.008f;

                        if (currentKeyboard.IsKeyDown(Keys.P) && !oldKeyboard.IsKeyDown(Keys.P))
                        {
                            currentGameState = GameState.Paused;
                        }
                        enemyManager.Update(gameTime, playerManager.weaponManager.bulletManager.bullets);
                        playerManager.Update(gameTime);
                        packageManager.Update(gameTime, playerManager.players);
                        floatingTextures.Update();
                        hudManager.Update(gameTime);
                        fpsManager.Update(gameTime);
                        enemyManager.CheckPlayerZombieCollisions(playerManager.players);
                        playerManager.CheckPlayerBulletCollisions();             
                        if (playerManager.GameOver())
                        {
                            //fadePercentage = 0.6f;
                            fadePercentage += 0.016f;
                            if (fadePercentage == -1)
                            {
                                Grid.menu = true;
                                Grid.CreateGridFactory();
                                menuManager.start = false;
                                currentGameState = GameState.Menu;
                                highscoreManager.WriteScore();
                                playerManager.CreatePlayers(); 
                            }
                        }
                        break;
                    }
                case GameState.Paused:
                    {
                        floatingTextures.Update();
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
                Color fadeOutColor = new Color(new Vector3(255, 0, 0));
                spriteBatch.Draw(TextureLibrary.fadeScreenTex, Vector2.Zero, fadeOutColor * fadePercentage);
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
                    spriteBatch.Draw(TextureLibrary.testMapTex, Vector2.Zero, Color.White);
                    packageManager.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    fpsManager.Draw(spriteBatch);
                    playerManager.Draw(spriteBatch);
                    hudManager.Draw(spriteBatch);
                    floatingTextures.Draw(spriteBatch);
                    Color fadeInColor = new Color(new Vector3(0, 0, 0));
                    spriteBatch.Draw(TextureLibrary.fadeScreenTex, Vector2.Zero, fadeInColor * fadePercentage);
                    break;
                }
                case GameState.Paused:
                {
                    spriteBatch.Draw(TextureLibrary.testMapTex, Vector2.Zero, Color.White);
                    packageManager.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    playerManager.Draw(spriteBatch);
                    floatingTextures.Draw(spriteBatch);
                    Color fadePauseColor = new Color(new Vector3(0, 0, 0));
                    spriteBatch.Draw(TextureLibrary.fadeScreenTex, Vector2.Zero, fadePauseColor * 0.5f);
                    fpsManager.Draw(spriteBatch);
                    hudManager.Draw(spriteBatch);
                    spriteBatch.DrawString(TextureLibrary.HUDText, "PAUSED - PRESS P TO UNPAUSE", new Vector2(400, 500), Color.Red);
                    break;
                }
            }
        }

        private void StartGame()
        {
            if (menuManager.start)
            {
                playerManager.CreatePlayers();
                currentGameState = GameState.Playing;
            }
        }
    }
}