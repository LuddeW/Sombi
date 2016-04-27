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

        public void Update(ref int shotgunLevel, ref int rifleLevel, ref int explosiveLevel)
        {
            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();
            MoveActive();
            LevelUp( ref shotgunLevel, ref rifleLevel, ref explosiveLevel);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < levelMenu.numberOfUpgrades; i++)
            {
                for (int k = 0; k < levelMenu.numberOfRows; k++)
                {
                    spriteBatch.Draw(TextureLibrary.busTex, levelMenu.hitbox[i, k], Color.White);
                }
            }
            spriteBatch.Draw(TextureLibrary.busTex, levelMenu.hitbox[(int)player1Active.X, (int)player1Active.Y], Color.Black);
            spriteBatch.Draw(TextureLibrary.busTex, levelMenu.hitbox[(int)player2Active.X, (int)player2Active.Y], Color.Black);
        }

        private void MoveActive()
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

        private void LevelUp(ref int shotgunLevel,ref int rifleLevel, ref int explosiveLevel)
        {
            if (currentKeyboard.IsKeyDown(Keys.Enter) && !oldKeyboard.IsKeyDown(Keys.Enter))
            {
                switch ((int)player1Active.X)
                {
                    case 0:
                        shotgunLevel = (int)player1Active.Y + 1;
                        break;
                    case 1:
                        rifleLevel = (int)player1Active.Y + 1;
                        break;
                    case 2:
                        explosiveLevel = (int)player1Active.Y + 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
