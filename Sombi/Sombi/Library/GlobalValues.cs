using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sombi
{
    public class GlobalValues
    {
        public const int tileSize = 50;
        public static Vector2 gridSize = new Vector2(114, 90);

        public static Random rnd = new Random();
        public static Rectangle windowBounds = new Rectangle(0, 0, (int)gridSize.X * tileSize, (int)gridSize.Y * tileSize);
        public static Vector2 cameraBounds = new Vector2(1900, 1000);
        public static Vector2 screenBounds = new Vector2(1900,1000);
        
    }
}
