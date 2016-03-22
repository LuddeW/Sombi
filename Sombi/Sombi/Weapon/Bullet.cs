using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Bullet : MovingObject
    {
        float angle;
        int damage;
        Vector2 velocity;
        public Bullet(Vector2 pos,float speed,float angle,int damage) : base(pos,speed)
        {
            this.angle = angle;
            this.damage = damage;
            velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));

        }

        public override void Update(GameTime gameTime)
        {
            pos += velocity * speed;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.BulletBlue, pos, Color.White);
        }
    }
}
