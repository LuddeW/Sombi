using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sombi
{
    public class Grid
    {

        public static Tile[,] grid;
        
        public static void CreateGridFactory()
        {
           StreamReader sr = new StreamReader(@"Content\Testmap.txt");
           List<string> stringList = new List<string>();
            
            while (!sr.EndOfStream)
            {
                stringList.Add(sr.ReadLine());
            }
            grid = new Tile[20, 20];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int k = 0; k < grid.GetLength(1); k++)
                {
                    switch (stringList[i][k])
                    {
                        case '0':
                            grid[k, i] = new Tile(new Vector2(k, i), true);
                            break;
                        case '1':
                            grid[k, i] = new Tile(new Vector2(k, i), false);
                            break;
                    }
                }
            }

        }
        public static void SetCurrentTilePassable(bool b, Vector2 index)
        {
            grid[(int)index.X, (int)index.Y].passable = b;
        }
        public static void SetCurrentTileHasZombie(bool b, Vector2 index)
        {
            grid[(int)index.X, (int)index.Y].hasZombie = b;
        }

        public void Draw(SpriteBatch sb)
        {
           
        }
    }
}
