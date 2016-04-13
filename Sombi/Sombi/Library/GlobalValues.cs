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
        public static Vector2 GRID_SIZE = new Vector2(76, 30);

        public static Random rnd = new Random();
        public static Rectangle windowBounds = new Rectangle(0, 0, 1900, 1000);
        public static Vector2 screenBounds = new Vector2(1900,1000);
        
    }
}
