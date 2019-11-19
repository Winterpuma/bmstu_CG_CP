namespace CityWeather
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonRain = new System.Windows.Forms.Button();
            this.textBoxDx = new System.Windows.Forms.TextBox();
            this.textBoxDz = new System.Windows.Forms.TextBox();
            this.textBoxDy = new System.Windows.Forms.TextBox();
            this.groupBoxLight = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIntensiveness = new System.Windows.Forms.TextBox();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxSH = new System.Windows.Forms.TextBox();
            this.textBoxSDy = new System.Windows.Forms.TextBox();
            this.textBoxSDx = new System.Windows.Forms.TextBox();
            this.textBoxSZ = new System.Windows.Forms.TextBox();
            this.textBoxSY = new System.Windows.Forms.TextBox();
            this.textBoxSX = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddBuilding = new System.Windows.Forms.Button();
            this.buttonFog = new System.Windows.Forms.Button();
            this.groupBoxLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(58, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(105, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonRain
            // 
            this.buttonRain.Location = new System.Drawing.Point(58, 112);
            this.buttonRain.Name = "buttonRain";
            this.buttonRain.Size = new System.Drawing.Size(75, 23);
            this.buttonRain.TabIndex = 6;
            this.buttonRain.Text = "Начать";
            this.buttonRain.UseVisualStyleBackColor = true;
            this.buttonRain.Click += new System.EventHandler(this.buttonRain_Click);
            // 
            // textBoxDx
            // 
            this.textBoxDx.Location = new System.Drawing.Point(58, 34);
            this.textBoxDx.Name = "textBoxDx";
            this.textBoxDx.Size = new System.Drawing.Size(75, 23);
            this.textBoxDx.TabIndex = 8;
            this.textBoxDx.Text = "20";
            // 
            // textBoxDz
            // 
            this.textBoxDz.Location = new System.Drawing.Point(58, 92);
            this.textBoxDz.Name = "textBoxDz";
            this.textBoxDz.Size = new System.Drawing.Size(75, 23);
            this.textBoxDz.TabIndex = 9;
            this.textBoxDz.Text = "20";
            // 
            // textBoxDy
            // 
            this.textBoxDy.Location = new System.Drawing.Point(58, 63);
            this.textBoxDy.Name = "textBoxDy";
            this.textBoxDy.Size = new System.Drawing.Size(75, 23);
            this.textBoxDy.TabIndex = 10;
            this.textBoxDy.Text = "20";
            // 
            // groupBoxLight
            // 
            this.groupBoxLight.Controls.Add(this.pictureBox1);
            this.groupBoxLight.Controls.Add(this.button2);
            this.groupBoxLight.Controls.Add(this.button3);
            this.groupBoxLight.Controls.Add(this.button4);
            this.groupBoxLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxLight.Location = new System.Drawing.Point(1129, 183);
            this.groupBoxLight.Name = "groupBoxLight";
            this.groupBoxLight.Size = new System.Drawing.Size(163, 90);
            this.groupBoxLight.TabIndex = 11;
            this.groupBoxLight.TabStop = false;
            this.groupBoxLight.Text = "Источник света";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CityWeather.Properties.Resources.LightDir2;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(25, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 25);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxDx);
            this.groupBox1.Controls.Add(this.textBoxDy);
            this.groupBox1.Controls.Add(this.textBoxDz);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1129, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 129);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Направление ветра";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "dz:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "dx:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "dy:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDelay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxIntensiveness);
            this.groupBox2.Controls.Add(this.buttonRain);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(1129, 414);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 149);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дождь";
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(85, 83);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(48, 23);
            this.textBoxDelay.TabIndex = 10;
            this.textBoxDelay.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Задержка:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Интенсивность:";
            // 
            // textBoxIntensiveness
            // 
            this.textBoxIntensiveness.Location = new System.Drawing.Point(58, 47);
            this.textBoxIntensiveness.Name = "textBoxIntensiveness";
            this.textBoxIntensiveness.Size = new System.Drawing.Size(75, 23);
            this.textBoxIntensiveness.TabIndex = 7;
            this.textBoxIntensiveness.Text = "5";
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(33, 44);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1068, 519);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxSH);
            this.groupBox3.Controls.Add(this.textBoxSDy);
            this.groupBox3.Controls.Add(this.textBoxSDx);
            this.groupBox3.Controls.Add(this.textBoxSZ);
            this.groupBox3.Controls.Add(this.textBoxSY);
            this.groupBox3.Controls.Add(this.textBoxSX);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.buttonAddBuilding);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(1129, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(163, 133);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Сцена";
            // 
            // textBoxSH
            // 
            this.textBoxSH.Location = new System.Drawing.Point(108, 75);
            this.textBoxSH.Name = "textBoxSH";
            this.textBoxSH.Size = new System.Drawing.Size(38, 23);
            this.textBoxSH.TabIndex = 26;
            this.textBoxSH.Text = "50";
            // 
            // textBoxSDy
            // 
            this.textBoxSDy.Location = new System.Drawing.Point(108, 47);
            this.textBoxSDy.Name = "textBoxSDy";
            this.textBoxSDy.Size = new System.Drawing.Size(38, 23);
            this.textBoxSDy.TabIndex = 25;
            this.textBoxSDy.Text = "-50";
            // 
            // textBoxSDx
            // 
            this.textBoxSDx.Location = new System.Drawing.Point(108, 19);
            this.textBoxSDx.Name = "textBoxSDx";
            this.textBoxSDx.Size = new System.Drawing.Size(38, 23);
            this.textBoxSDx.TabIndex = 24;
            this.textBoxSDx.Text = "20";
            // 
            // textBoxSZ
            // 
            this.textBoxSZ.Location = new System.Drawing.Point(32, 75);
            this.textBoxSZ.Name = "textBoxSZ";
            this.textBoxSZ.Size = new System.Drawing.Size(38, 23);
            this.textBoxSZ.TabIndex = 23;
            this.textBoxSZ.Text = "100";
            // 
            // textBoxSY
            // 
            this.textBoxSY.Location = new System.Drawing.Point(32, 47);
            this.textBoxSY.Name = "textBoxSY";
            this.textBoxSY.Size = new System.Drawing.Size(38, 23);
            this.textBoxSY.TabIndex = 22;
            this.textBoxSY.Text = "300";
            // 
            // textBoxSX
            // 
            this.textBoxSX.Location = new System.Drawing.Point(32, 19);
            this.textBoxSX.Name = "textBoxSX";
            this.textBoxSX.Size = new System.Drawing.Size(38, 23);
            this.textBoxSX.TabIndex = 21;
            this.textBoxSX.Text = "30";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "z:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "h:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "dy:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "dx:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "x:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "y:";
            // 
            // buttonAddBuilding
            // 
            this.buttonAddBuilding.Location = new System.Drawing.Point(6, 104);
            this.buttonAddBuilding.Name = "buttonAddBuilding";
            this.buttonAddBuilding.Size = new System.Drawing.Size(151, 23);
            this.buttonAddBuilding.TabIndex = 0;
            this.buttonAddBuilding.Text = "Добавить здание";
            this.buttonAddBuilding.UseVisualStyleBackColor = true;
            this.buttonAddBuilding.Click += new System.EventHandler(this.buttonAddBuilding_Click);
            // 
            // buttonFog
            // 
            this.buttonFog.Location = new System.Drawing.Point(1129, 570);
            this.buttonFog.Name = "buttonFog";
            this.buttonFog.Size = new System.Drawing.Size(75, 23);
            this.buttonFog.TabIndex = 15;
            this.buttonFog.Text = "AddFog";
            this.buttonFog.UseVisualStyleBackColor = true;
            this.buttonFog.Click += new System.EventHandler(this.buttonFog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 617);
            this.Controls.Add(this.buttonFog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxLight);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Город. Погода.";
            this.groupBoxLight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonRain;
        private System.Windows.Forms.TextBox textBoxDx;
        private System.Windows.Forms.TextBox textBoxDz;
        private System.Windows.Forms.TextBox textBoxDy;
        private System.Windows.Forms.GroupBox groupBoxLight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIntensiveness;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxSH;
        private System.Windows.Forms.TextBox textBoxSDy;
        private System.Windows.Forms.TextBox textBoxSDx;
        private System.Windows.Forms.TextBox textBoxSZ;
        private System.Windows.Forms.TextBox textBoxSY;
        private System.Windows.Forms.TextBox textBoxSX;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddBuilding;
        private System.Windows.Forms.Button buttonFog;
    }
}

