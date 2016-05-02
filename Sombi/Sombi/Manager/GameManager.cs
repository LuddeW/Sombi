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
        MainMenu,
        Settings,
        Highscore,
        Playing,
        Paused,
        LevelUp,
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
        LevelMenuManager levelMenuManager;
        FloatingTextures floatingTextures;
        GameState currentGameState = GameState.MainMenu;
        KeyboardState currentKeyboard;
        KeyboardState oldKeyboard;
        Game1 game;
        Camera camera;
        float fadeInPercentage = 1;
        float fadeOutPercentage = 0;

        public GameManager(ContentManager contentManager, Game1 game)
        {
            this.contentManager = contentManager;
            TextureLibrary.LoadContent(contentManager);
            SoundLibrary.LoadContent(contentManager);
            Grid.CreateGridFactory();
            camera = new Camera((int)GlobalValues.TILE_SIZE);
            playerManager = new PlayerManager(camera);
            enemyManager = new EnemyManager();
            hudManager = new HUDManager(playerManager.players);
            fpsManager = new FPSManager();
            floatingTextures = new FloatingTextures();
            highscoreManager = new HighscoreManager();
            highscoreManager.ReadScore();
            menuManager = new MenuManager(playerManager.players);
            levelMenuManager = new LevelMenuManager(playerManager.players);
            packageManager = new PackageManager(enemyManager);
            this.game = game;

        }

        public Matrix ViewMatrix
        {
            get { return camera.ViewMatrix; }
        }

        public void Update(GameTime gameTime)
        {
            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();
            switch (currentGameState)
            {
                case GameState.MainMenu:
                    {
                        MenuUpdate(gameTime);
                        if (currentKeyboard.IsKeyDown(Keys.A)) ///enbart för test, tas bort sen
                        {
                            currentGameState = GameState.Highscore;
                        }

                    }
                    break;

                case GameState.Highscore:
                    {
                        if (currentKeyboard.IsKeyDown(Keys.A) && !oldKeyboard.IsKeyDown(Keys.A)) // enbart för test, tas bort sen lolololo
                        {
                            currentGameState = GameState.Highscore;
                        }
                        break;
                    }
  
                case GameState.Playing:

                    {
                        PlayingUpdate(gameTime);
                        Upgrade();
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

                case GameState.LevelUp:
                    {
                        levelMenuManager.Update(ref playerManager.player1.shotgunLevel, ref playerManager.player1.rifleLevel, ref playerManager.player1.explosivesLevel, ref playerManager.player2.shotgunLevel, ref playerManager.player2.rifleLevel, ref playerManager.player2.explosivesLevel);
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
                spriteBatch.DrawString(TextureLibrary.HudText, "Well....", new Vector2(450, 500), Color.Black);
                Color fadeOutColor = new Color(new Vector3(255, 0, 0));
                Color fadeInColor = new Color(new Vector3(0, 0, 0));
                spriteBatch.Draw(TextureLibrary.fadeScreenTex, Vector2.Zero, fadeOutColor * fadeOutPercentage);
                spriteBatch.Draw(TextureLibrary.fadeScreenTex, Vector2.Zero, fadeInColor * fadeInPercentage);
            }
            switch (currentGameState)
            {
                case GameState.MainMenu:
                {
                    MenuDraw(spriteBatch);
                    break;               
                }
                case GameState.Highscore:
                {
                    highscoreManager.Draw(spriteBatch);
                    break;
                }
                case GameState.Playing:
                {
                    PlayingDraw(spriteBatch);   
                    break;
                }
                case GameState.Paused:
                {
                        PauseDraw(spriteBatch);
                    
                    break;
                }

                case GameState.LevelUp:
                {
                        levelMenuManager.Draw(spriteBatch);
                        break;
                }

            }
        }

        private void StartGame()
        {
            if (menuManager.start)
            {
                enemyManager.AddZombiesToRandomLocation(24 * GlobalValues.difficultyLevel * GlobalValues.numberOfPlayers);
                packageManager.AddPackage();

                if (menuManager.numberOfPlayers == 1)
                {
                    playerManager.CreateOnePlayer();
                }
                else if (menuManager.numberOfPlayers == 2)
                {
                    playerManager.CreatePlayers();
                }
                
                currentGameState = GameState.Playing;
            }
        }

        private void Settings()
        {
            if (menuManager.settings)
            {
                currentGameState = GameState.Settings;
            }
        }

        private void Highscore()
        {
            if (menuManager.highscore)
            {
                highscoreManager.ReadScore();
                currentGameState = GameState.Highscore;
            }
        }

        private void ExitGame()
        {
            if (menuManager.exit)
            {
                game.Exit();
            }
        }

        private void MenuDraw(SpriteBatch spriteBatch)
        {
            menuManager.Draw(spriteBatch);
            playerManager.Draw(spriteBatch);
        }

        private void MenuUpdate(GameTime gameTime)
        {
            camera.Update(playerManager.players[0].pos, playerManager.players[1].pos);
            menuManager.Update(gameTime);
            playerManager.Update(gameTime);
            floatingTextures.Update();
            StartGame();
            ExitGame();
            Settings();
            Highscore();
                       
        }

        private void PlayingDraw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(TextureLibrary.testMapTex, Vector2.Zero, Color.White);
            packageManager.Draw(spriteBatch);
            enemyManager.DrawBlood(spriteBatch);
            fpsManager.Draw(spriteBatch);
            playerManager.Draw(spriteBatch);
            enemyManager.DrawZombie(spriteBatch);
            floatingTextures.Draw(spriteBatch);
            enemyManager.DrawZombieCount(spriteBatch);
            hudManager.Draw(spriteBatch, menuManager.numberOfPlayers);
            Color fadeInColor = new Color(new Vector3(0, 0, 0));
            spriteBatch.Draw(TextureLibrary.fadeScreenTex, Vector2.Zero, fadeInColor * fadeInPercentage);
        }

        private void PlayingUpdate(GameTime gameTime)
        {
            if (menuManager.numberOfPlayers == 2)
            {
                if (playerManager.player1.eaten)
                {
                    camera.Update(playerManager.players[1].pos, playerManager.players[1].pos);
                }
                else if (playerManager.player2.eaten)
                {
                    camera.Update(playerManager.players[0].pos, playerManager.players[0].pos);
                }
                else
                {
                    camera.Update(playerManager.players[0].pos, playerManager.players[1].pos);
                }  
            }
            else
            {
                camera.Update(playerManager.players[0].pos);
            }
            fadeInPercentage -= 0.008f;
            if (currentKeyboard.IsKeyDown(Keys.P) && !oldKeyboard.IsKeyDown(Keys.P))
            {
                currentGameState = GameState.Paused;
            }
            enemyManager.Update(gameTime, playerManager.weaponManager.bulletManager.bullets);
            playerManager.Update(gameTime);
            packageManager.Update(gameTime, playerManager.players, menuManager.numberOfPlayers);
            floatingTextures.Update();
            hudManager.Update(gameTime, camera.position);
            fpsManager.Update(gameTime);
            enemyManager.CheckPlayerZombieCollisions(playerManager.players);
            playerManager.CheckPlayerBulletCollisions();
            if (playerManager.GameOver())
            {                
                fadeOutPercentage += 0.016f;
                fadeInPercentage += 0.025f;

                if (fadeOutPercentage >= 3)
                {
                    Grid.menu = true;
                    Grid.CreateGridFactory();
                    menuManager.start = false;
                    currentGameState = GameState.MainMenu;
                    highscoreManager.WriteScore();
                    playerManager.CreatePlayers();
                    enemyManager.zombies.Clear();
                }
            }
        }

        private void PauseDraw(SpriteBatch spriteBatch)
        {
            PlayingDraw(spriteBatch);
            spriteBatch.DrawString(TextureLibrary.billBoardText, "PAUSED - PRESS P TO UNPAUSE", new Vector2(400, 500), Color.Red);
        }

        private void Upgrade()
        {
            if ((playerManager.players[0].HitBox.Intersects(packageManager.dropZone) || playerManager.players[1].HitBox.Intersects(packageManager.dropZone)) && currentKeyboard.IsKeyDown(Keys.B) && !oldKeyboard.IsKeyDown(Keys.B))
            {
                currentGameState = GameState.LevelUp;
            }
        }
    }
}