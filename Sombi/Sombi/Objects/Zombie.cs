﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Zombie
    {
        bool haveTarget;
        public float health;
        public Vector2 pos;
        Vector2 direction;
        public Vector2 currentTile;
        float velocity;
        public int activationRange;
        Animation walkAnimation;
        AnimationPlayer animationPlayer;
        Rectangle hitBox;
        public Zombie(Vector2 startPos)
        {
            this.velocity = 50;
            this.pos = startPos;
            this.direction = new Vector2(0, 1);
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
            this.health = 70;
            this.activationRange = 250;
            this.haveTarget = false;
        }

        public void Load()
        {
            //walkAnimation = new Animation(TextureLibrary.fastZombieTex, 50, 0.08f, true);
            //walkAnimation = new Animation(TextureLibrary.zombieTex, 50, 0.2f, true);
            walkAnimation = new Animation(TextureLibrary.fatZombieTex, 50, 0.2f, true);
            currentTile = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            CalculateCurrentTile();
            pos += direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            hitBox.X = (int)pos.X - TextureLibrary.fatZombieTex.Width / 12;
            hitBox.Y = (int)pos.Y - TextureLibrary.fatZombieTex.Height / 3;
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
            animationPlayer.Draw(spriteBatch, pos);
            //spriteBatch.Draw(TextureLibrary.sourceRectTex, new Vector2(hitBox.X, hitBox.Y), Color.Red);

        }
        public void FindWallThroughMatrix()
        {
            if (direction.X > 0)
            {
                if (!Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].passable || Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].hasZombie)
                {
                    if (!haveTarget)
                    {
                        FindNewRandomDirection();
                    }
                    else
                    {
                        direction.X = 0;
                    }
                    
                }
            }
            else if (direction.X < 0)
            {
                if (!Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].passable || Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].hasZombie)
                {
                    if (!haveTarget)
                    {
                        FindNewRandomDirection();
                    }
                    else
                    {
                        direction.X = 0;
                    }
                }
            }
            if (direction.Y > 0)
            {
                if (!Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].passable || Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].hasZombie)
                {
                    if (!haveTarget)
                    {
                        FindNewRandomDirection();
                    }
                    else
                    {
                        direction.Y = 0;
                    }
                }
            }
            else if (direction.Y < 0)
            {
                if (!Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].passable || Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].hasZombie)
                {
                    if (!haveTarget)
                    {
                        FindNewRandomDirection();
                    }
                    else
                    {
                        direction.Y = 0;
                    }
                }
            }
        }
        public void FindNewRandomDirection()
        {
            int random = GlobalValues.rnd.Next(1, 3);

            switch (random)
            {
                case 1:
                    if (Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].passable && !Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].hasZombie)
                    {
                        direction.X = 0;
                        direction.Y = -1;
                        animationPlayer.rotation = MathHelper.ToRadians(180);
                    }
                    else if (Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].passable && !Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].hasZombie)
                    {
                        direction.X = 1;
                        direction.Y = 0;
                        animationPlayer.rotation = MathHelper.ToRadians(270);
                    }
                    else if (Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].passable && !Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].hasZombie)
                    {
                        direction.X = 0;
                        direction.Y = 1;
                        animationPlayer.rotation = MathHelper.ToRadians(0); 
                    }
                    else if (Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].passable && !Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].hasZombie)
                    {
                        direction.X = -1;
                        direction.Y = 0;
                        animationPlayer.rotation = MathHelper.ToRadians(90);                            
                    }
                    break;
                case 2:
                    if (Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].passable && !Grid.grid[(int)currentTile.X - 1, (int)currentTile.Y].hasZombie)
                    {
                        direction.X = -1;
                        direction.Y = 0;
                        animationPlayer.rotation = MathHelper.ToRadians(90);                            
                    }
                    else if (Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].passable && !Grid.grid[(int)currentTile.X, (int)currentTile.Y - 1].hasZombie)
                    {
                        direction.X = 0;
                        direction.Y = -1;
                        animationPlayer.rotation = MathHelper.ToRadians(180);
                    }
                    else if (Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].passable && !Grid.grid[(int)currentTile.X, (int)currentTile.Y + 1].hasZombie)
                    {
                        direction.X = 0;
                        direction.Y = 1;
                        animationPlayer.rotation = MathHelper.ToRadians(0);
                    }
                    else if (Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].passable && !Grid.grid[(int)currentTile.X + 1, (int)currentTile.Y].hasZombie)
                    {
                        direction.X = 1;
                        direction.Y = 0;
                        animationPlayer.rotation = MathHelper.ToRadians(270);
                    }
                    break;
                default:
                    break;
            }
        }
        public void SetChasingDirection(Vector2 playerPos)
        {
            this.haveTarget = true;
            this.direction = Vector2.Normalize(playerPos - this.pos);
            FindWallThroughMatrix();
        }
        public Rectangle GetHitbox()
        {
            return hitBox;
        }
        public void CalculateCurrentTile()
        {
            
            if (direction.X > 0)
            {
                Grid.SetCurrentTileHasZombie(false, currentTile);
                currentTile = new Vector2((int)(pos.X ) / 50, (int)(pos.Y) / 50);
                Grid.SetCurrentTileHasZombie(true, currentTile);
            }
            else if (direction.X < 0)
            {
                Grid.SetCurrentTileHasZombie(false, currentTile);
                currentTile = new Vector2((int)(pos.X) / 50, (int)(pos.Y) / 50);          //plusa på tex.width ist
                Grid.SetCurrentTileHasZombie(true, currentTile);
            }
            if (direction.Y > 0)
            {
                Grid.SetCurrentTileHasZombie(false, currentTile);
                currentTile = new Vector2((int)(pos.X) / 50, (int)(pos.Y) / 50);
                Grid.SetCurrentTileHasZombie(true, currentTile);
            }
            else if (direction.Y < 0)
            {
                Grid.SetCurrentTileHasZombie(false, currentTile);
                currentTile = new Vector2((int)(pos.X) / 50, (int)(pos.Y) / 50);
                Grid.SetCurrentTileHasZombie(true, currentTile);
            }
        }
        public void ResetTarget()
        {
            this.haveTarget = false;
        }
    }

}
