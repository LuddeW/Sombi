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
        Vector2 startPos;
        public float distanceTraveled;
        float angle;
        public int damage;
        public int range;
        Vector2 velocity;
        public Bullet(Vector2 pos,float speed,float angle,int damage, int range) : base(pos,speed)
        {
            this.angle = angle;
            this.damage = damage;
            velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            this.range = range;
            startPos = pos;
        }

        public Vector2 Pos
        {
            get
            {
                return pos;

            }
            set { }
        }

        public override void Update(GameTime gameTime)
        {
            pos += velocity * speed;
             distanceTraveled = Vector2.Distance(Pos,startPos);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.BulletBlue, pos, Color.White);
        }
    }
}
