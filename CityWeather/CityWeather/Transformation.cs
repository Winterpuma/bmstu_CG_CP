using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeather
{
    class Transformation
    {
        static int centerX = 0;
        static int centerY = 0;
        
        public static void SetSize(int w, int h)
        {
            centerX = (int)(w/2);
            centerY =(int)(h/2);
        }
        // Проверяет видимость текущей точки
        /*int Visible(int x, int y)
        {
            if (y < TOP[x] && y > DOWN[x]) return 0;
            if (y >= TOP[x]) return 1;
            return -1;
        }*/

        static void rotate_x(ref double y, ref double z, double tetax)
        {
            tetax = tetax * Math.PI / 180;
            double buf = y;
            y = centerY + Math.Cos(tetax) * (y - centerY) - Math.Sin(tetax) * z;
            z = Math.Cos(tetax) * z + Math.Sin(tetax) * (buf - centerY);
        }

        static void rotate_y(ref double x, ref double z, double tetay)
        {
            tetay = tetay * Math.PI / 180;
            double buf = x;
            x = centerX + Math.Cos(tetay) * (x - centerX) - Math.Sin(tetay) * z;
            z = Math.Cos(tetay) * z + Math.Sin(tetay) * (buf - centerX);
        }

        static void rotate_z(ref double x, ref double y, double tetaz)
        {
            tetaz = tetaz * Math.PI / 180;
            double buf = x;
            x = centerX + Math.Cos(tetaz) * (x - centerX) - Math.Sin(tetaz) * (y - centerY);
            y = centerY + Math.Cos(tetaz) * (y - centerY) + Math.Sin(tetaz) * (buf - centerX);
        }

        public static void transform(ref int x, ref int y, ref int z, double tetax, double tetay, double tetaz)
        {
            double x_tmp = x;
            double y_tmp = y;
            double z_tmp = z;
            rotate_x(ref y_tmp, ref z_tmp, tetax);
            rotate_y(ref x_tmp, ref z_tmp, tetay);
            rotate_z(ref x_tmp, ref y_tmp, tetaz);

            x = (int)x_tmp;
            y = (int)y_tmp;
            z = (int)z_tmp;

        }
    }
}
