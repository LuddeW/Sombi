using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class EnemyManager
    {


        int maxzombies = 10;


        public List<Zombie> zombies = new List<Zombie>();
        public List<BloodStain> bloodPositions = new List<BloodStain>();
        public void Update(GameTime gameTime, List<Projectile> bulletList)
        {
            CheckForBulletCollisions(bulletList);
            ClearZombies();
            if (zombies.Count < maxzombies) // just for moar zoambiez
            {
                AddZombie(new Vector2(1400, 500));
            }
            foreach (Zombie z in zombies)
            {
                z.Update(gameTime);
            }
        }

        public void AddZombie(Vector2 startPos)
        {
            Zombie z = new Zombie(startPos);
            zombies.Add(z);
            z.Load();
        }
        public void ClearZombies()
        {
            for (int i = zombies.Count - 1; i >= 0; i--)
            {
                if (zombies[i].health < 1)
                {
                    Grid.SetCurrentTileHasZombie(false, zombies[i].currentTile);
                    bloodPositions.Add(new BloodStain(zombies[i].pos));
                    zombies.RemoveAt(i);
                    HighscoreManager.score++;

                    maxzombies++;

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BloodStain bs in bloodPositions)
            {
                bs.Draw(spriteBatch);
            }

            foreach (Zombie z in zombies)
            {
                z.Draw(spriteBatch);
            }
            spriteBatch.DrawString(TextureLibrary.HudText, "Number of Zombies: " + zombies.Count, new Vector2(450, 15), Color.Black);

        }
        public void CheckForBulletCollisions(List<Projectile> bulletList)
        {
            for (int i = 0; i < zombies.Count; i++)
            {
                for (int k = 0; k < bulletList.Count; k++)
                {
                    if (zombies[i].GetHitbox().Intersects(bulletList[k].GetHitBox()))
                    {
                        zombies[i].handleBulletHit(bulletList[k].damage);
                        bulletList[k].Explode();
                        if (bulletList[k].timeToLiveAfterImpact == 0)
                        {
                            bulletList.RemoveAt(k);
                        }
                       

                    }
                }
            }
        }

        public void CheckPlayerZombieCollisions(List<Player> players)
        {
            for (int i = 0; i < zombies.Count; i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    if (zombies[i].GetHitbox().Intersects(players[j].HitBox))
                    {
                        players[j].handleBulletHit(10);
                    }

                    if (Vector2.Distance(zombies[i].pos, players[j].pos) < zombies[i].activationRange && !players[j].eaten)
                    {
                        zombies[i].SetChasingDirection(players[j].pos);

                    }
                    else if (Vector2.Distance(zombies[i].pos, players[j].pos) > zombies[i].activationRange)
                    {
                        zombies[i].ResetTarget();

                    }

                }
            }
        }
    }
}
