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
        public Vector2 velocity;
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
        //Weapon playerWeapon;
        PlayerID playerID;
        public int ID;
        Rectangle hitBox;
        public int health;
        public bool revive = false;
        public bool dead = false;
        public bool eaten = false;
        public bool gotPackage = false;
       

        public int shotgunLevel;
        public int rifleLevel;
        public int explosivesLevel;
        Animation player1RifleShootingAnimation;
        Animation player1AnimationRifle;
        Animation player1RifleIdle;
        AnimationPlayer animationplayer;
        

        public Player(/*Weapon weapon, */Vector2 position, int ID)
            : base(position)
        {
            //playerWeapon = weapon;
            this.ID = ID;
            hitBox = new Rectangle((int)position.X, (int)position.Y, TextureLibrary.sourceRectTex.Width, TextureLibrary.sourceRectTex.Height);
            SetPlayerID(ID);
        }

        public void LoadContent()
        {
            player1RifleIdle = new Animation(TextureLibrary.player1RifleIdle, 63, 0.1f, true);
            player1AnimationRifle = new Animation(TextureLibrary.player1RifleAnimationSheet, 63, 0.1f, true);
            player1RifleShootingAnimation = new Animation(TextureLibrary.player1RifleSheet, 63, 0.1f, true);
            velocity = Vector2.Zero;
            maxspeed = 2.0f;

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
                animationplayer.Update(gameTime);
                UpdateGamepad();
                if (gamePadState.IsConnected)
                {
                    UpdatePosition(gameTime);
                    UpdateRotation();
                    FireWeapon();
                }
                else
                {
                    KeyBoardMovement();
                    //Collide();                  
                }
               // Collide();
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
            
            if(!dead)
            {
                if (playerID == PlayerID.One)
                    animationplayer.Draw(spriteBatch, pos);
                //spriteBatch.Draw(TextureLibrary.player1RifleTex, pos, null, Color.White, angle, new Vector2(TextureLibrary.player1RifleTex.Width / 2, TextureLibrary.player1RifleTex.Height / 2), 1f, SpriteEffects.None, 0f);
                   // spriteBatch.Draw(TextureLibrary.player1RocketTex, pos, null, Color.White, angle, new Vector2(TextureLibrary.player1RifleTex.Width / 2, TextureLibrary.player1RifleTex.Height / 2), 1f, SpriteEffects.None, 0f);
                if (playerID == PlayerID.Two)
                    animationplayer.Draw(spriteBatch, pos);
                //    spriteBatch.Draw(TextureLibrary.player2RifleTex, pos, null, Color.White, angle, new Vector2(TextureLibrary.player2RifleTex.Width / 2, TextureLibrary.player2RifleTex.Height / 2), 1f, SpriteEffects.None, 0f);
                //////spriteBatch.Draw(TextureLibrary.sourceRectTex, new Vector2(hitBox.X, hitBox.Y), Color.Red);
            }
        }
        public void DrawDead(SpriteBatch spriteBatch)
        {
            if (dead)
            {
                if (playerID == PlayerID.One)
                    spriteBatch.Draw(TextureLibrary.player1DeadTex, pos, null, Color.White, angle, new Vector2(TextureLibrary.player1IncapacitatedTex.Width / 2, TextureLibrary.player1IncapacitatedTex.Height / 2), 1f, SpriteEffects.None, 0f);
                if (playerID == PlayerID.Two)
                    spriteBatch.Draw(TextureLibrary.player2DeadTex, pos, null, Color.White, angle, new Vector2(TextureLibrary.player2IncapacitatedTex.Width / 2, TextureLibrary.player2IncapacitatedTex.Height / 2), 1f, SpriteEffects.None, 0f);
            }
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

        public void UpdateAnimation(Weapon weapon)
        {


            if (weapon is Rifle)
            {


                if (!FireWeapon())
                {
                    animationplayer.PlayAnimation(player1RifleIdle);
                }
                else if (FireWeapon())
                    animationplayer.PlayAnimation(player1RifleShootingAnimation);
            }



            /*if (isShooting == true && weaponManager.rifleIsSelected == true)
            {
                animationplayer.PlayAnimation(player1RifleShootingAnimation);
            }*/
            else
            {
                animationplayer.PlayAnimation(player1RifleIdle);
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

        private void UpdatePosition(GameTime gameTime) //Update Velocity and Position based on controller input
        {

            velocity.X = gamePadState.ThumbSticks.Left.X/*  *maxspeed;*/;
            velocity.Y = -gamePadState.ThumbSticks.Left.Y/* * maxspeed;*/;

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
            else
                direction = new Vector2(0, 0);

            if (Grid.grid[(int)((pos.X) / 50) + (int)direction.X, (int)((pos.Y) / 50) + (int)direction.Y].passable)   //Förhindrar flytt om vägg framför
	        {
                velocity = Vector2.Normalize(velocity);                                             //För att diagonalen ska bli 1 istället för 1.4
                this.pos += velocity * maxspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;     //Flyttar gubben relativt till delta time
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
                //isShooting = true;
                return true;
            }
            else
            {
                //isShooting = false;
                return false;
            }
        }

        private void KeyBoardMovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Grid.grid[(int)((pos.X) / 50), (int)((pos.Y) / 50) - 1].passable == true)
            {
                pos.Y -= playerSpeed;
                direction.Y = -1;
                angle = MathHelper.ToRadians(270);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && Grid.grid[(int)((pos.X) / 50) - 1, (int)(pos.Y) / 50].passable == true)
            {
                pos.X -= playerSpeed;
                direction.X = -1;
                angle = MathHelper.ToRadians(180);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Grid.grid[(int)((pos.X) / 50), (int)((pos.Y) / 50) + 1].passable == true)
            {
                pos.Y += playerSpeed;
                direction.Y = 1;
                angle = MathHelper.ToRadians(90);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Grid.grid[(int)((pos.X) / 50) + 1, (int)(pos.Y) / 50].passable == true)
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
