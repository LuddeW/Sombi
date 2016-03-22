using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sombi
{
    class GameManager
    {
        const int TILE_SIZE = 50;
        PlayerManager playerManager;
        ContentManager contentManager;
        EnemyManager enemyManager;
        Vector2 testMapPos;
        // TextureLibrary textureLibrary;
        Tile[,] tiles;


        public GameManager(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            playerManager = new PlayerManager();
            enemyManager = new EnemyManager();
            TextureLibrary.LoadContent(contentManager);
            testMapPos = Vector2.Zero;
            CreateGridFactory();
            enemyManager.AddZombie(new Vector2(50, 50));  //Endast för TEST!!
        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
            enemyManager.Update(gameTime);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLibrary.testMapTex, testMapPos, Color.White);
            playerManager.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);
        }

        private void CreateTileMatrix(char objectChar)
        {
            int boardSize = 20;
            tiles = new Tile[boardSize, boardSize];
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int k = 0; k < tiles.GetLength(1); k++)
                {
                    switch (objectChar)
                    {
                        case '0':
                            tiles[i, k] = new Tile(new Vector2(i, k), true);
                            break;
                        case '1':
                            tiles[i, k] = new Tile(new Vector2(i, k), false);
                            break;
                    }                  
                }
            }
        }

        private void CreateGridFactory()
        {
            StreamReader sr = new StreamReader(@"Testmap.txt");
            int row = 0;
            while (!sr.EndOfStream)
            {
                string objectStr = sr.ReadLine();
                for (int col = 0; col < objectStr.Length; col++)
                {
                    CreateTileMatrix(objectStr[col]);
                }
                row++;
            }
        }
    }
}
