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
        private List<int[]> indexes;
        private Color basicColor = Color.Black;
        
        public Model(Color color)
        {
            basicColor = color;
            vertices = new List<Point3D>();
            polygons = new List<Polygon>();
            indexes = new List<int[]>();
        }

        public void AddVertex(Point3D vertex)
        {
            vertices.Add(vertex);
        }

        public void CreatePolygon(bool changeInd, params int[] indexes)
        {
            if (changeInd)
                this.indexes.Add(indexes);

            List<Point3D> verticesPolygon = new List<Point3D>();
            foreach (int i in indexes)
            {
                verticesPolygon.Add(vertices[i]);
            }
            polygons.Add(new Polygon(verticesPolygon, basicColor));
        }

        public void TransformModel(double tetax, double tetay, double tetaz)
        {
            foreach (Point3D v in vertices)
            {
                Transformation.transform(ref v.x, ref v.y, ref v.z, tetax, tetay, tetaz);
                polygons.Clear();
            }

            foreach (int[] i in indexes)
            {
                CreatePolygon(false, i);
            }

        }
    }
        

    class Polygon
    {
        List<Point3D> v;

        Color basicColor = Color.Gray;
        public List<Point3D> pointsInside;
        Vector normal;

        #region Создание Polygon
        /*public Polygon()
        {
            pointsInside = new List<Point3D>();
            v = new List<Point3D>();
        }*/
        
        public Polygon(List<Point3D> vertex)
        {
            pointsInside = new List<Point3D>();
            v = vertex;
            normal = GetNormal();
        }

        public Polygon(Color color)
        {
            basicColor = color;
            pointsInside = new List<Point3D>();
            v = new List<Point3D>();
            normal = GetNormal();
        }

        public Polygon(List<Point3D> vertex, Color color)
        {
            pointsInside = new List<Point3D>();
            v = vertex;
            basicColor = color;
            normal = GetNormal();
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
            int yMax, yMin;
            int[] x = new int[3], y = new int[3];
            
            for (int i = 0; i < 3; ++i)
            {
                x[i] = v[i].x;
                y[i] = v[i].y;
            }
            
            yMax = y.Max();
            yMin = y.Min();

            yMin = (yMin < 0) ? 0 : yMin;
            yMax = (yMax < height) ? yMax : height;

            int x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;
            
            for (int yDot = yMin; yDot <= yMax; yDot++)
            {
                int fFirst = 1;
                for (int n = 0; n < 3; ++n)
                {
                    int n1 = (n == 2) ? 0 : n + 1;
                    
                    if (yDot >= Math.Max(y[n], y[n1]) || yDot < Math.Min(y[n], y[n1])) // || y[n] == y[n1]  
                        continue; // точка вне
                    
                    double m = (double)(y[n] - yDot) / (y[n] - y[n1]);
                    if (fFirst == 0)
                    {
                        x2 = x[n] + (int)(m * (x[n1] - x[n]));
                        z2 = v[n].z + m * (v[n1].z - v[n].z);
                    }
                    else
                    {
                        x1 = x[n] + (int)(m * (x[n1] - x[n]));
                        z1 = v[n].z + m * (v[n1].z - v[n].z);
                    }
                    fFirst = 0;
                }

                if(x2 < x1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref z1, ref z2);
                }

                int xStart = (x1 < 0) ? 0 : x1;
                int xEnd = (x2 < width)? x2 : width;
                for (int xDot = xStart; xDot < xEnd; xDot++)
                {
                    double m = (double)(x1 - xDot) / (x1 - x2);
                    double zDot = z1 + m * (z2 - z1);

                    pointsInside.Add(new Point3D(xDot, yDot, (int)zDot));
                }
            }
        }
        #endregion

        public Vector GetNormal()
        {
            int len = v.Count();
            int a = 0, b = 0, c = 0;
            for (int i = 0; i < len - 1; i++)
            {
                a += (v[i].y - v[i + 1].y) * (v[i].z + v[i + 1].z);
                b += (v[i].x - v[i + 1].x) * (v[i].z + v[i + 1].z);
                c += (v[i].x - v[i + 1].x) * (v[i].y + v[i + 1].y);
            }
            a += (v[len - 1].y - v[0].y) * (v[len - 1].z + v[0].z);
            b += (v[len - 1].x - v[0].x) * (v[len - 1].z + v[0].z);
            c += (v[len - 1].x - v[0].x) * (v[len - 1].y + v[0].y);
            return new Vector(a, b, c);
        }
        
        public Color GetColor(LightSource light)
        {
            double cos = Vector.ScalarMultiplication(light.direction, normal) / 
                (light.direction.length * normal.length);
            cos = Math.Abs(cos);
            cos *= 255;
            return Colors.mix(Color.FromArgb((int)cos % 256, (int)cos % 256, (int)cos % 256), Color.Orange, 0.25f);
            
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
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
        public double x, y, z;
        public double length;

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            FindLength();
        }
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            FindLength();
        }

        public Vector(Point3D a, Point3D b)
        {
            x = b.x - a.x;
            y = b.y - a.y;
            z = b.z - b.z;
            FindLength();
        }
        
        private void FindLength()
        {
            length = Math.Sqrt(x * x + y * y + z * z);
        }

        public double GetLength()
        {
            return length;
        }

        public static Vector VectorMultiplication(Vector a, Vector b)
        {
            Vector res = new Vector(0, 0, 0);
            res.x = a.y * b.z - a.z * b.y;
            res.y = a.z * b.x - a.x * b.z;
            res.z = a.x * b.y - a.y * b.x;
            res.FindLength();
            return res;
        }

        public static double ScalarMultiplication(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
    
}
