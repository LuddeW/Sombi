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
        public BulletManager bulletManager;
        public Weapon playerOneWeapon;
        public Weapon playerTwoWeapon;
        private float timeSinceLastShot;
        private float timeBetweenBullets;
        private float timeSinceLastBullet;

        public WeaponManager()
        {
            this.bulletManager = new BulletManager();
            playerOneWeapon = new Rifle();
            playerTwoWeapon = new Rifle();
            timeSinceLastBullet = 100f;
        }


        public void Update(GameTime gameTime)
        {
            bulletManager.Update(gameTime);
            timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastBullet += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            bulletManager.Draw(spriteBatch);
        }

        public void CreateBullets(int PlayerID, Vector2 position, float angle)
        {
            if (PlayerID == 1)
            {
                if (timeSinceLastBullet > playerOneWeapon.fireRate)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        bulletManager.AddBullets(position, angle, playerOneWeapon.damage, playerOneWeapon.projectileSpeed, playerOneWeapon.weaponRange, PlayerID);
                    }
                    timeSinceLastBullet = 0f;
                    SoundManager.PlaySound(SoundManager.RifleFire);
                }
            }
            if (PlayerID == 2)
            {
                if (timeSinceLastBullet > playerTwoWeapon.fireRate)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        bulletManager.AddBullets(position, angle, playerTwoWeapon.damage, playerTwoWeapon.projectileSpeed, playerTwoWeapon.weaponRange, PlayerID);
                    }
                    timeSinceLastBullet = 0f;
                    SoundManager.PlaySound(SoundManager.RifleFire);
                }

            }

        }
    }
}
