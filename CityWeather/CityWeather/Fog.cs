using System;
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

        public static Bitmap AddFog(Zbuffer map, int visibility)
        {
            Bitmap img = map.GetImage();
            for (int i = 0; i < img.Width; i++)
            {
                for(int j = 0; j < img.Height; j++)
                {
                    int z = map.GetZ(i, j);
                    if (z < visibility)
                    {
                        int k = z / visibility;
                        img.SetPixel(i, j, Colors.mix(fogColor, img.GetPixel(i, j), k));
                    }
                    else
                    {
                        Console.WriteLine(z.ToString() + "   ");
                        img.SetPixel(i, j, fogColor);
                    }
                }
            }
            return img;
        }
    }
}
