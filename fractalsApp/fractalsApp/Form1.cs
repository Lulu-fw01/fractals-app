using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fractalsApp.FractalClasses;

namespace fractalsApp
{
    public partial class Form1 : Form
    {
        // Фрактал, объект.
        Fractal activeFractal;

        // Bitmap, где будет рисовться фрактал.
        private Bitmap fractalBitmap;

        public Form1()
        {
            
            InitializeComponent();
            
            //int startWidth = Screen.PrimaryScreen.WorkingArea.Width / 2;
            //int startHeight = Screen.PrimaryScreen.WorkingArea.Height / 2;

            this.DoubleBuffered = true;
            // Устанавливаем максимальный размер формы равный размеру экрана.
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            // Устанавливаем минимальный размер формы, равный половине экрана.
            this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
            // Устанавливаем текущий размер формы, равный минимальному.
            this.Size = MinimumSize;

            // Устанавливаем начальные размеры панели.
            mainPanel.Size = new Size(this.Width - settingsGroupBox.Width, this.Height);
           
            // Присваиваем кнопкам цвет, который сечас у фрактала.
            collorButton1.BackColor = Fractal.ColorFrom;
            collorButton2.BackColor = Fractal.ColorTo;

            
            BlownFractalTree.Angle1 = Math.PI / 4;
            BlownFractalTree.Angle2 = Math.PI / 4;

            coefficientNumericUpDown.Value = (decimal)Fractal.LineCoefficient;
           // numOfRecurStepsTrackBar.Value = Fractal.NumOfRecurSteps;

            // Создаем объект.
            activeFractal = BlownFractalTree.GetBlownFractalTree(mainPanel.Width, mainPanel.Height);
            

        }

        /// <summary>
        /// Изменение количества шагов рекурсии.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numOfRecurStepsTrackBar_Scroll(object sender, EventArgs e)
        {
            int prev = Fractal.NumOfRecurSteps;
            Fractal.NumOfRecurSteps = numOfRecurStepsTrackBar.Value;
            try
            {
                fractalBackgroundWorker.RunWorkerAsync();
            }
            // Ловим ошибку, которая возникает, если пользователь быстро скролит.
            catch (InvalidOperationException)
            {
                Fractal.NumOfRecurSteps = prev;
                numOfRecurStepsTrackBar.Value = prev;
                
            }
            catch (Exception)
            {
                MessageBox.Show("h-m-m-m-m, \n something went wrong with this TrackBar");
            }
        }

        /// <summary>
        /// Коэффициент, который определяет отношение веток в дереве Пифагора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coefficientNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            double prev = Fractal.LineCoefficient;
            Fractal.LineCoefficient = (double)coefficientNumericUpDown.Value;
            try
            {
                fractalBackgroundWorker.RunWorkerAsync();
            }
            catch (InvalidOperationException)
            {
                Fractal.LineCoefficient = prev;
                coefficientNumericUpDown.Value = (decimal)prev;
            }
            catch(Exception)
            {
                MessageBox.Show("h-m-m-m-m, \n something went wrong with this NmericUpDown");
            }
        }

        /// <summary>
        /// Сохранение изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                var fileName = saveFileDialog1.FileName;
                fractalBitmap.Save(fileName);
            }
            catch
            {
                // Ловим ошибку и выводим сообщение если что-то пойдет не так.
                MessageBox.Show("h-m-m-m, something went wrong \n and we didn't save thid picture.");
            }

        }

        /// <summary>
        /// Событие изменения размера формы.
        /// Тут описывается то, что происходит при изменении размеров формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //mainPanel.Size = new Size(this.Width - settingsGroupBox.Width, this.Height); 
            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    mainPanel.Size = new Size(this.Width - settingsGroupBox.Width, this.Height);
                }
            }
            catch
            {
                MessageBox.Show("h-m-m-m, something went wrong with resizing");
            }
        }

        /// <summary>
        /// Изменение размера формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                mainPanel.Size = new Size(this.Width - settingsGroupBox.Width, this.Height);
            }
            catch
            {
                MessageBox.Show("h-m-m-m, something went wrong with resizing");
            }
        }


        /// <summary>
        /// При нажатии на данную кнопку открывается форма выбора цвета. 
        /// Пользователь может выбрать цвет, с которого будет начинаться градиент.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void collorButton1_Click(object sender, EventArgs e)
        {
            
            colorDialog.Color = Fractal.ColorFrom;
            colorDialog.ShowDialog();
            if(colorDialog.Color != Fractal.ColorFrom)
            {
                var prev = Fractal.ColorFrom;
                Fractal.ColorFrom = colorDialog.Color;
                collorButton1.BackColor = colorDialog.Color;
                try
                {
                    fractalBackgroundWorker.RunWorkerAsync();
                }
                catch
                {
                    Fractal.ColorFrom = prev;
                    collorButton1.BackColor = prev;
                    MessageBox.Show("sorry, something went wrong \n and we didn't change color");
                }
            }
        }

        /// <summary>
        /// При нажатии на данную кнопку открывается форма выбора цвета.
        /// Пользователь может выбрать цвет, на который закончится градиент.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void collorButton2_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Fractal.ColorTo;
            colorDialog.ShowDialog();
            if (colorDialog.Color != Fractal.ColorTo)
            {
                var prev = Fractal.ColorTo;
                Fractal.ColorTo = colorDialog.Color;
                collorButton2.BackColor = colorDialog.Color;

                try
                {
                    fractalBackgroundWorker.RunWorkerAsync();
                }
                catch
                {
                    Fractal.ColorTo = prev;
                    collorButton2.BackColor = prev;
                    MessageBox.Show("sorry, something went wrong \n and we didn't change color");
                }
            }
        }


        /// <summary>
        /// Рисование изображения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fractalBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //var rect = (Rectangle)e.Argument;
                //var bitmap = new Bitmap(rect.Width, rect.Height);
                var bitmap = new Bitmap(mainPanel.Width, mainPanel.Height);
                using (var g = Graphics.FromImage(bitmap))
                {
                    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    activeFractal.Draw(g);
                }
                e.Result = bitmap;
            }
            catch
            {
                MessageBox.Show("Something went wrong when we tried to redraw image.");
            }
        }

        /// <summary>
        /// Вызов перерисовки изображения в панели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fractalBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var result = (Bitmap)e.Result;
                this.fractalBitmap = result;
                mainPanel.Invalidate();
            }
            catch
            {
                MessageBox.Show("Something went wrong when we tried to draw image.");
            }
        }



        /// <summary>
        /// Перерисовка панели( фрактала).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (fractalBitmap != null)
                    e.Graphics.DrawImage(fractalBitmap, mainPanel.ClientRectangle);
            }
            catch
            {
                MessageBox.Show("We started to draw new image and something went wrong");
            }
            
        }

        /// <summary>
        /// Что происходит при изменении размеров главной панели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            if (activeFractal != null)
            {
                var prev = mainPanel.Size;
                activeFractal.UpdateStartPosition(mainPanel.Width, mainPanel.Height);
                try
                {
                    fractalBackgroundWorker.RunWorkerAsync();
                }
                catch
                {
                    mainPanel.Size = prev;
                    activeFractal.UpdateStartPosition(prev.Width, prev.Height);
                }
            }
        }

        /// <summary>
        /// Изменение значения первого угла Пифагорова дерева.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angle1NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var prev = angle1NumericUpDown.Value;
            BlownFractalTree.Angle1 = Math.PI / (double)angle1NumericUpDown.Value;
            try
            {
                fractalBackgroundWorker.RunWorkerAsync();
            }
            catch(InvalidOperationException)
            {
                BlownFractalTree.Angle1 = Math.PI / (double)prev;
                angle1NumericUpDown.Value = prev;
            }
            catch(Exception)
            {
                MessageBox.Show("Something went wrong with this Numeric up down");
            }
        }

        /// <summary>
        /// Изменение значения Второго угла пифагорова дерева.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angle2NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var prev = angle2NumericUpDown.Value;
            BlownFractalTree.Angle2 = Math.PI / (double)angle2NumericUpDown.Value;
            try
            {
                fractalBackgroundWorker.RunWorkerAsync();
            }
            catch (InvalidOperationException)
            {
                BlownFractalTree.Angle2 = Math.PI / (double)prev;
                angle2NumericUpDown.Value = prev;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong with this Numeric up down");
            }
        }

        /// <summary>
        /// Выбор пифагорова дерева.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (treeRadioButton1.Checked == true)
                {
                    activeFractal = BlownFractalTree.GetBlownFractalTree(mainPanel.Width, mainPanel.Height);
                    fractalBackgroundWorker.RunWorkerAsync();
                }
            }
            catch { }
        }

        /// <summary>
        /// Выбор кривой Коха.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KochCurveRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (KochCurveRadioButton2.Checked == true)
                {
                    activeFractal = KochCurve.GetKochCurve(mainPanel.Width, mainPanel.Height);
                    fractalBackgroundWorker.RunWorkerAsync();
                }
            }
            catch { }
            
        }

        /// <summary>
        /// Выбор ковра Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sierpinskiCarpetRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (sierpinskiCarpetRadioButton3.Checked == true)
                {
                    activeFractal = SierpinskiCarpet.GetSierpinskiCarpet(mainPanel.Width, mainPanel.Height);
                    fractalBackgroundWorker.RunWorkerAsync();
                }
            }
            catch { }
        }

        /// <summary>
        /// Выбор множества Кантора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CantorSetRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CantorSetRadioButton5.Checked == true)
                {
                    activeFractal = CantorSet.GetCantorSet(mainPanel.Width, mainPanel.Height);
                    fractalBackgroundWorker.RunWorkerAsync();
                }
            }
            catch { }
        }

        /// <summary>
        /// Изменение расстояния между отрзками в множестве кантора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distanceTrackBar_Scroll(object sender, EventArgs e)
        {
            int prev = CantorSet.Distance;
            CantorSet.Distance = distanceTrackBar.Value;
            try
            {
                fractalBackgroundWorker.RunWorkerAsync();
            }
            catch(InvalidOperationException)
            {
                CantorSet.Distance = prev;
                distanceTrackBar.Value = prev;
            }
            catch(Exception)
            {
                MessageBox.Show("h-m-m-m-m, \n something went wrong with this TrackBar");
            }
        }

        /// <summary>
        /// Выбор треугольника Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SierpinskiTriangleRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (SierpinskiTriangleRadioButton4.Checked == true)
                {
                    activeFractal = SierpinskiTriangle.GetSierpinskiTriangle(mainPanel.Width, mainPanel.Height);
                    fractalBackgroundWorker.RunWorkerAsync();
                }
            }
            catch { }
        }

        private void settingsGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
