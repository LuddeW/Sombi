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
        
        public PackageManager()
        {
            package = new Package(new Vector2(50, 50));
        }

        public void Update(GameTime gameTime, List<Player> players)
        {
            GetChest(players);
            package.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            package.Draw(spriteBatch);
        }

        private void GetChest(List<Player> players)
        {
            

            foreach (Player player in players)
            {
                if (player.HitBox.Intersects(package.hitBox) && !package.taken)
                {
                    Console.WriteLine("Got Package");
                    package.taken = true;
                    if (package.taken == true)
                    {
                        players[0].cash += 100;
                        players[1].cash += 100;
                    }
                }
            }
        }
    }
}
