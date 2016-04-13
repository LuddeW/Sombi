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
        private float timeSinceLastPlayerOneBullet;
        private float timeSinceLastPlayerTwoBullet;

        public WeaponManager()
        {
            this.bulletManager = new BulletManager();
            playerOneWeapon = new Explosives();
            playerTwoWeapon = new Explosives();
            timeSinceLastPlayerOneBullet = 100f;
            timeSinceLastPlayerTwoBullet = 100f;
        }


        public void Update(GameTime gameTime)
        {
            bulletManager.Update(gameTime);
            timeSinceLastPlayerOneBullet += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastPlayerTwoBullet += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            bulletManager.Draw(spriteBatch);
        }

        public void CreateBullets(int PlayerID, Vector2 position, float angle)
        {
            if (PlayerID == 1)
            {
                if (timeSinceLastPlayerOneBullet > playerOneWeapon.fireRate)
                {
                    Bullet b = new Bullet(position, playerOneWeapon.projectileSpeed, angle, playerOneWeapon.damage, playerOneWeapon.weaponRange, PlayerID);
                    Rocket r = new Rocket(position, playerOneWeapon.projectileSpeed, angle, playerOneWeapon.damage, playerOneWeapon.weaponRange, PlayerID);
                    for (int i = 0; i < playerOneWeapon.numberOfProjectilesPerFire; i++)
                    {
                        if (playerOneWeapon is Rifle)
                        {
                            bulletManager.AddBullets(b);
                        }
                        else if (playerOneWeapon is Explosives)
                        {
                            bulletManager.AddBullets(r);
                        }
                    }
                    timeSinceLastPlayerOneBullet = 0f;
                    SoundManager.PlaySound(SoundManager.RifleFire);
                }
            }
            if (PlayerID == 2)
            {
                if (timeSinceLastPlayerTwoBullet > playerTwoWeapon.fireRate)
                {
                    Bullet b = new Bullet(position, playerTwoWeapon.projectileSpeed, angle, playerTwoWeapon.damage, playerTwoWeapon.weaponRange, PlayerID);
                    Rocket r = new Rocket(position, playerTwoWeapon.projectileSpeed, angle, playerTwoWeapon.damage, playerTwoWeapon.weaponRange, PlayerID);
                    for (int i = 0; i < playerTwoWeapon.numberOfProjectilesPerFire; i++)
                    {
                        if (playerTwoWeapon is Rifle)
                        {
                            bulletManager.AddBullets(b);
                        }
                        else if (playerTwoWeapon is Explosives)
                        {
                            bulletManager.AddBullets(r);
                        }
                    }
                    timeSinceLastPlayerTwoBullet = 0f;
                    SoundManager.PlaySound(SoundManager.RifleFire);
                }

            }


        }
        public void SwitchWeapon(int playerID)
        {
            switch (playerID)
            {
                case 1:
                    if (playerOneWeapon is Rifle)
                    {
                        playerOneWeapon = new Explosives();
                    }
                    else if (playerOneWeapon is Explosives)
                    {
                        playerOneWeapon = new Rifle();
                    }
                    break;
                case 2:
                    if (playerTwoWeapon is Rifle)
                    {
                        playerTwoWeapon = new Explosives();
                    }
                    else if (playerTwoWeapon is Explosives)
                    {
                        playerTwoWeapon = new Rifle();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
