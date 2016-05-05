using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Sombi
{
    class HUDManager
    {
        KeyboardState currentKeyboard;
        KeyboardState oldKeyboard;

        List<Player> players;
        Vector2 hudPos;

        int weaponRotationIndex = 0;
        int weaponRotationIndex2 = 0;

        public HUDManager(List<Player> players)
        {
            this.players = players;
            hudPos = new Vector2(0,0); 
        }
        public void Update(GameTime gameTime, Vector2 cameraPos, int numberOfPlayers)
        {
            hudPos.X = cameraPos.X;
            hudPos.Y = cameraPos.Y;
            WeaponRotation(numberOfPlayers);

        }
        public void WeaponRotation(int numberOfPlayers)
        {
            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();


            if (currentKeyboard.IsKeyDown(Keys.E) && !oldKeyboard.IsKeyDown(Keys.E))
            {
                weaponRotationIndex++;           //För player 1
                if (weaponRotationIndex > 2)
                {
                    weaponRotationIndex = 0;
                }
            }
            if (currentKeyboard.IsKeyDown(Keys.Q) && !oldKeyboard.IsKeyDown(Keys.Q))
            {
                weaponRotationIndex--;
                if (weaponRotationIndex < 0)
                {
                    weaponRotationIndex = 2;
                }
            }
            if (players[0].GamePadState.IsButtonDown(Buttons.RightShoulder) && !players[0].OldGamePadState.IsButtonDown(Buttons.RightShoulder))
            {
                weaponRotationIndex++;
                if (weaponRotationIndex > 2)
                {
                    weaponRotationIndex = 0;
                }
            }
            if (players[0].GamePadState.IsButtonDown(Buttons.LeftShoulder) && !players[0].OldGamePadState.IsButtonDown(Buttons.LeftShoulder))
            {
                weaponRotationIndex--;
                if (weaponRotationIndex < 0)
                {
                    weaponRotationIndex = 2;
                }
            }
            if (numberOfPlayers == 2)
            {
                if (players[1].GamePadState.IsButtonDown(Buttons.RightShoulder) && !players[1].OldGamePadState.IsButtonDown(Buttons.RightShoulder))
                {
                    weaponRotationIndex2++;
                    if (weaponRotationIndex2 > 2)
                    {
                        weaponRotationIndex2 = 0;
                    }
                }
                if (players[1].GamePadState.IsButtonDown(Buttons.LeftShoulder) && !players[1].OldGamePadState.IsButtonDown(Buttons.LeftShoulder))
                {
                    weaponRotationIndex2--;
                    if (weaponRotationIndex2 < 0)
                    {
                        weaponRotationIndex2 = 2;
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, int numberOfPlayers)
        {
            spriteBatch.Draw(TextureLibrary.player1ScoreHud, new Vector2(hudPos.X + 0, hudPos.Y + 0) , Color.White);          
            spriteBatch.Draw(TextureLibrary.weaponWheel[weaponRotationIndex], new Vector2(hudPos.X + 0, hudPos.Y + GlobalValues.screenBounds.Y - TextureLibrary.weaponHud.Height), Color.White * 0.8f);
            spriteBatch.DrawString(TextureLibrary.HudText, "Health: " + players[0].health, new Vector2(hudPos.X + 15, hudPos.Y + 10), Color.Black);
            spriteBatch.DrawString(TextureLibrary.HudText, "Cash: " + players[0].cash, new Vector2(hudPos.X + 15, hudPos.Y + 25), Color.Black);
            if (numberOfPlayers == 2)
            {
                spriteBatch.Draw(TextureLibrary.player2ScoreHud, new Vector2(hudPos.X + GlobalValues.screenBounds.X - TextureLibrary.player2ScoreHud.Width, hudPos.Y + 0), Color.White);
                spriteBatch.Draw(TextureLibrary.weaponWheel[weaponRotationIndex2], new Vector2(hudPos.X + GlobalValues.screenBounds.X - TextureLibrary.weaponHud.Width, hudPos.Y + GlobalValues.screenBounds.Y - TextureLibrary.weaponHud.Height), Color.White * 0.8f);
                spriteBatch.DrawString(TextureLibrary.HudText, "Health: " + players[1].health, new Vector2(hudPos.X + GlobalValues.screenBounds.X - 165, hudPos.Y + 10), Color.Black);
                spriteBatch.DrawString(TextureLibrary.HudText, "Cash: " + players[1].cash, new Vector2(hudPos.X + GlobalValues.screenBounds.X - 165, hudPos.Y + 25), Color.Black);
                //spriteBatch.Draw(TextureLibrary.weaponHud, new Vector2(GlobalValues.screenBounds.X - TextureLibrary.weaponHud.Width, GlobalValues.screenBounds.Y - TextureLibrary.weaponHud.Height), Color.White * 0.8f);
            }
            spriteBatch.DrawString(TextureLibrary.billBoardText, "" + PackageManager.deliveredPackages, new Vector2(1365, 1454), GlobalValues.billBoardColor);

            spriteBatch.DrawString(TextureLibrary.billBoardText, "" + HighscoreManager.kills, new Vector2(1320, 1478), GlobalValues.billBoardColor);
            //spriteBatch.DrawString(TextureLibrary.HudText, "Number of Zombies: " + EnemyManager.zombies.Count, new Vector2(1369, 1434), Color.Yellow);

        }
    }
}
