using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Sombi
{
    class Player
    {
        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        float angle;
        float maxspeed;
        GamePadState gamePadState;
        GamePadState circularGamePadState;


        public Player(Texture2D texture)
        {
            this.texture = texture;
            position = Vector2.Zero;
            velocity = Vector2.Zero;
            maxspeed = 3.0f;
        }


        public void Update()
        {
            gamePadState = GamePad.GetState(PlayerIndex.One);
            circularGamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);

            if (gamePadState.IsConnected)
            {
                UpdatePosition();
                UpdateRotation();
                FireWeapon();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
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
                angle = (float)Math.Atan2(circularGamePadState.ThumbSticks.Right.X, circularGamePadState.ThumbSticks.Right.Y) - (float)Math.PI / 2;
            }
        }

        private void FireWeapon() //Fire weapon when button is pressed
        {

        }


    }
}
