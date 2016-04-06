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
        public List<Player> players;
        public WeaponManager weaponManager;

        public PlayerManager()
        {
            weaponManager = new WeaponManager();
            players = new List<Player>();
            player1 = new Player(weaponManager.playerOneWeapon, new Vector2(300,100),1);
            player2 = new Player(weaponManager.playerTwoWeapon, new Vector2(500,100),2);
            players.Add(player1);
            players.Add(player2);
           
        }

        public bool GameOver()
        {
            if (player1.dead && player2.dead)
            {
                return true;
                Grid.menu = true;
                Grid.CreateGridFactory();               
            }
            else
            {
                return false;
            }
        }

        public void Update(GameTime gameTime)
        {
            player1.Update(gameTime);
            player2.Update(gameTime);

            if (player1.FireWeapon() && !player1.dead)
            {
                weaponManager.CreateBullets(1,player1.position, player1.angle);
            }

            if (player2.FireWeapon() && !player2.dead)
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
