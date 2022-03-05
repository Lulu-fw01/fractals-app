using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace fractalsApp.FractalClasses
{
    abstract class Fractal
    {
        // Начальная точка.
        protected Point startPoint;
        // Конечная точка.
        protected Point endPoint;

        // Количество шагов рекурсии.
        protected static int numOfRecurSteps;
        public static int NumOfRecurSteps 
        {
            get { return numOfRecurSteps; }
            set 
            { 
                numOfRecurSteps = value;
                gradientColors = GetGradientColors();
            }
        }

        // Длина самого первого отрезка.
        protected double length;

        // Цвет, из которого начинается градиент.
        protected static Color colorFrom;
        /// <summary>
        /// Цвет, из которого начинается градиент.
        /// </summary>
        public static Color ColorFrom 
        {
            get { return colorFrom; }
            set
            {
                colorFrom = value;
                gradientColors = GetGradientColors();
            }
        }

        // Цвет, на котором заканчивается градиент.
        protected static Color colorTo;
        /// <summary>
        /// Цвет, на котором заканчивается градиент.
        /// </summary>
        public static Color ColorTo 
        { 
            get { return colorTo; }
            set
            {
                colorTo = value;
                gradientColors = GetGradientColors();
            }
        
        }

        // Список со всеми граддиентными цветами.
        protected static List<Color> gradientColors;

        // Коэффициент.
        public static double LineCoefficient { get; set; }

        // Шириина ручки.
        public static float PenWidth { get; set; }

        

        protected static Pen fractalPen;

        static Fractal()
        {
            NumOfRecurSteps = 7;
            LineCoefficient = 0.7;
            ColorFrom = Color.White;
            ColorTo = Color.White;
            fractalPen = new Pen(ColorFrom, 4);
            PenWidth = 4;
            gradientColors = GetGradientColors();
        }

        protected Fractal(int panelWidth, int panelHeight)
        {
            UpdateStartPosition(panelWidth, panelHeight);
        }
           
        abstract public void Draw(Graphics g);

        /// <summary>
        /// Метод обновления начальных координат.
        /// </summary>
        /// <param name="panelWidth"></param>
        /// <param name="panelHeight"></param>
        abstract public void UpdateStartPosition(int panelWidth, int panelHeight);

        /// <summary>
        /// Получение списка цветов линейного градиента.
        /// </summary>
        /// <returns></returns>
        protected static List<Color> GetGradientColors()
        {
            List<Color> colorList = new List<Color>();
            if (NumOfRecurSteps < 2)
            {
                colorList.Add(ColorFrom);
            }
            else
            {
                double diffA = ColorTo.A - ColorFrom.A;
                double diffR = ColorTo.R - ColorFrom.R;
                double diffG = ColorTo.G - ColorFrom.G;
                double diffB = ColorTo.B - ColorFrom.B;

                var steps = NumOfRecurSteps - 1;

                var stepA = diffA / steps;
                var stepR = diffR / steps;
                var stepG = diffG / steps;
                var stepB = diffB / steps;

                for (int i = 1; i < NumOfRecurSteps; ++i)
                {
                    var a = ColorFrom.A + (int)(stepA * i);
                    var r = ColorFrom.R + (int)(stepR * i);
                    var g = ColorFrom.G + (int)(stepG * i);
                    var b = ColorFrom.B + (int)(stepB * i);
                    colorList.Add(Color.FromArgb(a, r, g, b));
                }
            }
            return colorList;
        }
        
        /// <summary>
        /// Возвращение цвета, соответствующего шагу рекурсии.
        /// </summary>
        /// <param name="numOfSteps"></param>
        protected static Color GetFractalPenGradientColor(int numOfSteps)
        {
            try
            {
                if (numOfSteps <= 1)
                    return colorTo;
                else
                {
                    if (numOfSteps == numOfRecurSteps)
                        return colorFrom;
                    else
                        return gradientColors[numOfRecurSteps - numOfSteps];
                }
            }
            catch
            {
                return colorTo;
            }
        }


        
    }
}
