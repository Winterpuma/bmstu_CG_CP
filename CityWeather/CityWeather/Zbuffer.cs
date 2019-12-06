using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CityWeather
{

    class Zbuffer
    {
        private Bitmap img;
        private Bitmap imgFromSun;
        private int[][] Zbuf;
        private int[][] ZbufFromSun;
        LightSource sun;
        Size size;
        double tettax, tettay, tettaz;

        private static readonly int zBackground = -10000;
        

        /// <summary>
        /// Получение изображения сцены
        /// </summary>
        /// <param name="models">Список всех моделей сцены</param>
        /// <param name="size">Размер сцены</param>
        /// <returns></returns>
        public Zbuffer(Scene s, Size size, LightSource sun)
        {
            img = new Bitmap(size.Width, size.Height);
            imgFromSun = new Bitmap(size.Width, size.Height);

            InitBuf(ref Zbuf, size.Width, size.Height, zBackground);
            InitBuf(ref ZbufFromSun, size.Width, size.Height, zBackground);

            this.sun = sun;
            this.size = size;
            InitTeta();

            foreach (Model m in s.GetModels())
            {
                ProcessModel(Zbuf, img, m);
                ProcessModelSpecial(ZbufFromSun, imgFromSun, m.GetTurnedModel(tettax, tettay, tettaz));
            }
            
        }

        /// <summary>
        /// Установка углов между взглядом и источником света
        /// </summary>
        private void InitTeta()
        {
            tettax = sun.tetax;
            tettay = sun.tetay;
            tettaz = sun.tetaz;
        }

        /// <summary>
        /// Инициализация буффера, заполнение начальным значением
        /// </summary>
        /// <param name="buf">Буфер</param>
        /// <param name="w">Ширина буфера</param>
        /// <param name="h">Высота буфера</param>
        /// <param name="value">Начальное значение</param>
        private void InitBuf(ref int[][] buf, int w, int h, int value)
        {
            buf = new int[h][];
            for (int i = 0; i < h; i++)
            {
                buf[i] = new int[w];
                for (int j = 0; j < w; j++)
                    buf[i][j] = value;
            }
        }

        public Bitmap AddShadows()
        {
            Bitmap hm = new Bitmap(size.Width, size.Height);

            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    int z = GetZ(i, j);
                    if (z != zBackground) 
                    {
                        Point3D newCoord = Transformation.Transform(i, j, z, tettax, tettay, tettaz);
                        
                        if (newCoord.x < 0 || newCoord.y < 0 || newCoord.x >= size.Width || newCoord.y >= size.Height)
                            continue;

                        Color curPixColor = img.GetPixel(i, j);
                        if (ZbufFromSun[newCoord.y][newCoord.x] > newCoord.z + 2) // текущая точка невидима из источника света
                        {
                            hm.SetPixel(i, j, Colors.Mix(Color.Black, curPixColor, 0.4f)); 
                        }
                        else
                        {
                            hm.SetPixel(i, j, curPixColor);
                        }
                    }
                }
            }

            return hm;
        }

        #region Получить данные извне
        public Bitmap GetImage()
        {
            return img;
        }

        public Bitmap GetSunImage()
        {
            return imgFromSun;
        }

        public int[][] GetZbuf()
        {
            return Zbuf;
        }

        public int GetZ(int x, int y)
        {
            return Zbuf[y][x];
        }

        public int GetZ(Point p)
        {
            return Zbuf[p.Y][p.X];
        }
        #endregion

        /// <summary>
        /// Обрабока одной модели для занесения ее в буфер
        /// </summary>
        /// <param name="m">Модель</param>
        private void ProcessModel(int[][] buffer, Bitmap image, Model m)
        {
            Color draw;
            foreach (Polygon polygon in m.polygons)
            {
                polygon.CalculatePointsInside(img.Width, img.Height);
                draw = polygon.GetColor(sun);
                foreach (Point3D point in polygon.pointsInside)
                {
                    ProcessPoint(buffer, image, point, draw);
                }
            }
        }

        private void ProcessModelSpecial(int[][] buffer, Bitmap image, Model m)
        {
            Color draw;
            foreach (Polygon polygon in m.polygons)
            {
                if (polygon.special)
                    continue;
                polygon.CalculatePointsInside(img.Width, img.Height);
                draw = polygon.GetColor(sun);
                foreach (Point3D point in polygon.pointsInside)
                {
                    ProcessPoint(buffer, image, point, draw);
                }
            }
        }

        /// <summary>
        /// Обработка одной точки и ее занесение в буфер
        /// </summary>
        /// <param name="point">Точка</param>
        /// <param name="color">Цвет точки</param>
        private void ProcessPoint(int[][] buffer, Bitmap image, Point3D point, Color color)
        {
            if (!(point.x < 0 || point.x >= image.Width || point.y < 0 || point.y >= image.Height))
            {
                if (point.z > buffer[point.y][point.x])
                {
                    buffer[point.y][point.x] = point.z;
                    image.SetPixel(point.x, point.y, color);
                }
            }
        }

    }
}
