using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Menu
    {
        const int PLATFORM_WIDTH = 200;
        const int PLATFORM_HEIGHT = 100;
        const int NUMBER_OF_PLATTFORMS = 4;

        int startIndex;
        int settingsIndex;
        int highscoreIndex;
        int exitIndex;
        Rectangle[] PlatformRectangle;

        public Menu()
        {
            startIndex = 0;
            settingsIndex = 1;
            highscoreIndex = 2;
            exitIndex = 3;
            PlatformRectangle = new Rectangle[NUMBER_OF_PLATTFORMS];
            int platformPosX = 400 - PLATFORM_WIDTH / 2;
            int platformPosY = 400 / 2 - NUMBER_OF_PLATTFORMS / 2 * PLATFORM_HEIGHT - (NUMBER_OF_PLATTFORMS % 2) * PLATFORM_HEIGHT / 2;
            for (int i = 0; i < NUMBER_OF_PLATTFORMS; i++)
            {
                PlatformRectangle[i] = new Rectangle(platformPosX, platformPosY, PLATFORM_WIDTH, PLATFORM_HEIGHT);
                platformPosY += PLATFORM_HEIGHT * 2;
            }
        }

    }
}
