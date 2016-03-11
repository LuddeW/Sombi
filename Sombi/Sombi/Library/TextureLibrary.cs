using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    public class TextureLibrary
    {
        public static Texture2D tileTex { get; private set; }
        public Texture2D testMapTex;
        public static Texture2D player1Tex { get; private set; }
        public static Texture2D player2Tex { get; private set; }

        public void LoadContent(ContentManager Content)
        {
            //tileTex = Content.Load<Texture2D>("tile");
            //testMapTex = Content.Load<Texture2D>("TestMap");
            player1Tex = Content.Load<Texture2D>(@"Player1");
            player2Tex = Content.Load<Texture2D>(@"Player1");
        }
    }
}
