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

        Animation walkAnimation;
        AnimationPlayer animationPlayer;
        public Zombie(Vector2 startPos)
        {
            this.velocity = 100;
            this.pos = startPos;
            this.direction = new Vector2(0, 1);
            this.health = 70;
            this.activationRange = 250;
        }

        public void Load()
        {
            walkAnimation = new Animation(TextureLibrary.fastZombieTex, 50, 0.08f, true);
        }

        public void Update(GameTime gameTime)
        {
            pos += direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            FindWallThroughMatrix();

           // Console.WriteLine((int)((pos.X + 25) / 50) + (int)direction.X);

            if (pos.X != 0)
                animationPlayer.PlayAnimation(walkAnimation);
            else if (pos.Y != 0)
                animationPlayer.PlayAnimation(walkAnimation);

            animationPlayer.Update(gameTime);
          
        }
        public void handleBulletHit(float damage)
        {
            this.health -= damage;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(TextureLibrary.zombieTex, new Vector2(pos.X, pos.Y), new Rectangle(0, 0, (int)TextureLibrary.zombieTex.Width / 3, TextureLibrary.zombieTex.Height), Color.White);
            animationPlayer.Draw(spriteBatch, pos, SpriteEffects.None);
        }
        public void FindWallThroughMatrix()
        {
            if (direction.X > 0)
            {
                if (Grid.grid[(int)((pos.X) / 50) + (int)direction.X, (int)(pos.Y) / 50].passable != true)
                {
                    direction.X *= -1;
                }
            }
            else if (direction.X < 0)
            {
                if (Grid.grid[(int)((pos.X + 50) / 50) + (int)direction.X, (int)(pos.Y) / 50].passable != true)
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
            else if (direction.Y < 0)
            {
                if (Grid.grid[(int)((pos.X) / 50), ((int)(pos.Y + 50) / 50) + (int)direction.Y].passable != true)
                {
                    direction.Y *= -1;
                }
            }
        }
    }
}
