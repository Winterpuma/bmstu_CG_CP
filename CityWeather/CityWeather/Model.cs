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
        
        public Model()
        {
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
            polygons.Add(new Polygon(verticesPolygon));
        }
    }

    class Polygon
    {
        List<Point3D> vertices;
        Color color = Color.Orange;
        public List<Point3D> pointsInside;

        public Polygon()
        {
            pointsInside = new List<Point3D>();
            vertices = new List<Point3D>();
        }

        public Polygon(List<Point3D> vertex)
        {
            pointsInside = new List<Point3D>();
            vertices = vertex;
        }
        
        public void CalculatePointsInside()
        {
            pointsInside = new List<Point3D>(); //todo
        }

        public Color GetColor()
        {
            return color; // color with count of shades??
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
}
