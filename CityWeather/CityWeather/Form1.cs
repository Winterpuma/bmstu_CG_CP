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
        LightSource sun1, sun2, sun3, sun4, sun5;
        Zbuffer zbuf;
        Drop rain;

        public Form1()
        {
            InitializeComponent();
            img = new Bitmap(canvas.Width, canvas.Height);
            g = canvas.CreateGraphics();
            //g = Graphics.FromImage(img);
            scene = new List<Model>();

            CreateScene();
            SetSun();
            StartRain();
        }

        #region Установка освещения
        private void button1_Click(object sender, EventArgs e)
        {
            UpdScene(sun1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdScene(sun2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdScene(sun3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdScene(sun4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdScene(sun5);
        }

        private void SetSun()
        {
            sun1 = new LightSource(new Vector(1, 0, 0), Color.White);
            sun2 = new LightSource(new Vector(0.5, 0, -0.5), Color.White);
            sun3 = new LightSource(new Vector(0, 0, -1), Color.White);
            sun4 = new LightSource(new Vector(-0.5, 0, -0.5), Color.White);
            sun5 = new LightSource(new Vector(-1, 0, 0), Color.White);
        }
        #endregion

        private void CreateScene()
        {
            //createCube();
            CreateCubeTurned(Color.Red, -30, -80, 100, 500, 100);
            CreateCubeTurned(Color.Red, -50, -80, 400, 500, 300);

            CreateCubeTurned(Color.Orange, 30, -80, 600, 500, 400);
            CreateCubeTurned(Color.Orange, 30, -80, 800, 500, 350);
        }

        private void UpdScene(LightSource sun)
        {
            zbuf = new Zbuffer(scene, canvas.Size, sun);
            canvas.Image = zbuf.GetImage();
            //g = Graphics.FromImage(canvas.Image);
        }

        private void buttonRain_Click(object sender, EventArgs e)
        {
            UpdRain();
        }

        private void StartRain()
        {
            //g = Graphics.FromImage(img);
            rain = new Drop(canvas.Width, canvas.Height);
        }

        private void UpdRain()
        {
            canvas.Refresh();
            if (rain.IsVisible(zbuf.GetZ(rain.GetPoint())) &&
                rain.IsNextVisible(zbuf.GetZ(rain.GetNextPoint())))
                g.DrawLine(Pens.Aqua, rain.GetPoint(), rain.GetNextPoint());
            rain.Update();
            canvas.Update();
        }
    
        #region Создание Параллелепипедов
        private void CreateCube()
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

        private void CreateCubeTurned(Color color, int xcoef, int ycoef, int x, int y, int h)
        {
            Model m = new Model(color);

            int xl = x + 100, xu = x + 200;
            int yl = y, yu = y - h;
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

            m.CreatePolygon(3, 2, 6, 7); // верхняя
            m.CreatePolygon(0, 1, 2, 3); // передняя
            m.CreatePolygon(0, 4, 7, 3); // левая
            m.CreatePolygon(4, 5, 6, 7); // задняя
            m.CreatePolygon(1, 5, 6, 2); // правая
            m.CreatePolygon(0, 1, 5, 4); // нижняя
            

            scene.Add(m);
        }
        #endregion
               
    }
}
