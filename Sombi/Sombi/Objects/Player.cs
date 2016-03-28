﻿using System;
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
        public Vector2 position;
        Vector2 velocity;
        Vector2 direction;
        public float angle;
        public float playerSpeed;
        float maxspeed;
        GamePadState gamePadState;
        GamePadState circularGamePadState;
        Weapon playerWeapon;
        PlayerID playerID;


        public Player(Weapon weapon, Vector2 position, int ID)
        {
            this.position = position;
            velocity = Vector2.Zero;
            maxspeed = 2.0f;
            playerWeapon = weapon;
            playerSpeed = 1.8f;
            
            if (ID == 1)
            {
                playerID = PlayerID.One;
            }
            else
            {
                playerID = PlayerID.Two;
            }

        }

        public void Update(GameTime gameTime)
        {
            UpdateGamepad();
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
            Collide();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.player1Tex, position, null, Color.White, angle, new Vector2(TextureLibrary.player1Tex.Width / 2, TextureLibrary.player1Tex.Height / 2), 1f, SpriteEffects.None, 0f);

        }

        private void UpdateGamepad()
        {
            if (playerID == PlayerID.One)
            {
                gamePadState = GamePad.GetState(PlayerIndex.One);
                circularGamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
            }
            else
            {
                gamePadState = GamePad.GetState(PlayerIndex.Two);
                circularGamePadState = GamePad.GetState(PlayerIndex.Two, GamePadDeadZone.Circular);
            }
        }

        private void UpdatePosition() //Update Velocity and Position based on controller input
        {

            velocity.X = gamePadState.ThumbSticks.Left.X * maxspeed;
            velocity.Y = -gamePadState.ThumbSticks.Left.Y * maxspeed;

            if (velocity.Y < 0) // CLEAR UP THIS CODE 
            {
                direction.Y = -1;
            }
            if (velocity.Y > 0)
            {
                direction.Y = 1;
            }
            if (velocity.X < 0)
            {
                direction.X = -1;
            }
            if (velocity.X > 1)
            {
                direction.X = 1;
            }
        }

        private void UpdateRotation() //Rotate sprite based on controller input
        {
            if (circularGamePadState.ThumbSticks.Right.X != 0 && circularGamePadState.ThumbSticks.Right.Y != 0)
            {
                angle = (float)Math.Atan2(circularGamePadState.ThumbSticks.Right.X, circularGamePadState.ThumbSticks.Right.Y) - (float)Math.PI / 2;
            }
        }

        public bool FireWeapon() //Fire weapon when button is pressed
        {
            if (gamePadState.Triggers.Right > 0.5f || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void KeyBoardMovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= 1;
                direction.Y = -1;
                angle = MathHelper.ToRadians(270);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {  
                position.X -= 1f;
		        direction.X = -1;             
                angle = MathHelper.ToRadians(180);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += 1f;
                direction.Y = 1;
                angle = MathHelper.ToRadians(90);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 1f;
		        direction.X = 1;             
                angle = MathHelper.ToRadians(0);

            }
        }

        private void Collide()
        {
            if (direction.X > 0)
            {
                if (Grid.grid[(int)((position.X) / 50) + (int)direction.X, (int)(position.Y) / 50].passable != true)
                {
                    position.X += direction.X * -1;
                }
                else
                {
                    position += velocity;
                }
            }
            else if (direction.X < 0)
            {
                if (Grid.grid[(int)((position.X + (TextureLibrary.player1Tex.Width / 3)) / 50) + (int)direction.X, (int)(position.Y) / 50].passable != true)
                {
                    position.X += direction.X * -1;

                }
                else
                {
                    position += velocity;
                }
            }

            if (direction.Y > 0)
            {
                if (Grid.grid[(int)(position.X / 50), ((int)(position.Y) / 50) + (int)direction.Y].passable != true)
                {
                    position.Y += direction.Y * -1;
                }
                else
                {
                    position += velocity;
                }
            }
            else if (direction.Y < 0)
            {
                if (Grid.grid[(int)((position.X) / 50), ((int)(position.Y + TextureLibrary.player1Tex.Height) / 50) + (int)direction.Y].passable != true)
                {
                    position.Y += direction.Y * -1;
                }
                else
                {
                    position += velocity;
                }
            }

        }

    }
}
