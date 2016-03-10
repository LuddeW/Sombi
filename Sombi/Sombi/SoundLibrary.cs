using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class SoundLibrary
    {
        public Song song1;
        public SoundEffect shotGunFire;
        public SoundEffectInstance shotGunFireInstance;

        public void LoadContent(ContentManager content)
        {
            song1 = content.Load<Song>("BackgroundMusic");
            shotGunFire = content.Load<SoundEffect>("rock_impact_3");
        }


    }
}
