﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            projectileSpeed = 15.0f;
            weaponRange = 150;
            damage = 20;
            fireRate = 2;
            numberOfProjectilesPerFire = 6;
            //projectileSpread = 1;
        }
        public Rifle(int level) : base()
        {
            SetVariables(level);
        }
        public void SetVariables(int level)
        {
            switch (level)
            {
                case 1:
                    projectileSpeed = 5.0f;
                    weaponRange = 150;
                    damage = 20;
                    fireRate = 0.5f;
                    numberOfProjectilesPerFire = 1;
                    projectileSpread = 40;
                    break;
                case 2:
                    projectileSpeed = 5.0f;
                    weaponRange = 200;
                    damage = 25;
                    fireRate = 0.5f;
                    numberOfProjectilesPerFire = 1;
                    projectileSpread = 40;
                    break;
                case 3:
                    projectileSpeed = 5.0f;
                    weaponRange = 200;
                    damage = 30;
                    fireRate = 0.25f;
                    numberOfProjectilesPerFire = 1;
                    projectileSpread = 40;
                    break;
                case 4:
                    projectileSpeed = 5.0f;
                    weaponRange = 200;
                    damage = 35;
                    fireRate = 0.25f;
                    numberOfProjectilesPerFire = 1;
                    projectileSpread = 40;
                    break;
                case 5:
                    projectileSpeed = 5.0f;
                    weaponRange = 250;
                    damage = 40;
                    fireRate = 0.25f;
                    numberOfProjectilesPerFire = 1;
                    projectileSpread = 40;
                    break;
                case 6:
                    projectileSpeed = 5.0f;
                    weaponRange = 250;
                    damage = 45;
                    fireRate = 0.10f;
                    numberOfProjectilesPerFire = 1;
                    projectileSpread = 40;
                    break;
                default:
                    break;
            }
        }
        protected override void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
        public override void FireWeapon(Vector2 position, float angle)
        {
            throw new NotImplementedException();
        }
    }
}
