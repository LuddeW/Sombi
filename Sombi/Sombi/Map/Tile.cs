using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    public class Tile
    {
        public bool passable;
        public bool hasZombie;
        Vector2 pos;

        public Tile(Vector2 index, bool passable)
        {
            this.pos = new Vector2(index.X * 50, index.Y * 50);
            this.passable = passable;
            this.hasZombie = false;
        }

        public void SetPassable(bool passable)
        {
            this.passable = passable;
        }
        public bool GetPassable()
        {
            return this.passable;
        }

        //public void SetHasSombie (bool b)
        //{
        //    this.hasZombie = b;
        //}
    }
    
}
