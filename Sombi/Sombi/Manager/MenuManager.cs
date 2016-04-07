using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private float timeToPress;
        private float pressedTime;
        float fadePercentage = 0;
        public MenuManager(List<Player> players)
        {
            menu = new Menu();
            this.players = players;
            timeToPress = 2f;
            pressedTime = 0;
            fadePercentage = 0;
        }
        public void Update(GameTime gameTime)
        {
            foreach (Player player in players)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && player.HitBox.Intersects(menu.startRect))
                {
                    pressedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        fadePercentage += 0.015f;
                    if (pressedTime > timeToPress)
                    {
                        if (fadePercentage >= 1)
                        {
                            start = true;
                            Grid.menu = false;
                            Grid.CreateGridFactory();
                        }

                    }
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
            Color fadeColor = new Color(new Vector3(0, 0, 0));
            spriteBatch.Draw(TextureLibrary.fadeScreenTex, Vector2.Zero, fadeColor * fadePercentage);
        }
    }
}
