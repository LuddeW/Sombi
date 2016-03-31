using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Package : GameObject
    {
        Vector2 packagePos;
        public Package(Vector2 packagePos)
            : base(packagePos)
        {
            this.packagePos = packagePos;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.packageTex, packagePos, Color.White);
        }
    }
}
