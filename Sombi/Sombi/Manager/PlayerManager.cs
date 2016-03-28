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
        public WeaponManager weaponManager;

        public PlayerManager()
        {
            weaponManager = new WeaponManager();
            player1 = new Player(weaponManager.playerOneWeapon, new Vector2(150,150),1);
            player2 = new Player(weaponManager.playerTwoWeapon, new Vector2(500,150),2);
           
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
            weaponManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            weaponManager.Draw(spriteBatch);
        }

    }
}
