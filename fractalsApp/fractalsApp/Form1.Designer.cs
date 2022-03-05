namespace fractalsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.distanceGroupBox = new System.Windows.Forms.GroupBox();
            this.distanceTrackBar = new System.Windows.Forms.TrackBar();
            this.colorsBox = new System.Windows.Forms.GroupBox();
            this.collorButton2 = new System.Windows.Forms.Button();
            this.collorButton1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numOfRecurStepsTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.coefficientNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.anglesGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.angle2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.angle1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fractalsGroupBox = new System.Windows.Forms.GroupBox();
            this.CantorSetRadioButton5 = new System.Windows.Forms.RadioButton();
            this.SierpinskiTriangleRadioButton4 = new System.Windows.Forms.RadioButton();
            this.sierpinskiCarpetRadioButton3 = new System.Windows.Forms.RadioButton();
            this.KochCurveRadioButton2 = new System.Windows.Forms.RadioButton();
            this.treeRadioButton1 = new System.Windows.Forms.RadioButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.fractalBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.settingsGroupBox.SuspendLayout();
            this.distanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceTrackBar)).BeginInit();
            this.colorsBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfRecurStepsTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coefficientNumericUpDown)).BeginInit();
            this.anglesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angle2NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle1NumericUpDown)).BeginInit();
            this.fractalsGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.settingsGroupBox.Controls.Add(this.distanceGroupBox);
            this.settingsGroupBox.Controls.Add(this.colorsBox);
            this.settingsGroupBox.Controls.Add(this.groupBox2);
            this.settingsGroupBox.Controls.Add(this.groupBox1);
            this.settingsGroupBox.Controls.Add(this.anglesGroupBox);
            this.settingsGroupBox.Controls.Add(this.fractalsGroupBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(0, 31);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(335, 518);
            this.settingsGroupBox.TabIndex = 0;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            this.settingsGroupBox.Enter += new System.EventHandler(this.settingsGroupBox_Enter);
            // 
            // distanceGroupBox
            // 
            this.distanceGroupBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.distanceGroupBox.Controls.Add(this.distanceTrackBar);
            this.distanceGroupBox.Location = new System.Drawing.Point(174, 227);
            this.distanceGroupBox.Name = "distanceGroupBox";
            this.distanceGroupBox.Size = new System.Drawing.Size(147, 108);
            this.distanceGroupBox.TabIndex = 4;
            this.distanceGroupBox.TabStop = false;
            this.distanceGroupBox.Text = "Cantor Set Distance";
            // 
            // distanceTrackBar
            // 
            this.distanceTrackBar.Location = new System.Drawing.Point(6, 43);
            this.distanceTrackBar.Maximum = 100;
            this.distanceTrackBar.Minimum = 15;
            this.distanceTrackBar.Name = "distanceTrackBar";
            this.distanceTrackBar.Size = new System.Drawing.Size(130, 56);
            this.distanceTrackBar.TabIndex = 5;
            this.distanceTrackBar.Value = 25;
            this.distanceTrackBar.Scroll += new System.EventHandler(this.distanceTrackBar_Scroll);
            // 
            // colorsBox
            // 
            this.colorsBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.colorsBox.Controls.Add(this.collorButton2);
            this.colorsBox.Controls.Add(this.collorButton1);
            this.colorsBox.Location = new System.Drawing.Point(9, 305);
            this.colorsBox.Name = "colorsBox";
            this.colorsBox.Size = new System.Drawing.Size(159, 75);
            this.colorsBox.TabIndex = 0;
            this.colorsBox.TabStop = false;
            this.colorsBox.Text = "Colors:";
            // 
            // collorButton2
            // 
            this.collorButton2.Location = new System.Drawing.Point(81, 26);
            this.collorButton2.Name = "collorButton2";
            this.collorButton2.Size = new System.Drawing.Size(69, 37);
            this.collorButton2.TabIndex = 1;
            this.collorButton2.Text = "to";
            this.collorButton2.UseVisualStyleBackColor = true;
            this.collorButton2.Click += new System.EventHandler(this.collorButton2_Click);
            // 
            // collorButton1
            // 
            this.collorButton1.Location = new System.Drawing.Point(6, 26);
            this.collorButton1.Name = "collorButton1";
            this.collorButton1.Size = new System.Drawing.Size(69, 37);
            this.collorButton1.TabIndex = 0;
            this.collorButton1.Text = "from";
            this.collorButton1.UseVisualStyleBackColor = true;
            this.collorButton1.Click += new System.EventHandler(this.collorButton1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.numOfRecurStepsTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(174, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 111);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Num Of Recursion Steps:";
            // 
            // numOfRecurStepsTrackBar
            // 
            this.numOfRecurStepsTrackBar.Location = new System.Drawing.Point(6, 49);
            this.numOfRecurStepsTrackBar.Maximum = 15;
            this.numOfRecurStepsTrackBar.Minimum = 1;
            this.numOfRecurStepsTrackBar.Name = "numOfRecurStepsTrackBar";
            this.numOfRecurStepsTrackBar.Size = new System.Drawing.Size(135, 56);
            this.numOfRecurStepsTrackBar.TabIndex = 1;
            this.numOfRecurStepsTrackBar.Value = 7;
            this.numOfRecurStepsTrackBar.Scroll += new System.EventHandler(this.numOfRecurStepsTrackBar_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.coefficientNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(174, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coefficient:";
            // 
            // coefficientNumericUpDown
            // 
            this.coefficientNumericUpDown.DecimalPlaces = 2;
            this.coefficientNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.coefficientNumericUpDown.Location = new System.Drawing.Point(6, 26);
            this.coefficientNumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.coefficientNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.coefficientNumericUpDown.Name = "coefficientNumericUpDown";
            this.coefficientNumericUpDown.Size = new System.Drawing.Size(79, 27);
            this.coefficientNumericUpDown.TabIndex = 0;
            this.coefficientNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.coefficientNumericUpDown.ValueChanged += new System.EventHandler(this.coefficientNumericUpDown_ValueChanged);
            // 
            // anglesGroupBox
            // 
            this.anglesGroupBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.anglesGroupBox.Controls.Add(this.label2);
            this.anglesGroupBox.Controls.Add(this.label1);
            this.anglesGroupBox.Controls.Add(this.angle2NumericUpDown);
            this.anglesGroupBox.Controls.Add(this.angle1NumericUpDown);
            this.anglesGroupBox.Location = new System.Drawing.Point(6, 212);
            this.anglesGroupBox.Name = "anglesGroupBox";
            this.anglesGroupBox.Size = new System.Drawing.Size(162, 87);
            this.anglesGroupBox.TabIndex = 1;
            this.anglesGroupBox.TabStop = false;
            this.anglesGroupBox.Text = "Angles:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Angle 2 = PI / ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Angle 1 = PI / ";
            // 
            // angle2NumericUpDown
            // 
            this.angle2NumericUpDown.DecimalPlaces = 1;
            this.angle2NumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.angle2NumericUpDown.Location = new System.Drawing.Point(112, 56);
            this.angle2NumericUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.angle2NumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.angle2NumericUpDown.Name = "angle2NumericUpDown";
            this.angle2NumericUpDown.Size = new System.Drawing.Size(44, 27);
            this.angle2NumericUpDown.TabIndex = 1;
            this.angle2NumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.angle2NumericUpDown.ValueChanged += new System.EventHandler(this.angle2NumericUpDown_ValueChanged);
            // 
            // angle1NumericUpDown
            // 
            this.angle1NumericUpDown.DecimalPlaces = 1;
            this.angle1NumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.angle1NumericUpDown.Location = new System.Drawing.Point(112, 21);
            this.angle1NumericUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.angle1NumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.angle1NumericUpDown.Name = "angle1NumericUpDown";
            this.angle1NumericUpDown.Size = new System.Drawing.Size(44, 27);
            this.angle1NumericUpDown.TabIndex = 0;
            this.angle1NumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.angle1NumericUpDown.ValueChanged += new System.EventHandler(this.angle1NumericUpDown_ValueChanged);
            // 
            // fractalsGroupBox
            // 
            this.fractalsGroupBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fractalsGroupBox.Controls.Add(this.CantorSetRadioButton5);
            this.fractalsGroupBox.Controls.Add(this.SierpinskiTriangleRadioButton4);
            this.fractalsGroupBox.Controls.Add(this.sierpinskiCarpetRadioButton3);
            this.fractalsGroupBox.Controls.Add(this.KochCurveRadioButton2);
            this.fractalsGroupBox.Controls.Add(this.treeRadioButton1);
            this.fractalsGroupBox.Location = new System.Drawing.Point(6, 36);
            this.fractalsGroupBox.Name = "fractalsGroupBox";
            this.fractalsGroupBox.Size = new System.Drawing.Size(162, 170);
            this.fractalsGroupBox.TabIndex = 0;
            this.fractalsGroupBox.TabStop = false;
            this.fractalsGroupBox.Text = "Fractals:";
            // 
            // CantorSetRadioButton5
            // 
            this.CantorSetRadioButton5.AutoSize = true;
            this.CantorSetRadioButton5.Location = new System.Drawing.Point(7, 143);
            this.CantorSetRadioButton5.Name = "CantorSetRadioButton5";
            this.CantorSetRadioButton5.Size = new System.Drawing.Size(99, 24);
            this.CantorSetRadioButton5.TabIndex = 4;
            this.CantorSetRadioButton5.TabStop = true;
            this.CantorSetRadioButton5.Text = "Cantor Set";
            this.CantorSetRadioButton5.UseVisualStyleBackColor = true;
            this.CantorSetRadioButton5.CheckedChanged += new System.EventHandler(this.CantorSetRadioButton5_CheckedChanged);
            // 
            // SierpinskiTriangleRadioButton4
            // 
            this.SierpinskiTriangleRadioButton4.AutoSize = true;
            this.SierpinskiTriangleRadioButton4.Location = new System.Drawing.Point(7, 117);
            this.SierpinskiTriangleRadioButton4.Name = "SierpinskiTriangleRadioButton4";
            this.SierpinskiTriangleRadioButton4.Size = new System.Drawing.Size(150, 24);
            this.SierpinskiTriangleRadioButton4.TabIndex = 3;
            this.SierpinskiTriangleRadioButton4.TabStop = true;
            this.SierpinskiTriangleRadioButton4.Text = "Sierpinski Triangle";
            this.SierpinskiTriangleRadioButton4.UseVisualStyleBackColor = true;
            this.SierpinskiTriangleRadioButton4.CheckedChanged += new System.EventHandler(this.SierpinskiTriangleRadioButton4_CheckedChanged);
            // 
            // sierpinskiCarpetRadioButton3
            // 
            this.sierpinskiCarpetRadioButton3.AutoSize = true;
            this.sierpinskiCarpetRadioButton3.Location = new System.Drawing.Point(7, 87);
            this.sierpinskiCarpetRadioButton3.Name = "sierpinskiCarpetRadioButton3";
            this.sierpinskiCarpetRadioButton3.Size = new System.Drawing.Size(141, 24);
            this.sierpinskiCarpetRadioButton3.TabIndex = 2;
            this.sierpinskiCarpetRadioButton3.TabStop = true;
            this.sierpinskiCarpetRadioButton3.Text = "Sierpinski Carpet";
            this.sierpinskiCarpetRadioButton3.UseVisualStyleBackColor = true;
            this.sierpinskiCarpetRadioButton3.CheckedChanged += new System.EventHandler(this.sierpinskiCarpetRadioButton3_CheckedChanged);
            // 
            // KochCurveRadioButton2
            // 
            this.KochCurveRadioButton2.AutoSize = true;
            this.KochCurveRadioButton2.Location = new System.Drawing.Point(7, 57);
            this.KochCurveRadioButton2.Name = "KochCurveRadioButton2";
            this.KochCurveRadioButton2.Size = new System.Drawing.Size(104, 24);
            this.KochCurveRadioButton2.TabIndex = 1;
            this.KochCurveRadioButton2.TabStop = true;
            this.KochCurveRadioButton2.Text = "Koch Curve";
            this.KochCurveRadioButton2.UseVisualStyleBackColor = true;
            this.KochCurveRadioButton2.CheckedChanged += new System.EventHandler(this.KochCurveRadioButton2_CheckedChanged);
            // 
            // treeRadioButton1
            // 
            this.treeRadioButton1.AutoSize = true;
            this.treeRadioButton1.Checked = true;
            this.treeRadioButton1.Location = new System.Drawing.Point(7, 27);
            this.treeRadioButton1.Name = "treeRadioButton1";
            this.treeRadioButton1.Size = new System.Drawing.Size(135, 24);
            this.treeRadioButton1.TabIndex = 0;
            this.treeRadioButton1.TabStop = true;
            this.treeRadioButton1.Text = "Pythagoras Tree";
            this.treeRadioButton1.UseVisualStyleBackColor = true;
            this.treeRadioButton1.CheckedChanged += new System.EventHandler(this.treeRadioButton1_CheckedChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(925, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.SaveAsToolStripMenuItem.Text = "Save image As";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "BMP files|*.bmp";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(341, 31);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(584, 497);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.SizeChanged += new System.EventHandler(this.mainPanel_SizeChanged);
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // fractalBackgroundWorker
            // 
            this.fractalBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fractalBackgroundWorker_DoWork);
            this.fractalBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fractalBackgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(925, 527);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.menuStrip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.settingsGroupBox.ResumeLayout(false);
            this.distanceGroupBox.ResumeLayout(false);
            this.distanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceTrackBar)).EndInit();
            this.colorsBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfRecurStepsTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coefficientNumericUpDown)).EndInit();
            this.anglesGroupBox.ResumeLayout(false);
            this.anglesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angle2NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle1NumericUpDown)).EndInit();
            this.fractalsGroupBox.ResumeLayout(false);
            this.fractalsGroupBox.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.GroupBox fractalsGroupBox;
        private System.Windows.Forms.RadioButton KochCurveRadioButton2;
        private System.Windows.Forms.RadioButton treeRadioButton1;
        private System.Windows.Forms.RadioButton CantorSetRadioButton5;
        private System.Windows.Forms.RadioButton SierpinskiTriangleRadioButton4;
        private System.Windows.Forms.RadioButton sierpinskiCarpetRadioButton3;
        private System.Windows.Forms.GroupBox anglesGroupBox;
        private System.Windows.Forms.NumericUpDown angle2NumericUpDown;
        private System.Windows.Forms.NumericUpDown angle1NumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown coefficientNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar numOfRecurStepsTrackBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel mainPanel;
        private System.ComponentModel.BackgroundWorker fractalBackgroundWorker;
        private System.Windows.Forms.GroupBox colorsBox;
        private System.Windows.Forms.Button collorButton2;
        private System.Windows.Forms.Button collorButton1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox distanceGroupBox;
        private System.Windows.Forms.TrackBar distanceTrackBar;
    }
}

