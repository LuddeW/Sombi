﻿using Microsoft.Xna.Framework;
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
        Rectangle dropZone;
        public PackageManager()
        {
            //package = new Package(new Vector2(850, 550));
            dropZone = new Rectangle(1600, 1375, 160, 170);
        }

        public void Update(GameTime gameTime, List<Player> players, int numberOfPlayers)
        {
            GetChest(players);
            leaveChest(players, numberOfPlayers);
            package.Update(gameTime);
        }
        public void AddPackage()
        {
            int spawnIndex = GlobalValues.rnd.Next(0, Grid.packageSpawnPoints.Count);
            package = new Package(Grid.packageSpawnPoints[spawnIndex]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!package.taken)
            {
                package.Draw(spriteBatch);
            }            
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
 
        

        private void leaveChest(List<Player>players, int numberOfPlayers)
        {
            if (package.taken)
            {
                foreach (Player player in players)
                {
                    if (player.HitBox.Intersects(dropZone) && player.gotPackage)
                    {
                        if (numberOfPlayers == 2)
                        {
                            players[0].cash += 100;
                            players[1].cash += 100;
                            HighscoreManager.score += 100;
                            package.taken = false;
                            GlobalValues.difficultyLevel++;
                            
                        }
                        else
                        {
                            players[0].cash += 100;
                            HighscoreManager.score += 100;
                            package.taken = false;
                            GlobalValues.difficultyLevel++;
                            AddPackage();
                            
                        }
                    }
                }
            }
        }
    }
}
