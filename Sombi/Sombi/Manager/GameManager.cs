using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sombi
{
    class GameManager
    {
        PlayerManager playerManager;
        public GameManager()
        {
            playerManager = new PlayerManager();
        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerManager.Draw(spriteBatch);
        }
    }
}
