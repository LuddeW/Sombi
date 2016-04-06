using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class MenuManager
    {
        Menu menu;
        List<Player> players;
        public bool start = false;
        public MenuManager(List<Player> players)
        {
            menu = new Menu();
            this.players = players;
        }
        public void Update(GameTime gameTime)
        {
            foreach (Player player in players)
            {
                if (player.HitBox.Intersects(menu.startRect))
                {
                    start = true;
                    Grid.menu = false;
                    Grid.CreateGridFactory();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.startButton, menu.startRect, Color.White);
            spriteBatch.Draw(TextureLibrary.settingButton, menu.settingRect, Color.White);
            spriteBatch.Draw(TextureLibrary.highscoreButton, menu.highscoreRect, Color.White);
            spriteBatch.Draw(TextureLibrary.exitButton, menu.exitRect, Color.White);
            spriteBatch.Draw(TextureLibrary.logoTex, menu.logoRect, Color.White);
        }
    }
}
