using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Design;
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

    class Player : GameObject
    {
        Vector2 velocity;
        Vector2 direction;
        public float angle;
        public float playerSpeed;
        float maxspeed;
        float timeToRevive;
        float reviveTime;
        public int cash;
        GamePadState gamePadState;
        GamePadState oldgamePadState;
        GamePadState circularGamePadState;
        Weapon playerWeapon;
        PlayerID playerID;
        public int ID;
        Rectangle hitBox;
        public int health;
        public bool revive = false;
        public bool dead = false;
        public bool eaten = false;
        public bool gotPackage = false;
        public bool isShooting = false;

        public int shotgunLevel;
        public int rifleLevel;
        public int explosivesLevel;
        public Animation rifleShootingAnimation;
        public Animation shotgunShootingAnimation;
        AnimationPlayer animationplayer;
        WeaponManager weaponManager;

        public Player(Weapon weapon, Vector2 position, int ID)
            : base(position)
        {
            playerWeapon = weapon;
            this.ID = ID;
            hitBox = new Rectangle((int)position.X, (int)position.Y, TextureLibrary.sourceRectTex.Width, TextureLibrary.sourceRectTex.Height);
            SetPlayerID(ID);
            weaponManager = new WeaponManager();
        }

        public void LoadContent()
        {
            rifleShootingAnimation = new Animation(TextureLibrary.player1RifleSheet, 63, 0.1f, true);
            velocity = Vector2.Zero;
            maxspeed = 2.0f;
            playerSpeed = 1.8f;
            //playerWeapon = weapon;
            playerSpeed = 2.0f;
            health = 1000;
            timeToRevive = 3.0f;
            reviveTime = 0.0f;
            cash = 0;
            explosivesLevel = 1;
            rifleLevel = 1;
            shotgunLevel = 1;
        }

        public Rectangle HitBox
        {
            get { return hitBox; }
            set { }
        }

        public GamePadState GamePadState
        {
            get { return gamePadState; }
            set { }
        }

        public GamePadState OldGamePadState
        {
            get { return oldgamePadState; }
            set { }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateAnimation();

            if (health <= 0)
            {
                dead = true;
            }
            if (health <= -2000)
            {
                eaten = true;
                health = -2000;
            }

            if (!dead)
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
                UpdateHitbox();
            }
            Revive(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (reviveTime > 0 && reviveTime < 3)
            {
                spriteBatch.DrawString(TextureLibrary.pauseText, (3 - (int)reviveTime).ToString(), pos - new Vector2(6, 45), Color.Green);
            }
            if (!dead)
            {
                if (playerID == PlayerID.One)
                    spriteBatch.Draw(TextureLibrary.player1RocketTex, pos, null, Color.White, angle, new Vector2(TextureLibrary.player1RifleTex.Width / 2, TextureLibrary.player1RifleTex.Height / 2), 1f, SpriteEffects.None, 0f);
                if (playerID == PlayerID.Two)
                    spriteBatch.Draw(TextureLibrary.player2RifleTex, pos, null, Color.White, angle, new Vector2(TextureLibrary.player2RifleTex.Width / 2, TextureLibrary.player2RifleTex.Height / 2), 1f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(TextureLibrary.sourceRectTex, new Vector2(hitBox.X, hitBox.Y), Color.Red);
                //animationplayer.Draw(spriteBatch, pos);
            }
            //if (isShooting == true && weaponManager.rifleIsShooting == true)
            //{
            //    animationplayer.Draw(spriteBatch, pos);
            //}
        }

        private void SetPlayerID(int ID)
        {
            if (ID == 1)
            {
                playerID = PlayerID.One;
            }
            else
            {
                playerID = PlayerID.Two;
            }
        }

        private void UpdateAnimation()
        {
            if (isShooting == true && weaponManager.rifleIsShooting == true)
            {
                animationplayer.PlayAnimation(rifleShootingAnimation);
            }
        }

        private void UpdateHitbox()
        {
            hitBox.X = (int)pos.X - ((TextureLibrary.player1RifleTex.Width) / 2) + 10;
            hitBox.Y = (int)pos.Y - ((TextureLibrary.player1RifleTex.Height) / 2);
        }

        private void UpdateGamepad()
        {
            if (playerID == PlayerID.One)
            {
                oldgamePadState = gamePadState;
                gamePadState = GamePad.GetState(PlayerIndex.One);
                circularGamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
            }
            else
            {
                oldgamePadState = gamePadState;
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
                isShooting = true;
                return true;
            }
            else
            {
                isShooting = false;
                return false;
            }
        }

        private void KeyBoardMovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                pos.Y -= playerSpeed;
                direction.Y = -1;
                angle = MathHelper.ToRadians(270);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                pos.X -= playerSpeed;
                direction.X = -1;
                angle = MathHelper.ToRadians(180);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                pos.Y += playerSpeed;
                direction.Y = 1;
                angle = MathHelper.ToRadians(90);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pos.X += playerSpeed;
                direction.X = 1;
                angle = MathHelper.ToRadians(0);

            }
        }

        private void Collide()
        {
            if (direction.X > 0)
            {
                if (Grid.grid[(int)((pos.X) / 50) + (int)direction.X, (int)(pos.Y) / 50].passable != true)
                {
                    pos.X += direction.X * -1;
                }
                else
                {
                    pos += velocity;
                }
            }
            else if (direction.X < 0)
            {
                if (Grid.grid[(int)((pos.X + (TextureLibrary.player1RifleTex.Width / 3)) / 50) + (int)direction.X, (int)(pos.Y) / 50].passable != true)
                {
                    pos.X += direction.X * -1;

                }
                else
                {
                    pos += velocity;
                }
            }

            if (direction.Y > 0)
            {
                if (Grid.grid[(int)(pos.X / 50), ((int)(pos.Y) / 50) + (int)direction.Y].passable != true)
                {
                    pos.Y += direction.Y * -1;
                }
                else
                {
                    pos += velocity;
                }
            }
            else if (direction.Y < 0)
            {
                if (Grid.grid[(int)((pos.X) / 50), ((int)(pos.Y + TextureLibrary.player1RifleTex.Height) / 50) + (int)direction.Y].passable != true)
                {
                    pos.Y += direction.Y * -1;
                }
                else
                {
                    pos += velocity;
                }
            }

        }

        public void handleBulletHit(int damage)
        {
            if (!eaten)
            {
                health -= damage;
            }
        }

        private void Revive(GameTime gameTime)
        {
            if (gamePadState.IsButtonDown(Buttons.A) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                reviveTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                reviveTime = 0;
                revive = false;
            }

            if (reviveTime > timeToRevive)
            {
                revive = true;
            }
        }

    }
}
