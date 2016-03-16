using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Rifle : Weapon
    {
        public Rifle() : base()
        {
            
        }



        public override void FireWeapon(Microsoft.Xna.Framework.Vector2 position, float angle)
        {
            Bullet b = new Bullet();     
        }
    }
}
