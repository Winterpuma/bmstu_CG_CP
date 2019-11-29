using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace CityWeather
{

    public partial class Form1 : Form
    {
        Bitmap img;
        Graphics g;
        List<Model> scene;
        LightSource sun1, sun2, sun3, sun4, sun5, current;
        Vector ViewDirection = new Vector(0, 0, -1);
        Zbuffer zbuf;
        ParticleSystem rain;
        static int ground = 400;
                
        public Form1()
        {
            InitializeComponent();
            Transformation.SetSize(canvas.Width, canvas.Height);

            img = new Bitmap(canvas.Width, canvas.Height);
            g = canvas.CreateGraphics();
            scene = new List<Model>();

            CreateScene();
            SetSun();

            UpdScene(sun1);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            label12.Text = zbuf.GetZ(e.X, e.Y).ToString();
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
            sun2 = new LightSource(new Vector(0.5, -0.5, 0), Color.White);
            sun3 = new LightSource(new Vector(0, -1, 0), Color.White);
            sun4 = new LightSource(new Vector(-0.5, -0.5, 0), Color.White);
            sun5 = new LightSource(new Vector(-1, 0, 0), Color.White);
        }
        #endregion

        #region Сцена
        private void CreateScene()
        {
            CreateGround(Color.Green, canvas.Width /2, 400 , canvas.Width / 2, 1000);
            CreateCube(Color.DarkOrange, 300, 100, 0, 150, 300);
            CreateCube(Color.Red, 750, 150, 100, 100, 100);

            /*foreach (Model m in scene)
            {
                m.TransformModel(-20, -30, 0);
            }*/
        }

        private void UpdScene(LightSource sun)
        {
            zbuf = new Zbuffer(scene, canvas.Size, sun, ViewDirection);
            canvas.Image = zbuf.AddShadows();//zbuf.GetImage();
            current = sun;
        }

        private void buttonAddBuilding_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBoxSX.Text);
            int z = Convert.ToInt32(textBoxSZ.Text);
            int dx = Convert.ToInt32(textBoxSDx.Text);
            int dz = Convert.ToInt32(textBoxSDz.Text);
            int h = Convert.ToInt32(textBoxSH.Text);
            CreateCube(Color.Black, x, dx, z, dz, h);
            UpdScene(current);
        }
        #endregion

        #region Дождь
        private void buttonRain_Click(object sender, EventArgs e)
        {
            int intensity = Convert.ToInt32(textBoxIntensiveness.Text);
            int dx = Convert.ToInt32(textBoxDx.Text);
            int dy = Convert.ToInt32(textBoxDy.Text);
            int dz = Convert.ToInt32(textBoxDz.Text);
            Vector wind = new Vector(dx, dy, dz);

            StartRain(intensity, wind);

            int delay = Convert.ToInt32(textBoxDelay.Text);
            for (int i = 0; i < 100; i++)
            {
                UpdRain();
                rain.InitParticles(intensity);
                System.Threading.Thread.Sleep(delay);
            }

            while (!rain.IsEmpty())
            {
                UpdRain();
                System.Threading.Thread.Sleep(delay);
            }
            /*
            for (int i = 0; i < 50; i++) // while not empty?
            {
                UpdRain();
                System.Threading.Thread.Sleep(delay);
            }*/
        }
        

        private void StartRain(int intensity, Vector direction)
        {
            rain = new ParticleSystem(canvas.Width, canvas.Height, direction, intensity);
        }

        private void UpdRain()
        {
            canvas.Refresh();
            rain.ProcessSystem(g, new Pen(Color.LightBlue, 2));
            canvas.Update();
        }
        #endregion

        #region Туман
        private void buttonFog_Click(object sender, EventArgs e)
        {
            int far = Convert.ToInt32(textBoxfar.Text);
            int close = Convert.ToInt32(textBoxClose.Text);
            canvas.Image = Fog.AddFog(zbuf, far, close);
        }
        #endregion

        #region Создание Параллелепипедов
        private void CreateCube(Color color, int xCent, int dx, int zCent, int dz, int height)
        {
            Model m = new Model(color);

            //передняя
            m.AddVertex(new Point3D(xCent - dx, ground, zCent + dz)); // левая нижняя
            m.AddVertex(new Point3D(xCent + dx, ground, zCent + dz)); // правая нижняя
            m.AddVertex(new Point3D(xCent + dx, ground - height, zCent + dz)); // правая верхняя
            m.AddVertex(new Point3D(xCent - dx, ground - height, zCent + dz)); // левая верхняя

            // задняя
            m.AddVertex(new Point3D(xCent - dx, ground, zCent - dz)); // левая нижняя
            m.AddVertex(new Point3D(xCent + dx, ground, zCent - dz)); // правая нижняя
            m.AddVertex(new Point3D(xCent + dx, ground - height, zCent - dz)); // правая верхняя
            m.AddVertex(new Point3D(xCent - dx, ground - height, zCent - dz)); // левая верхняя

            m.CreatePolygon(true, 3, 2, 6, 7); // верхняя
            m.CreatePolygon(true, 0, 1, 2, 3); // передняя
            m.CreatePolygon(true, 0, 4, 7, 3); // левая
            m.CreatePolygon(true, 4, 5, 6, 7); // задняя
            m.CreatePolygon(true, 1, 5, 6, 2); // правая
            m.CreatePolygon(true, 0, 1, 5, 4); // нижняя

            scene.Add(m);
        }
        
        private void CreateGround(Color color, int xCent, int dx, int zCent, int dz)
        {
            Model m = new Model(color);

            m.AddVertex(new Point3D(xCent + dx, ground, zCent + dz));
            m.AddVertex(new Point3D(xCent - dx, ground, zCent + dz));
            m.AddVertex(new Point3D(xCent - dx, ground, zCent - dz));
            m.AddVertex(new Point3D(xCent + dx, ground, zCent - dz));

            m.CreatePolygon(true, 0, 1, 2, 3);

            scene.Add(m);
        }
        #endregion

        #region Повороты
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            foreach (Model m in scene)
            {
                m.TransformModel(0, -10, 0);
            }
            //повернуть солнышко
            UpdScene(current);

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            foreach (Model m in scene)
            {
                m.TransformModel(0, 10, 0);
            }
            //повернуть солнышко
            UpdScene(current);
        }
        
        private void buttonUp_Click(object sender, EventArgs e)
        {
            foreach (Model m in scene)
            {
                m.TransformModel(10, 0, 0);
            }
            //повернуть солнышко
            UpdScene(current);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            foreach (Model m in scene)
            {
                m.TransformModel(-10, 0, 0);
            }
            //повернуть солнышко
            UpdScene(current);
        }


        #endregion

    }
}
