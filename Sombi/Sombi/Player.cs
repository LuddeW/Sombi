using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Sombi
{
    enum PlayerID
    {
        One,
        Two,
    }

    class Player
    {
        Vector2 position;
        Vector2 velocity;
        float angle;
        float maxspeed;
        GamePadState gamePadState;
        GamePadState circularGamePadState;
        WeaponManager weaponManager;
        Weapon playerWeapon;
        PlayerID playerID = PlayerID.One;


        public Player(Weapon weapon)
        {
            position = new Vector2(190,190);
            velocity = Vector2.Zero;
            maxspeed = 3.0f;
            playerWeapon = weapon;
            
        }

        public void Update(GameTime gameTime)
        {
            gamePadState = GamePad.GetState(PlayerIndex.One);
            circularGamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);

            if (gamePadState.IsConnected)
            {
                UpdatePosition();
                UpdateRotation();
                FireWeapon();
            }
            else
            {
                KeyBoardMovement();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.player1Tex, position, null, Color.White, angle, new Vector2(TextureLibrary.player1Tex.Width / 2, TextureLibrary.player1Tex.Height / 2), 1f, SpriteEffects.None, 0f);

        }

        private void UpdatePosition() //Update Velocity and Position based on controller input
        {
            velocity.X = gamePadState.ThumbSticks.Left.X * maxspeed;
            velocity.Y = -gamePadState.ThumbSticks.Left.Y * maxspeed;
            position += velocity;
        }

        private void UpdateRotation() //Rotate sprite based on controller input
        {
            if (circularGamePadState.ThumbSticks.Right.X != 0 && circularGamePadState.ThumbSticks.Right.Y != 0)
            {
                angle = (float)Math.Atan2(circularGamePadState.ThumbSticks.Right.X, circularGamePadState.ThumbSticks.Right.Y);
            }
        }

        private void FireWeapon() //Fire weapon when button is pressed
        {
            if (gamePadState.Triggers.Right > 0.5f)
            {
                playerWeapon.FireWeapon(position,angle);
            }
        }

        private void KeyBoardMovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 1f;
            }
        }

    }
}
