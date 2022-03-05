using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace fractalsApp.FractalClasses
{
    class SierpinskiCarpet: Fractal
    {
        private static SolidBrush brush;

        static SierpinskiCarpet()
        {
            brush = new SolidBrush(colorFrom);
        }
        private SierpinskiCarpet(int panelWidth, int panelHeight) : base(panelWidth, panelHeight)
        { }

        private static SierpinskiCarpet carpet;
        private static object syncRoot = new Object();
        /// <summary>
        /// Синглтон для получения ковра Серпинского .
        /// </summary>
        /// /// <param name="panelWidth">
        /// Ширина панели, в которой будет рисоваться ковер.
        /// </param>
        /// <param name="panelHeight">
        /// Высота панели.
        /// </param>
        /// <returns></returns>
        public static SierpinskiCarpet GetSierpinskiCarpet(int panelWidth, int panelHeight)
        {
            if (carpet == null)
            {
                lock (syncRoot)
                {
                    if (carpet == null)
                        carpet = new SierpinskiCarpet(panelWidth, panelHeight); ;
                }
            }
            else
            { carpet.UpdateStartPosition(panelWidth, panelHeight); }
            return carpet;
        }


        /// <summary>
        /// Метод рисования ковра Серпинского.
        /// </summary>
        /// <param name="g">
        /// Graphics.
        /// </param>
        public override void Draw(Graphics g)
        {
            
            brush.Color = GetFractalPenGradientColor(NumOfRecurSteps);
            var p = GetrectangleStartPointFromCenter(startPoint, length);
            g.FillRectangle(brush, p.X, p.Y,(int)Math.Round(length + 5), (int)Math.Round(length + 5) );
            
            DrawSierpinskiCarpet(g, startPoint, length, numOfRecurSteps - 1);
        }

        /// <summary>
        /// Рекурсивана функция рисования квадрата Серпинского.
        /// </summary>
        /// <param name="g">
        /// Graphics.
        /// </param>
        /// <param name="centerPoint">
        /// Центральная точка квадрата.</param>
        /// <param name="len">
        /// Длина стороны квадрата.</param>
        /// <param name="numOfSteps">
        /// Шаг рекурсии.</param>
        private void DrawSierpinskiCarpet(Graphics g, Point centerPoint, double len, int numOfSteps)
        {
            if (numOfSteps != 0 && len >= 1)
            {

                var newLen = len / 3;
                var p = GetrectangleStartPointFromCenter(centerPoint, newLen);
                brush.Color = GetFractalPenGradientColor(numOfSteps);
                g.FillRectangle(brush, p.X, p.Y, (int)newLen, (int)newLen);

                numOfSteps--;

                int t = (int)Math.Round(len / 6);
                //newLen = (int)newLen;
                p = GetrectangleStartPointFromCenter(centerPoint, len);

                var p1 = new Point(p.X + t, p.Y + t);
                DrawSierpinskiCarpet(g, p1, newLen, numOfSteps);
                var p2 = new Point(p.X + t, p.Y + 3 * t);
                DrawSierpinskiCarpet(g, p2, newLen, numOfSteps);
                var p3 = new Point(p.X + t, p.Y + 5 * t);
                DrawSierpinskiCarpet(g, p3, newLen, numOfSteps);
                var p4 = new Point(p.X + 3 * t, p.Y + t);
                DrawSierpinskiCarpet(g, p4, newLen, numOfSteps);
                var p5 = new Point(p.X + 3 * t,  p.Y + 5 * t);
                DrawSierpinskiCarpet(g, p5, newLen, numOfSteps);
                var p6 = new Point(p.X + 5 * t, p.Y + t);
                DrawSierpinskiCarpet(g, p6, newLen, numOfSteps);
                var p7 = new Point(p.X + 5 * t,p.Y + 3 * t);
                DrawSierpinskiCarpet(g, p7, newLen, numOfSteps);
                var p8 = new Point(p.X + 5 * t, p.Y + 5 * t);
                DrawSierpinskiCarpet(g, p8, newLen, numOfSteps);
            }
            else { }
        }

        /// <summary>
        /// Получение координат квадрата в соответствии с размерами панели.
        /// </summary>
        /// <param name="panelWidth">
        /// Ширина панели.</param>
        /// <param name="panelHeight">
        /// Высота панели.</param>
        public override void UpdateStartPosition(int panelWidth, int panelHeight)
        {
            //startPoint = new Point(panelWidth / 2, panelHeight / 2);
            if (panelHeight >= panelWidth)
            {
                length = 8 * panelWidth / 10;
                startPoint = new Point(panelWidth / 2, panelWidth / 2);
            }
            else
            { 
                length = 8 * panelHeight / 10;
                startPoint = new Point(panelHeight / 2, panelHeight / 2);
            }
        }

        /// <summary>
        /// Функция получения из центральных координат квадрата координат левого верхнего угла.
        /// </summary>
        /// <param name="centerPoint">
        /// Центральные координаты.
        /// </param>
        /// <param name="len">
        /// Длина стороны кадрата.</param>
        /// <returns></returns>
        private Point GetrectangleStartPointFromCenter(Point centerPoint, double len)
        {
            double x = centerPoint.X - len / 2;
            double y = centerPoint.Y - len / 2;
            int x1 = (int)Math.Round(x);
            int y1 = (int)Math.Round(y);
            

            var recPoint = new Point(x1,y1 );
            //var recPoint = new Point((int)(centerPoint.X - len / 2), (int)(centerPoint.Y - len / 2));
            return recPoint;
        }

    }
}
