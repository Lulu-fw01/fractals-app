using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace fractalsApp.FractalClasses
{
    class SierpinskiTriangle: Fractal
    {
        protected Point thirdPoint;

        private SierpinskiTriangle(int panelWidth, int panelHeight) : base(panelWidth, panelHeight)
        {
        }

        private static SierpinskiTriangle triangle;
        private static object syncRoot = new Object();
        /// <summary>
        /// Синглтон для получения Треугольника Серпинского.
        /// </summary>
        /// <param name="panelWidth">
        /// Ширина панели, в которой будет рисоваться треугольник.
        /// </param>
        /// <param name="panelHeight">
        /// Высота панели.
        /// </param>
        /// <returns></returns>
        public static SierpinskiTriangle GetSierpinskiTriangle(int panelWidth, int panelHeight)
        {
            if (triangle == null)
            {
                lock (syncRoot)
                {
                    if (triangle == null)
                        triangle = new SierpinskiTriangle(panelWidth, panelHeight); ;
                }
            }
            else
            { triangle.UpdateStartPosition(panelWidth, panelHeight); }
            return triangle;
        }


        /// <summary>
        /// Метод рисующий треугольник серпинского.
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            fractalPen.Color = GetFractalPenGradientColor(numOfRecurSteps);
            g.DrawPolygon(fractalPen, new Point[] { startPoint, endPoint, thirdPoint });


            var inTr = GetInnerTriangle(new Point[] {startPoint, endPoint, thirdPoint });
            DrawSierpinskiTriangle(g, inTr, length/2, numOfRecurSteps - 1, new Pen(fractalPen.Color, fractalPen.Width));
        }

        /// <summary>
        /// Рекурсивный метод рисования Треугольника Серпинского.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="oldPts"></param>
        /// <param name="len"></param>
        /// <param name="numOfSteps"></param>
        /// <param name="pen"></param>
        private void DrawSierpinskiTriangle(Graphics g, Point[] oldPts, double len, int numOfSteps, Pen pen)
        {
            if (numOfSteps != 0 && len >= 1)
            {
                if (pen.Width - 0.4 > 0)
                    pen.Width -= (float)0.4;
                else
                    pen.Width = (float)0.1;
                pen.Color = GetFractalPenGradientColor(numOfSteps);
                g.DrawPolygon(pen, oldPts);

                // Высота треугольника.
                int h = (int)Math.Round(len * Math.Sqrt(3) / 2);

                var p3 = new Point(oldPts[2].X, oldPts[2].Y - 2 * h);
                var pts1 = new Point[3] { oldPts[0], oldPts[1], p3 };              
                DrawSierpinskiTriangle(g, GetInnerTriangle(pts1) , len / 2, numOfSteps - 1, new Pen(pen.Color, pen.Width) );

                pts1 = new Point[3] {new Point((int)Math.Round(oldPts[2].X - len), oldPts[2].Y) , oldPts[2], oldPts[0] };
                DrawSierpinskiTriangle(g, GetInnerTriangle(pts1), len / 2, numOfSteps - 1, new Pen(pen.Color, pen.Width));

                pts1 = new Point[3] { oldPts[2], new Point((int)Math.Round(oldPts[2].X + len), oldPts[2].Y), oldPts[1] }; 
                DrawSierpinskiTriangle(g, GetInnerTriangle(pts1), len / 2, numOfSteps - 1, new Pen(pen.Color, pen.Width));
            }
            else { }
        }

        /// <summary>
        /// Получение координат треугольника,который лежит внутри искомого треугольника и перевернут.
        /// </summary>
        /// <param name="pts"></param>
        /// <returns></returns>
        private Point[] GetInnerTriangle(Point[] pts)
        {
            var newPoints = new Point[3];
            var p1 = new Point((int)(pts[0].X + (pts[1].X - pts[0].X) / 2), (int)(pts[0].Y + (pts[1].Y - pts[0].Y) / 2));
            newPoints[2] = p1;
            var p2 = new Point((int)(pts[0].X + (pts[2].X - pts[0].X) / 2), (int)(pts[0].Y + (pts[2].Y - pts[0].Y) / 2));
            newPoints[0] = p2;
            var p3 = new Point((int)(pts[2].X + (pts[1].X - pts[2].X) / 2), (int)(pts[2].Y + (pts[1].Y - pts[2].Y) / 2));
            newPoints[1] = p3;

            return newPoints;
        }

        /// <summary>
        /// Обновление позиции в зависимости от размеров панели, на которой рисуется фрактал.
        /// </summary>
        /// <param name="panelWidth">
        /// Ширина панели.</param>
        /// <param name="panelHeight">
        /// Высота Панели.</param>
        public override void UpdateStartPosition(int panelWidth, int panelHeight)
        {
            if(panelHeight >= panelWidth)
            {
                startPoint = new Point((int)(panelWidth / 15), 8 * panelWidth / 10);
                endPoint = new Point((int)(panelWidth - panelWidth / 15), 8 * panelWidth / 10);
            }
            else
            {
                startPoint = new Point((int)(panelHeight / 15), 8 * panelHeight / 10);
                endPoint = new Point((int)(panelHeight - panelHeight / 15), 8 * panelHeight / 10);
            }
             
             length = Math.Sqrt((startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) + (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y));
             thirdPoint = new Point((int)Math.Round(startPoint.X + length / 2), (int)Math.Round(startPoint.Y - length * Math.Sqrt(3) / 2));
        }
    }
}
