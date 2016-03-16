using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    abstract class Weapon
    {
        List<Bullet> bullets;
        
        public Weapon()
        {
            this.bullets = new List<Bullet>();
        }
        public void Update(GameTime gameTime)
        {

        }
        //public void Draw(SpriteBatch spriteBatch);
        //protected virtual void Update(GameTime gameTime)
        //{

        //}


        public virtual void FireWeapon(Vector2 position, float angle) //player calls method to fire bullets
        {

        }
    }
}
