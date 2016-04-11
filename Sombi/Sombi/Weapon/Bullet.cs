using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Bullet : Projectile
    {
        public Bullet(Vector2 pos,float speed,float angle,int damage, int range, int ID) : base(pos, speed, angle, damage, range, ID)   
        {

        }


        public override void Update(GameTime gameTime)
        {
            pos += velocity * speed;
             distanceTraveled = Vector2.Distance(Pos,startPos);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.bulletBlue, pos, Color.White);
        }
        public override void Explode()
        {
            
        }
        public override Rectangle GetHitBox()
        {
            Rectangle hb = new Rectangle((int)pos.X, (int)pos.Y, 4, 4);
            return hb;
        }
    }
}
