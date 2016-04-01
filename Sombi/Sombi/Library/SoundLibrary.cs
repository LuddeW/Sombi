using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    public class SoundLibrary
    {
        public static Song menuSong;
        public static SoundEffect shotGunFire;
        //public static SoundEffectInstance shotGunFireInstance;
        public static SoundEffect rifleFire;
        //public static SoundEffectInstance rifleFireInstance;
        public static SoundEffect explosiveFire;
        //public static SoundEffectInstance explosiveFireInstance;
        public static void LoadContent(ContentManager Content)
        {
            //menuSong = Content.Load<Song>("menuMusic");
            //SoundEffect.MasterVolume = 0.5f;

            //shotGunFire = Content.Load<SoundEffect>("shotgun");
            //SoundEffect.MasterVolume = 0.5f;

            rifleFire = Content.Load<SoundEffect>(@"50Cal1");
            SoundEffect.MasterVolume = 0.5f;
            
            //explosiveFire = Content.Load<SoundEffect>("explosive");
            //SoundEffect.MasterVolume = 0.5f;
        }
    }
}
