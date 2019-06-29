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
        static Bitmap res;
        static int[][] Zbuf;

        /// <summary>
        /// Получение изображения сцены
        /// </summary>
        /// <param name="models">Список всех моделей сцены</param>
        /// <param name="size">Размер сцены</param>
        /// <returns></returns>
        public static Bitmap GetImage(List<Model> models, Size size)
        {
            res = new Bitmap(size.Width, size.Height);
            Zbuf = new int[size.Height][];

            for (int i = 0; i < size.Height; i++)
                Zbuf[i] = new int[size.Width]; // нули???

            foreach (Model m in models)
            {
                ProcessModel(m);
            }
            
            return res;
        }

        /// <summary>
        /// Обрабока одной модели
        /// </summary>
        /// <param name="m">Модель</param>
        private static void ProcessModel(Model m)
        {
            foreach (Polygon polygon in m.polygons)
            {
                polygon.CalculatePointsInside();
                foreach (Point3D point in polygon.pointsInside)
                {
                    ProcessPoint(point, polygon.GetColor());
                }
            }
        }

        /// <summary>
        /// Обработка одной точки и ее занесение в буфер
        /// </summary>
        /// <param name="point">Точка</param>
        /// <param name="color">Цвет точки</param>
        private static void ProcessPoint(Point3D point, Color color)
        {
            if (point.x < 0 || point.x > Zbuf[0].Length || point.y < 0 || point.y > Zbuf.Length) // а если нет zbuf0?
                return;
            if (point.z > Zbuf[point.y][point.x])
            {
                Zbuf[point.y][point.x] = point.z;
                res.SetPixel(point.x, point.y, color);
            }
        }

    }
}
