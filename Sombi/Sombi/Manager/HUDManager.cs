﻿using Microsoft.Xna.Framework;
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
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.HUD, Vector2.Zero, Color.White);
            spriteBatch.DrawString(TextureLibrary.HUDText, "Health: " + players[0].health, new Vector2(15,10), Color.Black);
            spriteBatch.DrawString(TextureLibrary.HUDText, "Cash: " + players[0].cash, new Vector2(15,25), Color.Black);
            spriteBatch.DrawString(TextureLibrary.HUDText, "Health: " + players[1].health, new Vector2(835, 10), Color.Black);
            spriteBatch.DrawString(TextureLibrary.HUDText, "Cash: " + players[1].cash, new Vector2(835, 25), Color.Black);
            spriteBatch.DrawString(TextureLibrary.HUDText, "Score: " + HighscoreManager.score, new Vector2(450, 30), Color.Black);
        }
    }
}
