using Microsoft.Xna.Framework;
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
    }
}
