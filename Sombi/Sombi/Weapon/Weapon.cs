using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    abstract class Weapon
    {
        protected float rateOfFire; //time between shots fired
        protected float damage;
        

        public Weapon()
        {
            
        }

        protected virtual void Update(GameTime gameTime)
        {

        }


        public virtual void FireWeapon(Vector2 position, float angle) //player calls method to fire bullets
        {
        }    
    }
}
