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
        public MenuManager(List<Player> player)
        {
            menu = new Menu();
        }
        public void Update(GameTime gameTime)
        {

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
