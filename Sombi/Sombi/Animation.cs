using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class Animation
    {
        Texture2D texture;
        public int frameWidth; // Bredd

        public int frameHeight // Höjd
        {
            get { return texture.Height; } // frameHeight blir samma sak som höjden av bilden
        }

        float frameTime; // avgör hur snabbt bilden byter under animationen
        public float FrameTime // ju högre nummret är desto slöare kmr den byta bild
        {
            get { return frameTime; }
        }

        public int frameCount;

        bool isLooping; // en bool som bestämmer om animationen loopar eller inte
        public bool IsLooping
        {
            get { return isLooping; }
        }

        public Animation(Texture2D newTexture, int newFrameWidth, float newFrameTime, bool newIsLooping)
        {
            // vi har bild, bredden, hastigheten vid animationens förändring av bilder, och om den loopar eller ej.
            texture = newTexture;
            frameWidth = newFrameWidth;
            frameTime = newFrameTime;
            isLooping = newIsLooping;
            frameCount = texture.Width / frameWidth;

        }
    }
}
