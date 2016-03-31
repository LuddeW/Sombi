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
        public static Texture2D packageTex { get; private set; }
        public static Texture2D testMapTex;
        public static Texture2D player1Tex { get; private set; }
        public static Texture2D player2Tex { get; private set; }
        public static Texture2D zombieTex { get; private set; }
        public static Texture2D fastZombieTex { get; private set; }
        public static Texture2D BulletBlue { get; private set; }

        public static void LoadContent(ContentManager Content)
        {
            packageTex = Content.Load<Texture2D>("Package");
            BulletBlue = Content.Load<Texture2D>(@"BulletBlue");
            testMapTex = Content.Load<Texture2D>(@"TestMap2");
            player1Tex = Content.Load<Texture2D>(@"Player1");
            player2Tex = Content.Load<Texture2D>(@"Player2");
            zombieTex = Content.Load<Texture2D>(@"ZombieSheet");
            fastZombieTex = Content.Load<Texture2D>(@"ZombieSheet2");
           
        }
    }
}
