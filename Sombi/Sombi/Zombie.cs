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
        public float health;
        Vector2 pos;
        Vector2 direction;
        float velocity;
        int activationRange;
        public Zombie(Vector2 startPos)
        {
            this.velocity = 100;
            this.pos = startPos;
            this.direction = new Vector2(1, 0);
            this.health = 70;
            this.activationRange = 250;
        }
        public void Update(GameTime gameTime)
        {
            pos += direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Grid.grid[(int)((pos.X +25) / 50) + (int)direction.X, (int)(pos.Y + 25) / 50].passable != true)
            {
                direction.X *= -1;
            }
            Console.WriteLine((int)((pos.X + 25) / 50) + (int)direction.X);
          
        }
        public void handleBulletHit(float damage)
        {
            this.health -= damage;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(TextureLibrary.testMapTex, new Vector2(pos.X + 25, pos.Y + 25), new Rectangle(0, 0, 55, 50), Color.White);
        }
    }
}
