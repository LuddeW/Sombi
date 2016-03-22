using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    abstract class MovingObject : GameObject
    {
        Vector2 velocity;
        public MovingObject(Vector2 pos, Vector2 velocity) : base(pos)
        {
            this.velocity = velocity;
        }
    }
}
