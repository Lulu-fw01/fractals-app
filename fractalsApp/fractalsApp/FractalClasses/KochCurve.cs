using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace fractalsApp.FractalClasses
{
    class KochCurve: Fractal
    {

        private KochCurve(int panelWidth, int panelHeight): base(panelWidth, panelHeight)
        { }

        private static KochCurve curve;
        private static object syncRoot = new Object();
        /// <summary>
        /// Синглтон для получения кривой Коха.
        /// </summary>
        /// <param name="panelWidth">
        /// Ширина панели, в которой будет рисоваться фрактал.</param>
        /// <param name="panelHeight">
        /// Высота панели.</param>
        /// <returns></returns>
        public static KochCurve GetKochCurve(int panelWidth, int panelHeight)
        {
            if (curve == null)
            {
                lock (syncRoot)
                {
                    if (curve == null)
                        curve = new KochCurve(panelWidth, panelHeight); ;
                }
            }
            else
            { curve.UpdateStartPosition(panelWidth, panelHeight); }
            return curve;
        }

        /// <summary>
        /// Метод который вызывает рисование прямой Коха.
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            DrawCurve(g, startPoint, endPoint, numOfRecurSteps, length, new Pen(fractalPen.Color, fractalPen.Width), Math.PI / 3, NumOfRecurSteps);
        }

        /// <summary>
        /// Метод рисующий кривую Коха.
        /// </summary>
        /// <param name="g">
        /// Graphics.</param>
        /// <param name="p1">
        /// Первая точка.</param>
        /// <param name="p2">
        /// Вторая точка.</param>
        /// <param name="numOfSteps">
        /// Шаг рекурсии.</param>
        /// <param name="len">
        /// Длина.</param>
        /// <param name="pen">
        /// Ручка.</param>
        /// <param name="angle">
        /// Угол.</param>
        /// <param name="colorNum">
        /// Параметр для определения цвета.</param>
        private void DrawCurve(Graphics g, Point p1, Point p2, int numOfSteps, double len, Pen pen, double angle, int colorNum)
        {
            // Условие выхода из рекурсии.
            if (numOfSteps != 0 && len > 1)  
            {
                // Получение точек среднего отрезка.
                var mid1 = new Point(p1.X + (p2.X - p1.X) / 3, p1.Y + (p2.Y - p1.Y) / 3);
                var mid2 = new Point(p1.X + 2 * (p2.X - p1.X) / 3, p1.Y + 2 * (p2.Y - p1.Y) / 3);

                len = len / 3;

                var anp = new Point((int)(mid1.X + Math.Cos(angle) * len), (int)(mid1.Y - Math.Sin(angle) * len));

                if (pen.Width - 0.3 > 0)
                    pen.Width -= (float)0.3;
                else
                    pen.Width = (float)0.1;

                // Уменьшаем количество шаго  рекурсии, которое осталось.
                numOfSteps--;

                // Рисуем следующие куски;
                DrawCurve(g, p1, mid1, numOfSteps, len, new Pen(pen.Color, pen.Width), angle, colorNum);
                DrawCurve(g, mid2, p2, numOfSteps, len, new Pen(pen.Color, pen.Width), angle, colorNum);
                DrawCurve(g, mid1, anp, numOfSteps, len, new Pen(pen.Color, pen.Width), angle + Math.PI / 3, colorNum - 1);
                DrawCurve(g, anp, mid2, numOfSteps, len, new Pen(pen.Color, pen.Width), angle - Math.PI / 3, colorNum - 1);
            }
            else 
            {
                pen.Color = GetFractalPenGradientColor(colorNum);
                g.DrawLine(pen, p1, p2);
            }
        }

        /// <summary>
        /// Метод обновления стартовой позиции.
        /// Позиция зависит от рамеров панели.
        /// </summary>
        /// <param name="panelWidth">
        /// Ширина паели.</param>
        /// <param name="panelHeight">
        /// Высота панели.</param>
        public override void UpdateStartPosition(int panelWidth, int panelHeight)
        {
            int pw = panelWidth / 10;
            startPoint = new Point(0 + pw, panelHeight / 2);
            endPoint = new Point(panelWidth - pw, panelHeight / 2);
            length = Math.Sqrt((startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) + (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y));
        }

    }
}
