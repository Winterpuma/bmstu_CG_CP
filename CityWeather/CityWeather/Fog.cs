﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CityWeather
{
    class Fog
    {
        public static Color fogColor = Color.Gray;

        public static Bitmap AddFog(Zbuffer map, int farthestZ, int viewZ)
        {
            Bitmap img = map.GetImage().Clone(new Rectangle(0, 0, map.GetImage().Width, map.GetImage().Height), System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            /*int closestZ = 0;
            foreach(int[] i in map.GetZbuf())
            {
                if (i.Max() > closestZ)
                    closestZ = i.Max();
            }*/

            float rangeZ = viewZ - farthestZ;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    int z = map.GetZ(i, j);
                    if (z < farthestZ) // Дальше от нас; невидимо за туманом
                    {
                        img.SetPixel(i, j, fogColor);
                    }
                    else // Ближе к нам
                    {
                        float k = (z - farthestZ) / rangeZ;
                        img.SetPixel(i, j, Colors.mix(img.GetPixel(i, j), fogColor, k));
                    }
                }
            }
            return img;
        }
    }
}
