using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    abstract class Weapon
    {
        float rateOfFire; //time between shots fired
        float damage;

        public Weapon()
        {
            
        }

        public void FireWeapon() //player calls method to fire bullets
        {

        }
    }
}
