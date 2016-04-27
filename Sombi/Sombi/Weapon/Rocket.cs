using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Rocket : Projectile
    {
        private float explodeDuration = 2;
        private float explodeTimer = 0;
        Animation animation;
        private int AOE;
        AnimationPlayer animationPlayer;
        private Rectangle explodingHb;
        public Rocket(Vector2 pos, float speed, float angle, int damage, int range, int ID)
            : base(pos, speed, angle, damage, range, ID)
        {
            this.explodingHb = new Rectangle((int)this.pos.X, (int)this.pos.Y, 4, 4);
            animation = new Animation(TextureLibrary.rocketExplosion, 125, 0.1f, false);
            this.timeToLiveAfterImpact = 1;
            AOE = 100;
        }
        public Rocket(Vector2 pos, float speed, float angle, int damage, int range, int ID, int level)
            : base(pos, speed, angle, damage, range, ID)
        {
            this.explodingHb = new Rectangle((int)this.pos.X, (int)this.pos.Y, 4, 4);
            animation = new Animation(TextureLibrary.rocketExplosion, 125, 0.1f, false);
            SetVariables(level);
        }


        public override void Update(GameTime gameTime)
        {
            pos += velocity * speed;
            distanceTraveled = Vector2.Distance(Pos, startPos);
            explodingHb.X = (int)pos.X - (explodingHb.Width/2);
            explodingHb.Y = (int)pos.Y - (explodingHb.Height / 2);
            if (exploding && explodeTimer < explodeDuration)
            {
                timeToLiveAfterImpact -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                explodeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                animationPlayer.PlayAnimation(animation);
                animationPlayer.Update(gameTime);
                
                
            }


        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.rocket, pos, Color.White);
            animationPlayer.Draw(spriteBatch, pos);
        }
        public override void Explode()
        {
            this.speed = 0;
            explodingHb.Width = AOE;
            explodingHb.Height = AOE;
            exploding = true;
        }
        public override Rectangle GetHitBox()
        {
            return explodingHb;
        }
        public void SetVariables(int level)
        {
            switch (level)
            {
                case 1:
                    this.timeToLiveAfterImpact = 1;
                    AOE = 50;
                    break;
                case 2:
                    this.timeToLiveAfterImpact = 1;
                    AOE = 75;
                    break;
                case 3:
                    this.timeToLiveAfterImpact = 1;
                    AOE = 100;
                    break;
                case 4:
                    this.timeToLiveAfterImpact = 1;
                    AOE = 125;
                    break;
                case 5:
                    this.timeToLiveAfterImpact = 1;
                    AOE = 150;
                    break;
                case 6:
                    this.timeToLiveAfterImpact = 1;
                    AOE = 175;
                    break;
                default:
                    break;
            }
        }

    }
}
