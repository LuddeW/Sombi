using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class BulletManager
    {
        public List<Bullet> bullets;
        public BulletManager()
        {
            bullets = new List<Bullet>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Bullet b in bullets)
            {
                b.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet b in bullets)
            {
                b.Draw(spriteBatch);
            }
            RemoveBullets();
        }

        public void AddBullets(Vector2 position, float angle, int damage,float speed, int ID)
        {
            Bullet b = new Bullet(position,speed,angle,damage,ID);
            bullets.Add(b);
        }

        private void RemoveBullets()
        {
            for (int i = bullets.Count - 1; i > 0; i--)
            {
                if (!GlobalValues.windowBounds.Contains(bullets[i].Pos))
                {
                    bullets.Remove(bullets[i]);
                }
            }
        }
    }
}
