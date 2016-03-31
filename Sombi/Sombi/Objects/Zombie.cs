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
        Vector2 currentTile;
        float velocity;
        int activationRange;
        Animation walkAnimation;
        AnimationPlayer animationPlayer;
        public Zombie(Vector2 startPos)
        {
            this.velocity = 50;
            this.pos = startPos;
            this.direction = new Vector2(0, 1);
            this.health = 70;
            this.activationRange = 250;
        }

        public void Load()
        {
            walkAnimation = new Animation(TextureLibrary.zombieTex, 72, 0.2f, true);
            //walkAnimation = new Animation(TextureLibrary.fastZombieTex, 50, 0.08f, true);
            currentTile = new Vector2(0, 0);
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
        public void handleBulletHit(int damage)
        {
            this.health -= damage;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(TextureLibrary.zombieTex, new Vector2(pos.X, pos.Y), new Rectangle(0, 0, (int)TextureLibrary.zombieTex.Width / 3, TextureLibrary.zombieTex.Height), Color.White);
            animationPlayer.Draw(spriteBatch, pos);
        }
        public void FindWallThroughMatrix()
        {
            currentTile = new Vector2((int)(pos.X + 25) / 50, (int)(pos.Y + 25) / 50);

            if (direction.X > 0)
            {


                if (Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].passable != true)
                {
                    FindNewRandomDirection();
                }
            }
            else if (direction.X < 0)
            {
                if (Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].passable != true)
                {
                    FindNewRandomDirection();
                }
            }
            if (direction.Y > 0)
            {
                if (Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].passable != true)
                {
                    FindNewRandomDirection();
                }
            }
            else if (direction.Y < 0)
            {
                if (Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].passable != true)
                {
                    FindNewRandomDirection();
                }
            }
        }
        public void FindNewRandomDirection()
        {
            int random = GlobalValues.rnd.Next(1, 3);

            switch (random)
            {
                case 1:
                    if (Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].passable == true)
                    {
                        direction.X = 0;
                        direction.Y = -1;
                        AnimationPlayer.rotation = MathHelper.ToRadians(180);
                    }
                    else if (Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].passable == true)
                    {
                        direction.X = 1;
                        direction.Y = 0;
                        AnimationPlayer.rotation = MathHelper.ToRadians(270);
                    }
                    else if (Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].passable == true)
                    {
                        direction.X = 0;
                        direction.Y = 1;
                        AnimationPlayer.rotation = MathHelper.ToRadians(0); 
                    }
                    else if (Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].passable == true)
                    {
                        direction.X = -1;
                        direction.Y = 0;
                        AnimationPlayer.rotation = MathHelper.ToRadians(90);                            
                    }
                    break;
                case 2:
                    if (Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].passable == true)
                    {
                        direction.X = -1;
                        direction.Y = 0;
                        AnimationPlayer.rotation = MathHelper.ToRadians(90);
                    }
                    else if (Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].passable == true)
                    {
                        direction.X = 0;
                        direction.Y = -1;
                        AnimationPlayer.rotation = MathHelper.ToRadians(180);
                    }
                    else if (Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].passable == true)
                    {
                        direction.X = 0;
                        direction.Y = 1;
                        AnimationPlayer.rotation = MathHelper.ToRadians(0);
                    }
                    else if (Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].passable == true)
                    {
                        direction.X = 1;
                        direction.Y = 0;
                        AnimationPlayer.rotation = MathHelper.ToRadians(270);
                    }

                    break;
                default:
                    break;
            }






        }
        public Rectangle GetHitbox()
        {
            Rectangle hb = new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
            return hb;
        }
    }

}
