using Microsoft.Xna.Framework;
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
            speed = 10.0f;
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
