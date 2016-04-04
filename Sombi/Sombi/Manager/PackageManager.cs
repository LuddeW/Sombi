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
            leaveChest(players);
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
                    player.gotPackage = true;                   
                }
            }
        }

        private void leaveChest(List<Player>players)
        {
            if (package.taken)
            {
                foreach (Player player in players)
                {
                    if (player.position.X / 50 > 17 && player.position.Y / 50 < 2 && player.gotPackage)
                    {
                        players[0].cash += 100;
                        players[1].cash += 100;
                        package.taken = false;
                        Console.WriteLine(package.taken);
                    }
                }
            }
        }
    }
}
