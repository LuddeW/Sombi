using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sombi
{
    class PlayerManager
    {
        Player player1;
        Player player2;
        public PlayerManager()
        {
            player1 = new Player(TextureLibrary.player1Tex);
            player2 = new Player(TextureLibrary.player2Tex);
        }

        public void Update(GameTime gameTime)
        {
            player1.Update(gameTime);
            player2.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
        }

    }
}
