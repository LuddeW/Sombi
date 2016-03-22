using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Zombie
    {
        float health;
        Vector2 pos;
        Vector2 direction;
        float velocity;
        int activationRange;
        public Zombie(Vector2 startPos)
        {
            this.velocity = 100;
            this.pos = startPos;
            this.direction = new Vector2(0, 0);
            this.health = 70;
            this.activationRange = 250;
        }
        public void Update(GameTime gameTime)
        {
            pos += direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void handleBulletHit(float damage)
        {
            this.health -= damage;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
