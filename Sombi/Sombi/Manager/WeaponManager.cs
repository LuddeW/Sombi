using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        KeyboardState currentKeyboard;
        KeyboardState oldKeyboard;

        public WeaponManager()
        {
            this.bulletManager = new BulletManager();
            playerOneWeapon = new Shotgun();
            playerTwoWeapon = new Shotgun();
            timeSinceLastPlayerOneBullet = 100f;
            timeSinceLastPlayerTwoBullet = 100f;
        }


        public void Update(GameTime gameTime)
        {
            bulletManager.Update(gameTime);
            timeSinceLastPlayerOneBullet += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastPlayerTwoBullet += (float)gameTime.ElapsedGameTime.TotalSeconds;
            SwitchWeapon(1);
            SwitchWeapon(2);
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
                    
                    if (playerOneWeapon is Rifle)
                    {
                        bulletManager.AddBullets(b);
                    }
                    else if (playerOneWeapon is Explosives)
                    {
                        bulletManager.AddBullets(r);
                    }
                    else if (playerOneWeapon is Shotgun)
                    {
                        int angleIndex = 40 / playerOneWeapon.numberOfProjectilesPerFire; //Ändra 30 till spridning för vapen


                        bulletManager.AddBullets(b);
                        for (int i  = 0; i < playerOneWeapon.numberOfProjectilesPerFire - 1; i++)
                        {
                            if (i % 2 == 0)
                            {
                                b = new Bullet(position, playerOneWeapon.projectileSpeed, angle - (float)((Math.PI / 180) * angleIndex), playerOneWeapon.damage, playerOneWeapon.weaponRange, PlayerID);
                                
                            }
                            else
                            {
                                b = new Bullet(position, playerOneWeapon.projectileSpeed, angle + (float)((Math.PI / 180) * angleIndex), playerOneWeapon.damage, playerOneWeapon.weaponRange, PlayerID);
                                angleIndex += angleIndex;
                            }
                               bulletManager.AddBullets(b);
                               
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
                        else if (playerTwoWeapon is Shotgun)
                        {
                            Bullet b1 = new Bullet(position, playerTwoWeapon.projectileSpeed, angle - 1, playerTwoWeapon.damage, playerTwoWeapon.weaponRange, PlayerID);
                            Bullet b2 = new Bullet(position, playerTwoWeapon.projectileSpeed, angle, playerTwoWeapon.damage, playerTwoWeapon.weaponRange, PlayerID);
                            Bullet b3 = new Bullet(position, playerTwoWeapon.projectileSpeed, angle + 1, playerTwoWeapon.damage, playerTwoWeapon.weaponRange, PlayerID);
                        }
                    }
                    timeSinceLastPlayerTwoBullet = 0f;
                    SoundManager.PlaySound(SoundManager.RifleFire);
                }

            }


        }
        public void SwitchWeapon(int playerID)
        {
            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();
            switch (playerID)
            {
                case 1:
                    if (currentKeyboard.IsKeyDown(Keys.E) && !oldKeyboard.IsKeyDown(Keys.E))
                    {
                        if (playerOneWeapon is Rifle)
                        {
                            playerOneWeapon = new Explosives();
                        }
                        else if (playerOneWeapon is Explosives)
                        {
                            playerOneWeapon = new Shotgun();
                        }
                        else if (playerOneWeapon is Shotgun)
                        {
                            playerOneWeapon = new Rifle();
                        }
                    }
                    else if (currentKeyboard.IsKeyDown(Keys.Q) && !oldKeyboard.IsKeyDown(Keys.Q))
                    {
                        if (playerOneWeapon is Rifle)
                        {
                            playerOneWeapon = new Shotgun();
                        }
                        else if (playerOneWeapon is Shotgun)
                        {
                            playerOneWeapon = new Explosives();
                        }
                        else if (playerOneWeapon is Explosives)
                        {
                            playerOneWeapon = new Rifle();
                        }
                    }
                    
                    break;
                case 2:
                    if (playerTwoWeapon is Rifle)
                    {
                        playerTwoWeapon = new Explosives();
                    }
                    else if (playerTwoWeapon is Explosives)
                    {
                        playerTwoWeapon = new Shotgun();
                    }
                    else if (playerTwoWeapon is Shotgun)
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
