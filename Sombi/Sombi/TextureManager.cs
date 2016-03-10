using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class TextureManager
    {
        public static Texture2D tileTex { get; private set; }
        public static Texture2D player1Tex { get; private set; }
        public static Texture2D player2Tex { get; private set; }


        public static void LoadContent(ContentManager Content)
        {
            tileTex = Content.Load<Texture2D>("tile");

        }
    }
}
