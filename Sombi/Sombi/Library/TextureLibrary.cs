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

        //Player and Enemy Sprites
        public static Texture2D player1Tex { get; private set; }
        public static Texture2D player2Tex { get; private set; }
        public static Texture2D zombieTex { get; private set; }
        public static Texture2D fastZombieTex { get; private set; }
                
        //Structures and Objects
        public static Texture2D packageTex { get; private set; }
        public static Texture2D cloud1Tex { get; private set; }
        public static Texture2D cloud2Tex { get; private set; }
        public static Texture2D cloud3Tex { get; private set; }
        public static Texture2D cloud4Tex { get; private set; }

        //Map and UI
        public static Texture2D testMapTex;
        public static Texture2D startButton { get; private set; }
        public static Texture2D settingButton { get; private set; }
        public static Texture2D highscoreButton { get; private set; }
        public static Texture2D exitButton { get; private set; }
        
        //Projectiles and Blood
        public static Texture2D BulletBlue { get; private set; }
        public static Texture2D[] bloodStain = new Texture2D[10];
        
        //Spritefonts
        public static SpriteFont HUDText { get; private set; }
        public static Texture2D logoTex { get; private set; }

        //Miscellaneous
        public static Texture2D sourceRectTex { get; private set; }

        public static void LoadContent(ContentManager Content)
        {
            //Player and Enemy Sprites            
            player1Tex = Content.Load<Texture2D>(@"Player1");
            player2Tex = Content.Load<Texture2D>(@"Player2");
            zombieTex = Content.Load<Texture2D>(@"ZombieSheet");
            fastZombieTex = Content.Load<Texture2D>(@"ZombieSheet2");
            
            //Structures and Objects
            packageTex = Content.Load<Texture2D>("Package");
            cloud1Tex = Content.Load<Texture2D>("Cloud1");
            cloud2Tex = Content.Load<Texture2D>("Cloud2");
            cloud3Tex = Content.Load<Texture2D>("Cloud3");
            cloud4Tex = Content.Load<Texture2D>("Cloud4");

            //Projectiles and Blood
            BulletBlue = Content.Load<Texture2D>(@"BulletBlue");
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
            
            //Map and UI
            testMapTex = Content.Load<Texture2D>(@"TestMap2");
            startButton = Content.Load<Texture2D>(@"Play");
            settingButton = Content.Load<Texture2D>(@"Settings");
            highscoreButton = Content.Load<Texture2D>(@"Highscore");
            exitButton = Content.Load<Texture2D>(@"Exit");            
            
            //Spritefonts
            logoTex = Content.Load<Texture2D>(@"Logo");
            HUDText = Content.Load<SpriteFont>(@"HUDText");
            
            //Miscellaneous
            sourceRectTex = Content.Load<Texture2D>(@"Rectangle");
        }
    }
}
