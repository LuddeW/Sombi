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
        public static Texture2D fatZombieTex { get; private set; }

                
        //Structures and Objects
        public static Texture2D packageTex { get; private set; }
        public static Texture2D medicTentTex { get; private set; }
        public static Texture2D tankTex { get; private set; }
        public static Texture2D carTex { get; private set; }
        public static Texture2D busTex { get; private set; }
        public static Texture2D tent { get; private set; }
        //Floating Objects
        public static Texture2D cloud1Tex { get; private set; }
        public static Texture2D cloud2Tex { get; private set; }
        public static Texture2D cloud3Tex { get; private set; }
        public static Texture2D cloud4Tex { get; private set; }

        //Map and UI
        public static Texture2D testMapTex;
        //public static Texture2D HUD { get; private set; }
        public static Texture2D player1ScoreHud { get; private set; }
        public static Texture2D player2ScoreHud { get; private set; }
        public static Texture2D weaponHud { get; private set; }
        
        //Menu
        public static Texture2D startButton { get; private set; }
        public static Texture2D settingButton { get; private set; }
        public static Texture2D highscoreButton { get; private set; }
        public static Texture2D exitButton { get; private set; }
        public static Texture2D logoTex { get; private set; }
        
        //Projectiles and Blood
        public static Texture2D bulletBlue { get; private set; }
        public static Texture2D[] bloodStain = new Texture2D[10];
        public static Texture2D rocketExplosion { get; private set; }
        
        //Spritefonts
        public static SpriteFont HudText { get; private set; }

        //Miscellaneous
        public static Texture2D sourceRectTex { get; private set; }
        public static Texture2D fadeScreenTex { get; private set; }

        public static void LoadContent(ContentManager Content)
        {
            //Player and Enemy Sprites            
            player1Tex = Content.Load<Texture2D>(@"Player1v2");
            player2Tex = Content.Load<Texture2D>(@"Player2v2");
            zombieTex = Content.Load<Texture2D>(@"ZombieSheet");
            fastZombieTex = Content.Load<Texture2D>(@"ZombieSheet2");
            fatZombieTex = Content.Load<Texture2D>(@"FatZombie");
            
            //Structures and Objects
            packageTex = Content.Load<Texture2D>("Package");
            medicTentTex = Content.Load<Texture2D>("MedicTent");
            tankTex = Content.Load<Texture2D>("tank1");
            carTex = Content.Load<Texture2D>("Car1");
            busTex = Content.Load<Texture2D>("Bus1");
            tent = Content.Load<Texture2D>("base");

            //Floating Objects
            cloud1Tex = Content.Load<Texture2D>("Cloud1");
            cloud2Tex = Content.Load<Texture2D>("Cloud2");
            cloud3Tex = Content.Load<Texture2D>("Cloud3");
            cloud4Tex = Content.Load<Texture2D>("Cloud4");

            //Projectiles and Blood
            bulletBlue = Content.Load<Texture2D>(@"BulletBlue");
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
            rocketExplosion = Content.Load<Texture2D>(@"ExplosionSombi");
            
            //Map and UI
            testMapTex = Content.Load<Texture2D>(@"TestMap2");
            //HUD = Content.Load<Texture2D>(@"TestHud");
            player1ScoreHud = Content.Load<Texture2D>("Player1ScoreHUD");
            player2ScoreHud = Content.Load<Texture2D>("Player2ScoreHUD");
            weaponHud = Content.Load<Texture2D>("WeaponHUD");
            
            //Menu
            logoTex = Content.Load<Texture2D>(@"Logo1Sombi");
            startButton = Content.Load<Texture2D>(@"Play");
            settingButton = Content.Load<Texture2D>(@"Settings");
            highscoreButton = Content.Load<Texture2D>(@"Highscore");
            exitButton = Content.Load<Texture2D>(@"Exit");            
                        
            //Spritefonts
            HudText = Content.Load<SpriteFont>(@"HUDText");
            
            //Miscellaneous
            sourceRectTex = Content.Load<Texture2D>(@"Rectangle");
            fadeScreenTex = Content.Load<Texture2D>("FadeScreen");
        }
    }
}
