using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CityWeather
{
    class LightSource
    {
        //public Point3D position;
        public Vector direction;
        public Color color;

        public LightSource(Vector direction, Color color)
        {
            this.direction = direction;
            this.color = color;
        }
    }
}
