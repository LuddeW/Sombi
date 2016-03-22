using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    public class Grid
    {

        Tile[,] grid = new Tile[20, 20];
        Texture2D tex;

        public Grid()
        {
            //CreateGrid();
        }

        //public void CreateGrid()
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        for (int k = 0; k < 20; k++)
        //        {
        //            grid[i, k] = new Tile(new Vector2(i, k));
        //        } 
        //    }
        //}

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, new Vector2(0, 0), Color.White);
        }
    }
}
