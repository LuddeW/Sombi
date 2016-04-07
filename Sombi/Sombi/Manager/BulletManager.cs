﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class BulletManager
    {
        public List<Projectile> bullets;
        public BulletManager()
        {
            bullets = new List<Projectile>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Projectile b in bullets)
            {
                b.Update(gameTime);
            }
            

            RemoveBullets();


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Projectile b in bullets)
            {
                b.Draw(spriteBatch);
            }
            
        }


        public void AddBullets(Vector2 position, float angle, int damage,float speed, int range, int ID)
        {
            Bullet b = new Bullet(position,speed,angle,damage, range, ID);
            Rocket r = new Rocket(position, speed, angle, damage, range, ID);
            bullets.Add(r);
        }

        private void RemoveBullets()
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                if (!GlobalValues.windowBounds.Contains(bullets[i].Pos) || !Grid.grid[(int)bullets[i].Pos.X / 50, (int)bullets[i].Pos.Y / 50].passable || bullets[i].distanceTraveled > bullets[i].range)
                {
                    bullets.Remove(bullets[i]);
                }
            }
        }
    }
}
