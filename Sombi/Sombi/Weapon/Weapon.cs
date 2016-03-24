using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    abstract class Weapon
    {
        public float fireRate;
        public int damage;
        public float projectileSpeed;
        public float weaponRange;
        public float areaOfEffect;
        public float projectileSpread;
        public int numberOfProjectiles;
        

        public Weapon()
        {
            
        }

        protected abstract void Update(GameTime gameTime);


        public abstract void FireWeapon(Vector2 position, float angle); //player calls method to fire bullets
          
    }
}
