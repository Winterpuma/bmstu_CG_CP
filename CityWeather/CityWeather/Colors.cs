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

        public static Color mix(Color a, Color b, float a_pers)
        {
            float b_pers = 1 - a_pers;
            int red = (int)(a.R * a_pers + b.R * b_pers);
            int green = (int)(a.G * a_pers + b.G * b_pers);
            int blue = (int)(a.B * a_pers + b.B * b_pers);

            return Color.FromArgb(red, green, blue);
        }

        /* To get real color:
         * https://en.wikipedia.org/wiki/CIELAB_color_space
         * https://www.codeproject.com/Articles/19045/Manipulating-colors-in-NET-Part-1
         */
    }
}
