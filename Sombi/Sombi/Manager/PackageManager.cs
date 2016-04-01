using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class PackageManager
    {
        Package package;

        PlayerManager playerManager;
        public PackageManager(PlayerManager playerManager)
        {
            package = new Package(new Vector2(50, 50));
            this.playerManager = playerManager;
        }

        public void Update(GameTime gameTime)
        {
            GetChest();
            package.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            package.Draw(spriteBatch);
        }

        private void GetChest()
        {
            

            foreach (Player player in playerManager.players)
            {
                if (player.HitBox.Intersects(package.hitBox) && !package.taken)
                {
                    Console.WriteLine("Got Package");
                    package.taken = true;
                    if (package.taken == true)
                    {

                        playerManager.players[0].cash += 100;
                        playerManager.players[1].cash += 100;
                    }
                }
            }
        }
    }
}
