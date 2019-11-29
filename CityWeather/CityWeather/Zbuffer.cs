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
        private Bitmap res;
        private int[][] Zbuf;
        private static readonly int zBackground = -10000;
        

        /// <summary>
        /// Получение изображения сцены
        /// </summary>
        /// <param name="models">Список всех моделей сцены</param>
        /// <param name="size">Размер сцены</param>
        /// <returns></returns>
        public Zbuffer(List<Model> models, Size size, LightSource sun)
        {
            res = new Bitmap(size.Width, size.Height);
            Zbuf = new int[size.Height][];

            for (int i = 0; i < size.Height; i++)
            {
                Zbuf[i] = new int[size.Width];
                for (int j = 0; j < size.Width; j++)
                    Zbuf[i][j] = zBackground;
            }
            
            foreach (Model m in models)
            {
                ProcessModel(m, sun);
            }
        }

        public Bitmap AddShadows(Size size, Zbuffer visibleFromSun, double tettay, double tettaz, int dc = 0)
        {
            Bitmap hm = new Bitmap(size.Width, size.Height);
            int[][] lightParts = visibleFromSun.GetZbuf();

            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    int z = GetZ(i, j);
                    if (z != zBackground) 
                    {
                        Point3D newCoord = Transformation.Transform(i, j, z, 0, tettay, tettaz);
                        newCoord.x += dc;
                        newCoord.y += dc;

                        //если выходит за пределы?????????
                        if (newCoord.x < 0 || newCoord.y < 0)
                            continue;
                        if (lightParts[newCoord.x][newCoord.y] > newCoord.z) // текущая точка невидима из источника(если z текущей точки дальше, чем z видимой)
                        {
                            hm.SetPixel(i, j, Color.Black); // TODO: смешивать
                        }
                        else
                        {
                            hm.SetPixel(i, j, res.GetPixel(i, j));
                        }
                    }
                }
            }

            return hm;
        }

        public Bitmap GetImage()
        {
            return res;
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

        /// <summary>
        /// Обрабока одной модели для занесения ее в буфер
        /// </summary>
        /// <param name="m">Модель</param>
        private void ProcessModel(Model m, LightSource sun)
        {
            Color draw;
            foreach (Polygon polygon in m.polygons)
            {
                polygon.CalculatePointsInside(res.Width, res.Height);
                draw = polygon.GetColor(sun);
                foreach (Point3D point in polygon.pointsInside)
                {
                    ProcessPoint(point, draw);
                }
            }
        }

        /// <summary>
        /// Обработка одной точки и ее занесение в буфер
        /// </summary>
        /// <param name="point">Точка</param>
        /// <param name="color">Цвет точки</param>
        private void ProcessPoint(Point3D point, Color color)
        {
            if (point.x < 0 || point.x >= Zbuf[0].Length || point.y < 0 || point.y >= Zbuf.Length) // а если нет zbuf0?
                return;
            if (point.z > Zbuf[point.y][point.x])
            {
                Zbuf[point.y][point.x] = point.z;
                res.SetPixel(point.x, point.y, color);
            }
        }

    }
}
