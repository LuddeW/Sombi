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
            if (direction.X > 0)
            {
                if (Grid.grid[(int)((pos.X) / 50) + (int)direction.X, (int)(pos.Y) / 50].passable != true)
                {
                    direction.X *= -1;
                }
            }
            else if (direction.X <= 0)
            {
                if (Grid.grid[(int)((pos.X + (TextureLibrary.zombieTex.Width / 3)) / 50) + (int)direction.X, (int)(pos.Y) / 50].passable != true)
                {
                    direction.X *= -1;
                }
            }

            if (direction.Y > 0)
            {
                if (Grid.grid[(int)((pos.X) / 50), ((int)(pos.Y) / 50) + (int)direction.Y].passable != true)
                {
                    direction.Y *= -1;
                }
            }
            else if (direction.Y <= 0)
            {
                if (Grid.grid[(int)((pos.X) / 50) + (int)direction.X, ((int)(pos.Y + TextureLibrary.zombieTex.Height) / 50) + (int)direction.Y].passable != true)
                {
                    direction.Y *= -1;
                }
            }

            Console.WriteLine((int)((pos.X + 25) / 50) + (int)direction.X);
          
        }
        public void handleBulletHit(float damage)
        {
            this.health -= damage;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(TextureLibrary.testMapTex, new Vector2(pos.X, pos.Y), new Rectangle(0, 0, 55, 50), Color.White);
        }
    }
}
