namespace ElectroLife
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.layout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.FrameRate = 1000;
            this.openGLControl1.Location = new System.Drawing.Point(3, 3);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(853, 568);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseDown);
            this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseMove);
            this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseUp);
            // 
            // layout
            // 
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.layout.Controls.Add(this.openGLControl1, 0, 0);
            this.layout.Controls.Add(this.panel1, 1, 0);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 1;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Size = new System.Drawing.Size(1159, 574);
            this.layout.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.zoom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(862, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 568);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(97, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Начать новую симуляцию";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.radioButton10);
            this.groupBox2.Controls.Add(this.radioButton9);
            this.groupBox2.Controls.Add(this.radioButton8);
            this.groupBox2.Controls.Add(this.radioButton7);
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Location = new System.Drawing.Point(9, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 141);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Режим отображения";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(167, 20);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(77, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Погибшие";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(7, 109);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(67, 17);
            this.radioButton10.TabIndex = 4;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Возраст";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(7, 86);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(194, 17);
            this.radioButton9.TabIndex = 3;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Многоклеточные\\одноклеточные";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(7, 66);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(143, 17);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Количество минералов";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(7, 43);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(128, 17);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Количество энергии";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(7, 20);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(117, 17);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Источник энергии";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(3, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 44);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ускорение вычислений";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(187, 19);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(50, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "X100";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(137, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(44, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "X10";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(93, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(38, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "X5";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(49, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(38, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "X2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(5, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(38, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "X1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Рендер";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Пауза";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "-ЗУМ  - Скролл мыши\r\n\r\n-ПЕРЕМЕЩЕНИЕ КАМЕРЫ - ЛКМ+Перемещение";
            // 
            // zoom
            // 
            this.zoom.AutoSize = true;
            this.zoom.Location = new System.Drawing.Point(96, 38);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(48, 13);
            this.zoom.TabIndex = 11;
            this.zoom.Text = "Zoom x1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 574);
            this.Controls.Add(this.layout);
            this.Name = "Form1";
            this.Text = "Симуляция";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.layout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label zoom;
    }
}

