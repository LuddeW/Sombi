using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class HUDManager
    {
        List<Player> players;

        public HUDManager(List<Player> players)
        {
            this.players = players;   
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, int numberOfPlayers)
        {
            spriteBatch.Draw(TextureLibrary.player1ScoreHud, Vector2.Zero, Color.White);          
            spriteBatch.Draw(TextureLibrary.weaponHud, new Vector2(0, GlobalValues.screenBounds.Y - TextureLibrary.weaponHud.Height), Color.White * 0.8f);
            spriteBatch.DrawString(TextureLibrary.HudText, "Health: " + players[0].health, new Vector2(15, 10), Color.Black);
            spriteBatch.DrawString(TextureLibrary.HudText, "Cash: " + players[0].cash, new Vector2(15, 25), Color.Black);
            if (numberOfPlayers == 2)
            {
                spriteBatch.Draw(TextureLibrary.player2ScoreHud, new Vector2(GlobalValues.screenBounds.X - TextureLibrary.player2ScoreHud.Width, 0), Color.White);
                spriteBatch.Draw(TextureLibrary.weaponHud, new Vector2(GlobalValues.screenBounds.X - TextureLibrary.weaponHud.Width, GlobalValues.screenBounds.Y - TextureLibrary.weaponHud.Height), Color.White * 0.8f);
                spriteBatch.DrawString(TextureLibrary.HudText, "Health: " + players[1].health, new Vector2(GlobalValues.screenBounds.X - 165, 10), Color.Black);
                spriteBatch.DrawString(TextureLibrary.HudText, "Cash: " + players[1].cash, new Vector2(GlobalValues.screenBounds.X - 165, 25), Color.Black);
                spriteBatch.Draw(TextureLibrary.weaponHud, new Vector2(GlobalValues.screenBounds.X - TextureLibrary.weaponHud.Width, GlobalValues.screenBounds.Y - TextureLibrary.weaponHud.Height), Color.White * 0.8f);
            }            

            spriteBatch.DrawString(TextureLibrary.HudText, "Score: " + HighscoreManager.score, new Vector2(450, 30), Color.Black);
        }
    }
}
