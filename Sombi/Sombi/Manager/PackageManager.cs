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
        public Rectangle dropZone;
        EnemyManager enemyManager;
        public static int deliveredPackages;
        public static int numberOfCarriedPackages;
        public PackageManager(EnemyManager enemyManager)
        {
            //package = new Package(new Vector2(850, 550));
            dropZone = new Rectangle(1600, 1375, 160, 170);
            this.enemyManager = enemyManager;
        }

        public void Update(GameTime gameTime, List<Player> players)
        {
            GetChest(players);
            leaveChest(players);
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
                    numberOfCarriedPackages++;
                }
            }
        }        

        private void leaveChest(List<Player>players)
        {
            if (package.taken)
            {
                foreach (Player player in players)
                {
                    if (player.HitBox.Intersects(dropZone) && player.gotPackage)
                    {
                        if (GlobalValues.numberOfPlayers == 2)
                        {
                            players[0].cash += 110;
                            players[1].cash += 110;
                            HighscoreManager.score += 100;
                            package.taken = false;
                            GlobalValues.difficultyLevel++;
                            deliveredPackages++;
                            numberOfCarriedPackages = 0;
                        }
                        else
                        {
                            players[0].cash += 110;
                            HighscoreManager.score += 100;
                            package.taken = false;
                            GlobalValues.difficultyLevel++;
                            AddPackage();
                            deliveredPackages++;
                        }
                        AddPackage();
                        //enemyManager.AddZombiesToRandomLocation(13 * GlobalValues.difficultyLevel * GlobalValues.numberOfPlayers);
                        enemyManager.AddNewWave(0.5f, 24 * GlobalValues.difficultyLevel * GlobalValues.numberOfPlayers);
                    }
                }
            }
        }
    }
}
