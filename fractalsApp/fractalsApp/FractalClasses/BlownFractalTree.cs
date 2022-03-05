using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace fractalsApp.FractalClasses
{
   

    sealed class BlownFractalTree: Fractal
    {

        // Первый угол.
        public static double Angle1 { get; set; }
        // Второй угол.
        public static double Angle2 { get; set; }

        // Статический конструктор.
        static BlownFractalTree()
        {
            Angle1 = Math.PI / 4;
            Angle2 = Math.PI / 4;
        }

        private BlownFractalTree(int panelWidth, int panelHeight): base(panelWidth, panelHeight)
        {
        }

        private static BlownFractalTree tree;
        private static object syncRoot = new Object();
        /// <summary>
        /// Синглтон для получения Пифагорова дерева.
        /// </summary>
        /// <param name="panelWidth">
        /// Ширина панели, в которой будет рисоваться ковер.
        /// </param>
        /// <param name="panelHeight">
        /// Высота панели.
        /// </param>
        /// <returns></returns>
        public static BlownFractalTree GetBlownFractalTree(int panelWidth, int panelHeight)
        {
            if (tree == null)
            {
                lock (syncRoot)
                {
                    if (tree == null)
                        tree = new BlownFractalTree(panelWidth, panelHeight); ;
                }
            }
            else
            { tree.UpdateStartPosition(panelWidth, panelHeight); }
            return tree;
        }

        /// <summary>
        /// Прощитывается и рисуется каждая ветка.
        /// Рекурсивная функция.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="oldPoint">
        /// Предыдущая точка.
        /// </param>
        /// <param name="angle">
        /// Угол(в радианах).
        /// </param>
        /// <param name="len">
        /// Длина предыдущей ветки.
        /// </param>
        /// <param name="numOfSteps">
        /// Количество шагов рекурсии, которые остались.
        /// </param>
        /// <param name="pen">
        /// Ручка.
        /// </param>
        private void drawTree(Graphics g, Point oldPoint, double angle, double len, int numOfSteps, Pen pen)
        {
            // Проверка на корректность текущих данных.
            if (numOfSteps != 0 && len > 2)
            {
                // Определяем следующую точку.
                double newLen = LineCoefficient * len;
                var newPoint = new Point((int)(oldPoint.X + newLen * Math.Cos(angle)), (int)(oldPoint.Y - newLen * Math.Sin(angle)));

                // Уменьшаем ширину ручки для красоты изображения.
                if (pen.Width - 0.4 > 0)
                    pen.Width -= (float)0.4;
                else
                    pen.Width = (float)0.1;
                pen.Color = GetFractalPenGradientColor(numOfSteps);

                // Рисуем ветку.
                g.DrawLine(pen, oldPoint, newPoint);

                numOfSteps--;
                // Из этой ветки рисуем еще две.
                drawTree(g, newPoint, angle + Angle1, newLen, numOfSteps, new Pen(pen.Color, pen.Width));
                drawTree(g, newPoint, angle - Angle2, newLen, numOfSteps, new Pen(pen.Color, pen.Width));
            }
            else
            { }
        }

        
        /// <summary>
        /// Метод рисующий обдуваемое фрактальное дерево.
        /// </summary>
        /// <param name="e"></param>
        public override void Draw(Graphics g)
        {
            fractalPen.Color = ColorFrom;
            // Рисуем первую итерацию. Можно было это сделать в рекурсивной функции, но лень.
            g.DrawLine(fractalPen, startPoint, endPoint);
            // Из этой ветки рисуем две новых.
            drawTree(g, endPoint, Angle1, length, NumOfRecurSteps - 1, new Pen(fractalPen.Color, fractalPen.Width));
            drawTree(g, endPoint, Math.PI-Angle2, length, NumOfRecurSteps - 1, new Pen(fractalPen.Color, fractalPen.Width));
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
            // Получаем точки и обновляем начальные координаты.
            startPoint = new Point(panelWidth / 2, (int)(panelHeight - 2 * panelHeight / 20));
            endPoint = new Point(panelWidth / 2, (int)(panelHeight - 7 * panelHeight / 20));
            length = Math.Sqrt((startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) + (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y));
        }

    }
}
