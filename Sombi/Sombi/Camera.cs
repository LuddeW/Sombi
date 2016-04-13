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

        public Camera(int screenWidth, int viewTileSize, int gameAreaTilesWidth)
        {
            ScreenWidth = screenWidth;
            ViewTileSize = viewTileSize;
            GameAreaTilesWidth = gameAreaTilesWidth;
        }

        public Matrix ViewMatrix { get; private set; }
        public int ScreenWidth { get; set; }
        public int ViewTileSize { get; set; }
        public int GameAreaTilesWidth { get; set; }

        public void Update(Vector2 objectPos)
        {
            SinglePlayerCamera(objectPos);

            ViewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

        private void SinglePlayerCamera(Vector2 objectPos)
        {
            position.X = objectPos.X - (ScreenWidth / 2);

            if (position.X < 0)
            {
                position.X = 0;
            }
            else if (position.X > GlobalValues.TILE_SIZE * GlobalValues.GRID_SIZE.X - ScreenWidth)
            {
                position.X = GlobalValues.TILE_SIZE * GlobalValues.GRID_SIZE.X - ScreenWidth;
            }
        }
    }
}

