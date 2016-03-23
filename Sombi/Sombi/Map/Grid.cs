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
        
        


        public static void CreateTileMatrix(char objectChar)
        {
            int boardSize = 20;
            grid = new Tile[boardSize, boardSize];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int k = 0; k < grid.GetLength(1); k++)
                {
                    switch (objectChar)
                    {
                        case '0':
                            grid[i, k] = new Tile(new Vector2(i, k), true);
                            break;
                        case '1':
                            grid[i, k] = new Tile(new Vector2(i, k), false);
                            break;
                    }
                }
            }
        }

        public static void CreateGridFactory()
        {
           StreamReader sr = new StreamReader(@"Testmap.txt");
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
                            grid[i, k] = new Tile(new Vector2(i, k), true);
                            break;
                        case '1':
                            grid[i, k] = new Tile(new Vector2(i, k), false);
                            break;
                    }
                }
            }

        }

        public void Draw(SpriteBatch sb)
        {
           
        }
    }
}
