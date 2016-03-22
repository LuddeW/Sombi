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
        List<Bullet> bullets;

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
        }

        public void AddBullets(Vector2 position, float angle, int damage,float speed)
        {
            Bullet b = new Bullet(position,speed,angle,damage);
            bullets.Add(b);
        }
    }
}
