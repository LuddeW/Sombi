using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sombi
{
    public class GlobalValues
    {
        public const int TILE_SIZE = 50;

        public static Random rnd = new Random();
        public static Rectangle windowBounds = new Rectangle(0, 0, 1000, 1000);
    }
}
