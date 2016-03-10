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
        public static Song song { get; private set; }
        public static SoundEffect destroyed { get; private set; }

        public static void LoadContent(ContentManager content)
        {
            song = content.Load<Song>("BackgroundMusic");
            destroyed = content.Load<SoundEffect>("rock_impact_3");
        }

        public static void Playsound(int soundNbr, ContentManager content)
        {
            LoadContent(content);
            if (soundNbr == 1)
            {
                MediaPlayer.Play(song);
            }
            if (soundNbr == 2)
            {
                destroyed.Play();
            }
        }
    }
}
