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

        public void Update(GameTime gameTime)
        {
            ClearZombies();
            if (zombies.Count < maxzombies) // just for moar zoambiez
            {
                AddZombie(new Vector2(900,900));
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
                    zombies.RemoveAt(i);
                    maxzombies++;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Zombie z in zombies)
            {
                z.Draw(spriteBatch);
            }
        }
    }
}
