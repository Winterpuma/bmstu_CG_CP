using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CityWeather
{
    class Colors
    {
        public Color c;

        public static Color mix(Color a, Color b, float aPers)
        {
            aPers = Math.Min(aPers, 1);
            float bPers = 1 - aPers;
            int red = (int)(a.R * aPers + b.R * bPers);
            int green = (int)(a.G * aPers + b.G * bPers);
            int blue = (int)(a.B * aPers + b.B * bPers);

            return Color.FromArgb(red, green, blue);
        }

        /* To get real color:
         * https://en.wikipedia.org/wiki/CIELAB_color_space
         * https://www.codeproject.com/Articles/19045/Manipulating-colors-in-NET-Part-1
         */
    }
}
