using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class SoundManager
    {
        SoundLibrary soundLibrary = new SoundLibrary();
        //public static Song song { get; private set; }

        //public static void LoadContent(ContentManager content)
        //{
        //    song = content.Load<Song>("BackgroundMusic");
        //    destroyed = content.Load<SoundEffect>("rock_impact_3");
        //}

        //public static void Playsound(int soundNbr, ContentManager content)
        //{
        //    LoadContent(content);
        //    if (soundNbr == 1)
        //    {
        //        MediaPlayer.Play(song);
        //        MediaPlayer.IsRepeating = true;
        //        MediaPlayer.Volume = 0.3f;
        //    }
        //    if (soundNbr == 2)
        //    {
        //        destroyed.Play();
        //    }
        //}

        public void PlaySound(SoundEffectInstance sound)
        {
            if (sound != null)
            {
                if (sound.State == SoundState.Stopped)
                {
                    sound.Play();
                }
            }
        }
        public void StopSound(SoundEffectInstance sound)
        {
            if (sound.State == SoundState.Playing)
            {
                sound.Stop();
            }
        }


        //Instanser av ljud
        public SoundEffectInstance ShotGunFire
        {
            get
            {
                if (soundLibrary.shotGunFireInstance == null)
                {
                    soundLibrary.shotGunFireInstance = soundLibrary.shotGunFire.CreateInstance();
                }
                return soundLibrary.shotGunFireInstance;
            }
        }










    }
}
