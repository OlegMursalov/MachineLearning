namespace PointsDivision
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
            this.GeneratePoints = new System.Windows.Forms.Button();
            this.Classification = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lineClassificatorTxb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GeneratePoints
            // 
            this.GeneratePoints.Location = new System.Drawing.Point(11, 500);
            this.GeneratePoints.Name = "GeneratePoints";
            this.GeneratePoints.Size = new System.Drawing.Size(155, 46);
            this.GeneratePoints.TabIndex = 0;
            this.GeneratePoints.Text = "Генерация точек";
            this.GeneratePoints.UseVisualStyleBackColor = true;
            this.GeneratePoints.Click += new System.EventHandler(this.GeneratePoints_Click);
            // 
            // Classification
            // 
            this.Classification.Location = new System.Drawing.Point(172, 500);
            this.Classification.Name = "Classification";
            this.Classification.Size = new System.Drawing.Size(155, 46);
            this.Classification.TabIndex = 1;
            this.Classification.Text = "Классифицировать";
            this.Classification.UseVisualStyleBackColor = true;
            this.Classification.Click += new System.EventHandler(this.Classification_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(940, 482);
            this.mainPictureBox.TabIndex = 2;
            this.mainPictureBox.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // lineClassificatorTxb
            // 
            this.lineClassificatorTxb.Location = new System.Drawing.Point(333, 512);
            this.lineClassificatorTxb.Name = "lineClassificatorTxb";
            this.lineClassificatorTxb.Size = new System.Drawing.Size(194, 22);
            this.lineClassificatorTxb.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 617);
            this.Controls.Add(this.lineClassificatorTxb);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.Classification);
            this.Controls.Add(this.GeneratePoints);
            this.Name = "Form1";
            this.Text = "Главное окно";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GeneratePoints;
        private System.Windows.Forms.Button Classification;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox lineClassificatorTxb;
    }
}

