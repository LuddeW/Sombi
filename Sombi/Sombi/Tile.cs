using Microsoft.Xna.Framework;
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
        2222
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
    }
    
}
