using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sombi
{
    class PlayerManager
    {
        Player player1;
        Player player2;
        WeaponManager weaponManager;

        public PlayerManager()
        {
            weaponManager = new WeaponManager();
            player1 = new Player(weaponManager.playerOneWeapon);
            player2 = new Player(weaponManager.playerTwoWeapon);
           
        }

        public void Update(GameTime gameTime)
        {
            player1.Update(gameTime);
            player2.Update(gameTime);

            if (player1.FireWeapon())
            {
                weaponManager.CreateBullets(1,player1.position, player1.angle);
            }

            if (player2.FireWeapon())
            {
                weaponManager.CreateBullets(2,player2.position, player2.angle);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
        }

    }
}
