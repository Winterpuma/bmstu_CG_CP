using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CityWeather
{
    class Model
    {
        List<Point3D> vertices;
        public List<Polygon> polygons;
        private Color basicColor = Color.Black;
        
        public Model(Color color)
        {
            basicColor = color;
            vertices = new List<Point3D>();
            polygons = new List<Polygon>();
        }

        public void AddVertex(Point3D vertex)
        {
            vertices.Add(vertex);
        }

        public void CreatePolygon(params int[] indexes)
        {
            List<Point3D> verticesPolygon = new List<Point3D>();
            foreach (int i in indexes)
            {
                verticesPolygon.Add(vertices[i]);
            }
            polygons.Add(new Polygon(verticesPolygon, basicColor));
        }
    }
        

    class Polygon
    {
        List<Point3D> v;

        Color basicColor = Color.Black;
        public List<Point3D> pointsInside;

        #region Создание Polygon
        public Polygon()
        {
            pointsInside = new List<Point3D>();
            v = new List<Point3D>();
        }
        
        public Polygon(List<Point3D> vertex)
        {
            pointsInside = new List<Point3D>();
            v = vertex;
        }

        public Polygon(Color color)
        {
            basicColor = color;
            pointsInside = new List<Point3D>();
            v = new List<Point3D>();
        }

        public Polygon(List<Point3D> vertex, Color color)
        {
            pointsInside = new List<Point3D>();
            v = vertex;
            basicColor = color;
        }
        #endregion

        #region Нахождение внутренних точек
        public void CalculatePointsInside(int width, int height)
        {
            pointsInside = new List<Point3D>();

            if (v.Count() > 4)
            {
                ; // найти треугольники
                //CalculatePointsInsideTriangle(width, height);
            }
            else if (v.Count() == 4)
            {
                List<Point3D> triangle = new List<Point3D>();
                triangle.Add(v[0]);
                triangle.Add(v[2]);
                triangle.Add(v[1]);
                CalculatePointsInsideTriangle(width, height, triangle);
                triangle.RemoveAt(2);
                triangle.Add(v[3]);
                CalculatePointsInsideTriangle(width, height, triangle);
            }
            else if (v.Count() == 3)
            {
                CalculatePointsInsideTriangle(width, height, v);
            }
        }

        private void CalculatePointsInsideTriangle(int width, int height, List<Point3D> v)
        {
            int ymax, ymin;
            int[] x = new int[3], y = new int[3];
            
            for (int i = 0; i < 3; ++i)
            {
                x[i] = v[i].x;
                y[i] = v[i].y;
            }
            
            ymax = ymin = y[0];
            if (ymax < y[1])
                ymax = y[1];
            else
                if (ymin > y[1])
                ymin = y[1];

            if (ymax < y[2])
                ymax = y[2];
            else
                if (ymin > y[2])
                ymin = y[2];
            //ymax = v.Max<int>();

            ymin = (ymin < 0) ? 0 : ymin;
            ymax = (ymax < height) ? ymax : height;

            int x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;
            
            for (int ysc = ymin; ysc < ymax; ++ysc)
            {
                int ne = 0;
                for (int e = 0; e < 3; ++e)
                {
                    int e1 = e + 1;
                    if (e1 == 3) e1 = 0;
                    if (y[e] < y[e1])
                    {
                        if (y[e1] <= ysc || ysc < y[e]) continue;
                    }
                    else if (y[e] > y[e1])
                    {
                        if (y[e1] > ysc || ysc >= y[e]) continue;
                    }
                    else continue;

                    double tc = (double)(y[e] -ysc) / (y[e] - y[e1]);
                    if (ne != 0)
                    {
                        x2 = x[e] + (int)(tc * (x[e1] - x[e]));
                        z2 = v[e].z + tc * (v[e1].z - v[e].z);
                    }
                    else
                    {
                        x1 = x[e] + (int)(tc * (x[e1] - x[e]));
                        z1 = v[e].z + tc * (v[e1].z - v[e].z);
                    }
                    ne = 1;
                }
                if(x2 < x1)
                {
                    int e = x1;
                    x1 = x2;
                    x2 = e;
                    double tc = z1;
                    z1 = z2;
                    z2 = tc;
                }

                int xsc1 = ((x1 < 0)? 0 : x1);
                int xsc2 = (x2 < width)? x2 : width;
                for (int xsc = xsc1; xsc <= xsc2; ++xsc)
                {
                    double tc = (double)(x1 - xsc) / (x1 - x2);
                    double z = z1 + tc* (z2 - z1);

                    pointsInside.Add(new Point3D(xsc, ysc, (int)z));
                    /*if (z > (*(buff[ysc] + xsc )).z)
                        (*(buff[ysc] + xsc)).col = t.col,
                    (*(buff[ysc] + xsc)).z = z;*/
                }
            }
        }
        #endregion
        
        public Color GetColor()
        {

            return basicColor; // color with count of shades??
        }
    }

    class Point3D
    {
        public int x, y, z;
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    class Vector
    {
        public int x, y, z;

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(Point3D a, Point3D b)
        {
            x = b.x - a.x;
            y = b.y - a.y;
            z = b.z - b.z;
        }

        public double GetLength()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public static Vector VectorMultiplication(Vector a, Vector b)
        {
            Vector res = new Vector(0, 0, 0);
            res.x = a.y * b.z - a.z * b.y;
            res.y = a.z * b.x - a.x * b.z;
            res.z = a.x * b.y - a.y * b.x;
            return res;
        }

        public static float ScalarMultiplication(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
