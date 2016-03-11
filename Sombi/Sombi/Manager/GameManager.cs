using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class GameManager
    {
        //Texture2D testMap;
        Vector2 testMapPos = Vector2.Zero;
        TextureLibrary textureLibrary = new TextureLibrary();

        public void LoadContent(ContentManager Content)
        {
            //testMap = textureLibrary.testMapTex;
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureLibrary.testMapTex, testMapPos, Color.White); 
        }
    }
}
