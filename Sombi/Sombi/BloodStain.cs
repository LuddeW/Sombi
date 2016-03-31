using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class BloodStain
    {
        int time;
        int bloodNr;
        Vector2 pos;

        public BloodStain(Vector2 pos)
        {
            this.bloodNr = GlobalValues.rnd.Next(0, 3);
            this.pos = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.bloodPuddle[bloodNr], pos, Color.White);
        }
    }
}
