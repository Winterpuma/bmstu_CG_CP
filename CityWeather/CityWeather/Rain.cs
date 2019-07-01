using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CityWeather
{
    class Drop
    {
        int x, y, z;
        int dx, dy, dz;
        static Random rnd = new Random();

        public Drop(int width, int height)
        {
            x = rnd.Next(0, 400);
            y = 0;
            z = 700;//rnd.Next(300, 600);
            dx = rnd.Next(10, 15);
            dy = rnd.Next(10, 15);
            dz = rnd.Next(10, 15);
        }

        public void Update()
        {
            x += dx;
            y += dy;
            z += dz;
        }

        public int GetDepth()
        {
            return z;
        }

        public bool IsVisible(int maxZ)
        {
            if (z > maxZ)
                return true;
            return false;
        }

        public bool IsNextVisible(int maxZ)
        {
            if ((z + dz) > maxZ)
                return true;
            return false;
        }

        public Point GetPoint()
        {
            return new Point(x, y);
        }

        public Point GetNextPoint()
        {
            return new Point(x + dx, y + dy);
        }
    }
}
