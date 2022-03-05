using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace fractalsApp.FractalClasses
{
    class CantorSet : Fractal
    {
        public static int Distance { get; set; }

        static CantorSet()
        {
            Distance = 25;
        }
        private CantorSet(int panelWidth, int panelHeight) : base(panelWidth, panelHeight)
        { }

        private static CantorSet set;
        private static object syncRoot = new Object();
        /// <summary>
        /// Синглтон для получения множества Кантора.
        /// </summary>
        /// <param name="panelWidth">
        /// Ширина панели, в которой будет рисоваться ковер.
        /// </param>
        /// <param name="panelHeight">
        /// Высота панели.
        /// </param>
        /// <returns></returns>
        public static CantorSet GetCantorSet(int panelWidth, int panelHeight)
        {
            if (set == null)
            {
                lock (syncRoot)
                {
                    if (set == null)
                        set = new CantorSet(panelWidth, panelHeight); ;
                }
            }
            else
            { set.UpdateStartPosition(panelWidth, panelHeight); }
            return set;
        }

        /// <summary>
        /// Метод рисования множества Кантора. 
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            DrawCantorSet(g, startPoint, length, numOfRecurSteps);
        }

        /// <summary>
        /// Рекурсивная функция, рисующая множество кантора.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="oldPoint"></param>
        /// <param name="len"></param>
        /// <param name="numOfSteps"></param>
        private void DrawCantorSet(Graphics g, Point oldPoint, double len, int numOfSteps)
        {
            if (numOfSteps != 0 && len >= 0)
            {
                var oldPoint2 = new Point((int)Math.Round(oldPoint.X + len), oldPoint.Y);
                Fractal.fractalPen.Color = GetFractalPenGradientColor(numOfSteps);
                g.DrawLine(fractalPen, oldPoint, oldPoint2);

                double l = len / 3;
                var p1 = new Point(oldPoint.X, oldPoint.Y + Distance);
                var p2 = new Point((int)Math.Round(oldPoint2.X - l), oldPoint2.Y + Distance);

                numOfSteps--;
                DrawCantorSet(g, p1, l, numOfSteps);
                DrawCantorSet(g, p2, l, numOfSteps);
            }
            else { }
        }

        /// <summary>
        /// Обновление позиции в зависимости от размеров панели, на которой рисуется фрактал.
        /// </summary>
        /// <param name="panelWidth"></param>
        /// <param name="panelHeight"></param>
        public override void UpdateStartPosition(int panelWidth, int panelHeight)
        {
            startPoint = new Point((int)(panelWidth / 10), (int)(1 *panelHeight / 9));
            endPoint = new Point((int)(panelWidth - panelWidth / 10), (int)(1 * panelHeight / 9));
            length = Math.Sqrt((startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) + (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y));
        }

    }
}
