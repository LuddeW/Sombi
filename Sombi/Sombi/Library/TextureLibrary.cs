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
        public static SpriteFont HUDText { get; private set; }
        public static Texture2D[] bloodStain = new Texture2D[10];

        public static void LoadContent(ContentManager Content)
        {
            packageTex = Content.Load<Texture2D>("Package");
            BulletBlue = Content.Load<Texture2D>(@"BulletBlue");
            testMapTex = Content.Load<Texture2D>(@"TestMap2");
            player1Tex = Content.Load<Texture2D>(@"Player1");
            player2Tex = Content.Load<Texture2D>(@"Player2");
            zombieTex = Content.Load<Texture2D>(@"ZombieSheet");
            fastZombieTex = Content.Load<Texture2D>(@"ZombieSheet2");
            HUDText = Content.Load<SpriteFont>(@"HUDText");
           
            bloodStain[0] = Content.Load<Texture2D>(@"BlodStain1");
            bloodStain[1] = Content.Load<Texture2D>(@"BloodStain2");
            bloodStain[2] = Content.Load<Texture2D>(@"BloodStain3");
            bloodStain[3] = Content.Load<Texture2D>(@"BloodStain4");
            bloodStain[4] = Content.Load<Texture2D>(@"BloodStain5");
            bloodStain[5] = Content.Load<Texture2D>(@"BloodStain6");
            bloodStain[6] = Content.Load<Texture2D>(@"BloodStain7");
            bloodStain[7] = Content.Load<Texture2D>(@"BloodStain8");
            bloodStain[8] = Content.Load<Texture2D>(@"BloodStain9");
            bloodStain[9] = Content.Load<Texture2D>(@"BloodStain10");
        }
    }
}
