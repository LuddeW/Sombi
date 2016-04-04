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
        public List<BloodStain> blodPositions = new List<BloodStain>();
        public void Update(GameTime gameTime, List<Bullet> bulletList)
        {
            CheckForBulletCollisions(bulletList);
            ClearZombies();
           /* if (zombies.Count < maxzombies) // just for moar zoambiez
            {
                AddZombie(new Vector2(900, 900));
            }*/
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
                    blodPositions.Add(new BloodStain(zombies[i].pos));
                    zombies.RemoveAt(i);


                    maxzombies++;

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BloodStain bs in blodPositions)
            {
                bs.Draw(spriteBatch);
            }

            foreach (Zombie z in zombies)
            {
                z.Draw(spriteBatch);
            }
            spriteBatch.DrawString(TextureLibrary.HUDText, "Number of Zombies killed: " + zombies.Count, new Vector2(450, 15), Color.Black);

        }
        public void CheckForBulletCollisions(List<Bullet> bulletList)
        {
            for (int i = 0; i < zombies.Count; i++)
            {
                for (int k = 0; k < bulletList.Count; k++)
                {
                    if (zombies[i].GetHitbox().Contains(bulletList[k].Pos))
                    {
                        zombies[i].handleBulletHit(bulletList[k].damage);

                        bulletList.RemoveAt(k);

                    }
                }
            }
        }
    }
}
