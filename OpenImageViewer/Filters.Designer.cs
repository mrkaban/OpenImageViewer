namespace OpenImageViewer
{
    partial class Filters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filters));
            this.btApply = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btUndo = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.lblStdDev = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMedian = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEdges = new System.Windows.Forms.ComboBox();
            this.rbRotate = new System.Windows.Forms.RadioButton();
            this.rbEdges = new System.Windows.Forms.RadioButton();
            this.rbJitter = new System.Windows.Forms.RadioButton();
            this.rbPixelate = new System.Windows.Forms.RadioButton();
            this.rbSepia = new System.Windows.Forms.RadioButton();
            this.rbOil = new System.Windows.Forms.RadioButton();
            this.rbBlur = new System.Windows.Forms.RadioButton();
            this.rbSharp = new System.Windows.Forms.RadioButton();
            this.rbSmooth = new System.Windows.Forms.RadioButton();
            this.rbMedian = new System.Windows.Forms.RadioButton();
            this.rbInvert = new System.Windows.Forms.RadioButton();
            this.rbGray = new System.Windows.Forms.RadioButton();
            this.tbBr = new System.Windows.Forms.TextBox();
            this.tbGamma = new System.Windows.Forms.TextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tbContrast = new System.Windows.Forms.TextBox();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSat = new System.Windows.Forms.TextBox();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBin = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPerc = new System.Windows.Forms.Label();
            this.histogram1 = new IPLab.Histogram();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            this.SuspendLayout();
            // 
            // btApply
            // 
            this.btApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btApply.Location = new System.Drawing.Point(180, 404);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(75, 23);
            this.btApply.TabIndex = 0;
            this.btApply.Text = "Принять";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(365, 404);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Закрыть";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btUndo
            // 
            this.btUndo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btUndo.Enabled = false;
            this.btUndo.Location = new System.Drawing.Point(273, 404);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(75, 23);
            this.btUndo.TabIndex = 12;
            this.btUndo.Text = "Вернуть";
            this.btUndo.UseVisualStyleBackColor = true;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Красный",
            "Зеленый",
            "Синий",
            "Серый"});
            this.comboBox1.Location = new System.Drawing.Point(440, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Text = "Красный";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Канал:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Среднее:";
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Location = new System.Drawing.Point(427, 236);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(0, 13);
            this.lblMean.TabIndex = 18;
            // 
            // lblStdDev
            // 
            this.lblStdDev.AutoSize = true;
            this.lblStdDev.Location = new System.Drawing.Point(427, 261);
            this.lblStdDev.Name = "lblStdDev";
            this.lblStdDev.Size = new System.Drawing.Size(0, 13);
            this.lblStdDev.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Стд. Отклон.:";
            // 
            // lblMedian
            // 
            this.lblMedian.AutoSize = true;
            this.lblMedian.Location = new System.Drawing.Point(427, 285);
            this.lblMedian.Name = "lblMedian";
            this.lblMedian.Size = new System.Drawing.Size(0, 13);
            this.lblMedian.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Медиана:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Мин:";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(551, 236);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(0, 13);
            this.lblMin.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(503, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Макс:";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(551, 261);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(0, 13);
            this.lblMax.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Яркость:";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(89, 223);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = -100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(160, 45);
            this.trackBar1.TabIndex = 28;
            this.trackBar1.TickFrequency = 20;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEdges);
            this.groupBox1.Controls.Add(this.rbRotate);
            this.groupBox1.Controls.Add(this.rbEdges);
            this.groupBox1.Controls.Add(this.rbJitter);
            this.groupBox1.Controls.Add(this.rbPixelate);
            this.groupBox1.Controls.Add(this.rbSepia);
            this.groupBox1.Controls.Add(this.rbOil);
            this.groupBox1.Controls.Add(this.rbBlur);
            this.groupBox1.Controls.Add(this.rbSharp);
            this.groupBox1.Controls.Add(this.rbSmooth);
            this.groupBox1.Controls.Add(this.rbMedian);
            this.groupBox1.Controls.Add(this.rbInvert);
            this.groupBox1.Controls.Add(this.rbGray);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 205);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтры";
            // 
            // cmbEdges
            // 
            this.cmbEdges.FormattingEnabled = true;
            this.cmbEdges.Items.AddRange(new object[] {
            "Конволюция",
            "Гомогенность",
            "Различие",
            "Собел"});
            this.cmbEdges.Location = new System.Drawing.Point(210, 110);
            this.cmbEdges.Name = "cmbEdges";
            this.cmbEdges.Size = new System.Drawing.Size(84, 21);
            this.cmbEdges.TabIndex = 47;
            this.cmbEdges.Text = "Конволюция";
            this.cmbEdges.SelectedIndexChanged += new System.EventHandler(this.cmbEdges_SelectedIndexChanged);
            this.cmbEdges.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbEdges_MouseClick);
            // 
            // rbRotate
            // 
            this.rbRotate.AutoSize = true;
            this.rbRotate.Location = new System.Drawing.Point(149, 134);
            this.rbRotate.Name = "rbRotate";
            this.rbRotate.Size = new System.Drawing.Size(125, 17);
            this.rbRotate.TabIndex = 46;
            this.rbRotate.TabStop = true;
            this.rbRotate.Text = "Чередовать краски";
            this.rbRotate.UseVisualStyleBackColor = true;
            // 
            // rbEdges
            // 
            this.rbEdges.AutoSize = true;
            this.rbEdges.Location = new System.Drawing.Point(149, 111);
            this.rbEdges.Name = "rbEdges";
            this.rbEdges.Size = new System.Drawing.Size(55, 17);
            this.rbEdges.TabIndex = 45;
            this.rbEdges.TabStop = true;
            this.rbEdges.Text = "Грани";
            this.rbEdges.UseVisualStyleBackColor = true;
            // 
            // rbJitter
            // 
            this.rbJitter.AutoSize = true;
            this.rbJitter.Location = new System.Drawing.Point(149, 88);
            this.rbJitter.Name = "rbJitter";
            this.rbJitter.Size = new System.Drawing.Size(78, 17);
            this.rbJitter.TabIndex = 44;
            this.rbJitter.TabStop = true;
            this.rbJitter.Text = "Дрожание";
            this.rbJitter.UseVisualStyleBackColor = true;
            // 
            // rbPixelate
            // 
            this.rbPixelate.AutoSize = true;
            this.rbPixelate.Location = new System.Drawing.Point(149, 65);
            this.rbPixelate.Name = "rbPixelate";
            this.rbPixelate.Size = new System.Drawing.Size(99, 17);
            this.rbPixelate.TabIndex = 43;
            this.rbPixelate.TabStop = true;
            this.rbPixelate.Text = "Пикселизация";
            this.rbPixelate.UseVisualStyleBackColor = true;
            // 
            // rbSepia
            // 
            this.rbSepia.AutoSize = true;
            this.rbSepia.Location = new System.Drawing.Point(149, 42);
            this.rbSepia.Name = "rbSepia";
            this.rbSepia.Size = new System.Drawing.Size(56, 17);
            this.rbSepia.TabIndex = 42;
            this.rbSepia.TabStop = true;
            this.rbSepia.Text = "Сепия";
            this.rbSepia.UseVisualStyleBackColor = true;
            // 
            // rbOil
            // 
            this.rbOil.AutoSize = true;
            this.rbOil.Location = new System.Drawing.Point(149, 19);
            this.rbOil.Name = "rbOil";
            this.rbOil.Size = new System.Drawing.Size(121, 17);
            this.rbOil.TabIndex = 41;
            this.rbOil.TabStop = true;
            this.rbOil.Text = "Живопись маслом";
            this.rbOil.UseVisualStyleBackColor = true;
            // 
            // rbBlur
            // 
            this.rbBlur.AutoSize = true;
            this.rbBlur.Location = new System.Drawing.Point(9, 134);
            this.rbBlur.Name = "rbBlur";
            this.rbBlur.Size = new System.Drawing.Size(77, 17);
            this.rbBlur.TabIndex = 40;
            this.rbBlur.TabStop = true;
            this.rbBlur.Text = "Размытие";
            this.rbBlur.UseVisualStyleBackColor = true;
            // 
            // rbSharp
            // 
            this.rbSharp.AutoSize = true;
            this.rbSharp.Location = new System.Drawing.Point(9, 111);
            this.rbSharp.Name = "rbSharp";
            this.rbSharp.Size = new System.Drawing.Size(129, 17);
            this.rbSharp.TabIndex = 39;
            this.rbSharp.TabStop = true;
            this.rbSharp.Text = "Увеличить резкость";
            this.rbSharp.UseVisualStyleBackColor = true;
            // 
            // rbSmooth
            // 
            this.rbSmooth.AutoSize = true;
            this.rbSmooth.Location = new System.Drawing.Point(9, 88);
            this.rbSmooth.Name = "rbSmooth";
            this.rbSmooth.Size = new System.Drawing.Size(93, 17);
            this.rbSmooth.TabIndex = 38;
            this.rbSmooth.TabStop = true;
            this.rbSmooth.Text = "Сглаживание";
            this.rbSmooth.UseVisualStyleBackColor = true;
            // 
            // rbMedian
            // 
            this.rbMedian.AutoSize = true;
            this.rbMedian.Location = new System.Drawing.Point(9, 65);
            this.rbMedian.Name = "rbMedian";
            this.rbMedian.Size = new System.Drawing.Size(70, 17);
            this.rbMedian.TabIndex = 37;
            this.rbMedian.TabStop = true;
            this.rbMedian.Text = "Медиана";
            this.rbMedian.UseVisualStyleBackColor = true;
            // 
            // rbInvert
            // 
            this.rbInvert.AutoSize = true;
            this.rbInvert.Location = new System.Drawing.Point(9, 42);
            this.rbInvert.Name = "rbInvert";
            this.rbInvert.Size = new System.Drawing.Size(75, 17);
            this.rbInvert.TabIndex = 36;
            this.rbInvert.TabStop = true;
            this.rbInvert.Text = "Инверсия";
            this.rbInvert.UseVisualStyleBackColor = true;
            // 
            // rbGray
            // 
            this.rbGray.AutoSize = true;
            this.rbGray.Location = new System.Drawing.Point(9, 19);
            this.rbGray.Name = "rbGray";
            this.rbGray.Size = new System.Drawing.Size(111, 17);
            this.rbGray.TabIndex = 35;
            this.rbGray.TabStop = true;
            this.rbGray.Text = "Градации серого";
            this.rbGray.UseVisualStyleBackColor = true;
            // 
            // tbBr
            // 
            this.tbBr.Location = new System.Drawing.Point(255, 229);
            this.tbBr.Name = "tbBr";
            this.tbBr.Size = new System.Drawing.Size(54, 20);
            this.tbBr.TabIndex = 31;
            this.tbBr.Text = "0";
            // 
            // tbGamma
            // 
            this.tbGamma.Location = new System.Drawing.Point(255, 361);
            this.tbGamma.Name = "tbGamma";
            this.tbGamma.Size = new System.Drawing.Size(54, 20);
            this.tbGamma.TabIndex = 34;
            this.tbGamma.Text = "1.0";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 10;
            this.trackBar2.Location = new System.Drawing.Point(89, 355);
            this.trackBar2.Maximum = 500;
            this.trackBar2.Minimum = 10;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(160, 45);
            this.trackBar2.TabIndex = 33;
            this.trackBar2.TickFrequency = 20;
            this.trackBar2.Value = 100;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Гамма:";
            // 
            // tbContrast
            // 
            this.tbContrast.Location = new System.Drawing.Point(255, 267);
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(54, 20);
            this.tbContrast.TabIndex = 37;
            this.tbContrast.Text = "1.0";
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 10;
            this.trackBar3.Location = new System.Drawing.Point(89, 261);
            this.trackBar3.Maximum = 500;
            this.trackBar3.Minimum = 1;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(160, 45);
            this.trackBar3.TabIndex = 36;
            this.trackBar3.TickFrequency = 20;
            this.trackBar3.Value = 100;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Контраст:";
            // 
            // tbSat
            // 
            this.tbSat.Location = new System.Drawing.Point(255, 313);
            this.tbSat.Name = "tbSat";
            this.tbSat.Size = new System.Drawing.Size(54, 20);
            this.tbSat.TabIndex = 40;
            this.tbSat.Text = "0";
            // 
            // trackBar4
            // 
            this.trackBar4.LargeChange = 10;
            this.trackBar4.Location = new System.Drawing.Point(89, 307);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Minimum = -100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(160, 45);
            this.trackBar4.TabIndex = 39;
            this.trackBar4.TickFrequency = 20;
            this.trackBar4.ValueChanged += new System.EventHandler(this.trackBar4_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Насыщение:";
            // 
            // tbBin
            // 
            this.tbBin.Location = new System.Drawing.Point(557, 361);
            this.tbBin.Name = "tbBin";
            this.tbBin.Size = new System.Drawing.Size(54, 20);
            this.tbBin.TabIndex = 43;
            this.tbBin.Text = "128";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(337, 361);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Бин. Порог:";
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(408, 355);
            this.trackBar5.Maximum = 255;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(143, 45);
            this.trackBar5.TabIndex = 44;
            this.trackBar5.TickFrequency = 16;
            this.trackBar5.Value = 128;
            this.trackBar5.ValueChanged += new System.EventHandler(this.trackBar5_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(368, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Уровень:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(427, 307);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 13);
            this.lblLevel.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(503, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Кол-во:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(547, 307);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(368, 330);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "   % :";
            // 
            // lblPerc
            // 
            this.lblPerc.AutoSize = true;
            this.lblPerc.Location = new System.Drawing.Point(427, 330);
            this.lblPerc.Name = "lblPerc";
            this.lblPerc.Size = new System.Drawing.Size(0, 13);
            this.lblPerc.TabIndex = 50;
            // 
            // histogram1
            // 
            this.histogram1.AllowSelection = true;
            this.histogram1.Location = new System.Drawing.Point(340, 56);
            this.histogram1.Name = "histogram1";
            this.histogram1.Size = new System.Drawing.Size(267, 161);
            this.histogram1.TabIndex = 14;
            this.histogram1.Text = "histogram1";
            this.histogram1.PositionChanged += new IPLab.Histogram.HistogramEventHandler(this.histogram1_PositionChanged);
            this.histogram1.SelectionChanged += new IPLab.Histogram.HistogramEventHandler(this.histogram1_SelectionChanged);
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(619, 438);
            this.ControlBox = false;
            this.Controls.Add(this.lblPerc);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.tbBin);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbSat);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbContrast);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbGamma);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbBr);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMedian);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblStdDev);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.histogram1);
            this.Controls.Add(this.btUndo);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Filters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фильтры";
            this.Load += new System.EventHandler(this.Filters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btUndo;
        private IPLab.Histogram histogram1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Label lblStdDev;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMedian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbBr;
        private System.Windows.Forms.TextBox tbGamma;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbGray;
        private System.Windows.Forms.RadioButton rbInvert;
        private System.Windows.Forms.RadioButton rbSmooth;
        private System.Windows.Forms.RadioButton rbMedian;
        private System.Windows.Forms.RadioButton rbBlur;
        private System.Windows.Forms.RadioButton rbSharp;
        private System.Windows.Forms.RadioButton rbRotate;
        private System.Windows.Forms.RadioButton rbEdges;
        private System.Windows.Forms.RadioButton rbJitter;
        private System.Windows.Forms.RadioButton rbPixelate;
        private System.Windows.Forms.RadioButton rbSepia;
        private System.Windows.Forms.RadioButton rbOil;
        private System.Windows.Forms.TextBox tbContrast;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSat;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbBin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPerc;
        private System.Windows.Forms.ComboBox cmbEdges;
    }
}