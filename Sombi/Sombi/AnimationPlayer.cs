using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    struct AnimationPlayer
    {
        Animation animation;

        int frameIndex;
        public int FrameIndex
        {
            get { return frameIndex; }
            set { frameIndex = value; }
        }

        private float timer;

        public Vector2 Origin
        {
            get { return new Vector2(animation.frameWidth / 2, animation.frameHeight / 2); }
        }

        private float rotation;
        public void PlayAnimation(Animation newAnimation)
        {
            // Sänder igenom en animation och animerar den.
            if (animation == newAnimation)
                return;

            animation = newAnimation;
            // sätter till noll för att den ska börja om animationen
            frameIndex = 0;
            timer = 0;

        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (timer >= animation.FrameTime)
            {
                timer -= animation.FrameTime;

                if (animation.IsLooping) // Loopar den så sätt frameIndex
                    frameIndex = (frameIndex + 1) % animation.frameCount;
                else frameIndex = Math.Min((frameIndex + 1), (animation.frameCount - 1));
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rotation = MathHelper.ToRadians(0);
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rotation = MathHelper.ToRadians(180);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                rotation = MathHelper.ToRadians(-90);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                rotation = MathHelper.ToRadians(90);
            }


        }

        public void Draw(Texture2D texture, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
        {
            if (animation != null)
            {
                Rectangle rectangle = new Rectangle(frameIndex * animation.frameWidth, 0, animation.frameWidth, animation.frameHeight);

                spriteBatch.Draw(texture, position, rectangle, Color.White, rotation, Origin, 1f, spriteEffects, 0f);
            }
        }
    }
}
