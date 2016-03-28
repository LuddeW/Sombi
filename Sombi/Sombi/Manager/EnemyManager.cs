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
        
        public List<Zombie> zombies = new List<Zombie>();

        
        public void Update(GameTime gameTime)
        {
            ClearZombies();
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
