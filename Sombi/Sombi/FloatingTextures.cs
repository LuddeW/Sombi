using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombi
{
    class FloatingTextures
    {

        List<Vector2> cloud1, cloud2, cloud3, cloud4;
        int cloud1Spc, cloud2Spc, cloud3Spc, cloud4Spc;
        float cloud1Speed, cloud2Speed, cloud3Speed, cloud4Speed;
        Texture2D[] tex;
        Color color = Color.White;
        
        int height = 1000;
        int width = 1000;

        public FloatingTextures()
        {
            this.tex = new Texture2D[4];
            tex[0] = TextureLibrary.cloud1Tex;
            tex[1] = TextureLibrary.cloud2Tex;
            tex[2] = TextureLibrary.cloud3Tex;
            tex[3] = TextureLibrary.cloud4Tex;

            cloud1 = new List<Vector2>();
            cloud1Spc = width * 2;
            cloud1Speed = 0.65f;
            for (int i = 0; i < (width / cloud1Spc) + 2; i++)
                cloud1.Add(new Vector2(i * cloud1Spc, height - tex[0].Height - 10));

            cloud2 = new List<Vector2>();
            cloud2Spc = width * 1;
            cloud2Speed = 0.35f;
            for (int i = 0; i < (width / cloud2Spc) + 2; i++)
                cloud2.Add(new Vector2(i * cloud2Spc, height - tex[0].Height - tex[1].Height));

            cloud3 = new List<Vector2>();
            cloud3Spc = width * 4;
            cloud3Speed = 0.7f;
            for (int i = 0; i < (width / cloud3Spc) + 2; i++)
                cloud3.Add(new Vector2(i * cloud3Spc, height - tex[0].Height - (int)(tex[2].Height * 2)));

            cloud4 = new List<Vector2>();
            cloud4Spc = width * 3;
            cloud4Speed = 0.55f;
            for (int i = 0; i < (width / cloud4Spc) + 20; i++)
                cloud4.Add(new Vector2(i * cloud4Spc, height - tex[0].Height - (int)(tex[3].Height * 3.25)));       
        }
          
        public void Update()
        {
            for (int i = 0; i < cloud1.Count; i++)
            {
                cloud1[i] = new Vector2(cloud1[i].X - cloud1Speed, cloud1[i].Y);
                if (cloud1[i].X <= -cloud1Spc)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = cloud1.Count - 1;
                    }
                    cloud1[i] = new Vector2(cloud1[j].X + cloud1Spc - 1, cloud1[i].Y);
                }
            }
            for (int i = 0; i < cloud2.Count; i++)
            {
                cloud2[i] = new Vector2(cloud2[i].X - cloud2Speed, cloud2[i].Y);
                if (cloud2[i].X <= -cloud2Spc)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = cloud2.Count - 1;
                    }
                    cloud2[i] = new Vector2(cloud2[j].X + cloud2Spc - 1, cloud2[i].Y);
                }
            }
            for (int i = 0; i < cloud3.Count; i++)
            {
                cloud3[i] = new Vector2(cloud3[i].X - cloud3Speed, cloud3[i].Y);
                if (cloud3[i].X <= -cloud3Spc)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = cloud3.Count - 1;
                    }
                    cloud3[i] = new Vector2(cloud3[j].X + cloud3Spc - 1, cloud3[i].Y);
                }
            }
            for (int i = 0; i < cloud4.Count; i++)
            {
                cloud4[i] = new Vector2(cloud4[i].X - cloud4Speed, cloud4[i].Y);
                if (cloud4[i].X <= -cloud4Spc)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = cloud4.Count - 1;
                    }
                    cloud4[i] = new Vector2(cloud4[j].X + cloud4Spc - 1, cloud4[i].Y);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Vector2 v in cloud1)
            {
                spriteBatch.Draw(tex[0], v, color * 0.6f);
            }
            foreach (Vector2 v in cloud2)
            {
                spriteBatch.Draw(tex[1], v, color * 0.6f);
            }
            foreach (Vector2 v in cloud3)
            {
                spriteBatch.Draw(tex[2], v, color * 0.6f);
            }
            foreach (Vector2 v in cloud4)
            {
                spriteBatch.Draw(tex[3], v, color * 0.6f);
            }
        }
    }
}
