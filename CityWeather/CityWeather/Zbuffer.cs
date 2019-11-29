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
        private int[][] ZbufFromSun;
        LightSource sun;
        Vector viewDir;
        Size size;
        double tettax, tettay, tettaz;

        private static readonly int zBackground = -10000;
        

        /// <summary>
        /// Получение изображения сцены
        /// </summary>
        /// <param name="models">Список всех моделей сцены</param>
        /// <param name="size">Размер сцены</param>
        /// <returns></returns>
        public Zbuffer(List<Model> models, Size size, LightSource sun, Vector viewDir)
        {
            res = new Bitmap(size.Width, size.Height);
            
            InitBuf(ref Zbuf, size.Width, size.Height, zBackground);
            InitBuf(ref ZbufFromSun, size.Width, size.Height, zBackground);

            this.sun = sun;
            this.size = size;
            this.viewDir = viewDir;
            InitTeta();

            foreach (Model m in models)
            {
                ProcessModel(m);
            }
        }

        private void InitTeta()
        {
            tettax = Vector.GetAngleXBetween(viewDir, sun.direction);
            tettay = Vector.GetAngleYBetween(viewDir, sun.direction);
            tettaz = Vector.GetAngleZBetween(viewDir, sun.direction);
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
                        if (ZbufFromSun[newCoord.y][newCoord.x] > newCoord.z + 0.5) // текущая точка невидима из источника(если z текущей точки дальше, чем z видимой)
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

        #region Получить данные извне
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
        #endregion

        /// <summary>
        /// Обрабока одной модели для занесения ее в буфер
        /// </summary>
        /// <param name="m">Модель</param>
        private void ProcessModel(Model m)
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
            Point3D turned = Transformation.Transform(point, tettax, tettay, tettaz); 
            if (turned.x < 0 || turned.x >= ZbufFromSun[0].Length || turned.y < 0 || turned.y >= ZbufFromSun.Length) 
                return;
            if (turned.z > ZbufFromSun[turned.y][turned.x])
            {
                ZbufFromSun[turned.y][turned.x] = turned.z; // значит прошлая точка была в тени, если была
            }

        }

    }
}
