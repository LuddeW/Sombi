using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Shotgun : Weapon
    {
        public Shotgun() : base()
        {
            projectileSpeed = 15.0f;
            weaponRange = 75;
            damage = 10;
            fireRate = 1;
            numberOfProjectilesPerFire = 4;
            //projectileSpread = 1;
        }
        protected override void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
        private void SpreadBullets()
        {

        }
        public override void FireWeapon(Vector2 position, float angle)
        {
            throw new NotImplementedException();
        }
    }
}
