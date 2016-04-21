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
            projectileSpeed = 5.0f;
            weaponRange = 75;
            damage = 10;
            fireRate = 1;
            numberOfProjectilesPerFire = 7;
            projectileSpread = 40; //grader på konen
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
