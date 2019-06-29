using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityWeather
{
    public partial class Form1 : Form
    {
        Bitmap img;
        Graphics g;
        List<Model> scene;

        public Form1()
        {
            InitializeComponent();
            img = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(img);
            scene = new List<Model>();
            //createCube();
            createCubeTurned(Color.Red, -30, -80);
            //createCubeTurned(Color.Orange, 30, -80);

            canvas.Image = Zbuffer.GetImage(scene, canvas.Size);//img;
        }

        private void createCube()
        {
            Model m = new Model(Color.Red);

            int xl = 150, xu = 250;
            int yl = 100, yu = 250;
            int zl = 100, zu = 200;

            m.AddVertex(new Point3D(xl, yu, zu));
            m.AddVertex(new Point3D(xu, yu, zu));
            m.AddVertex(new Point3D(xu, yl, zu));
            m.AddVertex(new Point3D(xl, yl, zu));
            m.AddVertex(new Point3D(xl, yu, zl));
            m.AddVertex(new Point3D(xu, yu, zl));
            m.AddVertex(new Point3D(xu, yl, zl));
            m.AddVertex(new Point3D(xl, yl, zl));
            
            m.CreatePolygon(0, 1, 2, 3);
            m.CreatePolygon(4, 5, 6, 7);
            m.CreatePolygon(0, 4, 7, 3);
            m.CreatePolygon(1, 5, 6, 2);
            m.CreatePolygon(0, 1, 5, 4);
            m.CreatePolygon(3, 2, 6, 7);

            scene.Add(m);
        }

        private void createCubeTurned(Color color, int xcoef, int ycoef)
        {
            Model m = new Model(color);

            int xl = 100, xu = 200;
            int yl = 100, yu = 200;
            int zl = 100, zu = 200;

            m.AddVertex(new Point3D(xl, yu, zu));
            m.AddVertex(new Point3D(xu, yu, zu));
            m.AddVertex(new Point3D(xu, yl, zu));
            m.AddVertex(new Point3D(xl, yl, zu));

            // задняя
            m.AddVertex(new Point3D(xl + xcoef, yu + ycoef, zl));
            m.AddVertex(new Point3D(xu + xcoef, yu + ycoef, zl));
            m.AddVertex(new Point3D(xu + xcoef, yl + ycoef, zl));
            m.AddVertex(new Point3D(xl + xcoef, yl + ycoef, zl));

            m.CreatePolygon(0, 1, 2, 3);
            m.CreatePolygon(4, 5, 6, 7);
            m.CreatePolygon(0, 4, 7, 3);
            m.CreatePolygon(1, 5, 6, 2);
            m.CreatePolygon(0, 1, 5, 4);
            m.CreatePolygon(3, 2, 6, 7);

            scene.Add(m);
        }

    }
}
