using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    public class Camera
    {
        Vector2 position;
        Matrix viewMatrix;

        public Camera(int viewTileSize)
        {
            //ScreenWidth = screenWidth;
            ViewTileSize = viewTileSize;
            //GameAreaTilesWidth = gameAreaTilesWidth;
        }

        public Matrix ViewMatrix { get; private set; }
        //public int ScreenWidth { get; set; }
        public int ViewTileSize { get; set; }
        //public int GameAreaTilesWidth { get; set; }

        public void Update(Vector2 objectPos)
        {
            SinglePlayerCamera(objectPos);

            ViewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

        private void SinglePlayerCamera(Vector2 objectPos)
        {
            position.X = objectPos.X - (GlobalValues.windowBounds.Width / 2);
            position.Y = objectPos.Y - (GlobalValues.windowBounds.Height / 2);

            if (position.X < 0)
            {
                position.X = 0;
            }
            else if (position.X > GlobalValues.TILE_SIZE * GlobalValues.GRID_SIZE.X - GlobalValues.windowBounds.Width)
            {
                position.X = GlobalValues.TILE_SIZE * GlobalValues.GRID_SIZE.X - GlobalValues.windowBounds.Width;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
            }
            else if (position.Y > GlobalValues.TILE_SIZE * GlobalValues.GRID_SIZE.Y - GlobalValues.windowBounds.Height)
            {
                position.X = GlobalValues.TILE_SIZE * GlobalValues.GRID_SIZE.Y - GlobalValues.windowBounds.Height;
            }
        }
    }
}

