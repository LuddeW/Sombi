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

        //Player and Enemy Spritesheets
        public static Texture2D player1RifleTex { get; private set; }
        public static Texture2D player1ShotgunTex { get; private set; }
        public static Texture2D player1RocketTex { get; private set; }
        public static Texture2D player2RifleTex { get; private set; }
        public static Texture2D player2ShotgunTex { get; private set; }
        public static Texture2D player2RocketTex { get; private set; }
        public static Texture2D zombieTex { get; private set; }
        public static Texture2D player1IncapacitatedTex { get; private set; }
        public static Texture2D player2IncapacitatedTex { get; private set; }
        public static Texture2D player1DeadTex { get; private set; }
        public static Texture2D player2DeadTex { get; private set; }

        public static Texture2D fastZombieTex { get; private set; }
        public static Texture2D fatZombieTex { get; private set; }

        public static Texture2D player1RifleSheet { get; private set; }
        public static Texture2D player1RifleAnimationSheet { get; private set; }
        public static Texture2D player1RifleIdle { get; private set; }

        public static Texture2D player2RifleSheet { get; private set; }
        public static Texture2D player2RifleAnimationSheet { get; private set; }
        public static Texture2D player2RifleIdle { get; private set; }

        //Structures and Objects
        public static Texture2D packageTex { get; private set; }
        public static Texture2D medicTentTex { get; private set; }
        public static Texture2D hqTentTex { get; private set; }
        public static Texture2D tankTex { get; private set; }
        public static Texture2D carTex { get; private set; }
        public static Texture2D busTex { get; private set; }
        public static Texture2D tent { get; private set; }
        public static Texture2D Buildings { get; private set; }
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
        public static Texture2D rifleLevel { get; private set; }
        public static Texture2D shotgunLevel { get; private set; }
        public static Texture2D rocketLevel { get; private set; }
        public static Texture2D[] weaponWheel = new Texture2D[3];

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
        public static Texture2D rocket { get; private set; }

        //Spritefonts
        public static SpriteFont HudText { get; private set; }
        public static SpriteFont pauseText { get; private set; }
        public static SpriteFont billBoardText { get; private set; }

        //Miscellaneous
        public static Texture2D sourceRectTex { get; private set; }
        public static Texture2D fadeScreenTex { get; private set; }

        public static void LoadContent(ContentManager Content)
        {
            //Player and Enemy Sprites            
            player1RifleTex = Content.Load<Texture2D>(@"Player1Rifle");
            player1ShotgunTex = Content.Load<Texture2D>(@"Player1Shotgun");
            player1RocketTex = Content.Load<Texture2D>(@"Player1Rocket");

            player1RifleAnimationSheet = Content.Load<Texture2D>(@"AnimationPlayer1RifleSheet");
            player1RifleIdle = Content.Load<Texture2D>(@"Player1RifleIdle");

            player2RifleAnimationSheet = Content.Load<Texture2D>(@"AnimationPlayer2RifleSheet");
            player2RifleIdle = Content.Load<Texture2D>(@"Player2RifleIdle");

            // Player1 shooting animation
            player1RifleSheet = Content.Load<Texture2D>(@"Player1RifleSheet");
            // Player2 shooting animation
            player2RifleSheet = Content.Load<Texture2D>(@"Player2RifleSheet");

            player1RifleSheet = Content.Load<Texture2D>(@"Player1RifleSheet");
            player1ShotgunTex = Content.Load<Texture2D>(@"Player1Shotgun");
            player1RocketTex = Content.Load<Texture2D>(@"Player1Rocket");
            player1IncapacitatedTex = Content.Load<Texture2D>(@"Player1Incapacitated");
            player1DeadTex = Content.Load<Texture2D>(@"Player1Dead");


            player2RifleTex = Content.Load<Texture2D>(@"Player2Rifle");
            player2ShotgunTex = Content.Load<Texture2D>(@"Player2Shotgun");
            player2RocketTex = Content.Load<Texture2D>(@"Player2Rocket");
            player2IncapacitatedTex = Content.Load<Texture2D>(@"Player2Incapacitated");
            player2DeadTex = Content.Load<Texture2D>(@"Player2Dead");

            zombieTex = Content.Load<Texture2D>(@"ZombieSheet");
            fastZombieTex = Content.Load<Texture2D>(@"ZombieSheet2");
            fatZombieTex = Content.Load<Texture2D>(@"FatZombie");

            //Structures and Objects
            packageTex = Content.Load<Texture2D>("Package");
            medicTentTex = Content.Load<Texture2D>("MedicTent");
            hqTentTex = Content.Load<Texture2D>("HQtent");
            tankTex = Content.Load<Texture2D>("tank1");
            carTex = Content.Load<Texture2D>("Car1");
            busTex = Content.Load<Texture2D>("Bus1");
            tent = Content.Load<Texture2D>("base");
            Buildings = Content.Load<Texture2D>("Buildings");

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
            rocket = Content.Load<Texture2D>(@"Rocket");

            //Map and UI
            testMapTex = Content.Load<Texture2D>(@"TestMap2");
            //HUD = Content.Load<Texture2D>(@"TestHud");
            player1ScoreHud = Content.Load<Texture2D>("Player1ScoreHUD");
            player2ScoreHud = Content.Load<Texture2D>("Player2ScoreHUD");
            weaponHud = Content.Load<Texture2D>("WeaponHUD");
            rifleLevel = Content.Load<Texture2D>("RifleLevel");
            shotgunLevel = Content.Load<Texture2D>("ShotgunLevel");
            rocketLevel = Content.Load<Texture2D>("RocketLevel");
            weaponWheel[0] = Content.Load<Texture2D>("WeaponHUDRocket");
            weaponWheel[1] = Content.Load<Texture2D>("WeaponHUDRifle");
            weaponWheel[2] = Content.Load<Texture2D>("WeaponHUDShotgun");
            //Menu
            logoTex = Content.Load<Texture2D>(@"Logo1Sombi");
            startButton = Content.Load<Texture2D>(@"Play");
            settingButton = Content.Load<Texture2D>(@"Settings");
            highscoreButton = Content.Load<Texture2D>(@"Highscore");
            exitButton = Content.Load<Texture2D>(@"Exit");

            //Spritefonts
            HudText = Content.Load<SpriteFont>(@"HUDText");
            billBoardText = Content.Load<SpriteFont>("BillboardFont");
            pauseText = Content.Load<SpriteFont>("pauseFont");

            //Miscellaneous
            sourceRectTex = Content.Load<Texture2D>(@"Rectangle");
            fadeScreenTex = Content.Load<Texture2D>("FadeScreen");
        }
    }
}
