﻿using Microsoft.Xna.Framework;
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


        public WeaponManager()
        {
            this.bulletManager = new BulletManager();
            playerOneWeapon = new Rifle();
            playerTwoWeapon = new Rifle();
        }



        public void Update(GameTime gameTime)
        {
            bulletManager.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            bulletManager.Draw(spriteBatch);
        }

        public void CreateBullets(int PlayerID, Vector2 position, float angle)
        {
            if (PlayerID == 1)
            {
                bulletManager.AddBullets(position, angle, playerOneWeapon.damage,playerOneWeapon.projectileSpeed, playerOneWeapon.weaponRange, PlayerID);
            }
            if (PlayerID == 2)
            {
                bulletManager.AddBullets(position, angle, playerTwoWeapon.damage,playerTwoWeapon.projectileSpeed, playerTwoWeapon.weaponRange, PlayerID);
            }
            SoundManager.PlaySound(SoundManager.RifleFire);
        }
    }
}
