using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Tile
    {
        bool passable;
        Vector2 pos;

        public Tile(Vector2 index)
        {
            this.pos = new Vector2(index.X * 50, index.Y * 50);
        }

        public void SetPassable(bool passable)
        {
            this.passable = passable;
        }
        public bool GetPassable()
        {
            return this.passable;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
    
}
