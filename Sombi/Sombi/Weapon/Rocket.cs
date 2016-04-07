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
        private float explodeDuration = 3;
        private float explodeTimer = 0;
        bool exploding = false;
        private Rectangle explodingHb;
        public Rocket(Vector2 pos, float speed, float angle, int damage, int range, int ID)
            : base(pos, speed, angle, damage, range, ID)
        {
            this.explodingHb = new Rectangle((int)this.pos.X, (int)this.pos.Y, 4, 4);
        }


        public override void Update(GameTime gameTime)
        {
            pos += velocity * speed;
            distanceTraveled = Vector2.Distance(Pos, startPos);
            explodingHb.X = (int)pos.X - (explodingHb.Width/2);
            explodingHb.Y = (int)pos.Y - (explodingHb.Height / 2);
            if (exploding && explodeTimer < explodeDuration)
            {
                explodeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                explodingHb.Width += 50;
                explodingHb.Height += 50;
                
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.rocketTestExplosion, explodingHb, Color.White);
        }
        public override void Explode()
        {
            exploding = true;
        }
        public override Rectangle GetHitBox()
        {
            return explodingHb;
        }

    }
}
