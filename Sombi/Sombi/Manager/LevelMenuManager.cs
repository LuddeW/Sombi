using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class LevelMenuManager
    {
        LevelMenu levelMenu;
        Vector2 player1Active;
        Vector2 player2Active;
        KeyboardState currentKeyboard;
        KeyboardState oldKeyboard;

        public LevelMenuManager()
        {
            levelMenu = new LevelMenu();
            player1Active = new Vector2(0, 0);
            player2Active = new Vector2(3, 0);
        }

        public void Update(ref int shotgunLevelP1, ref int rifleLevelP1, ref int explosiveLevelP1, ref int shotgunLevelP2, ref int rifleLevelP2, ref int explosiveLevelP2)
        {
            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();
            MovePlayer1Active();
            MovePlayer2Active();
            LevelUpPlayer1(ref shotgunLevelP1, ref rifleLevelP1, ref explosiveLevelP1);
            LevelUpPlayer2(ref shotgunLevelP2, ref rifleLevelP2, ref explosiveLevelP2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < levelMenu.numberOfUpgrades; i++)
            {
                for (int k = 0; k < levelMenu.numberOfRows; k++)
                {
                    spriteBatch.Draw(TextureLibrary.rifleLevel, levelMenu.hitbox[0, k], Color.White);
                    spriteBatch.DrawString(TextureLibrary.HudText, "Level 1     $100", new Vector2(levelMenu.hitbox[i, 1].X, levelMenu.hitbox[0, 0].Y + levelMenu.hitbox[i, k].Height), Color.Black);
                    spriteBatch.Draw(TextureLibrary.shotgunLevel, levelMenu.hitbox[1, k], Color.White);
                    spriteBatch.DrawString(TextureLibrary.HudText, "Level 2     $150", new Vector2(levelMenu.hitbox[i, 1].X, levelMenu.hitbox[0, 1].Y + levelMenu.hitbox[i, k].Height), Color.Black);
                    spriteBatch.Draw(TextureLibrary.rocketLevel, levelMenu.hitbox[2, k], Color.White);
                    spriteBatch.DrawString(TextureLibrary.HudText, "Level 3     $200", new Vector2(levelMenu.hitbox[i, 1].X, levelMenu.hitbox[0, 2].Y + levelMenu.hitbox[i, k].Height), Color.Black);
                    spriteBatch.Draw(TextureLibrary.rifleLevel, levelMenu.hitbox[3, k], Color.White);
                    spriteBatch.DrawString(TextureLibrary.HudText, "Level 4     $250", new Vector2(levelMenu.hitbox[i, 1].X, levelMenu.hitbox[0, 3].Y + levelMenu.hitbox[i, k].Height), Color.Black);
                    spriteBatch.Draw(TextureLibrary.shotgunLevel, levelMenu.hitbox[4, k], Color.White);
                    spriteBatch.DrawString(TextureLibrary.HudText, "Level 5     $300", new Vector2(levelMenu.hitbox[i, 1].X, levelMenu.hitbox[0, 4].Y + levelMenu.hitbox[i, k].Height), Color.Black);
                    spriteBatch.Draw(TextureLibrary.rocketLevel, levelMenu.hitbox[5, k], Color.White);
                    spriteBatch.DrawString(TextureLibrary.HudText, "Level 6     $350", new Vector2(levelMenu.hitbox[i, 1].X, levelMenu.hitbox[0, 5].Y + levelMenu.hitbox[i, k].Height), Color.Black);
                }
            }
            spriteBatch.Draw(TextureLibrary.sourceRectTex, levelMenu.hitbox[(int)player1Active.X, (int)player1Active.Y], Color.Black * 0.2f);
            spriteBatch.Draw(TextureLibrary.sourceRectTex, levelMenu.hitbox[(int)player2Active.X, (int)player2Active.Y], Color.Black * 0.2f);
        }

        private void MovePlayer1Active()
        {
            if (currentKeyboard.IsKeyDown(Keys.W) && !oldKeyboard.IsKeyDown(Keys.W) && (int)player1Active.Y > 0)
            {
                player1Active.Y -= 1;
            }
            if (currentKeyboard.IsKeyDown(Keys.S) && !oldKeyboard.IsKeyDown(Keys.S) && (int)player1Active.Y < 5)
            {
                player1Active.Y += 1;
            }
            if (currentKeyboard.IsKeyDown(Keys.A) && !oldKeyboard.IsKeyDown(Keys.A) && (int)player1Active.X > 0)
            {
                player1Active.X -= 1;
            }
            if (currentKeyboard.IsKeyDown(Keys.D) && !oldKeyboard.IsKeyDown(Keys.D) && (int)player1Active.X < 2)
            {
                player1Active.X += 1;
            }
        }

        private void MovePlayer2Active()
        {
            if (currentKeyboard.IsKeyDown(Keys.Up) && !oldKeyboard.IsKeyDown(Keys.Up) && (int)player2Active.Y > 0)
            {
                player2Active.Y -= 1;
            }
            if (currentKeyboard.IsKeyDown(Keys.Down) && !oldKeyboard.IsKeyDown(Keys.Down) && (int)player2Active.Y < 5)
            {
                player2Active.Y += 1;
            }
            if (currentKeyboard.IsKeyDown(Keys.Left) && !oldKeyboard.IsKeyDown(Keys.Left) && (int)player2Active.X > 3)
            {
                player2Active.X -= 1;
            }
            if (currentKeyboard.IsKeyDown(Keys.Right) && !oldKeyboard.IsKeyDown(Keys.Right) && (int)player2Active.X < 5)
            {
                player2Active.X += 1;
            }
        }

        private void LevelUpPlayer1(ref int shotgunLevel, ref int rifleLevel, ref int explosiveLevel)
        {
            if (currentKeyboard.IsKeyDown(Keys.Enter) && !oldKeyboard.IsKeyDown(Keys.Enter))
            {
                switch ((int)player1Active.X)
                {
                    case 0:
                        if (true)
                        {
                            shotgunLevel = (int)player1Active.Y + 1;
                        }                  
                        break;
                    case 1:
                        if (true)
                        {
                            rifleLevel = (int)player1Active.Y + 1;
                        }
                        break;
                    case 2:
                        if (true)
                        {
                            explosiveLevel = (int)player1Active.Y + 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void LevelUpPlayer2(ref int shotgunLevel, ref int rifleLevel, ref int explosiveLevel)
        {
            if (currentKeyboard.IsKeyDown(Keys.Enter) && !oldKeyboard.IsKeyDown(Keys.Enter))
            {
                switch ((int)player2Active.X)
                {
                    case 3:
                        if (true)
                        {
                            shotgunLevel = (int)player1Active.Y + 1;
                        }                       
                        break;
                    case 4:
                        if (true)
                        {
                            rifleLevel = (int)player1Active.Y + 1;
                        }                      
                        break;
                    case 5:
                        if (true)
                        {
                            explosiveLevel = (int)player1Active.Y + 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
