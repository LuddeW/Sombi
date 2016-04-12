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
        public static bool menu = true;

        public static void CreateGridFactory()
        {
            if (!menu)
            {
                StreamReader sr = new StreamReader(@"Content\Testmap.txt");
                List<string> stringList = new List<string>();

                while (!sr.EndOfStream)
                {
                    stringList.Add(sr.ReadLine());
                }
                grid = new Tile[(int)GlobalValues.GRID_SIZE.X, (int)GlobalValues.GRID_SIZE.Y];
                for (int i = 0; i < GlobalValues.GRID_SIZE.Y; i++)
                {
                    for (int k = 0; k < GlobalValues.GRID_SIZE.X; k++)
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
            else
            {
                StreamReader sr = new StreamReader(@"Content\Menumap.txt");
                List<string> stringList = new List<string>();

                while (!sr.EndOfStream)
                {
                    stringList.Add(sr.ReadLine());
                }
                grid = new Tile[(int)GlobalValues.GRID_SIZE.X, (int)GlobalValues.GRID_SIZE.Y];
                for (int i = 0; i < GlobalValues.GRID_SIZE.Y; i++)
                {
                    for (int k = 0; k < GlobalValues.GRID_SIZE.X; k++)
                    {
                        switch (stringList[i][k])
                        {
                            case '0':
                                grid[k, i] = new Tile(new Vector2(k, k), true);
                                break;
                            case '1':
                                grid[k, i] = new Tile(new Vector2(k, i), false);
                                break;
                        }
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
    }
}
