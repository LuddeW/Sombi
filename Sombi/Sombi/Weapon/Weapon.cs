using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    abstract class Weapon
    {
        protected float fireRate; //time between shots fired
        public int damage;
        public float speed;
        public float range;

        

        public Weapon()
        {
            
        }

        protected abstract void Update(GameTime gameTime);


        public abstract void FireWeapon(Vector2 position, float angle); //player calls method to fire bullets
          
    }
}
