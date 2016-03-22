using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class WeaponManager
    {
        BulletManager bulletManager;
        Weapon playerOneWeapon;
        Weapon playerTwoWeapon;


        public WeaponManager()
        {
            this.bulletManager = new BulletManager();
            playerOneWeapon = new Rifle();
            playerTwoWeapon = new Rifle();
        }



        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
